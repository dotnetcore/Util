using System;
using System.Data;
using Util.Data;
using Util.Data.Metadata;
using Util.Generators.Configuration;
using Util.Generators.Contexts;
using Util.Generators.Logs;
using Util.Generators.Tests.Mocks;
using Xunit;

namespace Util.Generators.Tests.Contexts {
    /// <summary>
    /// 生成器上下文构建器测试
    /// </summary>
    public class GeneratorContextBuilderTest {
        /// <summary>
        /// 生成器上下文
        /// </summary>
        private GeneratorContext _context;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public GeneratorContextBuilderTest() {
            _context = new GeneratorContextBuilder( NullGeneratorLogger.Instance, new MockGeneratorOptionsBuilder(), new MockMetadataServiceFactory(), new TypeConverterFactory() ).BuildAsync().Result;
        }

        /// <summary>
        /// 测试生成器上下文 - 相对路径
        /// </summary>
        [Fact]
        public void TestGeneratorContext_Path_1() {
            Assert.Equal( $"{AppContext.BaseDirectory}Templates", _context.TemplateRootPath );
            Assert.Equal( $"{AppContext.BaseDirectory}Output", _context.OutputRootPath );
        }

        /// <summary>
        /// 测试生成器上下文 - 绝对路径
        /// </summary>
        [Fact]
        public void TestGeneratorContext_Path_2() {
            _context = new GeneratorContextBuilder( NullGeneratorLogger.Instance, new MockGeneratorOptionsBuilder2(), new MockMetadataServiceFactory(),new TypeConverterFactory() ).BuildAsync().Result;
            Assert.Equal( @"c:\Templates", _context.TemplateRootPath );
            Assert.Equal( @"d:\Output", _context.OutputRootPath );
        }

        /// <summary>
        /// 测试项目名称
        /// </summary>
        [Fact]
        public void TestProjectContext_Name() {
            var projectContext = _context.Projects[0];
            Assert.Equal( "Test", projectContext.Name );
            var projectContext2 = _context.Projects[1];
            Assert.Equal( "Test2", projectContext2.Name );
        }

        /// <summary>
        /// 测试项目工作单元名称
        /// </summary>
        [Fact]
        public void TestProjectContext_UnitOfWorkName() {
            var projectContext = _context.Projects[0];
            Assert.Equal( "UnitOfWork", projectContext.UnitOfWorkName );
            var projectContext2 = _context.Projects[1];
            Assert.Equal( "UnitOfWork2", projectContext2.UnitOfWorkName );
        }

        /// <summary>
        /// 测试项目客户端
        /// </summary>
        [Fact]
        public void TestProjectContext_Client() {
            var projectContext = _context.Projects[0];
            Assert.Equal( "ClientApp", projectContext.Client.AppName );
            Assert.Equal( "1", projectContext.Client.Port );
            var projectContext2 = _context.Projects[1];
            Assert.Equal( "ClientApp2", projectContext2.Client.AppName );
            Assert.Equal( "2", projectContext2.Client.Port );
        }

        /// <summary>
        /// 测试项目数据库类型
        /// </summary>
        [Fact]
        public void TestProjectContext_DbType() {
            var projectContext = _context.Projects[0];
            Assert.Equal( DatabaseType.SqlServer, projectContext.DbType );
            var projectContext2 = _context.Projects[1];
            Assert.Equal( DatabaseType.PgSql, projectContext2.DbType );
        }

        /// <summary>
        /// 测试项目目标数据库类型
        /// </summary>
        [Fact]
        public void TestProjectContext_TargetDbType() {
            var projectContext = _context.Projects[0];
            Assert.Equal( DatabaseType.PgSql, projectContext.TargetDbType );
            var projectContext2 = _context.Projects[1];
            Assert.Equal( DatabaseType.PgSql, projectContext2.TargetDbType );
        }

        /// <summary>
        /// 测试项目连接字符串
        /// </summary>
        [Fact]
        public void TestProjectContext_ConnectionString() {
            var projectContext = _context.Projects[0];
            Assert.Equal( "TestConnection", projectContext.ConnectionString );
            var projectContext2 = _context.Projects[1];
            Assert.Equal( "TestConnection2", projectContext2.ConnectionString );
        }

        /// <summary>
        /// 测试项目是否启用
        /// </summary>
        [Fact]
        public void TestProjectContext_Enabled() {
            var projectContext = _context.Projects[0];
            Assert.True( projectContext.Enabled );
            var projectContext2 = _context.Projects[1];
            Assert.True( projectContext2.Enabled );
            var projectContext3 = _context.Projects[2];
            Assert.False( projectContext3.Enabled );
        }

        /// <summary>
        /// 测试项目是否启用Utc
        /// </summary>
        [Fact]
        public void TestProjectContext_Utc() {
            var projectContext = _context.Projects[0];
            Assert.True( projectContext.Utc );
            var projectContext2 = _context.Projects[1];
            Assert.True( projectContext2.Utc );
            var projectContext3 = _context.Projects[2];
            Assert.False( projectContext3.Utc );
        }

