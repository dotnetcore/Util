using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Results.Builders {
    /// <summary>
    /// 结果标签生成器
    /// </summary>
    public class ResultBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化结果标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ResultBuilder( Config config ) : base( config,"nz-result" ) {
            _config = config;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public ResultBuilder Title() {
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 配置副标题
        /// </summary>
        public ResultBuilder SubTitle() {
            AttributeIfNotEmpty( "nzSubTitle", _config.GetValue( UiConst.Subtitle ) );
            AttributeIfNotEmpty( "[nzSubTitle]", _config.GetValue( AngularConst.BindSubtitle ) );
            return this;
        }

        /// <summary>
        /// 配置状态
        /// </summary>
        public ResultBuilder Status() {
            AttributeIfNotEmpty( "nzStatus", _config.GetValue<ResultStatus?>( UiConst.Status )?.Description() );
            AttributeIfNotEmpty( "[nzStatus]", _config.GetValue( AngularConst.BindStatus ) );
            return this;
        }

        /// <summary>
        /// 配置图标
        /// </summary>
        public ResultBuilder Icon() {
            AttributeIfNotEmpty( "nzIcon", _config.GetValue<AntDesignIcon?>( UiConst.Icon )?.Description() );
            AttributeIfNotEmpty( "[nzIcon]", _config.GetValue( AngularConst.BindIcon ) );
            return this;
        }

        /// <summary>
        /// 配置操作区
        /// </summary>
        public ResultBuilder Extra() {
            AttributeIfNotEmpty( "[nzExtra]", _config.GetValue( UiConst.Extra ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Title().SubTitle().Status().Icon().Extra();
        }
    }
}