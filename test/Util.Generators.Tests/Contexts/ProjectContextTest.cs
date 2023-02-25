using Util.Data;
using Util.Generators.Configuration;
using Util.Generators.Contexts;
using Util.Generators.Tests.Samples;
using Xunit;

namespace Util.Generators.Tests.Contexts {
    /// <summary>
    /// 项目上下文测试
    /// </summary>
    public class ProjectContextTest {
        /// <summary>
        /// 测试复制
        /// </summary>
        [Fact]
        public void TestClone() {
            //创建项目上下文
            var generatorContext = new GeneratorContext {
                TemplateRootPath = "Templates",
                OutputRootPath = "Output"
            };
            var projectContext = new ProjectContext( generatorContext ) {
                Name = "Project",
                UnitOfWorkName = "UnitOfWork",
                DbType = DatabaseType.MySql,
                TargetDbType = DatabaseType.PgSql,
                ConnectionString = "ConnectionString",
                Client = {
                    AppName = "ClientApp",
                    Port = "Port"
                },
                Enabled = true,
                Utc = true,
                I18n = true,
                ProjectType = ProjectType.Ui,
                ApiPort = "80",
                Extend = new TestExtend {
                    Id = "1",
                    Name = "Name"
                }
            };

            //添加架构列表
            projectContext.Schemas.Add( "a" );
            projectContext.Schemas.Add( "b" );

            //添加实体上下文1
            var entityContext1 = new EntityContext( projectContext, "a" );
            projectContext.Entities.Add( entityContext1 );

            //添加实体上下文2
            var entityContext2 = new EntityContext( projectContext, "b" );
            projectContext.Entities.Add( entityContext2 );

            //复制副本
            var clone = projectContext.Clone( generatorContext );

            //验证项目上下文
            Assert.NotSame( projectContext, clone );
            Assert.Equal( projectContext.Name, clone.Name );
            Assert.Equal( projectContext.UnitOfWorkName, clone.UnitOfWorkName );
            Assert.Equal( projectContext.DbType, clone.DbType );
            Assert.Equal( projectContext.TargetDbType, clone.TargetDbType );
            Assert.Equal( projectContext.ConnectionString, clone.ConnectionString );
            Assert.Equal( projectContext.Client.AppName, clone.Client.AppName );
            Assert.Equal( projectContext.Client.Port, clone.Client.Port );
            Assert.Equal( projectContext.Enabled, clone.Enabled );
            Assert.Equal( projectContext.Utc, clone.Utc );
            Assert.Equal( projectContext.I18n, clone.I18n );
            Assert.Equal( projectContext.ProjectType, clone.ProjectType );
            Assert.Equal( projectContext.ApiPort, clone.ApiPort );
            Assert.Equal( projectContext.GetExtend<TestExtend>().Id, clone.GetExtend<TestExtend>().Id );
            Assert.Equal( projectContext.GetExtend<TestExtend>().Name, clone.GetExtend<TestExtend>().Name );

            //验证架构列表
            Assert.Equal( 2, clone.Schemas.Count );

            //验证实体上下文
            Assert.Equal( 2, clone.Entities.Count );
        }
    }
}
