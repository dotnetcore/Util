using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Typographies.Renders {
    /// <summary>
    /// span排版组件渲染器
    /// </summary>
    public class SpanRender : TypographyRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化span排版组件渲染器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="builder">标签生成器</param>
        public SpanRender( Config config, TagBuilder builder ) : base( config, builder ) {
            _config = config;
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            var childTagBuilder = GetChildTagBuilder();
            if ( childTagBuilder == null ) {
                base.ConfigContent( builder );
                return;
            }
            _config.Content.AppendTo( childTagBuilder );
            builder.AppendContent( childTagBuilder );
        }

        /// <summary>
        /// 获取子标签生成器
        /// </summary>
        private TagBuilder GetChildTagBuilder() {
            var tag = _config.GetValue<SpanChildTag?>( UiConst.ChildTag );
            switch ( tag ) {
                case SpanChildTag.Code:
                    return new CodeBuilder();
                case SpanChildTag.Keyboard:
                    return new KbdBuilder();
                case SpanChildTag.Mark:
                    return new MarkBuilder();
                case SpanChildTag.Strong:
                    return new StrongBuilder();
                case SpanChildTag.Underline:
                    return new UBuilder();
                case SpanChildTag.Delete:
                    return new DelBuilder();
            }
            return null;
        }
    }
}
