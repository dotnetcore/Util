using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using CodeSmith.Engine;
using SchemaExplorer;

namespace SchemaMapper
{
    public enum TableNaming
    {
        Mixed = 0,
        Plural = 1,
        Singular = 2
    }

    public enum EntityNaming
    {
        Preserve = 0,
        Plural = 1,
        Singular = 2
    }

    public enum RelationshipNaming
    {
        None = 0,
        Plural = 1,
        ListSuffix = 2
    }

    public enum ContextNaming
    {
        Preserve = 0,
        Plural = 1,
        TableSuffix = 2
    }

    public class GeneratorSettings
    {
        public GeneratorSettings()
        {
            RelationshipNaming = RelationshipNaming.ListSuffix;
            EntityNaming = EntityNaming.Singular;
            TableNaming = TableNaming.Singular;
            CleanExpressions = new List<string> { @"^\d+" };
            IgnoreExpressions = new List<string>();
        }

        public TableNaming TableNaming { get; set; }

        public EntityNaming EntityNaming { get; set; }

        public RelationshipNaming RelationshipNaming { get; set; }

        public ContextNaming ContextNaming { get; set; }

        public List<string> IgnoreExpressions { get; set; }

        public List<string> CleanExpressions { get; set; }

        public bool InclusionMode { get; set; }

        public bool IsIgnored(string name)
        {
            if (IgnoreExpressions.Count == 0)
                return false;

            bool isMatch = IgnoreExpressions.Any(regex => Regex.IsMatch(name, regex));

            return isMatch && !InclusionMode;
        }

        public string CleanName(string name)
        {
            if (CleanExpressions.Count == 0)
                return name;

            foreach (var regex in CleanExpressions.Where(r => !string.IsNullOrEmpty(r)))
                if (Regex.IsMatch(name, regex))
                    return Regex.Replace(name, regex, "");

            return name;
        }

        public string RelationshipName(string name)
        {
            if (RelationshipNaming == RelationshipNaming.None)
                return name;

            if (RelationshipNaming == RelationshipNaming.ListSuffix)
                return name + "List";

            return StringUtil.ToPlural(name);
        }

        public string ContextName(string name)
        {
            if (ContextNaming == ContextNaming.Preserve)
                return name;

            if (ContextNaming == ContextNaming.TableSuffix)
                return name + "Table";

            return StringUtil.ToPlural(name);
        }

        public string EntityName(string name)
        {
            if (TableNaming != TableNaming.Plural && EntityNaming == EntityNaming.Plural)
                name = StringUtil.ToPlural(name);
            else if (TableNaming != TableNaming.Singular && EntityNaming == EntityNaming.Singular)
                name = StringUtil.ToSingular(name);

            return name;
        }
    }

    public class SchemaItemProcessedEventArgs : EventArgs
    {
        public SchemaItemProcessedEventArgs(string name)
        {
            _name = name;
        }

        private readonly string _name;
        public string Name
        {
            get { return _name; }
        }
    }

    public class UniqueNamer
    {
        private readonly ConcurrentDictionary<string, HashSet<string>> _names;

        public UniqueNamer()
        {
            _names = new ConcurrentDictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);
            Comparer = StringComparer.CurrentCulture;

            // add existing
            UniqueContextName("ChangeTracker");
            UniqueContextName("Configuration");
            UniqueContextName("Database");
            UniqueContextName("InternalContext");
        }

        public IEqualityComparer<string> Comparer { get; set; }

        public string UniqueName(string bucketName, string name)
        {
            var hashSet = _names.GetOrAdd(bucketName, k => new HashSet<string>(Comparer));
            string result = name.MakeUnique(hashSet.Contains);
            hashSet.Add(result);

            return result;
        }

        public string UniqueClassName(string className)
        {
            const string globalClassName = "global::ClassName";
            return UniqueName(globalClassName, className);
        }

        public string UniqueContextName(string name)
        {
            const string globalContextname = "global::ContextName";
            return UniqueName(globalContextname, name);
        }

