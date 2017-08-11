using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;

namespace SchemaMapper
{
    #region Mapping Parser
    [DebuggerDisplay("Table: {TableName}, Entity: {EntityClass}, Mapping: {MappingClass}")]
    public class ParsedEntity
    {
        public ParsedEntity()
        {
            Properties = new List<ParsedProperty>();
            Relationships = new List<ParsedRelationship>();
        }

        public string EntityClass { get; set; }
        public string MappingClass { get; set; }

        public string TableName { get; set; }
        public string TableSchema { get; set; }

        public List<ParsedProperty> Properties { get; private set; }
        public List<ParsedRelationship> Relationships { get; private set; }
    }

    [DebuggerDisplay("Column: {ColumnName}, Property: {PropertyName}")]
    public class ParsedProperty
    {
        public string ColumnName { get; set; }
        public string PropertyName { get; set; }
    }

    [DebuggerDisplay("This: {ThisPropertyName}, Other: {OtherPropertyName}")]
    public class ParsedRelationship
    {
        public ParsedRelationship()
        {
            ThisProperties = new List<string>();
            JoinThisColumn = new List<string>();
            JoinOtherColumn = new List<string>();
        }

        public string ThisPropertyName { get; set; }
        public List<string> ThisProperties { get; private set; }

        public string OtherPropertyName { get; set; }

        public string JoinTable { get; set; }
        public string JoinSchema { get; set; }
        public List<string> JoinThisColumn { get; private set; }
        public List<string> JoinOtherColumn { get; private set; }
    }

    public class MappingVisitor : DepthFirstAstVisitor<object, object>
    {
        public MappingVisitor()
        {
            MappingBaseType = "EntityTypeConfiguration";
        }

        public string MappingBaseType { get; set; }
        public ParsedEntity ParsedEntity { get; set; }

        public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
        {
            var baseType = typeDeclaration.BaseTypes.OfType<MemberType>().FirstOrDefault();
            if (baseType == null || baseType.MemberName != MappingBaseType)
                return base.VisitTypeDeclaration(typeDeclaration, data);

            var entity = baseType.TypeArguments.OfType<MemberType>().FirstOrDefault();
            if (entity == null)
                return base.VisitTypeDeclaration(typeDeclaration, data);

            if (ParsedEntity == null)
                ParsedEntity = new ParsedEntity();

            ParsedEntity.EntityClass = entity.MemberName;
            ParsedEntity.MappingClass = typeDeclaration.Name;

            return base.VisitTypeDeclaration(typeDeclaration, ParsedEntity);
        }

