using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Util.Data;

namespace Util.Helpers {
    /// <summary>
    /// Lambda表达式操作
    /// </summary>
    public static class Lambda {

        #region GetType(获取类型)

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="expression">表达式,范例：t => t.Name</param>
        public static Type GetType( Expression expression ) {
            var memberExpression = GetMemberExpression( expression );
            return memberExpression?.Type;
        }

        #endregion

        #region GetMember(获取成员)

        /// <summary>
        /// 获取成员
        /// </summary>
        /// <param name="expression">表达式,范例：t => t.Name</param>
        public static MemberInfo GetMember( Expression expression ) {
            var memberExpression = GetMemberExpression( expression );
            return memberExpression?.Member;
        }

        /// <summary>
        /// 获取成员表达式
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="right">取表达式右侧,(l,r) => l.id == r.id，设置为true,返回r.id表达式</param>
        public static MemberExpression GetMemberExpression( Expression expression, bool right = false ) {
            if( expression == null )
                return null;
            switch( expression.NodeType ) {
                case ExpressionType.Lambda:
                    return GetMemberExpression( ( (LambdaExpression)expression ).Body, right );
                case ExpressionType.Convert:
                case ExpressionType.Not:
                    return GetMemberExpression( ( (UnaryExpression)expression ).Operand, right );
                case ExpressionType.MemberAccess:
                    return (MemberExpression)expression;
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThanOrEqual:
                    return GetMemberExpression( right ? ( (BinaryExpression)expression ).Right : ( (BinaryExpression)expression ).Left, right );
                case ExpressionType.Call:
                    return GetMethodCallExpressionName( expression );
            }
            return null;
        }

        /// <summary>
        /// 获取方法调用表达式的成员名称
        /// </summary>
        private static MemberExpression GetMethodCallExpressionName( Expression expression ) {
            var methodCallExpression = (MethodCallExpression)expression;
            var left = (MemberExpression)methodCallExpression.Object;
            if( Reflection.IsGenericCollection( left?.Type ) ) {
                var argumentExpression = methodCallExpression.Arguments.FirstOrDefault();
                if( argumentExpression != null && argumentExpression.NodeType == ExpressionType.MemberAccess )
                    return (MemberExpression)argumentExpression;
            }
            return left;
        }

        #endregion

        #region GetName(获取成员名称)

        /// <summary>
        /// 获取成员名称，范例：t => t.A.Name,返回 A.Name
        /// </summary>
        /// <param name="expression">表达式,范例：t => t.Name</param>
        public static string GetName( Expression expression ) {
            var memberExpression = GetMemberExpression( expression );
            return GetMemberName( memberExpression );
        }

        /// <summary>
        /// 获取成员名称
        /// </summary>
        public static string GetMemberName( MemberExpression memberExpression ) {
            if( memberExpression == null )
                return string.Empty;
            string result = memberExpression.ToString();
            return result.Substring( result.IndexOf( ".", StringComparison.Ordinal ) + 1 );
        }

        #endregion

        #region GetNames(获取名称列表)

        /// <summary>
        /// 获取名称列表，范例：t => new object[] { t.A.B, t.C },返回A.B,C
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="expression">属性集合表达式,范例：t => new object[]{t.A,t.B}</param>
        public static List<string> GetNames<T>( Expression<Func<T, object[]>> expression ) {
            var result = new List<string>();
            if( expression == null )
                return result;
            if( !( expression.Body is NewArrayExpression arrayExpression ) )
                return result;
            foreach( var each in arrayExpression.Expressions ) {
                var name = GetName( each );
                if( string.IsNullOrWhiteSpace( name ) == false )
                    result.Add( name );
            }
            return result;
        }

        #endregion

        #region GetLastName(获取最后一级成员名称)

