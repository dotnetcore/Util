using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.Expressions;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Expressions;

namespace Util.Ui.NgZorro.Components.Selects.Helpers {
    /// <summary>
    /// 选择框表达式加载器
    /// </summary>
    public class SelectExpressionLoader : NgZorroExpressionLoaderBase {
        /// <summary>
        /// 加载模型信息
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="info">模型表达式信息</param>
        protected override void Load( Config config, ModelExpressionInfo info ) {
            LoadLabel( config, info );
            LoadName( config, info );
            LoadNgModel( config, info );
            LoadData( config, info );
            LoadRequired( config, info );
        }

        /// <summary>
        /// 加载标签
        /// </summary>
        protected virtual void LoadLabel( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.LabelText, info.DisplayName, false );
        }

        /// <summary>
        /// 加载名称
        /// </summary>
        protected virtual void LoadName( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.Name, info.LastPropertyName, false );
        }

        /// <summary>
        /// 加载模型绑定
        /// </summary>
        protected virtual void LoadNgModel( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( AngularConst.NgModel, info.SafePropertyName, false );
        }

        /// <summary>
        /// 加载数据源
        /// </summary>
        protected virtual void LoadData( Config config, ModelExpressionInfo info ) {
            LoadBool( config, info );
            LoadEnum( config, info );
        }

        /// <summary>
        /// 加载布尔值
        /// </summary>
        protected virtual void LoadBool( Config config, ModelExpressionInfo info ) {
            if ( info.IsBool == false )
                return;
            config.SetAttribute( UiConst.Data, GetBoolData(), false );
        }

        /// <summary>
        /// 获取布尔类型数据
        /// </summary>
        private string GetBoolData() {
            var result = new StringBuilder();
            result.Append( "[{" );
            result.Append( $"'text':'{GetYes()}','value':true,'sortId':1" );
            result.Append( "}," );
            result.Append( "{" );
            result.Append( $"'text':'{GetNo()}','value':false,'sortId':2" );
            result.Append( "}]" );
            return result.ToString();
        }

        /// <summary>
        /// 获取yes文本
        /// </summary>
        private string GetYes() {
            var options = NgZorroOptionsService.GetOptions();
            return options.EnableI18n ? I18nKeys.Yes : "是";
        }

        /// <summary>
        /// 获取no文本
        /// </summary>
        private string GetNo() {
            var options = NgZorroOptionsService.GetOptions();
            return options.EnableI18n ? I18nKeys.No : "否";
        }

        /// <summary>
        /// 加载枚举值
        /// </summary>
        protected virtual void LoadEnum( Config config, ModelExpressionInfo info ) {
            if ( info.IsEnum == false )
                return;
            var items = Util.Helpers.Enum.GetItems( info.ModelType );
            var options = new JsonSerializerOptions {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Encoder = JavaScriptEncoder.Create( UnicodeRanges.All )
            };
            var result = Util.Helpers.Json.ToJson( items, options, toSingleQuotes: true );
            config.SetAttribute( UiConst.Data, result, false );
        }

        /// <summary>
        /// 加载必填项验证
        /// </summary>
        protected virtual void LoadRequired( Config config, ModelExpressionInfo info ) {
            if ( info.IsRequired == false )
                return;
            config.SetAttribute( UiConst.Required, "true", false );
            config.SetAttribute( UiConst.RequiredMessage, info.RequiredMessage, false );
        }
    }
}
