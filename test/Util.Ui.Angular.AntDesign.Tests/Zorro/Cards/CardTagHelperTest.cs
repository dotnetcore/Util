using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Cards;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Cards {
    /// <summary>
    /// 卡片测试
    /// </summary>
    public class CardTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 卡片
        /// </summary>
        private readonly CardTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CardTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new CardTagHelper();
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
            result.Append( "<nz-card></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-card #a=\"\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            var attributes = new TagHelperAttributeList { { UiConst.Title, "a" } };
            var result = new String();
            result.Append( "<nz-card nzTitle=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示边框
        /// </summary>
        [Fact]
        public void TestShowBorder() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowBorder, true } };
            var result = new String();
            result.Append( "<nz-card [nzBordered]=\"true\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试操作组
        /// </summary>
        [Fact]
        public void TestActions() {
            var attributes = new TagHelperAttributeList { { UiConst.Actions, "a" } };
            var result = new String();
            result.Append( "<nz-card [nzActions]=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}