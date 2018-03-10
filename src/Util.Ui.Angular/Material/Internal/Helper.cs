using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Helpers;
using Util.Ui.Attributes;
using Util.Ui.Configs;
using Util.Ui.Material.Forms.Configs;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Internal {
    /// <summary>
    /// 辅助操作
    /// </summary>
    internal static class Helper {
        /// <summary>
        /// 初始化基础配置
        /// </summary>
        /// <typeparam name="TModel">模型类型</typeparam>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="config">配置</param>
        /// <param name="expression">属性表达式</param>
        /// <param name="member">成员</param>
        public static void Init<TModel, TProperty>( IConfig config, Expression<Func<TModel, TProperty>> expression, MemberInfo member ) {
            Type modelType = Common.GetType<TModel>();
            var propertyName = Lambda.GetName( expression );
            Init( config, modelType, member, propertyName );
        }

        /// <summary>
        /// 初始化基础配置
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="expression">属性表达式</param>
        /// <param name="member">成员</param>
        public static void Init( IConfig config, ModelExpression expression, MemberInfo member ) {
            Type modelType = expression.Metadata.ContainerType;
            var propertyName = expression.Name;
            Init( config, modelType, member, propertyName );
        }

        /// <summary>
        /// 初始化基础配置
        /// </summary>
        private static void Init( IConfig config, Type modelType, MemberInfo member, string propertyName ) {
            config.SetAttribute( UiConst.Name, Util.Helpers.String.FirstLowerCase( propertyName ) );
            var displayName = Reflection.GetDisplayNameOrDescription( member );
            config.SetAttribute( UiConst.Placeholder, displayName );
            config.SetAttribute( UiConst.Label, displayName );
            InitModel( config, modelType, member, propertyName );
            InitRequired( config, member );
        }

        /// <summary>
        /// 初始化模型绑定
        /// </summary>
        private static void InitModel( IConfig config, Type modelType, MemberInfo member, string propertyName ) {
            var model = GetModel( GetModelName( modelType ), GetPropertyName( member, propertyName ) );
            if( string.IsNullOrWhiteSpace( model ) )
                return;
            config.SetAttribute( UiConst.Model, model );
        }

        /// <summary>
        /// 获取模型绑定
        /// </summary>
        private static string GetModel( string modelName, string propertyName ) {
            modelName = Util.Helpers.String.FirstLowerCase( modelName );
            propertyName = Util.Helpers.String.FirstLowerCase( propertyName );
            if( string.IsNullOrWhiteSpace( modelName ) || string.IsNullOrWhiteSpace( propertyName ) )
                return string.Empty;
            return $"{modelName}&&{modelName}.{propertyName}";
        }

        /// <summary>
        /// 获取模型名称
        /// </summary>
        private static string GetModelName( Type modelType ) {
            if( modelType.GetCustomAttribute<ModelAttribute>() is ModelAttribute attribute )
                return attribute.Ignore ? string.Empty : attribute.Model;
            return modelType.Name;
        }

        /// <summary>
        /// 获取属性名称
        /// </summary>
        private static string GetPropertyName( MemberInfo member, string propertyName ) {
            var attribute = member.GetCustomAttribute<ModelAttribute>();
            return attribute == null ? propertyName : attribute.Ignore ? string.Empty : attribute.Model; ;
        }

        /// <summary>
        /// 初始化必填项验证
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="member">成员</param>
        private static void InitRequired( IConfig config, MemberInfo member ) {
            var attribute = member.GetCustomAttribute<RequiredAttribute>();
            if( attribute == null )
                return;
            config.SetAttribute( UiConst.Required, true );
            config.SetAttribute( UiConst.RequiredMessage, attribute.ErrorMessage );
        }

        /// <summary>
        /// 初始化数据类型
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="member">成员</param>
        public static void InitDataType( TextBoxConfig config, MemberInfo member ) {
            if( Reflection.IsDate( member ) ) {
                config.IsDatePicker = true;
                return;
            }
            if( Reflection.IsNumber( member ) ) {
                config.Number();
                return;
            }
            InitDataType( config, member.GetCustomAttribute<DataTypeAttribute>() );
        }

        /// <summary>
        /// 初始化数据类型
        /// </summary>
        private static void InitDataType( TextBoxConfig config, DataTypeAttribute attribute ) {
            if( attribute == null )
                return;
            switch ( attribute.DataType ) {
                case DataType.Date:
                case DataType.DateTime:
                case DataType.Time:
                    config.IsDatePicker = true;
                    break;
                case DataType.MultilineText:
                    config.IsTextArea = true;
                    break;
                case DataType.EmailAddress:
                    config.Email();
                    break;
                case DataType.Password:
                    config.Password();
                    break;
            }
        }

        /// <summary>
        /// 初始化验证
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="member">成员</param>
        public static void InitValidation( TextBoxConfig config, MemberInfo member ) {
            InitLength( config, member );
            InitEmail( config, member );
        }

        /// <summary>
        /// 初始化字符串长度验证
        /// </summary>
        private static void InitLength( TextBoxConfig config, MemberInfo member ) {
            InitStringLength( config, member );
            InitMinLength( config, member );
            InitMaxLength( config, member );
        }

        /// <summary>
        /// 初始化字符串长度验证
        /// </summary>
        private static void InitStringLength( TextBoxConfig config, MemberInfo member ) {
            var attribute = member.GetCustomAttribute<StringLengthAttribute>();
            if( attribute == null )
                return;
            if( attribute.MinimumLength > 0 )
                config.SetAttribute( UiConst.MinLength, attribute.MinimumLength );
            if( attribute.MaximumLength > 0 )
                config.SetAttribute( UiConst.MaxLength, attribute.MaximumLength );
        }

        /// <summary>
        /// 初始化字符串最小长度验证
        /// </summary>
        private static void InitMinLength( TextBoxConfig config, MemberInfo member ) {
            var attribute = member.GetCustomAttribute<MinLengthAttribute>();
            if( attribute == null )
                return;
            config.SetAttribute( UiConst.MinLength, attribute.Length );
            config.SetAttribute( UiConst.MinLengthMessage, attribute.ErrorMessage );
        }

        /// <summary>
        /// 初始化字符串最大长度验证
        /// </summary>
        private static void InitMaxLength( TextBoxConfig config, MemberInfo member ) {
            var attribute = member.GetCustomAttribute<MaxLengthAttribute>();
            if( attribute == null )
                return;
            config.SetAttribute( UiConst.MaxLength, attribute.Length );
        }

        /// <summary>
        /// 初始化电子邮件验证
        /// </summary>
        private static void InitEmail( TextBoxConfig config, MemberInfo member ) {
            var attribute = member.GetCustomAttribute<EmailAddressAttribute>();
            if( attribute == null )
                return;
            config.Email();
            if( attribute.ErrorMessage.Contains( "field is not a valid e-mail address" ) )
                return;
            config.SetAttribute( UiConst.EmailMessage, attribute.ErrorMessage );
        }

        /// <summary>
        /// 设置合并列
        /// </summary>
        public static void SetColspan( IConfig config, Context context ) {
            var colspan = context.GetValueFromItems<int?>( UiConst.Colspan );
            var beforeColspan = context.GetValueFromItems<int?>( UiConst.BeforeColspan );
            var afterColspan = context.GetValueFromItems<int?>( UiConst.AfterColspan );
            if( colspan != null )
                config.SetAttribute( UiConst.Colspan,colspan,false );
            if( beforeColspan != null )
                config.SetAttribute( UiConst.BeforeColspan, beforeColspan, false );
            if( afterColspan != null )
                config.SetAttribute( UiConst.AfterColspan, afterColspan, false );
        }
    }
}
