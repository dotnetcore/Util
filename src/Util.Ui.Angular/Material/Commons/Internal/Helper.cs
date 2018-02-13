using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Helpers;
using Util.Ui.Attributes;
using Util.Ui.Components;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Operations.Forms;
using Util.Ui.Operations.Forms.Validations;

namespace Util.Ui.Material.Commons.Internal {
    /// <summary>
    /// 辅助操作
    /// </summary>
    internal static class Helper {
        /// <summary>
        /// 初始化模型表单控件
        /// </summary>
        /// <typeparam name="TModel">模型类型</typeparam>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="control">表单控件</param>
        /// <param name="expression">属性表达式</param>
        /// <param name="member">成员</param>
        public static void InitControl<TModel, TProperty>( IFormControl control, Expression<Func<TModel, TProperty>> expression, MemberInfo member ) {
            control.Name( Util.Helpers.String.FirstLowerCase( Lambda.GetName( expression ) ) );
            control.Placeholder( Reflection.GetDisplayNameOrDescription( member ) );
            InitModel( control, expression );
            InitRequired( control, expression );
        }

        /// <summary>
        /// 初始化模型
        /// </summary>
        public static void InitModel<TModel, TProperty>( IModel control, Expression<Func<TModel, TProperty>> expression ) {
            var model = GetModel( expression );
            if( string.IsNullOrWhiteSpace( model ) )
                return;
            control.Model( model );
        }

        /// <summary>
        /// 获取模型绑定
        /// </summary>
        /// <typeparam name="TModel">模型类型</typeparam>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public static string GetModel<TModel, TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            return GetModel( GetModelName<TModel>(), GetPropertyName( expression ) );
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
        private static string GetModelName<TModel>() {
            Type type = Common.GetType<TModel>();
            return GetModelName( type );
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
        private static string GetPropertyName<TModel, TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            var attribute = Lambda.GetAttribute<ModelAttribute>( expression );
            return GetPropertyName( attribute, Lambda.GetName( expression ) );
        }

        /// <summary>
        /// 获取属性名称
        /// </summary>
        private static string GetPropertyName( ModelAttribute attribute,string propertyName ) {
            return attribute == null ? propertyName : attribute.Ignore ? string.Empty : attribute.Model; ;
        }

        /// <summary>
        /// 初始化必填项验证
        /// </summary>
        public static void InitRequired<TModel, TProperty>( IRequired control, Expression<Func<TModel, TProperty>> expression ) {
            var attribute = Lambda.GetAttribute<RequiredAttribute>( expression );
            if( attribute == null )
                return;
            control.Required( attribute.ErrorMessage );
        }

        /// <summary>
        /// 初始化模型配置
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="expression">属性表达式</param>
        /// <param name="member">成员</param>
        public static void InitConfig( IConfig config, ModelExpression expression, MemberInfo member ) {
            config.SetAttribute( UiConst.Name, Util.Helpers.String.FirstLowerCase( expression.Name ) );
            config.SetAttribute( UiConst.Placeholder, Reflection.GetDisplayNameOrDescription( member ) );
            InitModel( config, expression );
            InitRequired( config, expression );
        }

        /// <summary>
        /// 初始化模型
        /// </summary>
        public static void InitModel( IConfig config, ModelExpression expression ) {
            var model = GetModel( expression );
            if( string.IsNullOrWhiteSpace( model ) )
                return;
            config.SetAttribute( UiConst.Model, model );
        }

        /// <summary>
        /// 获取模型绑定
        /// </summary>
        public static string GetModel( ModelExpression expression ) {
            return GetModel( GetModelName( expression ), GetPropertyName( expression ) );
        }

        /// <summary>
        /// 获取模型名称
        /// </summary>
        private static string GetModelName( ModelExpression expression ) {
            Type type = expression.Metadata.ContainerType;
            return GetModelName( type );
        }

        /// <summary>
        /// 获取属性名称
        /// </summary>
        private static string GetPropertyName( ModelExpression expression ) {
            var attribute = expression.Metadata.ModelType.GetCustomAttribute<ModelAttribute>();
            return GetPropertyName( attribute, expression.Name );
        }

        /// <summary>
        /// 初始化必填项验证
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="expression">属性表达式</param>
        public static void InitRequired( IConfig config, ModelExpression expression ) {
            if ( expression.Metadata.IsRequired == false )
                return;
            var attribute = expression.GetValidationAttribute<RequiredAttribute>();
            if( attribute == null )
                return;
            config.SetAttribute( UiConst.Required, true );
            config.SetAttribute( UiConst.RequiredMessage, attribute.ErrorMessage );
        }
    }
}
