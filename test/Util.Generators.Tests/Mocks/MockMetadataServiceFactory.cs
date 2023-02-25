using Util.Data;
using Util.Data.Metadata;

namespace Util.Generators.Tests.Mocks {
    /// <summary>
    /// 模拟数据库元数据服务工厂
    /// </summary>
    public class MockMetadataServiceFactory : IMetadataServiceFactory {
        /// <summary>
        /// 创建数据库元数据服务
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connection">数据库连接字符串</param>
        public IMetadataService Create( DatabaseType dbType, string connection ) {
            if( connection == "TestConnection" )
                return new MockMetadataService();
            return new MockMetadataService2();
        }
    }
}
