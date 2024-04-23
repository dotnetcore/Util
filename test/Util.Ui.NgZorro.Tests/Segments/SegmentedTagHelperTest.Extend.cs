using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Segments {
    /// <summary>
    /// 分段控制器测试 - 指令扩展
    /// </summary>
    public partial class SegmentedTagHelperTest {

        #region EnableExtend

        /// <summary>
        /// 测试启用扩展指令
        /// </summary>
        [Fact]
        public void TestEnableExtend_1() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            var result = new StringBuilder();
            result.Append( "<nz-segmented #x_id=\"xSegmentedExtend\" (nzValueChange)=\"x_id.handleValueChange($event)\" " );
            result.Append( "x-segmented-extend=\"\" [(ngModel)]=\"x_id.index\" [nzOptions]=\"x_id.options\">" );
            result.Append( "</nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试启用扩展指令 - 不启用
        /// </summary>
        [Fact]
        public void TestEnableExtend_2() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, false );
            var result = new StringBuilder();
            result.Append( "<nz-segmented>" );
            result.Append( "</nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region AutoLoad

        /// <summary>
        /// 测试初始化时是否自动加载数据
        /// </summary>
        [Fact]
        public void TestAutoLoad() {
            _wrapper.SetContextAttribute( UiConst.AutoLoad, "false" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented [autoLoad]=\"false\">" );
            result.Append( "</nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Value

        /// <summary>
        /// 测试值绑定
        /// </summary>
        [Fact]
        public void TestValue() {
            _wrapper.SetContextAttribute( UiConst.Value, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented [(value)]=\"a\">" );
            result.Append( "</nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region QueryParam

        /// <summary>
        /// 测试查询参数
        /// </summary>
        [Fact]
        public void TestQueryParam() {
            _wrapper.SetContextAttribute( UiConst.QueryParam, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented [(queryParam)]=\"a\">" );
            result.Append( "</nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Url

        /// <summary>
        /// 测试Api地址
        /// </summary>
        [Fact]
        public void TestUrl_1() {
            _wrapper.SetContextAttribute( UiConst.Url, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented #x_id=\"xSegmentedExtend\" (nzValueChange)=\"x_id.handleValueChange($event)\" url=\"a\" " );
            result.Append( "x-segmented-extend=\"\" [(ngModel)]=\"x_id.index\" [nzOptions]=\"x_id.options\">" );
            result.Append( "</nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Api地址
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            _wrapper.SetContextAttribute( AngularConst.BindUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented #x_id=\"xSegmentedExtend\" (nzValueChange)=\"x_id.handleValueChange($event)\" " );
            result.Append( "x-segmented-extend=\"\" [(ngModel)]=\"x_id.index\" [nzOptions]=\"x_id.options\" [url]=\"a\">" );
            result.Append( "</nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Data

        /// <summary>
        /// 测试数据源
        /// </summary>
        [Fact]
        public void TestData() {
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented #x_id=\"xSegmentedExtend\" (nzValueChange)=\"x_id.handleValueChange($event)\" " );
            result.Append( "x-segmented-extend=\"\" [(ngModel)]=\"x_id.index\" [data]=\"a\" [nzOptions]=\"x_id.options\">" );
            result.Append( "</nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region OnLoad

        /// <summary>
        /// 测试数据加载完成事件
        /// </summary>
        [Fact]
        public void TestOnLoad() {
            _wrapper.SetContextAttribute( UiConst.OnLoad, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-segmented (onLoad)=\"a\"></nz-segmented>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion
    }
}