using System.Collections.Generic;
using System.Linq;
using Util.Properties;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Buttons.Builders;
using Util.Ui.Zorro.Enums;
using Util.Ui.Zorro.Forms.Builders;
using Util.Ui.Zorro.Icons.Builders;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 文件上传渲染器
    /// </summary>
    public class UploadRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化文件上传渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public UploadRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new UploadBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( UploadBuilder builder ) {
            ConfigId( builder );
            ConfigDataSource( builder );
            ConfigMultiple( builder );
            ConfigButton( builder );
            ConfigFileType( builder );
            ConfigLimit( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        private void ConfigDataSource( TagBuilder builder ) {
            builder.AddAttribute( "nzAction", _config.GetValue( UiConst.Url ) );
            builder.AddAttribute( "[nzAction]", _config.GetValue( AngularConst.BindUrl ) );
        }

        /// <summary>
        /// 配置多选
        /// </summary>
        private void ConfigMultiple( TagBuilder builder ) {
            builder.AddAttribute( "[nzMultiple]", _config.GetBoolValue( UiConst.Multiple ) );
        }

        /// <summary>
        /// 配置按钮
        /// </summary>
        private void ConfigButton( TagBuilder builder ) {
            if ( _config.Content.IsEmpty() == false )
                return;
            var buttonBuilder = new ButtonWrapperBuilder();
            ConfigButtonText( buttonBuilder );
            ConfigButtonIcon( buttonBuilder );
            builder.AppendContent( buttonBuilder );
        }

        /// <summary>
        /// 配置按钮文本
        /// </summary>
        private void ConfigButtonText( ButtonWrapperBuilder buttonBuilder  ) {
            if( _config.Contains( UiConst.ButtonText ) ) {
                buttonBuilder.AddText( _config.GetValue( UiConst.ButtonText ) );
                return;
            }
            buttonBuilder.AddText( R.Upload );
        }

        /// <summary>
        /// 配置按钮图标
        /// </summary>
        private void ConfigButtonIcon( ButtonWrapperBuilder buttonBuilder ) {
            var iconBuilder = new IconBuilder();
            buttonBuilder.AppendContent( iconBuilder );
            if( _config.Contains( UiConst.ButtonIcon ) ) {
                iconBuilder.AddType( _config.GetValue<AntDesignIcon?>( UiConst.ButtonIcon )?.Description() );
                return;
            }
            iconBuilder.AddType( AntDesignIcon.Upload.Description() );
        }

        /// <summary>
        /// 配置文件类型限制
        /// </summary>
        private void ConfigFileType( UploadBuilder builder ) {
            builder.Accept( _config.GetValue( UiConst.Accept ) );
            builder.FileType( _config.GetValue( UiConst.FileType ) );
            ConfigFileTypes( builder );
        }

        /// <summary>
        /// 配置文件类型限制
        /// </summary>
        private void ConfigFileTypes( UploadBuilder builder ) {
            if ( _config.Contains( UiConst.FileTypes ) == false )
                return;
            var types = _config.GetValue<List<FileType>>( UiConst.FileTypes );
            if ( types == null )
                return;
            builder.Accept( types.Select( t => t.GetNames() ).Join() );
            builder.FileType( types.Select( t => t.Description() ).Join() );
        }

        /// <summary>
        /// 配置文件限制
        /// </summary>
        private void ConfigLimit( UploadBuilder builder ) {
            builder.AddAttribute( "nzSize", _config.GetValue( UiConst.Size ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
        }
    }
}
