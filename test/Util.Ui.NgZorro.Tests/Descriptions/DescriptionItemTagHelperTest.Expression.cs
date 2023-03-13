using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Descriptions {
    /// <summary>
    /// 描述列表项测试 - 表达式解析
    /// </summary>
    public partial class DescriptionItemTagHelperTest {
        /// <summary>
        /// 测试属性表达式 - 文本类型
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetExpression( t => t.Code );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item nzTitle=\"code\">{{model.code}}</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 布尔类型
        /// </summary>
        [Fact]
        public void TestFor_2() {
            _wrapper.SetExpression( t => t.Enabled );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item nzTitle=\"启用\">" );
            result.Append( "<i *ngIf=\"model.enabled\" nz-icon=\"\" nzType=\"check\"></i>" );
            result.Append( "<i *ngIf=\"!(model.enabled)\" nz-icon=\"\" nzType=\"close\"></i>" );
            result.Append( "</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 日期类型
        /// </summary>
        [Fact]
        public void TestFor_3() {
            _wrapper.SetExpression( t => t.Birthday );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item nzTitle=\"出生日期\">{{model.birthday|date:\"yyyy-MM-dd HH:mm\"}}</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 日期类型 - 设置日期格式
        /// </summary>
        [Fact]
        public void TestFor_4() {
            _wrapper.SetContextAttribute( UiConst.DateFormat, "yyyy-MM" );
            _wrapper.SetExpression( t => t.Birthday );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item nzTitle=\"出生日期\">{{model.birthday|date:\"yyyy-MM\"}}</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}