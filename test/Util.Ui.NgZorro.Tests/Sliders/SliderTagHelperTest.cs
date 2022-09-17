using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Sliders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Sliders {
    /// <summary>
    /// 滑动输入条测试
    /// </summary>
    public class SliderTagHelperTest {
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
        public SliderTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new SliderTagHelper().ToWrapper();
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
            result.Append( "<nz-slider></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzDisabled]=\"true\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzDisabled]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否只能拖拽到刻度
        /// </summary>
        [Fact]
        public void TestDots() {
            _wrapper.SetContextAttribute( UiConst.Dots, true );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzDots]=\"true\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否只能拖拽到刻度
        /// </summary>
        [Fact]
        public void TestBindDots() {
            _wrapper.SetContextAttribute( AngularConst.BindDots, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzDots]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否包含
        /// </summary>
        [Fact]
        public void TestIncluded() {
            _wrapper.SetContextAttribute( UiConst.Included, true );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzIncluded]=\"true\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否包含
        /// </summary>
        [Fact]
        public void TestBindIncluded() {
            _wrapper.SetContextAttribute( AngularConst.BindIncluded, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzIncluded]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试刻度标记
        /// </summary>
        [Fact]
        public void TestMarks() {
            _wrapper.SetContextAttribute( UiConst.Marks, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzMarks]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大值
        /// </summary>
        [Fact]
        public void TestMax() {
            _wrapper.SetContextAttribute( UiConst.Max, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-slider nzMax=\"1\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大值
        /// </summary>
        [Fact]
        public void TestBindMax() {
            _wrapper.SetContextAttribute( AngularConst.BindMax, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzMax]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最小值
        /// </summary>
        [Fact]
        public void TestMin() {
            _wrapper.SetContextAttribute( UiConst.Min, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-slider nzMin=\"1\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最小值
        /// </summary>
        [Fact]
        public void TestBindMin() {
            _wrapper.SetContextAttribute( AngularConst.BindMin, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzMin]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试双滑块模式
        /// </summary>
        [Fact]
        public void TestRange() {
            _wrapper.SetContextAttribute( UiConst.Range, true );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzRange]=\"true\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试双滑块模式
        /// </summary>
        [Fact]
        public void TestBindRange() {
            _wrapper.SetContextAttribute( AngularConst.BindRange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzRange]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试步长
        /// </summary>
        [Fact]
        public void TestStep() {
            _wrapper.SetContextAttribute( UiConst.Step, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-slider nzStep=\"1\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试步长
        /// </summary>
        [Fact]
        public void TestBindStep() {
            _wrapper.SetContextAttribute( AngularConst.BindStep, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzStep]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示格式化函数
        /// </summary>
        [Fact]
        public void TestTipFormatter() {
            _wrapper.SetContextAttribute( UiConst.TipFormatter,"a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzTipFormatter]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试垂直方向
        /// </summary>
        [Fact]
        public void TestVertical() {
            _wrapper.SetContextAttribute( UiConst.Vertical, true );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzVertical]=\"true\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试垂直方向
        /// </summary>
        [Fact]
        public void TestBindVertical() {
            _wrapper.SetContextAttribute( AngularConst.BindVertical, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzVertical]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试反向
        /// </summary>
        [Fact]
        public void TestReverse() {
            _wrapper.SetContextAttribute( UiConst.Reverse, true );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzReverse]=\"true\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试反向
        /// </summary>
        [Fact]
        public void TestBindReverse() {
            _wrapper.SetContextAttribute( AngularConst.BindReverse, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzReverse]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示可见性
        /// </summary>
        [Fact]
        public void TestTooltipVisible() {
            _wrapper.SetContextAttribute( UiConst.TooltipVisible, SliderTooltipVisible.Always );
            var result = new StringBuilder();
            result.Append( "<nz-slider nzTooltipVisible=\"always\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示可见性
        /// </summary>
        [Fact]
        public void TestBindTooltipVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzTooltipVisible]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示位置
        /// </summary>
        [Fact]
        public void TestTooltipPlacement() {
            _wrapper.SetContextAttribute( UiConst.TooltipPlacement, TooltipPlacement.BottomRight );
            var result = new StringBuilder();
            result.Append( "<nz-slider nzTooltipPlacement=\"bottomRight\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示位置
        /// </summary>
        [Fact]
        public void TestBindTooltipPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider [nzTooltipPlacement]=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider>a</nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider (ngModelChange)=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试变更后事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            _wrapper.SetContextAttribute( UiConst.OnAfterChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-slider (nzOnAfterChange)=\"a\"></nz-slider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}