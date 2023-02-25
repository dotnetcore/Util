using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Util.Generators.Contexts;
using Util.Generators.Logs;
using Util.Generators.Resources;
using Util.Generators.Templates;
using Xunit;

namespace Util.Generators.Tests {
    /// <summary>
    /// 生成器测试
    /// </summary>
    public class GeneratorTest {
        /// <summary>
        /// 生成器
        /// </summary>
        private Generators.Generator _generator;
        /// <summary>
        /// 模拟生成器上下文构建器
        /// </summary>
        private readonly Mock<IGeneratorContextBuilder> _mockGeneratorContextBuilder;
        /// <summary>
        /// 模拟模板查找器
        /// </summary>
        private readonly Mock<ITemplateFinder> _mockTemplateFinder;
        /// <summary>
        /// 模拟静态资源管理器
        /// </summary>
        private readonly Mock<IResourceManager> _mockResourceManager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public GeneratorTest() {
            _mockGeneratorContextBuilder = new Mock<IGeneratorContextBuilder>();
            _mockTemplateFinder = new Mock<ITemplateFinder>();
            _mockResourceManager = new Mock<IResourceManager>();
        }

        /// <summary>
        /// 测试生成 - 1个项目,1个实体,1个模板
        /// </summary>
        [Fact]
        public async Task TestGenerate_1() {
            var path = "a";

            //创建生成器上下文
            var generatorContext = new GeneratorContext { TemplateRootPath = path, OutputRootPath = "b" };
            var projectContext = new ProjectContext( generatorContext ) { Name = "project", Enabled = true, };
            projectContext.Entities.Add( new EntityContext( projectContext, "entity1" ) );
            generatorContext.Projects.Add( projectContext );

            //设置模拟操作
            _mockGeneratorContextBuilder.Setup( t => t.BuildAsync() ).Returns( Task.FromResult(generatorContext) );
            var mockTemplate = new Mock<ITemplate>();
            _mockTemplateFinder.Setup( t => t.Find( path, It.IsAny<ProjectContext>() ) ).Returns( new List<ITemplate> { mockTemplate.Object } );

            //执行生成
            _generator = new Generators.Generator( NullGeneratorLogger.Instance, _mockGeneratorContextBuilder.Object, _mockTemplateFinder.Object, _mockResourceManager.Object );
            await _generator.GenerateAsync();

            //验证
            mockTemplate.Verify( t => t.RenderAsync( It.IsAny<EntityContext>() ), Times.Once );
        }

        /// <summary>
        /// 测试生成 - 1个项目,1个实体,2个模板
        /// </summary>
        [Fact]
        public async Task TestGenerate_2() {
            var path = "a";

            //创建生成器上下文
            var generatorContext = new GeneratorContext { TemplateRootPath = path, OutputRootPath = "b" };
            var projectContext = new ProjectContext( generatorContext ) { Name = "project", Enabled = true, };
            projectContext.Entities.Add( new EntityContext( projectContext, "entity1" ) );
            generatorContext.Projects.Add( projectContext );

            //设置模拟操作
            _mockGeneratorContextBuilder.Setup( t => t.BuildAsync() ).Returns( Task.FromResult( generatorContext ) );
            var mockTemplate = new Mock<ITemplate>();
            var mockTemplate2 = new Mock<ITemplate>();
            _mockTemplateFinder.Setup( t => t.Find( path, It.IsAny<ProjectContext>() ) ).Returns( new List<ITemplate> { mockTemplate.Object, mockTemplate2.Object } );

            //执行生成
            _generator = new Generator( NullGeneratorLogger.Instance, _mockGeneratorContextBuilder.Object, _mockTemplateFinder.Object, _mockResourceManager.Object );
            await _generator.GenerateAsync();

            //验证
            mockTemplate.Verify( t => t.RenderAsync( It.IsAny<EntityContext>() ), Times.Once );
            mockTemplate2.Verify( t => t.RenderAsync( It.IsAny<EntityContext>() ), Times.Once );
        }

