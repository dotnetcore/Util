using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Autocompletes {
    /// <summary>
    /// 自动完成测试 - 指令扩展
    /// </summary>
    public partial class AutocompleteTagHelperTest {

        #region 辅助操作

        /// <summary>
        /// 添加选项
        /// </summary>
        private void AppendOptions( StringBuilder result ) {
            result.Append( "@if(x_id.isGroup){" );
            result.Append( "@for(group of x_id.optionGroups;track group.text ){" );
            result.Append( "<nz-auto-optgroup [nzLabel]=\"group.text\">" );
            result.Append( "@for(item of group.value;track item.value){" );
            result.Append( "<nz-auto-option [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</nz-auto-option>" );
            result.Append( "}" );
            result.Append( "</nz-auto-optgroup>" );
            result.Append( "}} @else {" );
            result.Append( "@for(item of x_id.options;track item.value){" );
            result.Append( "<nz-auto-option [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text}}" );
            result.Append( "</nz-auto-option>" );
            result.Append( "}}" );
        }

        #endregion

        #region EnableExtend

        /// <summary>
        /// 测试启用扩展指令
        /// </summary>
        [Fact]
        public void TestEnableExtend_1() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, true );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete #x_id=\"xSelectExtend\" x-select-extend=\"\">" );
            AppendOptions( result );
            result.Append( "</nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试启用扩展指令 - 不启用
        /// </summary>
        [Fact]
        public void TestEnableExtend_2() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, false );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete>" );
            result.Append( "</nz-autocomplete>" );
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
            result.Append( "<nz-autocomplete [autoLoad]=\"false\">" );
            result.Append( "</nz-autocomplete>" );
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
            result.Append( "<nz-autocomplete [(queryParam)]=\"a\">" );
            result.Append( "</nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Sort

        /// <summary>
        /// 测试排序条件
        /// </summary>
        [Fact]
        public void TestSort() {
            _wrapper.SetContextAttribute( UiConst.Sort, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete order=\"a\">" );
            result.Append( "</nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试排序条件
        /// </summary>
        [Fact]
        public void TestBindSort() {
            _wrapper.SetContextAttribute( AngularConst.BindSort, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete [order]=\"a\">" );
            result.Append( "</nz-autocomplete>" );
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
            result.Append( "<nz-autocomplete #x_id=\"xSelectExtend\" url=\"a\" x-select-extend=\"\">" );
            AppendOptions( result );
            result.Append( "</nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Api地址
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            _wrapper.SetContextAttribute( AngularConst.BindUrl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete #x_id=\"xSelectExtend\" x-select-extend=\"\" [url]=\"a\">" );
            AppendOptions( result );
            result.Append( "</nz-autocomplete>" );
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
            result.Append( "<nz-autocomplete #x_id=\"xSelectExtend\" x-select-extend=\"\" [data]=\"a\">" );
            AppendOptions( result );
            result.Append( "</nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数据源 - 多语言
        /// </summary>
        [Fact]
        public void TestData_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Data, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete #x_id=\"xSelectExtend\" x-select-extend=\"\" [data]=\"a\">" );
            result.Append( "@if(x_id.isGroup){" );
            result.Append( "@for(group of x_id.optionGroups;track group.text ){" );
            result.Append( "<nz-auto-optgroup [nzLabel]=\"group.text|i18n\">" );
            result.Append( "@for(item of group.value;track item.value){" );
            result.Append( "<nz-auto-option [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text|i18n\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text|i18n}}" );
            result.Append( "</nz-auto-option>" );
            result.Append( "}" );
            result.Append( "</nz-auto-optgroup>" );
            result.Append( "}} @else {" );
            result.Append( "@for(item of x_id.options;track item.value){" );
            result.Append( "<nz-auto-option [nzDisabled]=\"item.disabled\" [nzLabel]=\"item.text|i18n\" [nzValue]=\"item.value\">" );
            result.Append( "{{item.text|i18n}}" );
            result.Append( "</nz-auto-option>" );
            result.Append( "}}" );
            result.Append( "</nz-autocomplete>" );
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
            result.Append( "<nz-autocomplete (onLoad)=\"a\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion
    }
}