using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
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
        /// 测试属性表达式 - 文本类型 - 多语言支持
        /// </summary>
        [Fact]
        public void TestFor_i18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetExpression( t => t.Code );
            _wrapper.SetContextAttribute( UiConst.ValueI18n, true );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item [nzTitle]=\"'code'|i18n\">{{model.code|i18n}}</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试测试属性表达式 - 复制到剪贴板
        /// </summary>
        [Fact]
        public void TestFor_Clipboard() {
            _wrapper.SetExpression( t => t.Code );
            _wrapper.SetContextAttribute( UiConst.Clipboard, true );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item nzTitle=\"code\">" );
            result.Append( "{{model.code}}" );
            result.Append( "<button #x_id=\"xButtonExtend\" (click)=\"x_id.copyToClipboard(model.code)\" *ngIf=\"model.code\" " );
            result.Append( "nz-button=\"\" nz-tooltip=\"\" nzTooltipTitle=\"复制到剪贴板\" nzType=\"text\" x-button-extend=\"\">" );
            result.Append( "<i nz-icon=\"\" nzType=\"copy\"></i>" );
            result.Append( "</button>" );
            result.Append( "</nz-descriptions-item>" );
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
            result.Append( "<nz-descriptions-item nzTitle=\"出生日期\">{{model.birthday|date:\"yyyy-MM-dd HH:mm:ss\"}}</nz-descriptions-item>" );
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

        /// <summary>
        /// 测试属性表达式 - 数值类型
        /// </summary>
        [Fact]
        public void TestFor_5() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetExpression( t => t.IdCard );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item [nzTitle]=\"'身份证'|i18n\">" );
            result.Append( "{{model.idCard}}" );
            result.Append( "</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}