        public override object VisitInvocationExpression(InvocationExpression invocationExpression, object data)
        {
            if (data == null)
                return base.VisitInvocationExpression(invocationExpression, null);

            // visit all the methods
            var identifier = invocationExpression.Target.Children.OfType<Identifier>().FirstOrDefault();
            string methodName = identifier == null ? string.Empty : identifier.Name;

            // the different types of incoming data, helps us know what we're parsing
            var parsedEntity = data as ParsedEntity;
            var parsedProperty = data as ParsedProperty;
            var parsedRelationship = data as ParsedRelationship;

            switch (methodName)
            {
                case "ToTable":
                    var tableNameExpression = invocationExpression.Arguments
                      .OfType<PrimitiveExpression>()
                      .ToArray();

                    string tableName = null;
                    string tableSchema = null;

                    if (tableNameExpression.Length >= 1)
                        tableName = tableNameExpression[0].Value.ToString();
                    if (tableNameExpression.Length >= 2)
                        tableSchema = tableNameExpression[1].Value.ToString();

                    // ToTable is either Entity -> Table map or Many to Many map
                    if (parsedEntity != null)
                    {
                        // when data is ParsedEntity, entity map
                        parsedEntity.TableName = tableName;
                        parsedEntity.TableSchema = tableSchema;
                    }
                    else if (parsedRelationship != null)
                    {
                        // when data is ParsedRelationship, many to many map
                        parsedRelationship.JoinTable = tableName;
                        parsedRelationship.JoinSchema = tableSchema;
                    }
                    break;
                case "HasColumnName":
                    var columnNameExpression = invocationExpression.Arguments
                      .OfType<PrimitiveExpression>()
                      .FirstOrDefault();

                    if (columnNameExpression == null)
                        break;

                    // property to column map start.
                    string columnName = columnNameExpression.Value.ToString();
                    var property = new ParsedProperty { ColumnName = columnName };
                    ParsedEntity.Properties.Add(property);

                    //only have column info at this point. pass data to get property name.
                    return base.VisitInvocationExpression(invocationExpression, property);
                case "Property":
                    var propertyExpression = invocationExpression.Arguments
                      .OfType<LambdaExpression>()
                      .FirstOrDefault();

                    if (parsedProperty == null || propertyExpression == null)
                        break;

                    // ParsedProperty is passed in as data from HasColumnName, add property name
                    var propertyBodyExpression = propertyExpression.Body as MemberReferenceExpression;
                    if (propertyBodyExpression != null)
                        parsedProperty.PropertyName = propertyBodyExpression.MemberName;

                    break;
                case "Map":
                    // start a new Many to Many relationship
                    var mapRelation = new ParsedRelationship();
                    ParsedEntity.Relationships.Add(mapRelation);
                    // pass to child nodes to fill in data
                    return base.VisitInvocationExpression(invocationExpression, mapRelation);
                case "HasForeignKey":
                    var foreignExpression = invocationExpression.Arguments
                      .OfType<LambdaExpression>()
                      .FirstOrDefault();

                    if (foreignExpression == null)
                        break;

                    // when only 1 fkey, body will be member ref
                    if (foreignExpression.Body is MemberReferenceExpression)
                    {
                        var foreignBodyExpression = foreignExpression.Body as MemberReferenceExpression;
                        // start a new relationship
                        var foreignRelation = new ParsedRelationship();
                        ParsedEntity.Relationships.Add(foreignRelation);

                        foreignRelation.ThisProperties.Add(foreignBodyExpression.MemberName);
                        // pass as data for child nodes to fill in data
                        return base.VisitInvocationExpression(invocationExpression, foreignRelation);
                    }
                    // when more then 1 fkey, body will be an anonymous type
                    if (foreignExpression.Body is AnonymousTypeCreateExpression)
                    {
                        var foreignBodyExpression = foreignExpression.Body as AnonymousTypeCreateExpression;
                        var foreignRelation = new ParsedRelationship();
                        ParsedEntity.Relationships.Add(foreignRelation);

                        var properties = foreignBodyExpression.Children
                          .OfType<MemberReferenceExpression>()
                          .Select(m => m.MemberName);

                        foreignRelation.ThisProperties.AddRange(properties);

                        return base.VisitInvocationExpression(invocationExpression, foreignRelation);
                    }
                    break;
                case "HasMany":
                    var hasManyExpression = invocationExpression.Arguments
                      .OfType<LambdaExpression>()
                      .FirstOrDefault();

                    if (parsedRelationship == null || hasManyExpression == null)
                        break;

                    // filling existing relationship data
                    var hasManyBodyExpression = hasManyExpression.Body as MemberReferenceExpression;
                    if (hasManyBodyExpression != null)
                        parsedRelationship.ThisPropertyName = hasManyBodyExpression.MemberName;

                    break;
                case "WithMany":
                    var withManyExpression = invocationExpression.Arguments
                      .OfType<LambdaExpression>()
                      .FirstOrDefault();

                    if (parsedRelationship == null || withManyExpression == null)
                        break;

                    // filling existing relationship data
                    var withManyBodyExpression = withManyExpression.Body as MemberReferenceExpression;
                    if (withManyBodyExpression != null)
                        parsedRelationship.OtherPropertyName = withManyBodyExpression.MemberName;

                    break;
                case "HasRequired":
                case "HasOptional":
                    var hasExpression = invocationExpression.Arguments
                      .OfType<LambdaExpression>()
                      .FirstOrDefault();

                    if (parsedRelationship == null || hasExpression == null)
                        break;

                    // filling existing relationship data
                    var hasBodyExpression = hasExpression.Body as MemberReferenceExpression;
                    if (hasBodyExpression != null)
                        parsedRelationship.ThisPropertyName = hasBodyExpression.MemberName;

                    break;
                case "MapLeftKey":
                    if (parsedRelationship == null)
                        break;

                    var leftKeyExpression = invocationExpression.Arguments
                      .OfType<PrimitiveExpression>()
                      .Select(e => e.Value.ToString());

                    parsedRelationship.JoinThisColumn.AddRange(leftKeyExpression);
                    break;
                case "MapRightKey":
                    if (parsedRelationship == null)
                        break;

                    var rightKeyExpression = invocationExpression.Arguments
                      .OfType<PrimitiveExpression>()
                      .Select(e => e.Value.ToString());

                    parsedRelationship.JoinOtherColumn.AddRange(rightKeyExpression);
                    break;
            }

            return base.VisitInvocationExpression(invocationExpression, data);
        }
    }

