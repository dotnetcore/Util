using System;

namespace Util.Data.Metadata {
    /// <summary>
    /// 数据类型转换器工厂
    /// </summary>
    public class TypeConverterFactory : ITypeConverterFactory {
        /// <summary>
        /// 创建数据库元数据服务
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        public ITypeConverter Create( DatabaseType dbType ) {
            switch ( dbType ) {
                case DatabaseType.SqlServer:
                    return new SqlServerTypeConverter();
                case DatabaseType.PgSql:
                    return new PostgreSqlTypeConverter();
                case DatabaseType.MySql:
                    return new MySqlTypeConverter();
            }
            throw new NotImplementedException();
        }
    }
}
