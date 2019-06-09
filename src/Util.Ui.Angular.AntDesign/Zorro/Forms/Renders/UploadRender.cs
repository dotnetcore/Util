using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Helpers;
using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Forms.Builders;

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
            ResolveExpression();
            var builder = CreateBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 解析属性表达式
        /// </summary>
        private void ResolveExpression() {
            if( _config.Contains( UiConst.For ) == false )
                return;
            var expression = _config.GetValue<ModelExpression>( UiConst.For );
            ExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 创建上传包装器生成器
        /// </summary>
        protected virtual TagBuilder CreateBuilder() {
            return new UploadWrapperBuilder();
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigServer( builder );
            ConfigList( builder );
            ConfigDisabled( builder );
            ConfigMultiple( builder );
            ConfigButton( builder );
            ConfigAccept( builder );
            ConfigLimit( builder );
            ConfigFilter( builder );
            ConfigRequired( builder );
            ConfigOperations( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置服务端参数
        /// </summary>
        private void ConfigServer( TagBuilder builder ) {
            builder.NgModel( _config );
            builder.AddAttribute( "name", _config.GetValue( UiConst.Name ) );
            builder.AddAttribute( "url", _config.GetValue( UiConst.Url ) );
            builder.AddAttribute( "[url]", _config.GetValue( AngularConst.BindUrl ) );
            builder.AddAttribute( "[data]", _config.GetValue( UiConst.Data ) );
            builder.AddAttribute( "[headers]", _config.GetValue( UiConst.Headers ) );
            builder.AddAttribute( "[withCredentials]", _config.GetBoolValue( UiConst.WithCredentials ) );
        }

        /// <summary>
        /// 配置列表
        /// </summary>
        private void ConfigList( TagBuilder builder ) {
            builder.AddAttribute( "[showUploadList]", _config.GetValue( UiConst.ShowUploadList ) );
            ConfigListType( builder );
        }

        /// <summary>
        /// 配置列表类型
        /// </summary>
        private void ConfigListType( TagBuilder builder ) {
            var listType = _config.GetValue<UploadListType?>( UiConst.ListType );
            builder.AddAttribute( "listType", listType?.Description() );
            if( listType == UploadListType.Picture || listType == UploadListType.PictureCard )
                _config.SetAttribute( UiConst.AcceptImage,true );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetValue( UiConst.Disabled ) );
        }

        /// <summary>
        /// 配置多选
        /// </summary>
        private void ConfigMultiple( TagBuilder builder ) {
            builder.AddAttribute( "[multiple]", _config.GetBoolValue( UiConst.Multiple ) );
            builder.AddAttribute( "[directory]", _config.GetBoolValue( UiConst.Directory ) );
        }

        /// <summary>
        /// 配置按钮文本
        /// </summary>
        private void ConfigButton( TagBuilder builder ) {
            builder.AddAttribute( "buttonText", _config.GetValue( UiConst.ButtonText ) );
            builder.AddAttribute( "buttonIcon", _config.GetValue<AntDesignIcon?>( UiConst.ButtonIcon )?.Description() );
            builder.AddAttribute( "[showButton]", _config.GetValue( UiConst.ShowButton ) );
        }

        /// <summary>
        /// 配置接受的文件类型
        /// </summary>
        private void ConfigAccept( TagBuilder builder ) {
            if( _config.Contains( UiConst.Accept ) ) {
                builder.AddAttribute( "accept",_config.GetValue( UiConst.Accept ) );
                return;
            }
            builder.AddAttribute("accept", GetAccepts() );
        }

        /// <summary>
        /// 获取接受的文件类型列表
        /// </summary>
        private string GetAccepts() {
            var result = new List<string>();
            result.AddRange( GetImageAccepts() );
            result.AddRange( GetDocumentAccepts() );
            return result.Join();
        }

        /// <summary>
        /// 获取图片类型接受列表
        /// </summary>
        private List<string> GetImageAccepts() {
            if( _config.Contains( UiConst.ImageTypes ) ) {
                var types = _config.GetValue<List<ImageType>>( UiConst.ImageTypes );
                if( types != null )
                    return types.Select( t => t.Description() ).ToList();
            }
            if( _config.GetValue<bool?>( UiConst.AcceptImage ) == true )
                return GetAccepts<ImageType>();
            return new List<string>();
        }

        /// <summary>
        /// 获取枚举接受列表
        /// </summary>
        private List<string> GetAccepts<TEnum>() {
            var items = Enum.GetItems<TEnum>();
            return items.Select( t => t.Text ).ToList();
        }

        /// <summary>
        /// 获取文档类型接受列表
        /// </summary>
        private List<string> GetDocumentAccepts() {
            if( _config.Contains( UiConst.DocumentTypes ) ) {
                var types = _config.GetValue<List<DocumentType>>( UiConst.DocumentTypes );
                if( types != null )
                    return types.Select( t => t.Description() ).ToList();
            }
            if( _config.GetValue<bool?>( UiConst.AcceptDocument ) == true )
                return GetAccepts<DocumentType>();
            return new List<string>();
        }

        /// <summary>
        /// 配置文件限制
        /// </summary>
        private void ConfigLimit( TagBuilder builder ) {
            builder.AddAttribute( "[size]", _config.GetValue( UiConst.Size ) );
            builder.AddAttribute( "[limit]", _config.GetValue( UiConst.Limit ) );
            builder.AddAttribute( "[totalLimit]", _config.GetValue( UiConst.TotalLimit ) );
        }

        /// <summary>
        /// 配置过滤器
        /// </summary>
        private void ConfigFilter( TagBuilder builder ) {
            builder.AddAttribute( "[customFilters]", _config.GetValue( UiConst.Filter ) );
        }

        /// <summary>
        /// 配置必填项
        /// </summary>
        private void ConfigRequired( TagBuilder builder ) {
            builder.AddAttribute( "[required]", _config.GetBoolValue( UiConst.Required ) );
            builder.AddAttribute( "requiredMessage", _config.GetValue( UiConst.RequiredMessage ) );
        }

        /// <summary>
        /// 配置上传操作
        /// </summary>
        private void ConfigOperations( TagBuilder builder ) {
            builder.AddAttribute( "[beforeUpload]", _config.GetValue( UiConst.BeforeUpload ) );
            builder.AddAttribute( "[preview]", _config.GetValue( UiConst.Preview ) );
            builder.AddAttribute( "[remove]", _config.GetValue( UiConst.Remove ) );
            builder.AddAttribute( "[customRequest]", _config.GetValue( UiConst.CustomRequest ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(modelChange)", _config.GetValue( UiConst.OnChange ) );
        }
    }
}
