using Util.Generators.Contexts;
using Xunit;

namespace Util.Generators.Tests.Contexts {
    /// <summary>
    /// 实体上下文测试
    /// </summary>
    public class EntityContextTest {
        /// <summary>
        /// 测试复制
        /// </summary>
        [Fact]
        public void TestClone() {
            //创建实体上下文
            var generatorContext = new GeneratorContext {
                TemplateRootPath = "Templates",
                OutputRootPath = "Output"
            };
            var projectContext = new ProjectContext( generatorContext ) { Name = "Project" };
            var context = new EntityContext( projectContext, "a" ) {
                Schema = "TestSchema", 
                Description = "TestDescription",
                Output = {
                    Extension = ".txt"
                }
            };

            //复制副本
            var clone = context.Clone( projectContext );

            //验证实体上下文
            Assert.NotSame( context, clone );
            Assert.Equal( context.Name, clone.Name );
            Assert.Equal( context.Schema, clone.Schema );
            Assert.Equal( context.Description, clone.Description );

            //验证输出
            Assert.Equal( @"Output\Project", clone.Output.RootPath );
            Assert.Equal( ".txt", clone.Output.Extension );
        }
    }
}
