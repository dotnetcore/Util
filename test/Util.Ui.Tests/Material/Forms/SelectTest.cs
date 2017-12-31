using System;
using System.IO;
using System.Text.Encodings.Web;
using Util.Helpers;
using Util.Ui.Material.Forms;
using Util.Webs;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Forms {
    /// <summary>
    /// 下拉列表测试
    /// </summary>
    public class SelectTest : IDisposable {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 单引号
        /// </summary>
        public const string Quote = HtmlEscape.SingleQuote27;
        /// <summary>
        /// 下拉列表
        /// </summary>
        private readonly Select _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SelectTest( ITestOutputHelper output ) {
            _output = output;
            _component = new Select();
            Id.SetId( "id" );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Id.Reset();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( Select component ) {
            component.WriteTo( new StringWriter(), HtmlEncoder.Default );
            var result = component.ToString();
            _output.WriteLine( result );
            return result;
        }
    }
}
