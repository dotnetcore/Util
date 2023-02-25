using System.Data;
using Util.Generators.Contexts;
using Xunit;

namespace Util.Generators.Tests.Contexts {
    /// <summary>
    /// 属性测试
    /// </summary>
    public class PropertyTest {
        /// <summary>
        /// 测试复制
        /// </summary>
        [Fact]
        public void TestClone() {
            //创建属性
            var generatorContext = new GeneratorContext {
                TemplateRootPath = "Templates",
                OutputRootPath = "Output"
            };
            var projectContext = new ProjectContext( generatorContext ) { Name = "Project" };
            var context = new EntityContext( projectContext, "a" ) {
                Output = {
                    Extension = ".txt"
                }
            };
            var property = new Property( context ) {
                Name = "b",
                Description = "c",
                IsKey = true,
                IsRequired = true,
                SystemType = SystemType.DateTime,
                Type = DbType.Boolean,
                NativeType = "nvarchar",
                MaxLength = 1,
                IsAutoIncrement = true,
                Precision = 5,
                Scale = 2
            };

            //复制副本
            var clone = property.Clone( context );

            //验证属性
            Assert.NotSame( property, clone );
            Assert.Equal( property.Name, clone.Name );
            Assert.Equal( property.Description, clone.Description );
            Assert.Equal( property.IsKey, clone.IsKey );
            Assert.Equal( property.IsRequired, clone.IsRequired );
            Assert.Equal( property.Type, clone.Type );
            Assert.Equal( property.SystemType, clone.SystemType );
            Assert.Equal( property.NativeType, clone.NativeType );
            Assert.Equal( property.MaxLength, clone.MaxLength );
            Assert.Equal( property.IsAutoIncrement, clone.IsAutoIncrement );
            Assert.Equal( property.Precision, clone.Precision );
            Assert.Equal( property.Scale, clone.Scale );
        }
    }
}