        /// <summary>
        /// 测试生成 - 1个项目,2个实体,1个模板 - 执行2次
        /// </summary>
        [Fact]
        public async Task TestGenerate_3() {
            var path = "a";

            //创建生成器上下文
            var generatorContext = new GeneratorContext { TemplateRootPath = path, OutputRootPath = "b" };
            var projectContext = new ProjectContext( generatorContext ) { Name = "project", Enabled = true, };
            projectContext.Entities.Add( new EntityContext( projectContext, "entity1" ) );
            projectContext.Entities.Add( new EntityContext( projectContext, "entity2" ) );
            generatorContext.Projects.Add( projectContext );

            //设置模拟操作
            _mockGeneratorContextBuilder.Setup( t => t.BuildAsync() ).Returns( Task.FromResult( generatorContext ) );
            var mockTemplate = new Mock<ITemplate>();
            _mockTemplateFinder.Setup( t => t.Find( path, It.IsAny<ProjectContext>() ) ).Returns( new List<ITemplate> { mockTemplate.Object } );

            //执行生成
            _generator = new Generator( NullGeneratorLogger.Instance, _mockGeneratorContextBuilder.Object, _mockTemplateFinder.Object, _mockResourceManager.Object );
            await _generator.GenerateAsync();

            //验证
            mockTemplate.Verify( t => t.RenderAsync( It.IsAny<EntityContext>() ), Times.Exactly( 2 ) );
        }

        /// <summary>
        /// 测试生成 - 1个项目,2个实体,2个模板 - 每个模板执行2次
        /// </summary>
        [Fact]
        public async Task TestGenerate_4() {
            var path = "a";

            //创建生成器上下文
            var generatorContext = new GeneratorContext { TemplateRootPath = path, OutputRootPath = "b" };
            var projectContext = new ProjectContext( generatorContext ) { Name = "project", Enabled = true, };
            projectContext.Entities.Add( new EntityContext( projectContext, "entity1" ) );
            projectContext.Entities.Add( new EntityContext( projectContext, "entity2" ) );
            generatorContext.Projects.Add( projectContext );

            //设置模拟操作
            _mockGeneratorContextBuilder.Setup( t => t.BuildAsync() ).Returns( Task.FromResult( generatorContext ) );
            var mockTemplate = new Mock<ITemplate>();
            var mockTemplate2 = new Mock<ITemplate>();
            _mockTemplateFinder.Setup( t => t.Find( path, It.IsAny<ProjectContext>() ) ).Returns( new List<ITemplate> { mockTemplate.Object, mockTemplate2.Object } );

            //执行生成
            _generator = new Generator( NullGeneratorLogger.Instance, _mockGeneratorContextBuilder.Object, _mockTemplateFinder.Object, _mockResourceManager.Object );
            await _generator.GenerateAsync();

            //验证
            mockTemplate.Verify( t => t.RenderAsync( It.IsAny<EntityContext>() ), Times.Exactly( 2 ) );
            mockTemplate2.Verify( t => t.RenderAsync( It.IsAny<EntityContext>() ), Times.Exactly( 2 ) );
        }

        /// <summary>
        /// 测试生成 - 2个项目,4个实体,2个模板 - 每个模板执行4次
        /// </summary>
        [Fact]
        public async Task TestGenerate_5() {
            var path = "a";

            //创建生成器上下文
            var generatorContext = new GeneratorContext { TemplateRootPath = path, OutputRootPath = "b" };

            //创建项目上下文
            var projectContext = new ProjectContext( generatorContext ) { Name = "project", Enabled = true, };
            projectContext.Entities.Add( new EntityContext( projectContext, "entity1" ) );
            projectContext.Entities.Add( new EntityContext( projectContext, "entity2" ) );
            generatorContext.Projects.Add( projectContext );

            //创建项目上下文2
            var projectContext2 = new ProjectContext( generatorContext ) { Name = "project2", Enabled = true, };
            projectContext2.Entities.Add( new EntityContext( projectContext2, "entity3" ) );
            projectContext2.Entities.Add( new EntityContext( projectContext2, "entity4" ) );
            generatorContext.Projects.Add( projectContext2 );

            //设置模拟操作
            _mockGeneratorContextBuilder.Setup( t => t.BuildAsync() ).Returns( Task.FromResult( generatorContext ) );
            var mockTemplate = new Mock<ITemplate>();
            var mockTemplate2 = new Mock<ITemplate>();
            _mockTemplateFinder.Setup( t => t.Find( path, It.IsAny<ProjectContext>() ) ).Returns( new List<ITemplate> { mockTemplate.Object, mockTemplate2.Object } );

            //执行生成
            _generator = new Generator( NullGeneratorLogger.Instance, _mockGeneratorContextBuilder.Object, _mockTemplateFinder.Object, _mockResourceManager.Object );
            await _generator.GenerateAsync();

            //验证
            mockTemplate.Verify( t => t.RenderAsync( It.IsAny<EntityContext>() ), Times.Exactly( 4 ) );
            mockTemplate2.Verify( t => t.RenderAsync( It.IsAny<EntityContext>() ), Times.Exactly( 4 ) );
        }

