using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Components.Inputs.Configs;
using Util.Ui.Angular.Builders;

namespace Util.Ui.NgZorro.Components.Inputs.Builders {
    /// <summary>
    /// 输入框组合标签生成器
    /// </summary>
    public class InputGroupBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 输入框组合共享配置
        /// </summary>
        private readonly InputGroupShareConfig _shareConfig;

        /// <summary>
        /// 初始化输入框组合标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public InputGroupBuilder( Config config ) : base( config,"nz-input-group" ) {
            _config = config;
            _shareConfig = GetInputGroupShareConfig();
        }

        /// <summary>
        /// 获取输入框组合共享配置
        /// </summary>
        private InputGroupShareConfig GetInputGroupShareConfig() {
            return _config.GetValueFromItems<InputGroupShareConfig>() ?? new InputGroupShareConfig();
        }

        /// <summary>
        /// 配置前置标签
        /// </summary>
        public InputGroupBuilder AddOnBefore() {
            AttributeIfNotEmpty( "nzAddOnBefore", _config.GetValue( UiConst.AddOnBefore ));
            AttributeIfNotEmpty( "[nzAddOnBefore]", _config.GetValue( AngularConst.BindAddOnBefore ) );
            AttributeIfNotEmpty( "nzAddOnBefore", _shareConfig.AddOnBefore );
            AttributeIfNotEmpty( "[nzAddOnBefore]", _shareConfig.BindAddOnBefore );
            return this;
        }

        /// <summary>
        /// 配置后置标签
        /// </summary>
        public InputGroupBuilder AddOnAfter() {
            AttributeIfNotEmpty( "nzAddOnAfter", _config.GetValue( UiConst.AddOnAfter ) );
            AttributeIfNotEmpty( "[nzAddOnAfter]", _config.GetValue( AngularConst.BindAddOnAfter ) );
            AttributeIfNotEmpty( "nzAddOnAfter", _shareConfig.AddOnAfter );
            AttributeIfNotEmpty( "[nzAddOnAfter]", _shareConfig.BindAddOnAfter );
            return this;
        }

        /// <summary>
        /// 配置前置图标
        /// </summary>
        public InputGroupBuilder AddOnBeforeIcon() {
            AttributeIfNotEmpty( "nzAddOnBeforeIcon", _config.GetValue<AntDesignIcon?>( UiConst.AddOnBeforeIcon )?.Description() );
            AttributeIfNotEmpty( "[nzAddOnBeforeIcon]", _config.GetValue( AngularConst.BindAddOnBeforeIcon ) );
            AttributeIfNotEmpty( "nzAddOnBeforeIcon", _shareConfig.AddOnBeforeIcon?.Description() );
            AttributeIfNotEmpty( "[nzAddOnBeforeIcon]", _shareConfig.BindAddOnBeforeIcon );
            return this;
        }

        /// <summary>
        /// 配置后置图标
        /// </summary>
        public InputGroupBuilder AddOnAfterIcon() {
            AttributeIfNotEmpty( "nzAddOnAfterIcon", _config.GetValue<AntDesignIcon?>( UiConst.AddOnAfterIcon )?.Description() );
            AttributeIfNotEmpty( "[nzAddOnAfterIcon]", _config.GetValue( AngularConst.BindAddOnAfterIcon ) );
            AttributeIfNotEmpty( "nzAddOnAfterIcon", _shareConfig.AddOnAfterIcon?.Description() );
            AttributeIfNotEmpty( "[nzAddOnAfterIcon]", _shareConfig.BindAddOnAfterIcon );
            return this;
        }

        /// <summary>
        /// 配置前缀
        /// </summary>
        public InputGroupBuilder Prefix() {
            AttributeIfNotEmpty( "nzPrefix", _config.GetValue( UiConst.Prefix ) );
            AttributeIfNotEmpty( "[nzPrefix]", _config.GetValue( AngularConst.BindPrefix ) );
            AttributeIfNotEmpty( "nzPrefix", _shareConfig.Prefix );
            AttributeIfNotEmpty( "[nzPrefix]", _shareConfig.BindPrefix );
            return this;
        }

        /// <summary>
        /// 配置后缀
        /// </summary>
        public InputGroupBuilder Suffix() {
            AttributeIfNotEmpty( "nzSuffix", _config.GetValue( UiConst.Suffix ) );
            AttributeIfNotEmpty( "[nzSuffix]", _config.GetValue( AngularConst.BindSuffix ) );
            AttributeIfNotEmpty( "nzSuffix", _shareConfig.Suffix );
            AttributeIfNotEmpty( "[nzSuffix]", _shareConfig.BindSuffix );
            return this;
        }

        /// <summary>
        /// 配置前缀图标
        /// </summary>
        public InputGroupBuilder PrefixIcon() {
            AttributeIfNotEmpty( "nzPrefixIcon", _config.GetValue<AntDesignIcon?>( UiConst.PrefixIcon )?.Description() );
            AttributeIfNotEmpty( "[nzPrefixIcon]", _config.GetValue( AngularConst.BindPrefixIcon ) );
            AttributeIfNotEmpty( "nzPrefixIcon", _shareConfig.PrefixIcon?.Description() );
            AttributeIfNotEmpty( "[nzPrefixIcon]", _shareConfig.BindPrefixIcon );
            return this;
        }

        /// <summary>
        /// 配置后缀图标
        /// </summary>
        public InputGroupBuilder SuffixIcon() {
            AttributeIfNotEmpty( "nzSuffixIcon", _config.GetValue<AntDesignIcon?>( UiConst.SuffixIcon )?.Description() );
            AttributeIfNotEmpty( "[nzSuffixIcon]", _config.GetValue( AngularConst.BindSuffixIcon ) );
            AttributeIfNotEmpty( "nzSuffixIcon", _shareConfig.SuffixIcon?.Description() );
            AttributeIfNotEmpty( "[nzSuffixIcon]", _shareConfig.BindSuffixIcon );
            return this;
        }

        /// <summary>
        /// 配置搜索
        /// </summary>
        public InputGroupBuilder Search() {
            AttributeIfNotEmpty( "[nzSearch]", _config.GetBoolValue( UiConst.Search ) );
            AttributeIfNotEmpty( "[nzSearch]", _config.GetValue( AngularConst.BindSearch ) );
            return this;
        }

        /// <summary>
        /// 配置输入框大小
        /// </summary>
        public InputGroupBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<InputSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置紧凑模式
        /// </summary>
        public InputGroupBuilder Compact() {
            AttributeIfNotEmpty( "[nzCompact]", _config.GetBoolValue( UiConst.Compact ) );
            AttributeIfNotEmpty( "[nzCompact]", _config.GetValue( AngularConst.BindCompact ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            AddOnBefore().AddOnAfter().AddOnBeforeIcon().AddOnAfterIcon()
                .Prefix().Suffix().PrefixIcon().SuffixIcon()
                .Search().Size().Compact();
        }
    }
}