        /// <summary>
        /// 测试项目是否启用多语言
        /// </summary>
        [Fact]
        public void TestProjectContext_I18n() {
            var projectContext = _context.Projects[0];
            Assert.True( projectContext.I18n );
            var projectContext2 = _context.Projects[1];
            Assert.True( projectContext2.I18n );
            var projectContext3 = _context.Projects[2];
            Assert.False( projectContext3.I18n );
        }

        /// <summary>
        /// 测试项目类型
        /// </summary>
        [Fact]
        public void TestProjectContext_ProjectType() {
            var projectContext = _context.Projects[0];
            Assert.Equal( ProjectType.WebApi, projectContext.ProjectType );
            var projectContext2 = _context.Projects[1];
            Assert.Equal( ProjectType.Ui, projectContext2.ProjectType );
        }

        /// <summary>
        /// 测试Web Api项目端口
        /// </summary>
        [Fact]
        public void TestProjectContext_ApiPort() {
            var projectContext = _context.Projects[0];
            Assert.Equal( "123", projectContext.ApiPort );
            var projectContext2 = _context.Projects[1];
            Assert.Equal( "456", projectContext2.ApiPort );
        }

        /// <summary>
        /// 测试项目扩展
        /// </summary>
        [Fact]
        public void TestProjectContext_Extend() {
            var projectContext = _context.Projects[0];
            Assert.Equal( "Extend1", projectContext.Extend );
            var projectContext2 = _context.Projects[1];
            Assert.Equal( "Extend2", projectContext2.Extend );
        }

        /// <summary>
        /// 测试项目架构列表
        /// </summary>
        [Fact]
        public void TestProjectContext_Schemas() {
            var projectContext = _context.Projects[0];
            Assert.Equal( 2, projectContext.Schemas.Count );
            Assert.Equal( "TestSchema", projectContext.Schemas[0] );
            Assert.Equal( "TestSchema2", projectContext.Schemas[1] );
            var projectContext2 = _context.Projects[1];
            Assert.Equal( 2, projectContext2.Schemas.Count );
        }

        /// <summary>
        /// 测试实体架构
        /// </summary>
        [Fact]
        public void TestEntityContext_Schema() {
            var projectContext = _context.Projects[0];
            Assert.Equal( "TestSchema", projectContext.Entities[0].Schema );
            Assert.Equal( "TestSchema2", projectContext.Entities[1].Schema );

            var projectContext2 = _context.Projects[1];
            Assert.Equal( "TestSchema3", projectContext2.Entities[0].Schema );
            Assert.Equal( "TestSchema4", projectContext2.Entities[1].Schema );
        }

        /// <summary>
        /// 测试实体描述
        /// </summary>
        [Fact]
        public void TestEntityContext_Description() {
            var projectContext = _context.Projects[0];
            Assert.Equal( "TestComment", projectContext.Entities[0].Description );
            Assert.Equal( "TestComment2", projectContext.Entities[1].Description );

            var projectContext2 = _context.Projects[1];
            Assert.Equal( "TestComment3", projectContext2.Entities[0].Description );
            Assert.Equal( "TestComment4", projectContext2.Entities[1].Description );
        }

        /// <summary>
        /// 测试实体上下文根路径
        /// </summary>
        [Fact]
        public void TestEntityContext_RootPath() {
            var projectContext = _context.Projects[0];
            Assert.Equal( @$"{AppContext.BaseDirectory}Output\Test", projectContext.Entities[0].Output.RootPath );
            Assert.Equal( @$"{AppContext.BaseDirectory}Output\Test", projectContext.Entities[1].Output.RootPath );

            var projectContext2 = _context.Projects[1];
            Assert.Equal( @$"{AppContext.BaseDirectory}Output\Test2", projectContext2.Entities[0].Output.RootPath );
            Assert.Equal( @$"{AppContext.BaseDirectory}Output\Test2", projectContext2.Entities[1].Output.RootPath );
        }

        /// <summary>
        /// 测试实体上下文输出文件名
        /// </summary>
        [Fact]
        public void TestEntityContext_FileNameNoExtension() {
            var projectContext = _context.Projects[0];
            Assert.Equal( "TestName", projectContext.Entities[0].Output.FileNameNoExtension );
            Assert.Equal( "TestName2", projectContext.Entities[1].Output.FileNameNoExtension );

            var projectContext2 = _context.Projects[1];
            Assert.Equal( "TestName3", projectContext2.Entities[0].Output.FileNameNoExtension );
            Assert.Equal( "TestName4", projectContext2.Entities[1].Output.FileNameNoExtension );
        }

