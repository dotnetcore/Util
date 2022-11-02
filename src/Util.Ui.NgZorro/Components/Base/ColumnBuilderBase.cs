using Microsoft.AspNetCore.Mvc.Rendering;
using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Grids.Helpers;

namespace Util.Ui.NgZorro.Components.Base {
    /// <summary>
    /// 栅格列标签生成器基类
    /// </summary>
    public abstract class ColumnBuilderBase<TBuilder> : AngularTagBuilder where TBuilder : ColumnBuilderBase<TBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化栅格列标签生成器基类
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="tagName">标签名称，范例：div</param>
        /// <param name="renderMode">渲染模式</param>
        protected ColumnBuilderBase( Config config, string tagName, TagRenderMode renderMode = TagRenderMode.Normal ) : base( config,tagName, renderMode ) {
            _config = config;
        }

        /// <summary>
        /// 配置跨度
        /// </summary>
        public virtual TBuilder Span() {
            AttributeIfNotEmpty( "nzSpan", _config.GetValue( UiConst.Span ) );
            AttributeIfNotEmpty( "[nzSpan]", _config.GetValue( AngularConst.BindSpan ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置偏移量
        /// </summary>
        public virtual TBuilder Offset() {
            AttributeIfNotEmpty( "nzOffset", _config.GetValue( UiConst.Offset ) );
            AttributeIfNotEmpty( "[nzOffset]", _config.GetValue( AngularConst.BindOffset ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置左移
        /// </summary>
        public virtual TBuilder Pull() {
            AttributeIfNotEmpty( "nzPull", _config.GetValue( UiConst.Pull ) );
            AttributeIfNotEmpty( "[nzPull]", _config.GetValue( AngularConst.BindPull ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置右移
        /// </summary>
        public virtual TBuilder Push() {
            AttributeIfNotEmpty( "nzPush", _config.GetValue( UiConst.Push ) );
            AttributeIfNotEmpty( "[nzPush]", _config.GetValue( AngularConst.BindPush ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置栅格顺序
        /// </summary>
        public virtual TBuilder Order() {
            AttributeIfNotEmpty( "nzOrder", _config.GetValue( UiConst.Order ) );
            AttributeIfNotEmpty( "[nzOrder]", _config.GetValue( AngularConst.BindOrder ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Flex布局
        /// </summary>
        public virtual TBuilder Flex() {
            AttributeIfNotEmpty( "nzFlex", _config.GetValue( UiConst.Flex ) );
            AttributeIfNotEmpty( "[nzFlex]", _config.GetValue( AngularConst.BindFlex ) );
            return (TBuilder)this;
        }

        /// <summary>
        /// 配置Xs超窄尺寸响应式栅格
        /// </summary>
        public TBuilder ConfigXs() {
            AttributeIfNotEmpty( "[nzXs]", GetXs() );
            var model = new GridModel {
                Span = GetXsSpan(),
                Offset = GetXsOffset(),
                Order = GetXsOrder(),
                Pull = GetXsPull(),
                Push = GetXsPush()
            };
            AttributeIfNotEmpty( "[nzXs]", model.ToJson() );
            return (TBuilder)this;
        }

        /// <summary>
        /// 获取Xs超窄尺寸响应式栅格
        /// </summary>
        protected virtual string GetXs() {
            return _config.GetValue( UiConst.Xs );
        }

        /// <summary>
        /// 获取Xs超窄尺寸跨度
        /// </summary>
        protected virtual int? GetXsSpan() {
            return _config.GetValue<int?>( UiConst.XsSpan );
        }

        /// <summary>
        /// 获取Xs超窄尺寸偏移量
        /// </summary>
        protected virtual int? GetXsOffset() {
            return _config.GetValue<int?>( UiConst.XsOffset );
        }

        /// <summary>
        /// 获取Xs超窄尺寸顺序
        /// </summary>
        protected virtual int? GetXsOrder() {
            return _config.GetValue<int?>( UiConst.XsOrder );
        }

        /// <summary>
        /// 获取Xs超窄尺寸左移
        /// </summary>
        protected virtual int? GetXsPull() {
            return _config.GetValue<int?>( UiConst.XsPull );
        }

        /// <summary>
        /// 获取Xs超窄尺寸右移
        /// </summary>
        protected virtual int? GetXsPush() {
            return _config.GetValue<int?>( UiConst.XsPush );
        }
        
        /// <summary>
        /// 配置Sm窄尺寸响应式栅格
        /// </summary>
        public TBuilder ConfigSm() {
            AttributeIfNotEmpty( "[nzSm]", GetSm() );
            var model = new GridModel {
                Span = GetSmSpan(),
                Offset = GetSmOffset(),
                Order = GetSmOrder(),
                Pull = GetSmPull(),
                Push = GetSmPush()
            };
            AttributeIfNotEmpty( "[nzSm]", model.ToJson() );
            return (TBuilder)this;
        }

        /// <summary>
        /// 获取Sm窄尺寸响应式栅格
        /// </summary>
        protected virtual string GetSm() {
            return _config.GetValue( UiConst.Sm );
        }

        /// <summary>
        /// 获取Sm窄尺寸跨度
        /// </summary>
        protected virtual int? GetSmSpan() {
            return _config.GetValue<int?>( UiConst.SmSpan );
        }

        /// <summary>
        /// 获取Sm窄尺寸偏移量
        /// </summary>
        protected virtual int? GetSmOffset() {
            return _config.GetValue<int?>( UiConst.SmOffset );
        }

        /// <summary>
        /// 获取Sm窄尺寸顺序
        /// </summary>
        protected virtual int? GetSmOrder() {
            return _config.GetValue<int?>( UiConst.SmOrder );
        }

        /// <summary>
        /// 获取Sm窄尺寸左移
        /// </summary>
        protected virtual int? GetSmPull() {
            return _config.GetValue<int?>( UiConst.SmPull );
        }

        /// <summary>
        /// 获取Sm窄尺寸右移
        /// </summary>
        protected virtual int? GetSmPush() {
            return _config.GetValue<int?>( UiConst.SmPush );
        }

        /// <summary>
        /// 配置Md中尺寸响应式栅格
        /// </summary>
        public TBuilder ConfigMd() {
            AttributeIfNotEmpty( "[nzMd]", GetMd() );
            var model = new GridModel {
                Span = GetMdSpan(),
                Offset = GetMdOffset(),
                Order = GetMdOrder(),
                Pull = GetMdPull(),
                Push = GetMdPush()
            };
            AttributeIfNotEmpty( "[nzMd]", model.ToJson() );
            return (TBuilder)this;
        }

        /// <summary>
        /// 获取Md中尺寸响应式栅格
        /// </summary>
        protected virtual string GetMd() {
            return _config.GetValue( UiConst.Md );
        }

        /// <summary>
        /// 获取Md中尺寸跨度
        /// </summary>
        protected virtual int? GetMdSpan() {
            return _config.GetValue<int?>( UiConst.MdSpan );
        }

        /// <summary>
        /// 获取Md中尺寸偏移量
        /// </summary>
        protected virtual int? GetMdOffset() {
            return _config.GetValue<int?>( UiConst.MdOffset );
        }

        /// <summary>
        /// 获取Md中尺寸顺序
        /// </summary>
        protected virtual int? GetMdOrder() {
            return _config.GetValue<int?>( UiConst.MdOrder );
        }

        /// <summary>
        /// 获取Md中尺寸左移
        /// </summary>
        protected virtual int? GetMdPull() {
            return _config.GetValue<int?>( UiConst.MdPull );
        }

        /// <summary>
        /// 获取Md中尺寸右移
        /// </summary>
        protected virtual int? GetMdPush() {
            return _config.GetValue<int?>( UiConst.MdPush );
        }

        /// <summary>
        /// 配置Lg宽尺寸响应式栅格
        /// </summary>
        public TBuilder ConfigLg() {
            AttributeIfNotEmpty( "[nzLg]", GetLg() );
            var model = new GridModel {
                Span = GetLgSpan(),
                Offset = GetLgOffset(),
                Order = GetLgOrder(),
                Pull = GetLgPull(),
                Push = GetLgPush()
            };
            AttributeIfNotEmpty( "[nzLg]", model.ToJson() );
            return (TBuilder)this;
        }

        /// <summary>
        /// 获取Lg宽尺寸响应式栅格
        /// </summary>
        protected virtual string GetLg() {
            return _config.GetValue( UiConst.Lg );
        }

        /// <summary>
        /// 获取Lg宽尺寸跨度
        /// </summary>
        protected virtual int? GetLgSpan() {
            return _config.GetValue<int?>( UiConst.LgSpan );
        }

        /// <summary>
        /// 获取Lg宽尺寸偏移量
        /// </summary>
        protected virtual int? GetLgOffset() {
            return _config.GetValue<int?>( UiConst.LgOffset );
        }

        /// <summary>
        /// 获取Lg宽尺寸顺序
        /// </summary>
        protected virtual int? GetLgOrder() {
            return _config.GetValue<int?>( UiConst.LgOrder );
        }

        /// <summary>
        /// 获取Lg宽尺寸左移
        /// </summary>
        protected virtual int? GetLgPull() {
            return _config.GetValue<int?>( UiConst.LgPull );
        }

        /// <summary>
        /// 获取Lg宽尺寸右移
        /// </summary>
        protected virtual int? GetLgPush() {
            return _config.GetValue<int?>( UiConst.LgPush );
        }

        /// <summary>
        /// 配置Xl超宽尺寸响应式栅格
        /// </summary>
        public TBuilder ConfigXl() {
            AttributeIfNotEmpty( "[nzXl]", GetXl() );
            var model = new GridModel {
                Span = GetXlSpan(),
                Offset = GetXlOffset(),
                Order = GetXlOrder(),
                Pull = GetXlPull(),
                Push = GetXlPush()
            };
            AttributeIfNotEmpty( "[nzXl]", model.ToJson() );
            return (TBuilder)this;
        }

        /// <summary>
        /// 获取Xl超宽尺寸响应式栅格
        /// </summary>
        protected virtual string GetXl() {
            return _config.GetValue( UiConst.Xl );
        }

        /// <summary>
        /// 获取Xl超宽尺寸跨度
        /// </summary>
        protected virtual int? GetXlSpan() {
            return _config.GetValue<int?>( UiConst.XlSpan );
        }

        /// <summary>
        /// 获取Xl超宽尺寸偏移量
        /// </summary>
        protected virtual int? GetXlOffset() {
            return _config.GetValue<int?>( UiConst.XlOffset );
        }

        /// <summary>
        /// 获取Xl超宽尺寸顺序
        /// </summary>
        protected virtual int? GetXlOrder() {
            return _config.GetValue<int?>( UiConst.XlOrder );
        }

        /// <summary>
        /// 获取Xl超宽尺寸左移
        /// </summary>
        protected virtual int? GetXlPull() {
            return _config.GetValue<int?>( UiConst.XlPull );
        }

        /// <summary>
        /// 获取Xl超宽尺寸右移
        /// </summary>
        protected virtual int? GetXlPush() {
            return _config.GetValue<int?>( UiConst.XlPush );
        }

        /// <summary>
        /// 配置Xxl极宽尺寸响应式栅格
        /// </summary>
        public TBuilder ConfigXxl() {
            AttributeIfNotEmpty( "[nzXXl]", GetXxl() );
            var model = new GridModel {
                Span = GetXxlSpan(),
                Offset = GetXxlOffset(),
                Order = GetXxlOrder(),
                Pull = GetXxlPull(),
                Push = GetXxlPush()
            };
            AttributeIfNotEmpty( "[nzXXl]", model.ToJson() );
            return (TBuilder)this;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸响应式栅格
        /// </summary>
        protected virtual string GetXxl() {
            return _config.GetValue( UiConst.Xxl );
        }

        /// <summary>
        /// 获取Xxl极宽尺寸跨度
        /// </summary>
        protected virtual int? GetXxlSpan() {
            return _config.GetValue<int?>( UiConst.XxlSpan );
        }

        /// <summary>
        /// 获取Xxl极宽尺寸偏移量
        /// </summary>
        protected virtual int? GetXxlOffset() {
            return _config.GetValue<int?>( UiConst.XxlOffset );
        }

        /// <summary>
        /// 获取Xxl极宽尺寸顺序
        /// </summary>
        protected virtual int? GetXxlOrder() {
            return _config.GetValue<int?>( UiConst.XxlOrder );
        }

        /// <summary>
        /// 获取Xxl极宽尺寸左移
        /// </summary>
        protected virtual int? GetXxlPull() {
            return _config.GetValue<int?>( UiConst.XxlPull );
        }

        /// <summary>
        /// 获取Xxl极宽尺寸右移
        /// </summary>
        protected virtual int? GetXxlPush() {
            return _config.GetValue<int?>( UiConst.XxlPush );
        }

        /// <summary>
        /// 配置栅格列
        /// </summary>
        protected TBuilder ConfigColumn() {
            return Span().Offset().Pull().Push().Order().Flex()
                .ConfigXs().ConfigSm().ConfigMd().ConfigLg().ConfigXl().ConfigXxl();
        }
    }
}