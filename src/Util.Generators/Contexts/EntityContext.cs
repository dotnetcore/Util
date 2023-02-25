using System;
using System.Collections.Generic;
using System.Linq;
using Humanizer;
using Util.Generators.Properties;

namespace Util.Generators.Contexts {
    /// <summary>
    /// 实体上下文
    /// </summary>
    public class EntityContext {
        /// <summary>
        /// 初始化实体上下文
        /// </summary>
        /// <param name="projectContext">项目上下文</param>
        /// <param name="name">实体名称</param>
        public EntityContext( ProjectContext projectContext, string name ) {
            ProjectContext = projectContext ?? throw new ArgumentNullException( nameof( projectContext ) );
            Name = name;
            Id = Util.Helpers.Id.Create();
            Output = new Output {
                RootPath = System.IO.Path.Combine( projectContext.GeneratorContext.OutputRootPath, projectContext.Name ),
                FileNameNoExtension = name
            };
            Properties = new List<Property>();
        }

        /// <summary>
        /// 实体标识
        /// </summary>
        public string Id { get; private init; }
        /// <summary>
        /// 项目上下文
        /// </summary>
        public ProjectContext ProjectContext { get; }
        /// <summary>
        /// 输出
        /// </summary>
        public Output Output { get; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 架构名
        /// </summary>
        public string Schema { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 属性列表
        /// </summary>
        public List<Property> Properties { get; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName => ProjectContext.Name;
        /// <summary>
        /// 项目复数名称
        /// </summary>
        public string PluralName => Name.Pluralize().Pascalize();
        /// <summary>
        /// 项目Pascal名称
        /// </summary>
        public string PascalName => Name.Pascalize();
        /// <summary>
        /// 项目驼峰名称
        /// </summary>
        public string CamelName => Name.Camelize();

        /// <summary>
        /// 标识属性
        /// </summary>
        public Property Key {
            get {
                var result = Properties.FirstOrDefault( t => t.IsKey );
                if( result == null ) {
                    var message = string.Format( GeneratorResource.NotSetPrimaryKey, GetNameWithSchema() );
                    throw new InvalidOperationException( message );
                }
                return result;
            }
        }
        /// <summary>
        /// 版本属性
        /// </summary>
        public Property Version {
            get {
                return Properties.FirstOrDefault( t => t.IsVersion );
            }
        }

        /// <summary>
        /// 是否包含逻辑删除
        /// </summary>
        public bool HasIsDeleted => Properties.Any( t => t.IsDeleted );

        /// <summary>
        /// 是否包含创建时间
        /// </summary>
        public bool HasCreationTime => Properties.Any( t => t.IsCreationTime );

        /// <summary>
        /// 是否包含树形属性
        /// </summary>
        public bool HasTree => Properties.Any( t => t.IsTree );

        /// <summary>
        /// 是否包含排序号
        /// </summary>
        public bool HasSortId => Properties.Any( t => t.IsSortId );

        /// <summary>
        /// 是否多对多关联表
        /// </summary>
        public bool IsRelationTable => Properties.Count == 2 && Properties.All( t => t.IsKey );

        /// <summary>
        /// 获取带架构的名称
        /// </summary>
        public string GetNameWithSchema() {
            if( Schema.IsEmpty() )
                return Name;
            return $"{Schema}.{Name}";
        }

        /// <summary>
        /// 复制
        /// </summary>
        public EntityContext Clone() {
            var generatorContext = ProjectContext.GeneratorContext.Clone();
            var projectContext = generatorContext.Projects.Find( t => t.Id == ProjectContext.Id );
            if ( projectContext == null )
                throw new InvalidOperationException();
            return projectContext.Entities.Find( t => t.Id == Id );
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="projectContext">项目上下文</param>
        public EntityContext Clone( ProjectContext projectContext ) {
            var result = new EntityContext( projectContext, Name ) {
                Id = Id,
                Schema = Schema,
                Description = Description
            };
            Output.CopyTo( result.Output );
            Properties.ForEach( property => result.Properties.Add( property.Clone( result ) ) );
            return result;
        }
    }
}