    public static class MappingParser
    {
        public static ParsedEntity Parse(string mappingFile)
        {
            if (string.IsNullOrEmpty(mappingFile) || !File.Exists(mappingFile))
                return null;

            var parser = new CSharpParser();
            CompilationUnit compilationUnit;

            using (var stream = File.OpenText(mappingFile))
                compilationUnit = parser.Parse(stream, mappingFile);

            var visitor = new MappingVisitor();

            visitor.VisitCompilationUnit(compilationUnit, null);
            var parsedEntity = visitor.ParsedEntity;

            if (parsedEntity != null)
                Debug.WriteLine("Parsed Mapping File: '{0}'; Properties: {1}; Relationships: {2}",
                  Path.GetFileName(mappingFile),
                  parsedEntity.Properties.Count,
                  parsedEntity.Relationships.Count);

            return parsedEntity;
        }
    }
    #endregion

    #region Context Parser
    [DebuggerDisplay("Context: {ContextClass}")]
    public class ParsedContext
    {
        public ParsedContext()
        {
            Properties = new List<ParsedEntitySet>();
        }

        public string ContextClass { get; set; }

        public List<ParsedEntitySet> Properties { get; private set; }
    }

    [DebuggerDisplay("Entity: {EntityClass}, Property: {ContextProperty}")]
    public class ParsedEntitySet
    {
        public string EntityClass { get; set; }
        public string ContextProperty { get; set; }
    }

    public class ContextVisitor : DepthFirstAstVisitor<object, object>
    {
        public ContextVisitor()
        {
            ContextBaseType = "DbContext";
            DataSetType = "DbSet";
        }

        public string ContextBaseType { get; set; }
        public string DataSetType { get; set; }

        public ParsedContext ParsedContext { get; set; }

        public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
        {
            var baseType = typeDeclaration.BaseTypes
              .OfType<MemberType>()
              .FirstOrDefault();

            // warning: if inherited from custom base type, this will break
            // anyway to improve this?
            if (baseType == null || baseType.MemberName != ContextBaseType)
                return base.VisitTypeDeclaration(typeDeclaration, data);

            if (ParsedContext == null)
                ParsedContext = new ParsedContext();

            ParsedContext.ContextClass = typeDeclaration.Name;

            return base.VisitTypeDeclaration(typeDeclaration, ParsedContext);
        }

