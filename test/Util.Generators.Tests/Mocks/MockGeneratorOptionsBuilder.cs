using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Data;
using Util.Generators.Configuration;

namespace Util.Generators.Tests.Mocks {
    /// <summary>
    /// 模拟生成器配置项构建器
    /// </summary>
    public class MockGeneratorOptionsBuilder : IGeneratorOptionsBuilder {
        /// <summary>
        /// 构建生成器配置项
        /// </summary>
        public Task<GeneratorOptions> BuildAsync() {
            var options = new GeneratorOptions {
                TemplatePath = "Templates",
                OutputPath = "Output",
                Messages = new MessageOptions {
                    RequiredMessage = "Required_Message",
                    MaxLengthMessage = "MaxLength_Message"
                },
                Projects = new Dictionary<string, ProjectOptions> {
                    {"Test",new ProjectOptions {
                        Name = "Test",
                        UnitOfWorkName = "UnitOfWork",
                        DbType = DatabaseType.SqlServer,
                        TargetDbType = DatabaseType.PgSql,
                        ConnectionString = "TestConnection",
                        Enabled = true,
                        Utc = true,
                        I18n = true,
                        Client = {
                            AppName =  "ClientApp",
                            Port =  "1"
                        },
                        ProjectType = ProjectType.WebApi,
                        ApiPort = "123",
                        Extend = "Extend1"
                    }},
                    {"Test2",new ProjectOptions {
                        Name = "Test2",
                        UnitOfWorkName = "UnitOfWork2",
                        DbType = DatabaseType.PgSql,
                        ConnectionString = "TestConnection2",
                        Enabled = true,
                        Utc = true,
                        I18n = true,
                        Client = {
                            AppName =  "ClientApp2",
                            Port =  "2"
                        },
                        ProjectType = ProjectType.Ui,
                        ApiPort = "456",
                        Extend = "Extend2"
                    }},
                    {"Test3",new ProjectOptions {
                        Name = "Test3",
                        UnitOfWorkName = "UnitOfWork3",
                        DbType = DatabaseType.SqlServer,
                        TargetDbType = DatabaseType.PgSql,
                        ConnectionString = "TestConnection3",
                        Enabled = false,
                        Utc = false,
                        I18n = false,
                        Client = {
                            AppName =  "ClientApp3",
                            Port =  "3"
                        },
                        ProjectType = ProjectType.WebApi,
                        ApiPort = "789",
                    }},
                }
            };
            return Task.FromResult( options );
        }
    }

    /// <summary>
    /// 模拟生成器配置项构建器2
    /// </summary>
    public class MockGeneratorOptionsBuilder2 : IGeneratorOptionsBuilder {
        /// <summary>
        /// 构建生成器配置项
        /// </summary>
        public Task<GeneratorOptions> BuildAsync() {
            var options = new GeneratorOptions {
                TemplatePath = @"c:\Templates",
                OutputPath = @"d:\Output",
                Projects = new Dictionary<string, ProjectOptions> {
                    {"Test",new ProjectOptions {
                        Name = "Test",
                        UnitOfWorkName = "UnitOfWork",
                        DbType = DatabaseType.SqlServer,
                        ConnectionString = "TestConnection",
                        Client = {
                            AppName =  "ClientApp",
                        }
                    }},
                    {"Test2",new ProjectOptions {
                        Name = "Test2",
                        UnitOfWorkName = "UnitOfWork2",
                        DbType = DatabaseType.PgSql,
                        TargetDbType = DatabaseType.SqlServer,
                        ConnectionString = "TestConnection2",
                        Client = {
                            AppName =  "ClientApp2",
                        }
                    }}
                }
            };
            return Task.FromResult( options );
        }
    }
}
