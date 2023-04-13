using Util.Generators.Configuration;
using Util.Generators.Contexts;
using Xunit;

namespace Util.Generators.Tests.Contexts {
    /// <summary>
    /// 生成器上下文测试
    /// </summary>
    public class GeneratorContextTest {
        /// <summary>
        /// 测试复制
        /// </summary>
        [Fact]
        public void TestClone() {
            //创建生成器上下文
            var context = new GeneratorContext {
                TemplateRootPath = "a",
                OutputRootPath = "b",
                Message = new MessageOptions {
                    RequiredMessage = "RequiredMessage",
                    MaxLengthMessage = "MaxLengthMessage"
                }
            };

            //添加项目上下文1
            var project1 = new ProjectContext( context ) { Name = "c" };
            context.Projects.Add( project1 );

            //添加实体上下文1
            var entityContext1 = new EntityContext( project1, "a" );
            project1.Entities.Add( entityContext1 );

            //添加属性1
            var property = new Property( entityContext1 ) { Name = "p1" };
            entityContext1.Properties.Add( property );

            //添加属性2
            var property2 = new Property( entityContext1 ) { Name = "p2" };
            entityContext1.Properties.Add( property2 );

            //添加实体上下文2
            var entityContext2 = new EntityContext( project1, "b" );
            project1.Entities.Add( entityContext2 );

            //添加项目上下文2
            var project2 = new ProjectContext( context );
            project2.Name = "d";
            context.Projects.Add( project2 );

            //添加实体上下文3
            var entityContext3 = new EntityContext( project2, "c" );
            project2.Entities.Add( entityContext3 );

            //添加实体上下文4
            var entityContext4 = new EntityContext( project2, "d" );
            project2.Entities.Add( entityContext4 );

            //复制副本
            var clone = context.Clone();

            //验证生成器上下文
            Assert.NotSame( context, clone );
            Assert.Equal( context.TemplateRootPath, clone.TemplateRootPath );
            Assert.Equal( context.OutputRootPath, clone.OutputRootPath );
            Assert.Equal( context.Message.RequiredMessage, clone.Message.RequiredMessage );
            Assert.Equal( context.Message.MaxLengthMessage, clone.Message.MaxLengthMessage );

            //验证项目上下文
            Assert.Equal( 2, clone.Projects.Count );
            Assert.Equal( "c", clone.Projects[0].Name );
            Assert.Equal( "d", clone.Projects[1].Name );
            Assert.Same( clone, clone.Projects[0].GeneratorContext );
            Assert.Same( clone, clone.Projects[1].GeneratorContext );

            //验证实体上下文
            Assert.Equal( 2, clone.Projects[0].Entities.Count );
            Assert.Equal( 2, clone.Projects[1].Entities.Count );
            Assert.Equal( "a", clone.Projects[0].Entities[0].Name );
            Assert.Equal( "b", clone.Projects[0].Entities[1].Name );
            Assert.Equal( "c", clone.Projects[1].Entities[0].Name );
            Assert.Equal( "d", clone.Projects[1].Entities[1].Name );
            Assert.Equal( clone, clone.Projects[0].Entities[0].ProjectContext.GeneratorContext );

            //验证属性
            var entity = clone.Projects[0].Entities[0];
            Assert.Equal( 2, entity.Properties.Count );
        }
    }
}
