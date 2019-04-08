using System.Collections.Generic;
using System.Linq;
using Util.Helpers;
using Util.Properties;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Helpers;
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
            ConfigDirectory( builder );
            ConfigButton( builder );
            ConfigAccept( builder );
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
            builder.AddAttribute( "[nzData]", _config.GetValue( UiConst.Data ) );
        }

        /// <summary>
        /// 配置多选
        /// </summary>
        private void ConfigMultiple( TagBuilder builder ) {
            builder.AddAttribute( "[nzMultiple]", _config.GetBoolValue( UiConst.Multiple ) );
        }

        /// <summary>
        /// 配置上传文件夹
        /// </summary>
        private void ConfigDirectory( TagBuilder builder ) {
            builder.AddAttribute( "[nzDirectory]", _config.GetBoolValue( UiConst.Directory ) );
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
        /// 配置接受的文件类型
        /// </summary>
        private void ConfigAccept( UploadBuilder builder ) {
            if( _config.Contains( UiConst.Accept ) ) {
                builder.Accept( _config.GetValue( UiConst.Accept ) );
                return;
            }
            builder.Accept( GetAccepts() );
        }

        /// <summary>
        /// 获取接受的文件类型列表
        /// </summary>
        private string GetAccepts() {
            var result = new List<string>();
            result.AddRange( GetImageAccepts() );
            return result.Join();
        }

        /// <summary>
        /// 获取图片类型接受列表
        /// </summary>
        private List<string> GetImageAccepts() {
            if( _config.Contains( UiConst.ImageTypes ) ) {
                var types = _config.GetValue<List<ImageType>>( UiConst.ImageTypes );
                if( types != null )
                    return types.Select( t => t.GetExtensions() ).ToList();
            }
            if( _config.GetValue<bool?>( UiConst.AcceptImage ) == true )
                return GetAccepts<ImageType>();
            return new List<string>();
        }

        /// <summary>
        /// 获取枚举接受列表
        /// </summary>
        private List<string> GetAccepts<TEnum>() {
            var names = Enum.GetNames<TEnum>();
            return names.Select( ImageTypeHelper.GetExtensions ).ToList();
        }

        /// <summary>
        /// 配置文件类型限制
        /// </summary>
        private void ConfigFileType( UploadBuilder builder ) {
            if( _config.Contains( UiConst.FileType ) ) {
                builder.FileType( _config.GetValue( UiConst.FileType ) );
                return;
            }
            builder.FileType( GetFileTypes() );
        }

        /// <summary>
        /// 获取文件类型限制列表
        /// </summary>
        private string GetFileTypes() {
            var result = new List<string>();
            result.AddRange( GetImageFileTypes() );
            return result.Join();
        }

        /// <summary>
        /// 获取图片类型接受列表
        /// </summary>
        private List<string> GetImageFileTypes() {
            if( _config.Contains( UiConst.ImageTypes ) ) {
                var types = _config.GetValue<List<ImageType>>( UiConst.ImageTypes );
                if( types != null )
                    return types.Select( t => t.Description() ).ToList();
            }
            if( _config.GetValue<bool?>( UiConst.AcceptImage ) == true )
                return GetFileTypes<ImageType>();
            return new List<string>();
        }

        /// <summary>
        /// 获取枚举文件类型限制列表
        /// </summary>
        private List<string> GetFileTypes<TEnum>() {
            var items = Enum.GetItems<TEnum>();
            return items.Select( t => t.Text.SafeString() ).ToList();
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
