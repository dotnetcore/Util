using Microsoft.AspNetCore.Mvc.Rendering;
using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Base {
    /// <summary>
    /// 栅格行标签生成器基类
    /// </summary>
    public abstract class RowBuilderBase<TBuilder> : AngularTagBuilder where TBuilder : RowBuilderBase<TBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化栅格行标签生成器基类
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="tagName">标签名称，范例：div</param>
        /// <param name="renderMode">渲染模式</param>
        protected RowBuilderBase( Config config, string tagName, TagRenderMode renderMode = TagRenderMode.Normal ) : base( config,tagName, renderMode ) {
            _config = config;
        }

        /// <summary>
        /// 配置对齐
        /// </summary>
        public virtual TBuilder Align() {
            Align( _config.GetValue<Align?>( UiConst.Align ) );
            BindAlign( _config.GetValue( AngularConst.BindAlign ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置对齐
        /// </summary>
        /// <param name="align">对齐方式</param>
        protected void Align( Align? align ) {
            AttributeIfNotEmpty( "nzAlign", align?.Description(),true );
        }

        /// <summary>
        /// 配置对齐
        /// </summary>
        /// <param name="align">对齐方式</param>
        protected void BindAlign( string align ) {
            AttributeIfNotEmpty( "[nzAlign]", align, true );
        }

        /// <summary>
        /// 配置间隔
        /// </summary>
        public virtual TBuilder Gutter() {
            Gutter( _config.GetValue( UiConst.Gutter ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置间隔
        /// </summary>
        protected void Gutter( string gutter ) {
            AttributeIfNotEmpty( "[nzGutter]", gutter, true );
        }

        /// <summary>
        /// 配置水平排列方式
        /// </summary>
        public virtual TBuilder Justify() {
            Justify( _config.GetValue<Justify?>( UiConst.Justify ) );
            BindJustify( _config.GetValue( AngularConst.BindJustify ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置水平排列方式
        /// </summary>
        /// <param name="justify">排列方式</param>
        protected void Justify( Justify? justify ) {
            AttributeIfNotEmpty( "nzJustify", justify?.Description(), true );
        }

        /// <summary>
        /// 配置水平排列方式
        /// </summary>
        /// <param name="justify">排列方式</param>
        protected void BindJustify( string justify ) {
            AttributeIfNotEmpty( "[nzJustify]", justify, true );
        }

        /// <summary>
        /// 配置栅格行
        /// </summary>
        protected TBuilder ConfigRow() {
            return Align().Gutter().Justify();
        }
    }
}