        /// <summary>
        /// 获取最后一级成员名称，范例：t => t.A.Name,返回 Name
        /// </summary>
        /// <param name="expression">表达式,范例：t => t.Name</param>
        /// <param name="right">取表达式右侧,(l,r) => l.LId == r.RId，设置为true,返回RId</param>
        public static string GetLastName( Expression expression, bool right = false ) {
            var memberExpression = GetMemberExpression( expression, right );
            if( memberExpression == null )
                return string.Empty;
            if( IsValueExpression( memberExpression ) )
                return string.Empty;
            string result = memberExpression.ToString();
            return result.Substring( result.LastIndexOf( ".", StringComparison.Ordinal ) + 1 );
        }

        /// <summary>
        /// 是否值表达式
        /// </summary>
        /// <param name="expression">表达式</param>
        private static bool IsValueExpression( Expression expression ) {
            if( expression == null )
                return false;
            switch( expression.NodeType ) {
                case ExpressionType.MemberAccess:
                    return IsValueExpression( ( (MemberExpression)expression ).Expression );
                case ExpressionType.Constant:
                    return true;
            }
            return false;
        }

        #endregion

        #region GetLastNames(获取最后一级成员名称列表)

        /// <summary>
        /// 获取最后一级成员名称列表，范例：t => new object[] { t.A.B, t.C },返回B,C
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="expression">属性集合表达式,范例：t => new object[]{t.A,t.B}</param>
        public static List<string> GetLastNames<T>( Expression<Func<T, object[]>> expression ) {
            var result = new List<string>();
            if( expression == null )
                return result;
            if( !( expression.Body is NewArrayExpression arrayExpression ) )
                return result;
            foreach( var each in arrayExpression.Expressions ) {
                var name = GetLastName( each );
                if( string.IsNullOrWhiteSpace( name ) == false )
                    result.Add( name );
            }
            return result;
        }

        #endregion

        #region GetValue(获取值)

        /// <summary>
        /// 获取值,范例：t => t.Name == "A",返回 A
        /// </summary>
        /// <param name="expression">表达式,范例：t => t.Name == "A"</param>
        public static object GetValue( Expression expression ) {
            if( expression == null )
                return null;
            switch( expression.NodeType ) {
                case ExpressionType.Lambda:
                    return GetValue( ( (LambdaExpression)expression ).Body );
                case ExpressionType.Convert:
                    return GetValue( ( (UnaryExpression)expression ).Operand );
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThanOrEqual:
                    var hasParameter = HasParameter( ( (BinaryExpression)expression ).Left );
                    if( hasParameter )
                        return GetValue( ( (BinaryExpression)expression ).Right );
                    return GetValue( ( (BinaryExpression)expression ).Left );
                case ExpressionType.Call:
                    return GetMethodCallExpressionValue( expression );
                case ExpressionType.MemberAccess:
                    return GetMemberValue( (MemberExpression)expression );
                case ExpressionType.Constant:
                    return GetConstantExpressionValue( expression );
                case ExpressionType.Not:
                    if( expression.Type == typeof( bool ) )
                        return false;
                    return null;
            }
            return null;
        }

