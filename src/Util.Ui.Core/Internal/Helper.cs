using System;
using System.Linq.Expressions;
using System.Reflection;
using Util.Helpers;
using Util.Ui.Attributes;

namespace Util.Ui.Internal {
    /// <summary>
    /// 辅助操作
    /// </summary>
    public static class Helper {
        /// <summary>
        /// 获取模型
        /// </summary>
        /// <typeparam name="TModel">模型类型</typeparam>
        /// <typeparam name="TProperty">属性类型</typeparam>
        public static string GetModel<TModel, TProperty>( Expression<Func<TModel, TProperty>> expression ) {
            var modelName = Util.Helpers.String.FirstLowerCase( GetModelName<TModel>() );
            var propertyName = Util.Helpers.String.FirstLowerCase( GetPropertyName( expression ) );
            if ( string.IsNullOrWhiteSpace( modelName ) || string.IsNullOrWhiteSpace( propertyName ) )
                return string.Empty;
            return $"{modelName}.{propertyName}";
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
