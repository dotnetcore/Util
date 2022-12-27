using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Steps;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Steps {
    /// <summary>
    /// 步骤条测试
    /// </summary>
    public class StepsTagHelperTest {
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
        public StepsTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new StepsTagHelper().ToWrapper();
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
            result.Append( "<nz-steps></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试类型
        /// </summary>
        [Fact]
        public void TestType() {
            _wrapper.SetContextAttribute( UiConst.Type, StepsType.Navigation );
            var result = new StringBuilder();
            result.Append( "<nz-steps nzType=\"navigation\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试类型
        /// </summary>
        [Fact]
        public void TestBindType() {
            _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-steps [nzType]=\"a\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试当前步骤
        /// </summary>
        [Fact]
        public void TestCurrent() {
            _wrapper.SetContextAttribute( UiConst.Current, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-steps [nzCurrent]=\"1\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试当前步骤
        /// </summary>
        [Fact]
        public void TestBindCurrent() {
            _wrapper.SetContextAttribute( AngularConst.BindCurrent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-steps [nzCurrent]=\"a\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试尺寸
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, StepsSize.Small );
            var result = new StringBuilder();
            result.Append( "<nz-steps nzSize=\"small\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试尺寸
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-steps [nzSize]=\"a\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试起始序号
        /// </summary>
        [Fact]
        public void TestStartIndex() {
            _wrapper.SetContextAttribute( UiConst.StartIndex, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-steps [nzStartIndex]=\"1\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试起始序号
        /// </summary>
        [Fact]
        public void TestBindStartIndex() {
            _wrapper.SetContextAttribute( AngularConst.BindStartIndex, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-steps [nzStartIndex]=\"a\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试方向
        /// </summary>
        [Fact]
        public void TestDirection() {
            _wrapper.SetContextAttribute( UiConst.Direction, StepsDirection.Vertical );
            var result = new StringBuilder();
            result.Append( "<nz-steps nzDirection=\"vertical\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试方向
        /// </summary>
        [Fact]
        public void TestBindDirection() {
            _wrapper.SetContextAttribute( AngularConst.BindDirection, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-steps [nzDirection]=\"a\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态
        /// </summary>
        [Fact]
        public void TestStatus() {
            _wrapper.SetContextAttribute( UiConst.Status, StepStatus.Finish );
            var result = new StringBuilder();
            result.Append( "<nz-steps nzStatus=\"finish\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态
        /// </summary>
        [Fact]
        public void TestBindStatus() {
            _wrapper.SetContextAttribute( AngularConst.BindStatus, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-steps [nzStatus]=\"a\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点状
        /// </summary>
        [Fact]
        public void TestProgressDot() {
            _wrapper.SetContextAttribute( UiConst.ProgressDot, true );
            var result = new StringBuilder();
            result.Append( "<nz-steps [nzProgressDot]=\"true\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点状
        /// </summary>
        [Fact]
        public void TestBindProgressDot() {
            _wrapper.SetContextAttribute( AngularConst.BindProgressDot, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-steps [nzProgressDot]=\"a\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签位置
        /// </summary>
        [Fact]
        public void TestLabelPlacement() {
            _wrapper.SetContextAttribute( UiConst.LabelPlacement, StepsLabelPlacement.Vertical );
            var result = new StringBuilder();
            result.Append( "<nz-steps nzLabelPlacement=\"vertical\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签位置
        /// </summary>
        [Fact]
        public void TestBindLabelPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindLabelPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-steps [nzLabelPlacement]=\"a\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-steps>a</nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点击步骤事件
        /// </summary>
        [Fact]
        public void TestOnIndexChange() {
            _wrapper.SetContextAttribute( UiConst.OnIndexChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-steps (nzIndexChange)=\"a\"></nz-steps>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}