using Xunit;

namespace Util.Datas.Tests.Commons.Datas.PgSql.Configs {
    /// <summary>
    /// 全局测试配置
    /// </summary>
    [CollectionDefinition( "PgSqlGlobalConfig" )]
    public class GlobalConfig : ICollectionFixture<GlobalFixture> {
    }
}