        /// <summary>
        /// 测试生成 - 1个项目,项目已禁用,不生成
        /// </summary>
        [Fact]
        public async Task TestGenerate_6() {
            var path = "a";

            //创建生成器上下文
            var generatorContext = new GeneratorContext { TemplateRootPath = path, OutputRootPath = "b" };
            var projectContext = new ProjectContext( generatorContext ) { Name = "project", Enabled = false, };
            projectContext.Entities.Add( new EntityContext( projectContext, "entity1" ) );
            generatorContext.Projects.Add( projectContext );

            //设置模拟操作
            _mockGeneratorContextBuilder.Setup( t => t.BuildAsync() ).Returns( Task.FromResult( generatorContext ) );
            var mockTemplate = new Mock<ITemplate>();
            _mockTemplateFinder.Setup( t => t.Find( path, It.IsAny<ProjectContext>() ) ).Returns( new List<ITemplate> { mockTemplate.Object } );

            //执行生成
            _generator = new Generator( NullGeneratorLogger.Instance, _mockGeneratorContextBuilder.Object, _mockTemplateFinder.Object, _mockResourceManager.Object );
            await _generator.GenerateAsync();

            //验证
            mockTemplate.Verify( t => t.RenderAsync( It.IsAny<EntityContext>() ), Times.Never );
        }

        /// <summary>
        /// 测试生成 - 2个项目,第一个项目已禁用
        /// </summary>
        [Fact]
        public async Task TestGenerate_7() {
            var path = "a";

            //创建生成器上下文
            var generatorContext = new GeneratorContext { TemplateRootPath = path, OutputRootPath = "b" };

            //创建项目上下文
            var projectContext = new ProjectContext( generatorContext ) { Name = "project", Enabled = false, };
            projectContext.Entities.Add( new EntityContext( projectContext, "entity1" ) );
            projectContext.Entities.Add( new EntityContext( projectContext, "entity2" ) );
            generatorContext.Projects.Add( projectContext );

            //创建项目上下文2
            var projectContext2 = new ProjectContext( generatorContext ) { Name = "project2", Enabled = true, };
            projectContext2.Entities.Add( new EntityContext( projectContext2, "entity3" ) );
            projectContext2.Entities.Add( new EntityContext( projectContext2, "entity4" ) );
            generatorContext.Projects.Add( projectContext2 );

            //设置模拟操作
            _mockGeneratorContextBuilder.Setup( t => t.BuildAsync() ).Returns( Task.FromResult( generatorContext ) );
            var mockTemplate = new Mock<ITemplate>();
            var mockTemplate2 = new Mock<ITemplate>();
            _mockTemplateFinder.Setup( t => t.Find( path, It.IsAny<ProjectContext>() ) ).Returns( new List<ITemplate> { mockTemplate.Object, mockTemplate2.Object } );

            //执行生成
            _generator = new Generator( NullGeneratorLogger.Instance, _mockGeneratorContextBuilder.Object, _mockTemplateFinder.Object, _mockResourceManager.Object );
            await _generator.GenerateAsync();

            //验证
            mockTemplate.Verify( t => t.RenderAsync( It.IsAny<EntityContext>() ), Times.Exactly( 2 ) );
            mockTemplate2.Verify( t => t.RenderAsync( It.IsAny<EntityContext>() ), Times.Exactly( 2 ) );
        }

        /// <summary>
        /// 测试生成 - 导入静态资源
        /// </summary>
        [Fact]
        public async Task TestGenerate_8() {
            var templateRootPath = "a";
            var outputRootPath = "b";
            var project = "project";

            //创建生成器上下文
            var generatorContext = new GeneratorContext { TemplateRootPath = templateRootPath, OutputRootPath = outputRootPath };

            //创建项目上下文
            var projectContext = new ProjectContext( generatorContext ) { Name = project, Enabled = true };
            generatorContext.Projects.Add( projectContext );

            //设置模拟操作
            _mockGeneratorContextBuilder.Setup( t => t.BuildAsync() ).Returns( Task.FromResult( generatorContext ) );
            var mockTemplate = new Mock<ITemplate>();
            _mockTemplateFinder.Setup( t => t.Find( templateRootPath, It.IsAny<ProjectContext>() ) ).Returns( new List<ITemplate> { mockTemplate.Object } );

            //执行生成
            _generator = new Generator( NullGeneratorLogger.Instance, _mockGeneratorContextBuilder.Object, _mockTemplateFinder.Object, _mockResourceManager.Object );
            await _generator.GenerateAsync();

            //验证
            _mockResourceManager.Verify( t => t.ImportsAsync( templateRootPath, outputRootPath, projectContext ) );
        }
    }
}
