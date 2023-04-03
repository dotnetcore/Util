using System;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Util.Ui.Expressions {
    /// <summary>
    /// 模型表达式辅助操作
    /// </summary>
    public static class ModelExpressionHelper {
        /// <summary>
        /// 创建模型表达式
        /// </summary>
        /// <typeparam name="TModel">模型类型</typeparam>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="name">属性名</param>
        /// <param name="expression">属性表达式</param>
        public static ModelExpression Create<TModel,TProperty>( string name, Expression<Func<TModel, TProperty>> expression ) {
            var property = Util.Helpers.Lambda.GetMember( expression ) as PropertyInfo;
            property.CheckNull( nameof(property) );
            var provider = CreateModelMetadataProvider();
            var metadata = provider.GetMetadataForProperty( property, typeof( TProperty ) );
            var modelExplorer = new ModelExplorer( provider, metadata, null );
            return new ModelExpression( name, modelExplorer );
        }

        /// <summary>
        /// 创建模型表达式
        /// </summary>
        /// <typeparam name="TModel">模型类型</typeparam>
        /// <param name="name">属性名</param>
        public static ModelExpression Create<TModel>( string name ) {
            return Create( name, typeof( TModel ), typeof( TModel ) );
        }

        /// <summary>
        /// 获取模型元数据提供程序
        /// </summary>
        private static ModelMetadataProvider CreateModelMetadataProvider() {
            return new EmptyModelMetadataProvider();
        }

        /// <summary>
        /// 创建模型表达式
        /// </summary>
        /// <typeparam name="TModel">模型类型</typeparam>
        /// <typeparam name="TContainer">容器模型类型</typeparam>
        /// <param name="name">属性名</param>
        public static ModelExpression Create<TModel, TContainer>( string name ) {
            return Create( name, typeof( TModel ), typeof( TContainer ) );
        }

        /// <summary>
        /// 创建模型表达式
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="modelType">模型类型</param>
        /// <param name="containerType">容器模型类型</param>
        private static ModelExpression Create( string name, Type modelType, Type containerType ) {
            var provider = CreateModelMetadataProvider();
            var containerModelExplorer = provider.GetModelExplorerForType( containerType, null );
            var metadata = provider.GetMetadataForType( modelType );
            var modelExplorer = new ModelExplorer( provider, containerModelExplorer, metadata, null );
            return new ModelExpression( name, modelExplorer );
        }

        /// <summary>
        /// 按System.Text.Json转换命名
        /// </summary>
        /// <param name="name">属性名</param>
        public static string ConvertName( string name ) {
            if ( string.IsNullOrEmpty( name ) || !char.IsUpper( name[0] ) ) {
                return name;
            }
            return string.Create( name.Length, name, ( chars, name2 ) => {
                name2.AsSpan().CopyTo( chars );
                FixCasing( chars );
            } );
        }

        /// <summary>
        /// 修复小写
        /// </summary>
        private static void FixCasing( Span<char> chars ) {
            for ( int i = 0; i < chars.Length; i++ ) {
                if ( i == 1 && !char.IsUpper( chars[i] ) )
                    break;
                bool hasNext = ( i + 1 < chars.Length );
                if ( i > 0 && hasNext && !char.IsUpper( chars[i + 1] ) ) {
                    if ( chars[i + 1] == ' ' ) {
                        chars[i] = char.ToLowerInvariant( chars[i] );
                    }
                    break;
                }
                chars[i] = char.ToLowerInvariant( chars[i] );
            }
        }
    }
}
