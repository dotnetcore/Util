using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Cards.TagHelpers;
using Util.Ui.Material.Enums;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Cards {
    /// <summary>
    /// 卡片标题图片测试
    /// </summary>
    public class CardTitleImageTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 卡片标题图片
        /// </summary>
        private readonly CardTitleImageTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CardTitleImageTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new CardTitleImageTagHelper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<img mat-card-md-image=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<img #a=\"\" mat-card-md-image=\"\" />" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试图片路径
        /// </summary>
        [Fact]
        public void TestSrc() {
            var attributes = new TagHelperAttributeList { { UiConst.Src, "a" } };
            var result = new String();
            result.Append( "<img mat-card-md-image=\"\" src=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试图片大小
        /// </summary>
        [Fact]
        public void TestSize() {
            var attributes = new TagHelperAttributeList { { UiConst.Size, CardTitleImageSize.Large } };
            var result = new String();
            result.Append( "<img mat-card-lg-image=\"\" />" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}