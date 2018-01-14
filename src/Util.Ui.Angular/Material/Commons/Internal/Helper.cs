using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using Util.Helpers;
using Util.Ui.Attributes;
using Util.Ui.Components;
using Util.Ui.Extensions;

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
        public static void InitModelControl<TModel, TProperty>( IFormControl control, Expression<Func<TModel, TProperty>> expression, MemberInfo member ) {
            control.Name( Util.Helpers.String.FirstLowerCase( Lambda.GetName( expression ) ) );
            control.Placeholder( Reflection.GetDisplayNameOrDescription( member ) );
            InitModel( control,expression );
            InitRequired( control, expression );
        }

        /// <summary>
        /// 初始化模型
        /// </summary>
        private static void InitModel<TModel, TProperty>( IFormControl control, Expression<Func<TModel, TProperty>> expression ) {
            var model = GetModel( expression );
            if( string.IsNullOrWhiteSpace( model ) )
                return;
            control.Model( model );
        }

        /// <summary>
        /// 初始化必填项验证
        /// </summary>
        private static void InitRequired<TModel, TProperty>( IFormControl control, Expression<Func<TModel, TProperty>> expression ) {
            var attribute = Lambda.GetAttribute<RequiredAttribute>( expression );
            if ( attribute == null )
                return;
            control.Required( attribute.ErrorMessage );
        }

        /// <summary>
        /// 获取模型绑定
        /// </summary>
        /// <typeparam name="TModel">模型类型</typeparam>
        /// <typeparam name="TProperty">属性类型</typeparam>
        public static string GetModel<TModel, TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            var modelName = Util.Helpers.String.FirstLowerCase( GetModelName<TModel>() );
            var propertyName = Util.Helpers.String.FirstLowerCase( GetPropertyName( expression ) );
            if ( string.IsNullOrWhiteSpace( modelName ) || string.IsNullOrWhiteSpace( propertyName ) )
                return string.Empty;
            return $"{modelName}&&{modelName}.{propertyName}";
        }

        /// <summary>
        /// 获取模型名称
        /// </summary>
        private static string GetModelName<TModel>() {
            Type type = Common.GetType<TModel>();
            if ( type.GetCustomAttribute<ModelAttribute>() is ModelAttribute attribute ) {
                return attribute.Ignore ? string.Empty : attribute.Model;
            }
            return typeof( TModel ).Name;
        }

        /// <summary>
        /// 获取属性名称
        /// </summary>
        private static string GetPropertyName<TModel, TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            var attribute = Lambda.GetAttribute<ModelAttribute>( expression );
            return attribute == null ? Lambda.GetName( expression ) : attribute.Ignore ? string.Empty : attribute.Model; ;
        }
    }
}