        /// <summary>
        /// 是否包含参数，用于检测是属性，而不是值
        /// </summary>
        private static bool HasParameter( Expression expression ) {
            if( expression == null )
                return false;
            switch( expression.NodeType ) {
                case ExpressionType.Convert:
                    return HasParameter( ( (UnaryExpression)expression ).Operand );
                case ExpressionType.MemberAccess:
                    return HasParameter( ( (MemberExpression)expression ).Expression );
                case ExpressionType.Parameter:
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获取方法调用表达式的值
        /// </summary>
        private static object GetMethodCallExpressionValue( Expression expression ) {
            var methodCallExpression = (MethodCallExpression)expression;
            var value = GetValue( methodCallExpression.Arguments.FirstOrDefault() );
            if( value != null )
                return value;
            if( methodCallExpression.Arguments.Count > 1 )
                return GetValue( methodCallExpression.Arguments[1] );
            if ( methodCallExpression.Object == null )
                return methodCallExpression.Type.InvokeMember( methodCallExpression.Method.Name, BindingFlags.InvokeMethod, null, null, null );
            return GetValue( methodCallExpression.Object );
        }

        /// <summary>
        /// 获取属性表达式的值
        /// </summary>
        private static object GetMemberValue( MemberExpression expression ) {
            if( expression == null )
                return null;
            var field = expression.Member as FieldInfo;
            if( field != null ) {
                var constValue = GetConstantExpressionValue( expression.Expression );
                return field.GetValue( constValue );
            }
            var property = expression.Member as PropertyInfo;
            if( property == null )
                return null;
            if( expression.Expression == null )
                return property.GetValue( null );
            var value = GetMemberValue( expression.Expression as MemberExpression );
            if( value == null ) {
                if( property.PropertyType == typeof( bool ) )
                    return true;
                return null;
            }
            return property.GetValue( value );
        }

        /// <summary>
        /// 获取常量表达式的值
        /// </summary>
        private static object GetConstantExpressionValue( Expression expression ) {
            var constantExpression = (ConstantExpression)expression;
            return constantExpression.Value;
        }

        #endregion

        #region GetOperator(获取查询操作符)

        /// <summary>
        /// 获取查询操作符,范例：t => t.Name == "A",返回 Operator.Equal
        /// </summary>
        /// <param name="expression">表达式,范例：t => t.Name == "A"</param>
        public static Operator? GetOperator( Expression expression ) {
            if( expression == null )
                return null;
            switch( expression.NodeType ) {
                case ExpressionType.Lambda:
                    return GetOperator( ( (LambdaExpression)expression ).Body );
                case ExpressionType.Convert:
                    return GetOperator( ( (UnaryExpression)expression ).Operand );
                case ExpressionType.Equal:
                    return Operator.Equal;
                case ExpressionType.NotEqual:
                    return Operator.NotEqual;
                case ExpressionType.GreaterThan:
                    return Operator.Greater;
                case ExpressionType.LessThan:
                    return Operator.Less;
                case ExpressionType.GreaterThanOrEqual:
                    return Operator.GreaterEqual;
                case ExpressionType.LessThanOrEqual:
                    return Operator.LessEqual;
                case ExpressionType.Call:
                    return GetMethodCallExpressionOperator( expression );
            }
            return null;
        }

        /// <summary>
        /// 获取方法调用表达式的值
        /// </summary>
        private static Operator? GetMethodCallExpressionOperator( Expression expression ) {
            var methodCallExpression = (MethodCallExpression)expression;
            switch( methodCallExpression?.Method?.Name?.ToLower() ) {
                case "contains":
                    return Operator.Contains;
                case "endswith":
                    return Operator.Ends;
                case "startswith":
                    return Operator.Starts;
            }
            return null;
        }

        #endregion

        #region GetParameter(获取参数)

        /// <summary>
        /// 获取参数，范例：t.Name,返回 t
        /// </summary>
        /// <param name="expression">表达式，范例：t.Name</param>
        public static ParameterExpression GetParameter( Expression expression ) {
            if( expression == null )
                return null;
            switch( expression.NodeType ) {
                case ExpressionType.Lambda:
                    return GetParameter( ( (LambdaExpression)expression ).Body );
                case ExpressionType.Convert:
                    return GetParameter( ( (UnaryExpression)expression ).Operand );
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThanOrEqual:
                    return GetParameter( ( (BinaryExpression)expression ).Left );
                case ExpressionType.MemberAccess:
                    return GetParameter( ( (MemberExpression)expression ).Expression );
                case ExpressionType.Call:
                    return GetParameter( ( (MethodCallExpression)expression ).Object );
                case ExpressionType.Parameter:
                    return (ParameterExpression)expression;
            }
            return null;
        }

        #endregion

        #region GetGroupPredicates(获取分组的谓词表达式)

        /// <summary>
        /// 获取分组的谓词表达式，通过Or进行分组
        /// </summary>
        /// <param name="expression">谓词表达式</param>
        public static List<List<Expression>> GetGroupPredicates( Expression expression ) {
            var result = new List<List<Expression>>();
            if( expression == null )
                return result;
            AddPredicates( expression, result, CreateGroup( result ) );
            return result;
        }

        /// <summary>
        /// 创建分组
        /// </summary>
        private static List<Expression> CreateGroup( List<List<Expression>> result ) {
            var gourp = new List<Expression>();
            result.Add( gourp );
            return gourp;
        }

        /// <summary>
        /// 添加通过Or分割的谓词表达式
        /// </summary>
        private static void AddPredicates( Expression expression, List<List<Expression>> result, List<Expression> group ) {
            switch( expression.NodeType ) {
                case ExpressionType.Lambda:
                    AddPredicates( ( (LambdaExpression)expression ).Body, result, group );
                    break;
                case ExpressionType.OrElse:
                    AddPredicates( ( (BinaryExpression)expression ).Left, result, group );
                    AddPredicates( ( (BinaryExpression)expression ).Right, result, CreateGroup( result ) );
                    break;
                case ExpressionType.AndAlso:
                    AddPredicates( ( (BinaryExpression)expression ).Left, result, group );
                    AddPredicates( ( (BinaryExpression)expression ).Right, result, group );
                    break;
                default:
                    group.Add( expression );
                    break;
            }
        }

        #endregion

        #region GetConditionCount(获取查询条件个数)

        /// <summary>
        /// 获取查询条件个数
        /// </summary>
        /// <param name="expression">谓词表达式,范例1：t => t.Name == "A" ，结果1。
        /// 范例2：t => t.Name == "A" &amp;&amp; t.Age =1 ，结果2。</param>
        public static int GetConditionCount( LambdaExpression expression ) {
            if( expression == null )
                return 0;
            var result = expression.ToString().Replace( "AndAlso", "|" ).Replace( "OrElse", "|" );
            return result.Split( '|' ).Count();
        }

        #endregion

        #region GetAttribute(获取特性)

        /// <summary>
        /// 获取特性
        /// </summary>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public static TAttribute GetAttribute<TAttribute>( Expression expression ) where TAttribute : Attribute {
            var memberInfo = GetMember( expression );
            return memberInfo.GetCustomAttribute<TAttribute>();
        }

        /// <summary>
        /// 获取特性
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="propertyExpression">属性表达式</param>
        public static TAttribute GetAttribute<TEntity, TProperty, TAttribute>( Expression<Func<TEntity, TProperty>> propertyExpression ) where TAttribute : Attribute {
            return GetAttribute<TAttribute>( propertyExpression );
        }

        /// <summary>
        /// 获取特性
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="propertyExpression">属性表达式</param>
        public static TAttribute GetAttribute<TProperty, TAttribute>( Expression<Func<TProperty>> propertyExpression ) where TAttribute : Attribute {
            return GetAttribute<TAttribute>( propertyExpression );
        }

        #endregion

        #region GetAttributes(获取特性列表)

        /// <summary>
        /// 获取特性列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="propertyExpression">属性表达式</param>
        public static IEnumerable<TAttribute> GetAttributes<TEntity, TProperty, TAttribute>( Expression<Func<TEntity, TProperty>> propertyExpression ) where TAttribute : Attribute {
            var memberInfo = GetMember( propertyExpression );
            return memberInfo.GetCustomAttributes<TAttribute>();
        }

        #endregion

        #region Constant(获取常量)

        /// <summary>
        /// 获取常量表达式
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="expression">表达式</param>
        public static ConstantExpression Constant( object value, Expression expression = null ) {
            var type = GetType( expression );
            if( type == null )
                return Expression.Constant( value );
            return Expression.Constant( value, type );
        }

        #endregion

        #region CreateParameter(创建参数表达式)

        /// <summary>
        /// 创建参数表达式
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        public static ParameterExpression CreateParameter<T>() {
            return Expression.Parameter( typeof( T ), "t" );
        }

        #endregion

        #region Equal(等于表达式)

        /// <summary>
        /// 创建等于运算lambda表达式
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">值</param>
        public static Expression<Func<T, bool>> Equal<T>( string propertyName, object value ) {
            var parameter = CreateParameter<T>();
            return parameter.Property( propertyName ).Equal( value ).ToPredicate<T>( parameter );
        }

        #endregion

        #region NotEqual(不等于表达式)

        /// <summary>
        /// 创建不等于运算lambda表达式
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">值</param>
        public static Expression<Func<T, bool>> NotEqual<T>( string propertyName, object value ) {
            var parameter = CreateParameter<T>();
            return parameter.Property( propertyName ).NotEqual( value ).ToPredicate<T>( parameter );
        }

        #endregion

        #region Greater(大于表达式)

        /// <summary>
        /// 创建大于运算lambda表达式
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">值</param>
        public static Expression<Func<T, bool>> Greater<T>( string propertyName, object value ) {
            var parameter = CreateParameter<T>();
            return parameter.Property( propertyName ).Greater( value ).ToPredicate<T>( parameter );
        }

        #endregion

        #region GreaterEqual(大于等于表达式)

        /// <summary>
        /// 创建大于等于运算lambda表达式
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">值</param>
        public static Expression<Func<T, bool>> GreaterEqual<T>( string propertyName, object value ) {
            var parameter = CreateParameter<T>();
            return parameter.Property( propertyName ).GreaterEqual( value ).ToPredicate<T>( parameter );
        }

        #endregion

        #region Less(小于表达式)

        /// <summary>
        /// 创建小于运算lambda表达式
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">值</param>
        public static Expression<Func<T, bool>> Less<T>( string propertyName, object value ) {
            var parameter = CreateParameter<T>();
            return parameter.Property( propertyName ).Less( value ).ToPredicate<T>( parameter );
        }

        #endregion

        #region LessEqual(小于等于表达式)

        /// <summary>
        /// 创建小于等于运算lambda表达式
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">值</param>
        public static Expression<Func<T, bool>> LessEqual<T>( string propertyName, object value ) {
            var parameter = CreateParameter<T>();
            return parameter.Property( propertyName ).LessEqual( value ).ToPredicate<T>( parameter );
        }

        #endregion

        #region Starts(调用StartsWith方法)

        /// <summary>
        /// 调用StartsWith方法
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">值</param>
        public static Expression<Func<T, bool>> Starts<T>( string propertyName, object value ) {
            var parameter = CreateParameter<T>();
            return parameter.Property( propertyName ).StartsWith( value ).ToPredicate<T>( parameter );
        }

        #endregion

        #region Ends(调用EndsWith方法)

        /// <summary>
        /// 调用EndsWith方法
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">值</param>
        public static Expression<Func<T, bool>> Ends<T>( string propertyName, object value ) {
            var parameter = CreateParameter<T>();
            return parameter.Property( propertyName ).EndsWith( value ).ToPredicate<T>( parameter );
        }

        #endregion

        #region Contains(调用Contains方法)

        /// <summary>
        /// 调用Contains方法
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">值</param>
        public static Expression<Func<T, bool>> Contains<T>( string propertyName, object value ) {
            var parameter = CreateParameter<T>();
            return parameter.Property( propertyName ).Contains( value ).ToPredicate<T>( parameter );
        }

        #endregion

        #region ParsePredicate(解析为谓词表达式)

        /// <summary>
        /// 解析为谓词表达式
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public static Expression<Func<T, bool>> ParsePredicate<T>( string propertyName, object value, Operator @operator ) {
            var parameter = CreateParameter<T>();
            return parameter.Property( propertyName ).Operation( @operator, value ).ToPredicate<T>( parameter );
        }

        #endregion
    }
}