        public override object VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration, object data)
        {
            if (data == null)
                return base.VisitPropertyDeclaration(propertyDeclaration, null);

            // look for property to return generic DbSet type
            var memberType = propertyDeclaration.ReturnType as MemberType;
            if (memberType == null || memberType.MemberName != DataSetType)
                return base.VisitPropertyDeclaration(propertyDeclaration, data);

            // get the first generic type
            var entityType = memberType.TypeArguments
              .OfType<MemberType>()
              .FirstOrDefault();

            if (entityType == null)
                return base.VisitPropertyDeclaration(propertyDeclaration, data);

            var entitySet = new ParsedEntitySet
            {
                EntityClass = entityType.MemberName,
                ContextProperty = propertyDeclaration.Name
            };

            ParsedContext.Properties.Add(entitySet);

            return base.VisitPropertyDeclaration(propertyDeclaration, data);
        }
    }

    public static class ContextParser
    {
        public static ParsedContext Parse(string contextFile)
        {
            if (string.IsNullOrEmpty(contextFile) || !File.Exists(contextFile))
                return null;

            var parser = new CSharpParser();
            CompilationUnit compilationUnit;

            using (var stream = File.OpenText(contextFile))
                compilationUnit = parser.Parse(stream, contextFile);

            var visitor = new ContextVisitor();

            visitor.VisitCompilationUnit(compilationUnit, null);
            var parsedContext = visitor.ParsedContext;

            if (parsedContext != null)
                Debug.WriteLine("Parsed Context File: '{0}'; Entities: {1}",
                  Path.GetFileName(contextFile),
                  parsedContext.Properties.Count);

            return parsedContext;
        }
    }
    #endregion

    public static class Synchronizer
    {
        public static bool UpdateFromSource(EntityContext generatedContext, string contextDirectory, string mappingDirectory)
        {
            if (generatedContext == null)
                return false;

            // make sure to update the entities before the context
            UpdateFromMapping(generatedContext, mappingDirectory);
            UpdateFromContext(generatedContext, contextDirectory);
            return true;
        }

        private static void UpdateFromContext(EntityContext generatedContext, string contextDirectory)
        {
            if (generatedContext == null
              || contextDirectory == null
              || !Directory.Exists(contextDirectory))
                return;

            // parse context
            ParsedContext parsedContext = null;
            var files = Directory.EnumerateFiles(contextDirectory, "*.Generated.cs").GetEnumerator();
            while (files.MoveNext() && parsedContext == null)
                parsedContext = ContextParser.Parse(files.Current);

            if (parsedContext == null)
                return;

            if (generatedContext.ClassName != parsedContext.ContextClass)
            {
                Debug.WriteLine("Rename Context Class'{0}' to '{1}'.",
                                generatedContext.ClassName,
                                parsedContext.ContextClass);

                generatedContext.ClassName = parsedContext.ContextClass;
            }

            foreach (var parsedProperty in parsedContext.Properties)
            {
                var entity = generatedContext.Entities.ByClass(parsedProperty.EntityClass);
                if (entity == null)
                    continue;


                if (entity.ContextName == parsedProperty.ContextProperty)
                    continue;

                Debug.WriteLine("Rename Context Property'{0}' to '{1}'.",
                                entity.ContextName,
                                parsedProperty.ContextProperty);

                entity.ContextName = parsedProperty.ContextProperty;
            }
        }

        private static void UpdateFromMapping(EntityContext generatedContext, string mappingDirectory)
        {
            if (generatedContext == null
              || mappingDirectory == null
              || !Directory.Exists(mappingDirectory))
                return;

            // parse all mapping files
            var mappingFiles = Directory.EnumerateFiles(mappingDirectory, "*.Generated.cs");
            var parsedEntities = mappingFiles
              .Select(MappingParser.Parse)
              .Where(parsedEntity => parsedEntity != null)
              .ToList();

            var relationshipQueue = new List<Tuple<Entity, ParsedEntity>>();

            // update all entity and property names first because relationships are linked by property names
            foreach (var parsedEntity in parsedEntities)
            {
                // find entity by table name to support renaming entity
                var entity = generatedContext.Entities
                  .ByTable(parsedEntity.TableName, parsedEntity.TableSchema);

                if (entity == null)
                    continue;

                // sync names
                if (entity.MappingName != parsedEntity.MappingClass)
                {
                    Debug.WriteLine("Rename Mapping Class'{0}' to '{1}'.",
                          entity.MappingName,
                          parsedEntity.MappingClass);

                    entity.MappingName = parsedEntity.MappingClass;
                }

                // use rename api to make sure all instances are renamed
                generatedContext.RenameEntity(entity.ClassName, parsedEntity.EntityClass);

                // sync properties
                foreach (var parsedProperty in parsedEntity.Properties)
                {
                    // find property by column name to support property name rename
                    var property = entity.Properties.ByColumn(parsedProperty.ColumnName);
                    if (property == null)
                        continue;

                    // use rename api to make sure all instances are renamed
                    generatedContext.RenameProperty(
                      entity.ClassName,
                      property.PropertyName,
                      parsedProperty.PropertyName);
                }

                // save relationship for later processing
                var item = new Tuple<Entity, ParsedEntity>(entity, parsedEntity);
                relationshipQueue.Add(item);
            }

            // update relationships last
            foreach (var tuple in relationshipQueue)
                UpdateRelationships(generatedContext, tuple.Item1, tuple.Item2);
        }

        private static void UpdateRelationships(EntityContext generatedContext, Entity entity, ParsedEntity parsedEntity)
        {
            // sync relationships
            foreach (var parsedRelationship in parsedEntity.Relationships.Where(r => r.JoinTable == null))
            {
                var parsedProperties = parsedRelationship.ThisProperties;
                var relationship = entity.Relationships
                    .Where(r => !r.IsManyToMany)
                    .FirstOrDefault(r => r.ThisProperties.Except(parsedProperties).Count() == 0);

                if (relationship == null)
                    continue;

                bool isThisSame = relationship.ThisPropertyName == parsedRelationship.ThisPropertyName;
                bool isOtherSame = relationship.OtherPropertyName == parsedRelationship.OtherPropertyName;

                if (isThisSame && isOtherSame)
                    continue;

                if (!isThisSame)
                {
                    Debug.WriteLine("Rename Relationship Property '{0}.{1}' to '{0}.{2}'.",
                          relationship.ThisEntity,
                          relationship.ThisPropertyName,
                          parsedRelationship.ThisPropertyName);

                    relationship.ThisPropertyName = parsedRelationship.ThisPropertyName;
                }
                if (!isOtherSame)
                {
                    Debug.WriteLine("Rename Relationship Property '{0}.{1}' to '{0}.{2}'.",
                          relationship.OtherEntity,
                          relationship.OtherPropertyName,
                          parsedRelationship.OtherPropertyName);

                    relationship.OtherPropertyName = parsedRelationship.OtherPropertyName;
                }

                // sync other relationship
                var otherEntity = generatedContext.Entities.ByClass(relationship.OtherEntity);
                if (otherEntity == null)
                    continue;

                var otherRelationship = otherEntity.Relationships.ByName(relationship.RelationshipName);
                if (otherRelationship == null)
                    continue;

                otherRelationship.ThisPropertyName = relationship.OtherPropertyName;
                otherRelationship.OtherPropertyName = relationship.ThisPropertyName;
            }

            // sync many to many
            foreach (var parsedRelationship in parsedEntity.Relationships.Where(r => r.JoinTable != null))
            {
                var joinThisColumn = parsedRelationship.JoinThisColumn;
                var joinOtherColumn = parsedRelationship.JoinOtherColumn;

                var relationship = entity.Relationships
                  .Where(r => r.IsManyToMany)
                  .FirstOrDefault(r =>
                                  r.JoinThisColumn.Except(joinThisColumn).Count() == 0 &&
                                  r.JoinOtherColumn.Except(joinOtherColumn).Count() == 0 &&
                                  r.JoinTable == parsedRelationship.JoinTable &&
                                  r.JoinSchema == parsedRelationship.JoinSchema);

                if (relationship == null)
                    continue;


                bool isThisSame = relationship.ThisPropertyName == parsedRelationship.ThisPropertyName;
                bool isOtherSame = relationship.OtherPropertyName == parsedRelationship.OtherPropertyName;

                if (isThisSame && isOtherSame)
                    continue;

                if (!isThisSame)
                {
                    Debug.WriteLine("Rename Relationship Property '{0}.{1}' to '{0}.{2}'.",
                          relationship.ThisEntity,
                          relationship.ThisPropertyName,
                          parsedRelationship.ThisPropertyName);

                    relationship.ThisPropertyName = parsedRelationship.ThisPropertyName;
                }
                if (!isOtherSame)
                {
                    Debug.WriteLine("Rename Relationship Property '{0}.{1}' to '{0}.{2}'.",
                          relationship.OtherEntity,
                          relationship.OtherPropertyName,
                          parsedRelationship.OtherPropertyName);

                    relationship.OtherPropertyName = parsedRelationship.OtherPropertyName;
                }

                // sync other relationship
                var otherEntity = generatedContext.Entities.ByClass(relationship.OtherEntity);
                if (otherEntity == null)
                    continue;

                var otherRelationship = otherEntity.Relationships.ByName(relationship.RelationshipName);
                if (otherRelationship == null)
                    continue;

                otherRelationship.ThisPropertyName = relationship.OtherPropertyName;
                otherRelationship.OtherPropertyName = relationship.ThisPropertyName;
            }
        }
    }
}