        public string UniqueRelationshipName(string name)
        {
            const string globalContextname = "global::RelationshipName";
            return UniqueName(globalContextname, name);
        }

    }

    public class Generator
    {
        private readonly UniqueNamer _namer;

        public Generator()
        {
            _settings = new GeneratorSettings();
            _namer = new UniqueNamer();
        }

        public event EventHandler<SchemaItemProcessedEventArgs> SchemaItemProcessed;
        protected void OnSchemaItemProcessed(string name)
        {
            var handler = SchemaItemProcessed;
            if (handler == null)
                return;

            handler(this, new SchemaItemProcessedEventArgs(name));
        }

        private readonly GeneratorSettings _settings;
        public GeneratorSettings Settings
        {
            get { return _settings; }
        }

        public EntityContext Generate(DatabaseSchema databaseSchema)
        {
            // only DeepLoad when in ignore mode
            databaseSchema.DeepLoad = !Settings.InclusionMode;

            var entityContext = new EntityContext();
            entityContext.DatabaseName = databaseSchema.Name;

            string dataContextName = StringUtil.ToPascalCase(databaseSchema.Name) + "Context";
            dataContextName = _namer.UniqueClassName(dataContextName);

            entityContext.ClassName = dataContextName;

            foreach (TableSchema t in databaseSchema.Tables)
            {
                if (Settings.IsIgnored(t.FullName))
                {
                    Debug.WriteLine("Skipping Table: " + t.FullName);
                }
                else if (IsManyToMany(t))
                {
                    CreateManyToMany(entityContext, t);
                }
                else
                {
                    Debug.WriteLine("Getting Table Schema: " + t.FullName);
                    GetEntity(entityContext, t);
                }

                OnSchemaItemProcessed(t.FullName);
            }

            return entityContext;
        }


        private Entity GetEntity(EntityContext entityContext, TableSchema tableSchema, bool processRelationships = true, bool processMethods = true)
        {
            string key = tableSchema.FullName;

            Entity entity = entityContext.Entities.ByTable(key)
              ?? CreateEntity(entityContext, tableSchema);

            if (!entity.Properties.IsProcessed)
                CreateProperties(entity, tableSchema);

            if (processRelationships && !entity.Relationships.IsProcessed)
                CreateRelationships(entityContext, entity, tableSchema);

            if (processMethods && !entity.Methods.IsProcessed)
                CreateMethods(entity, tableSchema);

            entity.IsProcessed = true;
            return entity;
        }

        private Entity CreateEntity(EntityContext entityContext, TableSchema tableSchema)
        {
            var entity = new Entity
            {
                FullName = tableSchema.FullName,
                TableName = tableSchema.Name,
                TableSchema = tableSchema.Owner,
                Description = tableSchema.Description,
                Context = entityContext
            };

            string className = ToClassName(tableSchema.Name);
            className = _namer.UniqueClassName(className);

            string mappingName = className + "Map";
            mappingName = _namer.UniqueClassName(mappingName);

            string contextName = Settings.ContextName(className);
            contextName = ToPropertyName(entityContext.ClassName, contextName);
            contextName = _namer.UniqueContextName(contextName);

            entity.ClassName = className;
            entity.ContextName = contextName;
            entity.MappingName = mappingName;

            entityContext.Entities.Add(entity);

            return entity;
        }


        private void CreateProperties(Entity entity, TableSchema tableSchema)
        {
            foreach (ColumnSchema columnSchema in tableSchema.Columns)
            {
                // skip unsupported type
                if (columnSchema.NativeType.Equals("hierarchyid", StringComparison.OrdinalIgnoreCase)
                  || columnSchema.NativeType.Equals("sql_variant", StringComparison.OrdinalIgnoreCase))
                {
                    Debug.WriteLine(string.Format("Skipping column '{0}' because it has an unsupported db type '{1}'.",
                                                  columnSchema.Name, columnSchema.NativeType));
                    continue;
                }

                Property property = entity.Properties.ByColumn(columnSchema.Name);

                if (property == null)
                {
                    property = new Property { ColumnName = columnSchema.Name };
                    entity.Properties.Add(property);
                }

                string propertyName = ToPropertyName(entity.ClassName, columnSchema.Name);
                propertyName = _namer.UniqueName(entity.ClassName, propertyName);

                property.PropertyName = propertyName;
                property.Description = columnSchema.Description;

                property.DataType = columnSchema.DataType;
                property.SystemType = columnSchema.SystemType;
                property.NativeType = columnSchema.NativeType;

                property.IsPrimaryKey = columnSchema.IsPrimaryKeyMember;
                property.IsForeignKey = columnSchema.IsForeignKeyMember;
                property.IsNullable = columnSchema.AllowDBNull;

                property.IsIdentity = IsIdentity(columnSchema);
                property.IsRowVersion = IsRowVersion(columnSchema);
                property.IsAutoGenerated = IsDbGenerated(columnSchema);

                if (columnSchema.IsUnique)
                    property.IsUnique = columnSchema.IsUnique;

                if (property.SystemType == typeof(string)
                  || property.SystemType == typeof(byte[]))
                {
                    property.MaxLength = columnSchema.Size;
                }

                if (property.SystemType == typeof(float)
                  || property.SystemType == typeof(double)
                  || property.SystemType == typeof(decimal))
                {
                    property.Precision = columnSchema.Precision;
                    property.Scale = columnSchema.Scale;
                }

                property.IsProcessed = true;
            }

            entity.Properties.IsProcessed = true;
        }


        private void CreateRelationships(EntityContext entityContext, Entity entity, TableSchema tableSchema)
        {
            foreach (TableKeySchema tableKey in tableSchema.ForeignKeys)
            {
                if (Settings.IsIgnored(tableKey.ForeignKeyTable.FullName)
                    || Settings.IsIgnored(tableKey.PrimaryKeyTable.FullName))
                    continue;

                CreateRelationship(entityContext, entity, tableKey);
            }

            entity.Relationships.IsProcessed = true;
        }

        private void CreateRelationship(EntityContext entityContext, Entity foreignEntity, TableKeySchema tableKeySchema)
        {
            Entity primaryEntity = GetEntity(entityContext, tableKeySchema.PrimaryKeyTable, false, false);

            string primaryName = primaryEntity.ClassName;
            string foreignName = foreignEntity.ClassName;

            string relationshipName = tableKeySchema.Name;
            relationshipName = _namer.UniqueRelationshipName(relationshipName);

            bool foreignMembersRequired;
            bool primaryMembersRequired;

            var foreignMembers = GetKeyMembers(foreignEntity, tableKeySchema.ForeignKeyMemberColumns, tableKeySchema.Name, out foreignMembersRequired);
            var primaryMembers = GetKeyMembers(primaryEntity, tableKeySchema.PrimaryKeyMemberColumns, tableKeySchema.Name, out primaryMembersRequired);

            Relationship foreignRelationship = foreignEntity.Relationships
              .FirstOrDefault(r => r.RelationshipName == relationshipName && r.IsForeignKey);

            if (foreignRelationship == null)
            {
                foreignRelationship = new Relationship { RelationshipName = relationshipName };
                foreignEntity.Relationships.Add(foreignRelationship);
            }
            foreignRelationship.IsMapped = true;
            foreignRelationship.IsForeignKey = true;
            foreignRelationship.ThisCardinality = foreignMembersRequired ? Cardinality.One : Cardinality.ZeroOrOne;
            foreignRelationship.ThisEntity = foreignName;
            foreignRelationship.ThisProperties = new List<string>(foreignMembers);
            foreignRelationship.OtherEntity = primaryName;
            foreignRelationship.OtherProperties = new List<string>(primaryMembers);

            string prefix = GetMemberPrefix(foreignRelationship, primaryName, foreignName);

            string foreignPropertyName = ToPropertyName(foreignEntity.ClassName, prefix + primaryName);
            foreignPropertyName = _namer.UniqueName(foreignEntity.ClassName, foreignPropertyName);
            foreignRelationship.ThisPropertyName = foreignPropertyName;

            // add reverse
            Relationship primaryRelationship = primaryEntity.Relationships
              .FirstOrDefault(r => r.RelationshipName == relationshipName && r.IsForeignKey == false);

            if (primaryRelationship == null)
            {
                primaryRelationship = new Relationship { RelationshipName = relationshipName };
                primaryEntity.Relationships.Add(primaryRelationship);
            }

            primaryRelationship.IsMapped = false;
            primaryRelationship.IsForeignKey = false;
            primaryRelationship.ThisEntity = primaryName;
            primaryRelationship.ThisProperties = new List<string>(primaryMembers);
            primaryRelationship.OtherEntity = foreignName;
            primaryRelationship.OtherProperties = new List<string>(foreignMembers);

            bool isOneToOne = IsOneToOne(tableKeySchema, foreignRelationship);

            if (isOneToOne)
                primaryRelationship.ThisCardinality = primaryMembersRequired ? Cardinality.One : Cardinality.ZeroOrOne;
            else
                primaryRelationship.ThisCardinality = Cardinality.Many;

            string primaryPropertyName = prefix + foreignName;
            if (!isOneToOne)
                primaryPropertyName = Settings.RelationshipName(primaryPropertyName);

            primaryPropertyName = ToPropertyName(primaryEntity.ClassName, primaryPropertyName);
            primaryPropertyName = _namer.UniqueName(primaryEntity.ClassName, primaryPropertyName);

            primaryRelationship.ThisPropertyName = primaryPropertyName;

            foreignRelationship.OtherPropertyName = primaryRelationship.ThisPropertyName;
            foreignRelationship.OtherCardinality = primaryRelationship.ThisCardinality;

            primaryRelationship.OtherPropertyName = foreignRelationship.ThisPropertyName;
            primaryRelationship.OtherCardinality = foreignRelationship.ThisCardinality;

            foreignRelationship.IsProcessed = true;
            primaryRelationship.IsProcessed = true;
        }

        private void CreateManyToMany(EntityContext entityContext, TableSchema joinTable)
        {
            if (joinTable.ForeignKeys.Count != 2)
                return;

            var joinTableName = joinTable.Name;
            var joinSchemaName = joinTable.Owner;

            // first fkey is always left, second fkey is right
            var leftForeignKey = joinTable.ForeignKeys[0];
            var leftTable = leftForeignKey.PrimaryKeyTable;
            var joinLeftColumn = leftForeignKey.ForeignKeyMemberColumns.Select(c => c.Name).ToList();
            var leftEntity = GetEntity(entityContext, leftTable, false, false);

            var rightForeignKey = joinTable.ForeignKeys[1];
            var rightTable = rightForeignKey.PrimaryKeyTable;
            var joinRightColumn = rightForeignKey.ForeignKeyMemberColumns.Select(c => c.Name).ToList();
            var rightEntity = GetEntity(entityContext, rightTable, false, false);

            string leftPropertyName = Settings.RelationshipName(rightEntity.ClassName);
            leftPropertyName = _namer.UniqueName(leftEntity.ClassName, leftPropertyName);

            string rightPropertyName = Settings.RelationshipName(leftEntity.ClassName);
            rightPropertyName = _namer.UniqueName(rightEntity.ClassName, rightPropertyName);

            string relationshipName = string.Format("{0}|{1}",
              leftForeignKey.Name,
              rightForeignKey.Name);

            relationshipName = _namer.UniqueRelationshipName(relationshipName);

            var left = new Relationship { RelationshipName = relationshipName };
            left.IsForeignKey = false;
            left.IsMapped = true;

            left.ThisCardinality = Cardinality.Many;
            left.ThisEntity = leftEntity.ClassName;
            left.ThisPropertyName = leftPropertyName;

            left.OtherCardinality = Cardinality.Many;
            left.OtherEntity = rightEntity.ClassName;
            left.OtherPropertyName = rightPropertyName;

            left.JoinTable = joinTableName;
            left.JoinSchema = joinSchemaName;
            left.JoinThisColumn = new List<string>(joinLeftColumn);
            left.JoinOtherColumn = new List<string>(joinRightColumn);

            leftEntity.Relationships.Add(left);

            var right = new Relationship { RelationshipName = relationshipName };
            right.IsForeignKey = false;
            right.IsMapped = false;

            right.ThisCardinality = Cardinality.Many;
            right.ThisEntity = rightEntity.ClassName;
            right.ThisPropertyName = rightPropertyName;

            right.OtherCardinality = Cardinality.Many;
            right.OtherEntity = leftEntity.ClassName;
            right.OtherPropertyName = leftPropertyName;

            right.JoinTable = joinTableName;
            right.JoinSchema = joinSchemaName;
            right.JoinThisColumn = new List<string>(joinRightColumn);
            right.JoinOtherColumn = new List<string>(joinLeftColumn);

            rightEntity.Relationships.Add(right);
        }


        private void CreateMethods(Entity entity, TableSchema tableSchema)
        {
            if (tableSchema.HasPrimaryKey)
            {
                var method = GetMethodFromColumns(entity, tableSchema.PrimaryKey.MemberColumns);
                if (method != null)
                {
                    method.IsKey = true;
                    method.SourceName = tableSchema.PrimaryKey.FullName;

                    if (!entity.Methods.Any(m=> m.NameSuffix == method.NameSuffix))
                        entity.Methods.Add(method);
                }
            }

            GetIndexMethods(entity, tableSchema);
            GetForeignKeyMethods(entity, tableSchema);

            entity.Methods.IsProcessed = true;
        }

        private static void GetForeignKeyMethods(Entity entity, TableSchema table)
        {
            var columns = new List<ColumnSchema>();

            foreach (ColumnSchema column in table.ForeignKeyColumns)
            {
                columns.Add(column);

                Method method = GetMethodFromColumns(entity, columns);                
                if (method != null && !entity.Methods.Any(m => m.NameSuffix == method.NameSuffix))
                    entity.Methods.Add(method);

                columns.Clear();
            }
        }

        private static void GetIndexMethods(Entity entity, TableSchema table)
        {
            foreach (IndexSchema index in table.Indexes)
            {
                Method method = GetMethodFromColumns(entity, index.MemberColumns);
                if (method == null)
                    continue;

                method.SourceName = index.FullName;
                method.IsUnique = index.IsUnique;
                method.IsIndex = true;

                if (!entity.Methods.Any(m => m.NameSuffix == method.NameSuffix))
                    entity.Methods.Add(method);
            }
        }

        private static Method GetMethodFromColumns(Entity entity, IEnumerable<ColumnSchema> columns)
        {
            var method = new Method();
            string methodName = string.Empty;

            foreach (var column in columns)
            {
                var property = entity.Properties.ByColumn(column.Name);
                if (property == null)
                    continue;

                method.Properties.Add(property);
                methodName += property.PropertyName;
            }

            if (method.Properties.Count == 0)
                return null;

            method.NameSuffix = methodName;
            return method;
        }


        private static List<string> GetKeyMembers(Entity entity, IEnumerable<MemberColumnSchema> members, string name, out bool isRequired)
        {
            var keyMembers = new List<string>();
            isRequired = false;

            foreach (var member in members)
            {
                var property = entity.Properties.ByColumn(member.Name);

                if (property == null)
                    throw new InvalidOperationException(string.Format(
                        "Could not find column {0} for relationship {1}.",
                        member.Name,
                        name));

                if (!isRequired)
                    isRequired = property.IsRequired;

                keyMembers.Add(property.PropertyName);
            }

            return keyMembers;
        }

        private static string GetMemberPrefix(Relationship relationship, string primaryClass, string foreignClass)
        {
            string thisKey = relationship.ThisProperties.FirstOrDefault() ?? string.Empty;
            string otherKey = relationship.OtherProperties.FirstOrDefault() ?? string.Empty;

            bool isSameName = thisKey.Equals(otherKey, StringComparison.OrdinalIgnoreCase);
            isSameName = (isSameName || thisKey.Equals(primaryClass + otherKey, StringComparison.OrdinalIgnoreCase));

            string prefix = string.Empty;
            if (isSameName)
                return prefix;

            prefix = thisKey.Replace(otherKey, "");
            prefix = prefix.Replace(primaryClass, "");
            prefix = prefix.Replace(foreignClass, "");
            prefix = Regex.Replace(prefix, @"(_ID|_id|_Id|\.ID|\.id|\.Id|ID|Id)$", "");
            prefix = Regex.Replace(prefix, @"^\d", "");

            return prefix;
        }

        private static bool IsOneToOne(TableKeySchema tableKeySchema, Relationship foreignRelationship)
        {
            bool isFkeyPkey = tableKeySchema.ForeignKeyTable.HasPrimaryKey
                              && tableKeySchema.ForeignKeyTable.PrimaryKey != null
                              && tableKeySchema.ForeignKeyTable.PrimaryKey.MemberColumns.Count == 1
                              && tableKeySchema.ForeignKeyTable.PrimaryKey.MemberColumns.Contains(
                                foreignRelationship.ThisProperties.FirstOrDefault());

            if (isFkeyPkey)
                return true;

            // if f.key is unique
            return tableKeySchema.ForeignKeyMemberColumns.All(column => column.IsUnique);
        }

        private static bool IsManyToMany(TableSchema tableSchema)
        {
            // 1) Table must have Two ForeignKeys.
            // 2) All columns must be either...
            //    a) Member of a Foreign Key.
            //    b) DbGenerated

            if (tableSchema.Columns.Count < 2)
                return false;

            if (tableSchema.ForeignKeyColumns.Count != 2)
                return false;

            // all columns are fkeys
            if (tableSchema.Columns.Count == 2 &&
              tableSchema.ForeignKeyColumns.Count == 2)
                return true;

            // check all non fkey columns to make sure db gen'd
            return tableSchema.NonForeignKeyColumns.All(c => 
                IsDbGenerated(c) || HasDefaultValue(c));
        }

        #region Name Helpers
        private string ToClassName(string name)
        {
            name = Settings.EntityName(name);
            string legalName = ToLegalName(name);

            return legalName;
        }

        private string ToPropertyName(string className, string name)
        {
            string propertyName = ToLegalName(name);
            if (className.Equals(propertyName, StringComparison.OrdinalIgnoreCase))
                propertyName += "Member";

            return propertyName;
        }

        private string ToLegalName(string name)
        {
            string legalName = Settings.CleanName(name);
            legalName = StringUtil.ToPascalCase(legalName);

            return legalName;
        }
        #endregion

        #region Column Flag Helpers
        private static bool IsRowVersion(DataObjectBase column)
        {
            bool isTimeStamp = column.NativeType.Equals(
                "timestamp", StringComparison.OrdinalIgnoreCase);
            bool isRowVersion = column.NativeType.Equals(
                "rowversion", StringComparison.OrdinalIgnoreCase);

            return (isTimeStamp || isRowVersion);
        }

        private static bool IsDbGenerated(DataObjectBase column)
        {
            if (IsRowVersion(column))
                return true;

            if (IsIdentity(column))
                return true;

            bool isComputed = false;
            string value;
            try
            {
                if (column.ExtendedProperties.Contains(ExtendedPropertyNames.IsComputed))
                {
                    value = column.ExtendedProperties[ExtendedPropertyNames.IsComputed].Value.ToString();
                    bool.TryParse(value, out isComputed);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }

            return isComputed;
        }

        private static bool IsIdentity(DataObjectBase column)
        {
            string temp;
            bool isIdentity = false;
            try
            {
                if (column.ExtendedProperties.Contains(ExtendedPropertyNames.IsIdentity))
                {
                    temp = column.ExtendedProperties[ExtendedPropertyNames.IsIdentity].Value.ToString();
                    bool.TryParse(temp, out isIdentity);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }

            return isIdentity;
        }

        private static bool HasDefaultValue(DataObjectBase column)
        {
            try
            {
                if (!column.ExtendedProperties.Contains(ExtendedPropertyNames.DefaultValue))
                    return false;
                
                string value = column.ExtendedProperties[ExtendedPropertyNames.DefaultValue].Value.ToString();
                return !string.IsNullOrEmpty(value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }

            return false;
        }
        #endregion
    }
}
