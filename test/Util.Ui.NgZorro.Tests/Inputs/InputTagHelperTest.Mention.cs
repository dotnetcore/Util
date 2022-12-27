using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Mentions;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - 提及相关
    /// </summary>
    public partial class InputTagHelperTest {
        /// <summary>
        /// 测试提及触发元素
        /// </summary>
        [Fact]
        public void TestMentionTrigger() {
            var mention = new MentionTagHelper().ToWrapper();
            mention.AppendContent( _wrapper );
            var result = new StringBuilder();
            result.Append( "<nz-mention>" );
            result.Append( "<input nz-input=\"\" nzMentionTrigger=\"\" />" );
            result.Append( "</nz-mention>" );
            Assert.Equal( result.ToString(), mention.GetResult() );
        }

        /// <summary>
        /// 测试放入提及组件中,并设置前置标签
        /// </summary>
        [Fact]
        public void TestMention_AddOnBefore() {
            _wrapper.SetContextAttribute( UiConst.AddOnBefore, "a" );
            
            var mention = new MentionTagHelper().ToWrapper();
            mention.AppendContent( _wrapper );

            var result = new StringBuilder();
            result.Append( "<nz-mention>" );
            result.Append( "<nz-input-group nzAddOnBefore=\"a\">" );
            result.Append( "<input nz-input=\"\" nzMentionTrigger=\"\" />" );
            result.Append( "</nz-input-group>" );
            result.Append( "</nz-mention>" );
            Assert.Equal( result.ToString(), mention.GetResult() );
        }

        /// <summary>
        /// 测试放入提及组件中,并设置标签文本
        /// </summary>
        [Fact]
        public void TestMention_LabelText() {
            _wrapper.SetContextAttribute( UiConst.LabelText, "a" );

            var mention = new MentionTagHelper().ToWrapper();
            mention.AppendContent( _wrapper );

            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-mention>" );
            result.Append( "<input nz-input=\"\" nzMentionTrigger=\"\" />" );
            result.Append( "</nz-mention>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), mention.GetResult() );
        }

        /// <summary>
        /// 测试放入提及组件中,并设置标签文本和前置标签
        /// </summary>
        [Fact]
        public void TestMention_LabelText_AddOnBefore() {
            _wrapper.SetContextAttribute( UiConst.LabelText, "a" );
            _wrapper.SetContextAttribute( UiConst.AddOnBefore, "a" );

            var mention = new MentionTagHelper().ToWrapper();
            mention.AppendContent( _wrapper );

            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-mention>" );
            result.Append( "<nz-input-group nzAddOnBefore=\"a\">" );
            result.Append( "<input nz-input=\"\" nzMentionTrigger=\"\" />" );
            result.Append( "</nz-input-group>" );
            result.Append( "</nz-mention>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), mention.GetResult() );
        }

        /// <summary>
        /// 测试放入提及组件中,设置标签文本和前置标签,并自动设置标签for
        /// </summary>
        [Fact]
        public void TestMention_LabelText_AddOnBefore_AutoLabelFor() {
            _wrapper.SetContextAttribute( UiConst.LabelText, "a" );
            _wrapper.SetContextAttribute( UiConst.AddOnBefore, "a" );
            _wrapper.SetContextAttribute( UiConst.AutoLabelFor, true );

            var mention = new MentionTagHelper().ToWrapper();
            mention.AppendContent( _wrapper );

            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label nzFor=\"control_id\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-mention>" );
            result.Append( "<nz-input-group nzAddOnBefore=\"a\">" );
            result.Append( "<input id=\"control_id\" nz-input=\"\" nzMentionTrigger=\"\" />" );
            result.Append( "</nz-input-group>" );
            result.Append( "</nz-mention>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), mention.GetResult() );
        }
    }
}

