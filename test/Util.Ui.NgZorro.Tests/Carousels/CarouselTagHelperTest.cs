using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Carousels;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Carousels {
    /// <summary>
    /// 走马灯测试
    /// </summary>
    public class CarouselTagHelperTest {
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
        public CarouselTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CarouselTagHelper().ToWrapper();
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
            result.Append( "<nz-carousel></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否自动切换
        /// </summary>
        [Fact]
        public void TestAutoPlay() {
            _wrapper.SetContextAttribute( UiConst.AutoPlay, true );
            var result = new StringBuilder();
            result.Append( "<nz-carousel [nzAutoPlay]=\"true\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否自动切换
        /// </summary>
        [Fact]
        public void TestBindAutoPlay() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoPlay, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-carousel [nzAutoPlay]=\"a\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试切换时间
        /// </summary>
        [Fact]
        public void TestAutoPlaySpeed() {
            _wrapper.SetContextAttribute( UiConst.AutoPlaySpeed, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-carousel nzAutoPlaySpeed=\"1\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试切换时间
        /// </summary>
        [Fact]
        public void TestBindAutoPlaySpeed() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoPlaySpeed, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-carousel [nzAutoPlaySpeed]=\"a\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试指示点渲染模板
        /// </summary>
        [Fact]
        public void TestDotRender() {
            _wrapper.SetContextAttribute( UiConst.DotRender, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-carousel [nzDotRender]=\"a\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试指示点位置
        /// </summary>
        [Fact]
        public void TestDotPosition() {
            _wrapper.SetContextAttribute( UiConst.DotPosition, CarouselDotPosition.Left );
            var result = new StringBuilder();
            result.Append( "<nz-carousel nzDotPosition=\"left\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试指示点位置
        /// </summary>
        [Fact]
        public void TestBindDotPosition() {
            _wrapper.SetContextAttribute( AngularConst.BindDotPosition, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-carousel [nzDotPosition]=\"a\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示指示点
        /// </summary>
        [Fact]
        public void TestDots() {
            _wrapper.SetContextAttribute( UiConst.Dots, true );
            var result = new StringBuilder();
            result.Append( "<nz-carousel [nzDots]=\"true\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示指示点
        /// </summary>
        [Fact]
        public void TestBindDots() {
            _wrapper.SetContextAttribute( AngularConst.BindDots, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-carousel [nzDots]=\"a\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试动画效果
        /// </summary>
        [Fact]
        public void TestEffect() {
            _wrapper.SetContextAttribute( UiConst.Effect, CarouselEffect.Fade );
            var result = new StringBuilder();
            result.Append( "<nz-carousel nzEffect=\"fade\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试动画效果
        /// </summary>
        [Fact]
        public void TestBindEffect() {
            _wrapper.SetContextAttribute( AngularConst.BindEffect, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-carousel [nzEffect]=\"a\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持手势划动切换
        /// </summary>
        [Fact]
        public void TestEnableSwipe() {
            _wrapper.SetContextAttribute( UiConst.EnableSwipe, true );
            var result = new StringBuilder();
            result.Append( "<nz-carousel [nzEnableSwipe]=\"true\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持手势划动切换
        /// </summary>
        [Fact]
        public void TestBindEnableSwipe() {
            _wrapper.SetContextAttribute( AngularConst.BindEnableSwipe, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-carousel [nzEnableSwipe]=\"a\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
        
        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-carousel>a</nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试切换面板事件
        /// </summary>
        [Fact]
        public void TestOnAfterChange() {
            _wrapper.SetContextAttribute( UiConst.OnAfterChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-carousel (nzAfterChange)=\"a\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试切换面板前事件
        /// </summary>
        [Fact]
        public void TestOnBeforeChange() {
            _wrapper.SetContextAttribute( UiConst.OnBeforeChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-carousel (nzBeforeChange)=\"a\"></nz-carousel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}