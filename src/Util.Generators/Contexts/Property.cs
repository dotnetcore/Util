using System;
using System.Data;
using Humanizer;

namespace Util.Generators.Contexts {
    /// <summary>
    /// 属性
    /// </summary>
    public class Property {
        /// <summary>
        /// 初始化属性
        /// </summary>
        /// <param name="entity">实体上下文</param>
        public Property( EntityContext entity ) {
            Entity = entity ?? throw new ArgumentNullException( nameof( entity ) );
        }

        /// <summary>
        /// 实体上下文
        /// </summary>
        public EntityContext Entity { get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否标识
        /// </summary>
        public bool IsKey { get; set; }
        /// <summary>
        /// 是否必填项
        /// </summary>
        public bool IsRequired { get; set; }
        /// <summary>
        /// 是否自增
        /// </summary>
        public bool IsAutoIncrement { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public DbType? Type { get; set; }
        /// <summary>
        /// 系统类型
        /// </summary>
        public SystemType? SystemType { get; set; }
        /// <summary>
        /// 原生类型
        /// </summary>
        public string NativeType { get; set; }
        /// <summary>
        /// 最大长度
        /// </summary>
        public int? MaxLength { get; set; }
        /// <summary>
        /// 精度,即数值位数
        /// </summary>
        public int? Precision { get; set; }
        /// <summary>
        /// 小数位数
        /// </summary>
        public int? Scale { get; set; }
        /// <summary>
        /// 获取字段名称
        /// </summary>
        public string FieldName => $"_{Name.Camelize()}";
        /// <summary>
        /// 获取类型名称
        /// </summary>
        public string TypeName => SystemType.ToTypeString( !IsRequired );
        /// <summary>
        /// 获取可空类型名称
        /// </summary>
        public string NullableTypeName => SystemType.ToTypeString( true );
        /// <summary>
        /// 是否行版本
        /// </summary>
        public bool IsVersion => Name.ToUpperInvariant() == "Version".ToUpperInvariant() && SystemType == Generators.SystemType.Binary;
        /// <summary>
        /// 是否逻辑删除
        /// </summary>
        public bool IsDeleted => Name.ToUpperInvariant() == "IsDeleted".ToUpperInvariant() && SystemType == Generators.SystemType.Bool;
        /// <summary>
        /// 是否创建时间
        /// </summary>
        public bool IsCreationTime => Name.ToUpperInvariant() == "CreationTime".ToUpperInvariant() && SystemType == Generators.SystemType.DateTime;
        /// <summary>
        /// 是否创建人标识
        /// </summary>
        public bool IsCreatorId => Name.ToUpperInvariant() == "CreatorId".ToUpperInvariant();
        /// <summary>
        /// 是否修改人标识
        /// </summary>
        public bool IsLastModifierId => Name.ToUpperInvariant() == "LastModifierId".ToUpperInvariant();
        /// <summary>
        /// 是否拼音简码
        /// </summary>
        public bool IsPinYin => Name.ToUpperInvariant() == "PinYin".ToUpperInvariant();
        /// <summary>
        /// 是否排序号
        /// </summary>
        public bool IsSortId => Name.ToUpperInvariant() == "SortId".ToUpperInvariant();
        /// <summary>
        /// 是否父标识
        /// </summary>
        public bool IsParentId => Name.ToUpperInvariant() == "ParentId".ToUpperInvariant();
        /// <summary>
        /// 是否扩展属性
        /// </summary>
        public bool IsExtraProperties => Name.ToUpperInvariant() == "ExtraProperties".ToUpperInvariant();
        /// <summary>
        /// 是否审计属性
        /// </summary>
        public bool IsAudited => Name.ToUpperInvariant() == "CreatorId".ToUpperInvariant() || 
                                 Name.ToUpperInvariant() == "CreationTime".ToUpperInvariant() || 
                                 Name.ToUpperInvariant() == "LastModifierId".ToUpperInvariant() || 
                                 Name.ToUpperInvariant() == "LastModificationTime".ToUpperInvariant();
        /// <summary>
        /// 是否字符串
        /// </summary>
        public bool IsString => SystemType == Generators.SystemType.String;
        /// <summary>
        /// 是否布尔值
        /// </summary>
        public bool IsBool => SystemType == Generators.SystemType.Bool;
        /// <summary>
        /// 是否日期
        /// </summary>
        public bool IsDateTime => SystemType == Generators.SystemType.DateTime;
        /// <summary>
        /// 是否整数
        /// </summary>
        public bool IsInteger => SystemType == Generators.SystemType.Short ||
                                 SystemType == Generators.SystemType.Int ||
                                 SystemType == Generators.SystemType.Long;
        /// <summary>
        /// 是否浮点数
        /// </summary>
        public bool IsFloat => SystemType == Generators.SystemType.Single ||
                               SystemType == Generators.SystemType.Double ||
                               SystemType == Generators.SystemType.Decimal;
        /// <summary>
        /// 是否数值类型,包含整数和浮点数
        /// </summary>
        public bool IsNumber => IsInteger || IsFloat;

        /// <summary>
        /// 是否树形属性
        /// </summary>
        public bool IsTree => Entity.Properties.Exists( t => t.Name.ToUpperInvariant() == "ParentId".ToUpperInvariant() ) && 
                              Entity.Properties.Exists( t => t.Name.ToUpperInvariant() == "Path".ToUpperInvariant() ) && 
                              ( Name.ToUpperInvariant() == "ParentId".ToUpperInvariant() || 
                                Name.ToUpperInvariant() == "Path".ToUpperInvariant() || 
                                Name.ToUpperInvariant() == "Level".ToUpperInvariant() || 
                                Name.ToUpperInvariant() == "SortId".ToUpperInvariant() );

        /// <summary>
        /// 属性驼峰名称
        /// </summary>
        public string CamelName => Name.Camelize();

        /// <summary>
        /// 获取属性最大安全长度
        /// </summary>
        public int GetSafeMaxLength() {
            if( NativeType == "nvarchar" )
                return MaxLength.SafeValue() / 2;
            return MaxLength.SafeValue();
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="entityContext">实体上下文</param>
        public Property Clone( EntityContext entityContext ) {
            var result = new Property( entityContext ) {
                Name = Name,
                Description = Description,
                IsKey = IsKey,
                IsRequired = IsRequired,
                Type = Type,
                SystemType = SystemType,
                NativeType = NativeType,
                MaxLength = MaxLength,
                IsAutoIncrement = IsAutoIncrement,
                Precision = Precision,
                Scale = Scale
            };
            return result;
        }
    }
}