        /// <summary>
        /// 测试实体上下文路径 - 命名约定
        /// </summary>
        [Fact]
        public void TestEntityContext_Path_NamingConvention() {
            var projectContext = _context.Projects[0];
            var entityContext = projectContext.Entities[0];
            entityContext.Output.FileNameNoExtension = "testName";
            entityContext.Output.Extension = ".ts";
            entityContext.Output.NamingConvention = NamingConvention.PascalCase;
            Assert.Equal( @$"{AppContext.BaseDirectory}Output\Test\TestName.ts", entityContext.Output.Path );

            var entityContext2 = projectContext.Entities[1];
            entityContext2.Output.FileNameNoExtension = "TestName";
            entityContext2.Output.Extension = ".ts";
            entityContext2.Output.NamingConvention = NamingConvention.CamelCase;
            Assert.Equal( @$"{AppContext.BaseDirectory}Output\Test\testName.ts", entityContext2.Output.Path );
        }

        /// <summary>
        /// 测试实体上下文属性列表
        /// </summary>
        [Fact]
        public void TestEntityContext_Properties() {
            var projectContext = _context.Projects[0];
            Assert.Equal( 2, projectContext.Entities[0].Properties.Count );
            Assert.Equal( 2, projectContext.Entities[1].Properties.Count );

            var property = projectContext.Entities[0].Properties[0];
            Assert.Equal( "TestColumn", property.Name );
            Assert.Equal( "TestComment", property.Description );
        }

        /// <summary>
        /// 测试实体上下文标识列
        /// </summary>
        [Fact]
        public void TestEntityContext_Key() {
            var projectContext = _context.Projects[0];

            var entity = projectContext.Entities[0];
            var property = entity.Properties[0];
            Assert.Equal( "TestColumn", property.Name );
            Assert.False( property.IsKey );

            var property2 = entity.Properties[1];
            Assert.Equal( "TestColumn2", property2.Name );
            Assert.True( property2.IsKey );

            Assert.Equal( "TestColumn2", entity.Key.Name );
        }

        /// <summary>
        /// 测试实体上下文自增列
        /// </summary>
        [Fact]
        public void TestEntityContext_IsAutoIncrement() {
            var projectContext = _context.Projects[0];

            var entity = projectContext.Entities[0];
            var property = entity.Properties[0];
            Assert.Equal( "TestColumn", property.Name );
            Assert.False( property.IsAutoIncrement );

            var property2 = entity.Properties[1];
            Assert.Equal( "TestColumn2", property2.Name );
            Assert.True( property2.IsAutoIncrement );
        }

        /// <summary>
        /// 测试属性类型
        /// </summary>
        [Fact]
        public void TestProperty_Type() {
            var projectContext = _context.Projects[0];
            var entity = projectContext.Entities[0];

            var property = entity.Properties[0];
            Assert.Equal( "TestColumn", property.Name );
            Assert.Equal( DbType.String, property.Type );
            Assert.Equal( SystemType.String, property.SystemType );
            Assert.Equal( "nvarchar", property.NativeType );

            var property2 = entity.Properties[1];
            Assert.Equal( "TestColumn2", property2.Name );
            Assert.Equal( DbType.AnsiString, property2.Type );
            Assert.Equal( SystemType.String, property2.SystemType );
            Assert.Equal( "varchar", property2.NativeType );
        }

        /// <summary>
        /// 测试属性必填项
        /// </summary>
        [Fact]
        public void TestProperty_IsRequired() {
            var projectContext = _context.Projects[0];
            var entity = projectContext.Entities[1];

            var property = entity.Properties[0];
            Assert.Equal( "TestColumn3", property.Name );
            Assert.False( property.IsRequired );

            var property2 = entity.Properties[1];
            Assert.Equal( "TestColumn4", property2.Name );
            Assert.True( property2.IsRequired );
        }

        /// <summary>
        /// 测试属性最大长度
        /// </summary>
        [Fact]
        public void TestProperty_MaxLength() {
            var projectContext = _context.Projects[0];
            var entity = projectContext.Entities[0];

            var property = entity.Properties[0];
            Assert.Equal( "TestColumn", property.Name );
            Assert.Equal( 200, property.MaxLength );
        }

        /// <summary>
        /// 测试属性精度
        /// </summary>
        [Fact]
        public void TestProperty_Precision() {
            var projectContext = _context.Projects[0];
            var entity = projectContext.Entities[1];

            var property = entity.Properties[0];
            Assert.Equal( "TestColumn3", property.Name );
            Assert.Equal( 5, property.Precision );
            Assert.Equal( 2, property.Scale );
        }

        /// <summary>
        /// 测试生成器上下文 - 消息
        /// </summary>
        [Fact]
        public void TestGeneratorContext_Message() {
            Assert.Equal( "Required_Message", _context.Message.RequiredMessage );
            Assert.Equal( "MaxLength_Message", _context.Message.MaxLengthMessage );
        }
    }
}
