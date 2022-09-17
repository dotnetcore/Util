using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Progresses;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Progresses {
    /// <summary>
    /// 进度条测试
    /// </summary>
    public class ProgressTagHelperTest {
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
        public ProgressTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ProgressTagHelper().ToWrapper();
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
            result.Append( "<nz-progress></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试类型
        /// </summary>
        [Fact]
        public void TestType() {
            _wrapper.SetContextAttribute( UiConst.Type, ProgressType.Dashboard );
            var result = new StringBuilder();
            result.Append( "<nz-progress nzType=\"dashboard\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试类型
        /// </summary>
        [Fact]
        public void TestBindType() {
            _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzType]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试格式化函数
        /// </summary>
        [Fact]
        public void TestFormat() {
            _wrapper.SetContextAttribute( UiConst.Format, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzFormat]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试百分比
        /// </summary>
        [Fact]
        public void TestPercent() {
            _wrapper.SetContextAttribute( UiConst.Percent, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-progress nzPercent=\"1\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试百分比
        /// </summary>
        [Fact]
        public void TestBindPercent() {
            _wrapper.SetContextAttribute( AngularConst.BindPercent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzPercent]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示进度信息
        /// </summary>
        [Fact]
        public void TestShowInfo() {
            _wrapper.SetContextAttribute( UiConst.ShowInfo, true );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzShowInfo]=\"true\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示进度信息
        /// </summary>
        [Fact]
        public void TestBindShowInfo() {
            _wrapper.SetContextAttribute( AngularConst.BindShowInfo, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzShowInfo]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态
        /// </summary>
        [Fact]
        public void TestStatus() {
            _wrapper.SetContextAttribute( UiConst.Status, ProgressStatus.Exception );
            var result = new StringBuilder();
            result.Append( "<nz-progress nzStatus=\"exception\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态
        /// </summary>
        [Fact]
        public void TestBindStatus() {
            _wrapper.SetContextAttribute( AngularConst.BindStatus, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzStatus]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试端点形状
        /// </summary>
        [Fact]
        public void TestStrokeLinecap() {
            _wrapper.SetContextAttribute( UiConst.StrokeLinecap, ProgressStrokeLinecap.Round );
            var result = new StringBuilder();
            result.Append( "<nz-progress nzStrokeLinecap=\"round\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试端点形状
        /// </summary>
        [Fact]
        public void TestBindStrokeLinecap() {
            _wrapper.SetContextAttribute( AngularConst.BindStrokeLinecap, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzStrokeLinecap]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestStrokeColor() {
            _wrapper.SetContextAttribute( UiConst.StrokeColor, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress nzStrokeColor=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestBindStrokeColor() {
            _wrapper.SetContextAttribute( AngularConst.BindStrokeColor, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzStrokeColor]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试已完成分段百分比
        /// </summary>
        [Fact]
        public void TestSuccessPercent() {
            _wrapper.SetContextAttribute( UiConst.SuccessPercent, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-progress nzSuccessPercent=\"1\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试已完成分段百分比
        /// </summary>
        [Fact]
        public void TestBindSuccessPercent() {
            _wrapper.SetContextAttribute( AngularConst.BindSuccessPercent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzSuccessPercent]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试线条宽度
        /// </summary>
        [Fact]
        public void TestStrokeWidth() {
            _wrapper.SetContextAttribute( UiConst.StrokeWidth, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-progress nzStrokeWidth=\"1\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试线条宽度
        /// </summary>
        [Fact]
        public void TestBindStrokeWidth() {
            _wrapper.SetContextAttribute( AngularConst.BindStrokeWidth, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzStrokeWidth]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试总步数
        /// </summary>
        [Fact]
        public void TestSteps() {
            _wrapper.SetContextAttribute( UiConst.Steps, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-progress nzSteps=\"1\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试总步数
        /// </summary>
        [Fact]
        public void TestBindSteps() {
            _wrapper.SetContextAttribute( AngularConst.BindSteps, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzSteps]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试画布宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            _wrapper.SetContextAttribute( UiConst.Width, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-progress nzWidth=\"1\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试画布宽度
        /// </summary>
        [Fact]
        public void TestBindWidth() {
            _wrapper.SetContextAttribute( AngularConst.BindWidth, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzWidth]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试缺口角度
        /// </summary>
        [Fact]
        public void TestGapDegree() {
            _wrapper.SetContextAttribute( UiConst.GapDegree, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-progress nzGapDegree=\"1\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试缺口角度
        /// </summary>
        [Fact]
        public void TestBindGapDegree() {
            _wrapper.SetContextAttribute( AngularConst.BindGapDegree, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzGapDegree]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试缺口位置
        /// </summary>
        [Fact]
        public void TestGapPosition() {
            _wrapper.SetContextAttribute( UiConst.GapPosition, ProgressGapPosition.Bottom );
            var result = new StringBuilder();
            result.Append( "<nz-progress nzGapPosition=\"bottom\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试缺口位置
        /// </summary>
        [Fact]
        public void TestBindGapPosition() {
            _wrapper.SetContextAttribute( AngularConst.BindGapPosition, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress [nzGapPosition]=\"a\"></nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-progress>a</nz-progress>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}