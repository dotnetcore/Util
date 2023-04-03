using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Avatars;
using Util.Ui.NgZorro.Components.Comments;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Avatars {
    /// <summary>
    /// 头像测试
    /// </summary>
    public class AvatarTagHelperTest {
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
        public AvatarTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new AvatarTagHelper().ToWrapper();
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
            result.Append( "<nz-avatar></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试访问控制
        /// </summary>
        [Fact]
        public void TestAcl() {
            _wrapper.SetContextAttribute( UiConst.Acl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar *aclIf=\"'a'\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试访问控制
        /// </summary>
        [Fact]
        public void TestBindAcl() {
            _wrapper.SetContextAttribute( AngularConst.BindAcl, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar [acl]=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标
        /// </summary>
        [Fact]
        public void TestIcon() {
            _wrapper.SetContextAttribute( UiConst.Icon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-avatar nzIcon=\"account-book\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标
        /// </summary>
        [Fact]
        public void TestBindIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar [nzIcon]=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试形状
        /// </summary>
        [Fact]
        public void TestShape() {
            _wrapper.SetContextAttribute( UiConst.Shape, AvatarShape.Square );
            var result = new StringBuilder();
            result.Append( "<nz-avatar nzShape=\"square\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试形状
        /// </summary>
        [Fact]
        public void TestBindShape() {
            _wrapper.SetContextAttribute( AngularConst.BindShape, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar [nzShape]=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, AvatarSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-avatar nzSize=\"large\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar [nzSize]=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本距离两侧间距
        /// </summary>
        [Fact]
        public void TestGap() {
            _wrapper.SetContextAttribute( UiConst.Gap, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-avatar nzGap=\"1\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本距离两侧间距
        /// </summary>
        [Fact]
        public void TestBindGap() {
            _wrapper.SetContextAttribute( AngularConst.BindGap, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar [nzGap]=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图片头像地址
        /// </summary>
        [Fact]
        public void TestSrc() {
            _wrapper.SetContextAttribute( UiConst.Src, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar nzSrc=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图片头像地址
        /// </summary>
        [Fact]
        public void TestBindSrc() {
            _wrapper.SetContextAttribute( AngularConst.BindSrc, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar [nzSrc]=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图片头像响应式资源地址
        /// </summary>
        [Fact]
        public void TestSrcSet() {
            _wrapper.SetContextAttribute( UiConst.SrcSet, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar nzSrcSet=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图片头像响应式资源地址
        /// </summary>
        [Fact]
        public void TestBindSrcSet() {
            _wrapper.SetContextAttribute( AngularConst.BindSrcSet, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar [nzSrcSet]=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图片无法显示时的替代文本
        /// </summary>
        [Fact]
        public void TestAlt() {
            _wrapper.SetContextAttribute( UiConst.Alt, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar nzAlt=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图片无法显示时的替代文本
        /// </summary>
        [Fact]
        public void TestBindAlt() {
            _wrapper.SetContextAttribute( AngularConst.BindAlt, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar [nzAlt]=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar nzText=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestBindText() {
            _wrapper.SetContextAttribute( AngularConst.BindText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar [nzText]=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar>a</nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图片加载失败事件
        /// </summary>
        [Fact]
        public void TestOnError() {
            _wrapper.SetContextAttribute( UiConst.OnError, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-avatar (nzError)=\"a\"></nz-avatar>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试评论头像-头像标签放入评论标签中,会自动添加nz-comment-avatar属性
        /// </summary>
        [Fact]
        public void TestCommentAvatar() {
            var comment = new CommentTagHelper().ToWrapper();
            comment.AppendContent( _wrapper );
            var result = new StringBuilder();
            result.Append( "<nz-comment>" );
            result.Append( "<nz-avatar nz-comment-avatar=\"\"></nz-avatar>" );
            result.Append( "</nz-comment>" );
            Assert.Equal( result.ToString(), comment.GetResult() );
        }
    }
}