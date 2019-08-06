using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms.Builders;
using Util.Ui.Zorro.Grid.Helpers;

namespace Util.Ui.Zorro.Forms.Helpers {
    /// <summary>
    /// 表单操作
    /// </summary>
    public class FormHelper {
        /// <summary>
        /// 是否启用标签
        /// </summary>
        /// <param name="config">配置</param>
        public static bool EnableLabel( Config config ) {
            if( config.GetValue<bool?>( UiConst.ShowLabel ) == true )
                return true;
            if( config.Contains( UiConst.LabelText ) )
                return true;
            if( config.Contains( UiConst.LabelSpan ) )
                return true;
            var shareConfig = GridHelper.GetShareConfig( config );
            if( shareConfig == null )
                return false;
            if( shareConfig.LabelSpan.IsEmpty() == false )
                return true;
            return false;
        }

        /// <summary>
        /// 创建表单项生成器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="controlBuilder">控件生成器</param>
        public static TagBuilder CreateFormItemBuilder( Config config, TagBuilder controlBuilder ) {
            var formControlBuilder = CreateFormControlBuilder( config, controlBuilder );
            if( EnableLabel( config ) == false )
                return formControlBuilder;
            var result = CreateFormItemBuilder( config );
            var labelBuilder = CreateFormLabelBuilder( config );
            result.AppendContent( labelBuilder );
            result.AppendContent( formControlBuilder );
            return result;
        }

        /// <summary>
        /// 创建表单项生成器
        /// </summary>
        /// <param name="config">配置</param>
        public static FormItemBuilder CreateFormItemBuilder( Config config ) {
            var result = new FormItemBuilder();
            result.AddGutter( GridHelper.GetGutter( config ) );
            var isFlex = config.GetValue<bool?>( UiConst.IsFlex );
            if( isFlex == true )
                result.AddAttribute( "[nzFlex]", "true" );
            return result;
        }

        /// <summary>
        /// 创建表单标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public static FormLabelBuilder CreateFormLabelBuilder( Config config ) {
            var result = new FormLabelBuilder();
            result.AppendContent( GetLabel( config ) );
            result.AddRequired( config.GetBoolValue( UiConst.Required ) );
            result.AddSpan( GridHelper.GetLabelSpan( config ) );
            return result;
        }

        /// <summary>
        /// 获取标签
        /// </summary>
        private static string GetLabel( Config config ) {
            var result = config.GetValue( UiConst.LabelText );
            if( result.IsEmpty() )
                result = config.GetValue( UiConst.Label );
            return result;
        }

        /// <summary>
        /// 创建表单控件生成器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="builder">配置</param>
        public static TagBuilder CreateFormControlBuilder( Config config, TagBuilder builder ) {
            if( EnableLabel( config ) == false && GridHelper.EnabelGrid( config ) == false )
                return builder;
            var result = new FormControlBuilder();
            result.AddLayout( config );
            result.AppendContent( builder );
            return result;
        }
    }
}
