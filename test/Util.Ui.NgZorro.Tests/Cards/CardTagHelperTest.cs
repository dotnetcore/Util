using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Cards;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Cards {
    /// <summary>
    /// 卡片测试
    /// </summary>
    public partial class CardTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CardTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CardTagHelper().ToWrapper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<nz-card></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试操作组
        /// </summary>
        [Fact]
        public void TestActions() {
            _wrapper.SetContextAttribute( UiConst.Actions, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzActions]=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容区域自定义样式
        /// </summary>
        [Fact]
        public void TestBodyStyle() {
            _wrapper.SetContextAttribute( UiConst.BodyStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzBodyStyle]=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否移除边框
        /// </summary>
        [Fact]
        public void TestBorderless() {
            _wrapper.SetContextAttribute( UiConst.Borderless, true );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzBorderless]=\"true\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否移除边框
        /// </summary>
        [Fact]
        public void TestBindBorderless() {
            _wrapper.SetContextAttribute( AngularConst.BindBorderless, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzBorderless]=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试封面
        /// </summary>
        [Fact]
        public void TestCover() {
            _wrapper.SetContextAttribute( UiConst.Cover, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzCover]=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右上角操作区域
        /// </summary>
        [Fact]
        public void TestExtra() {
            _wrapper.SetContextAttribute( UiConst.Extra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzExtra]=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试鼠标滑过时是否可浮起
        /// </summary>
        [Fact]
        public void TestHoverable() {
            _wrapper.SetContextAttribute( UiConst.Hoverable, true );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzHoverable]=\"true\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试鼠标滑过时是否可浮起
        /// </summary>
        [Fact]
        public void TestBindHoverable() {
            _wrapper.SetContextAttribute( AngularConst.BindHoverable, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzHoverable]=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否加载状态
        /// </summary>
        [Fact]
        public void TestLoading() {
            _wrapper.SetContextAttribute( UiConst.Loading, true );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzLoading]=\"true\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否加载状态
        /// </summary>
        [Fact]
        public void TestBindLoading() {
            _wrapper.SetContextAttribute( AngularConst.BindLoading, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzLoading]=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试卡片类型
        /// </summary>
        [Fact]
        public void TestType() {
            _wrapper.SetContextAttribute( UiConst.Type, CardType.Inner );
            var result = new StringBuilder();
            result.Append( "<nz-card nzType=\"inner\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试卡片类型 - default不设置nzType属性
        /// </summary>
        [Fact]
        public void TestType_Default() {
            _wrapper.SetContextAttribute( UiConst.Type, CardType.Default );
            var result = new StringBuilder();
            result.Append( "<nz-card></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试卡片类型
        /// </summary>
        [Fact]
        public void TestBindType() {
            _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzType]=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试卡片大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, CardSize.Small );
            var result = new StringBuilder();
            result.Append( "<nz-card nzSize=\"small\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试卡片大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzSize]=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card (click)=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card>a</nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}