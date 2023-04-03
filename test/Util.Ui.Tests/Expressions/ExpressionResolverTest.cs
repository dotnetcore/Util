using System;
using Util.Domain.Biz.Enums;
using Util.Ui.Expressions;
using Util.Ui.Tests.Samples;
using Xunit;

namespace Util.Ui.Tests.Expressions {
    /// <summary>
    /// 表达式解析器测试
    /// </summary>
    public class ExpressionResolverTest {
        /// <summary>
        /// 表达式解析器
        /// </summary>
        private readonly ExpressionResolver _resolver;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ExpressionResolverTest() {
            _resolver = new ExpressionResolver();
        }

        /// <summary>
        /// 测试解析模型类型
        /// </summary>
        [Fact]
        public void TestResolve_ModelType() {
            var expression = ModelExpressionHelper.Create<Customer,string>( "Code",t => t.Code );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "System.String", result.ModelType?.FullName );
        }

        /// <summary>
        /// 测试解析原始属性名
        /// </summary>
        [Fact]
        public void TestResolve_OriginalPropertyName() {
            var expression = ModelExpressionHelper.Create<Customer>( "a" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "a", result.OriginalPropertyName );
        }

        /// <summary>
        /// 测试解析属性名
        /// </summary>
        [Fact]
        public void TestResolve_PropertyName_1() {
            var expression = ModelExpressionHelper.Create<Customer>( "a" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "a", result.PropertyName );
        }

        /// <summary>
        /// 测试解析属性名 - 修正为首字母小写
        /// </summary>
        [Fact]
        public void TestResolve_PropertyName_2() {
            var expression = ModelExpressionHelper.Create<Customer>( "CustomerName" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "customerName", result.PropertyName );
        }

        /// <summary>
        /// 测试解析属性名 - 2级对象
        /// </summary>
        [Fact]
        public void TestResolve_PropertyName_3() {
            var expression = ModelExpressionHelper.Create<Customer>( "Customer.UserName" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "customer.userName", result.PropertyName );
        }

        /// <summary>
        /// 测试解析属性名 - 3级对象
        /// </summary>
        [Fact]
        public void TestResolve_PropertyName_4() {
            var expression = ModelExpressionHelper.Create<Customer>( "Employee.Department.UserName" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "employee.department.userName", result.PropertyName );
        }

        /// <summary>
        /// 测试解析属性名 - 修正缩写大小写
        /// </summary>
        [Fact]
        public void TestResolve_PropertyName_5() {
            var expression = ModelExpressionHelper.Create<Customer>( "UIName" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "uiName", result.PropertyName );
        }

        /// <summary>
        /// 测试解析最后一级属性名
        /// </summary>
        [Fact]
        public void TestResolve_LastPropertyName_1() {
            var expression = ModelExpressionHelper.Create<Customer,string>( "Code",t => t.Code );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "code", result.LastPropertyName );
        }

        /// <summary>
        /// 测试解析最后一级属性名 - 2级对象
        /// </summary>
        [Fact]
        public void TestResolve_LastPropertyName_2() {
            var expression = ModelExpressionHelper.Create<Customer, string>( "Employee.Name", t => t.Employee.Name );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "name", result.LastPropertyName );
        }

        /// <summary>
        /// 测试解析安全属性名
        /// </summary>
        [Fact]
        public void TestResolve_GetSafePropertyName_1() {
            var expression = ModelExpressionHelper.Create<Customer>( "CustomerName" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "model.customerName", result.GetSafePropertyName() );
        }

        /// <summary>
        /// 测试解析安全属性名 - 2级对象
        /// </summary>
        [Fact]
        public void TestResolve_GetSafePropertyName_2() {
            var expression = ModelExpressionHelper.Create<Customer>( "Customer.UserName" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "a.customer&&a.customer.userName", result.GetSafePropertyName("a") );
        }

        /// <summary>
        /// 测试解析安全属性名 - 3级对象
        /// </summary>
        [Fact]
        public void TestResolve_GetSafePropertyName_3() {
            var expression = ModelExpressionHelper.Create<Customer>( "Employee.Department.UserName" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "model.employee&&model.employee.department&&model.employee.department.userName", result.GetSafePropertyName() );
        }

        /// <summary>
        /// 测试解析安全属性名 - 4级对象
        /// </summary>
        [Fact]
        public void TestResolve_GetSafePropertyName_4() {
            var expression = ModelExpressionHelper.Create<Customer>( "Employee.Department.Customer.UserName" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "model.employee&&model.employee.department&&model.employee.department.customer&&model.employee.department.customer.userName", result.GetSafePropertyName() );
        }

        /// <summary>
        /// 测试解析安全属性名 - 转换名称大小写
        /// </summary>
        [Fact]
        public void TestResolve_GetSafePropertyName_5() {
            var expression = ModelExpressionHelper.Create<Customer>( "UIName" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "model.uiName", result.GetSafePropertyName() );
        }

        /// <summary>
        /// 测试安全属性名
        /// </summary>
        [Fact]
        public void TestResolve_SafePropertyName_1() {
            var expression = ModelExpressionHelper.Create<Customer>( "CustomerName" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "model.customerName", result.SafePropertyName );
        }

        /// <summary>
        /// 测试安全属性名- 2级对象
        /// </summary>
        [Fact]
        public void TestResolve_SafePropertyName_2() {
            var expression = ModelExpressionHelper.Create<Customer>( "Customer.UserName" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "model.customer&&model.customer.userName", result.SafePropertyName );
        }

        /// <summary>
        /// 测试安全属性名- 设置模型名称
        /// </summary>
        [Fact]
        public void TestResolve_SafePropertyName_3() {
            var expression = ModelExpressionHelper.Create<Employee>( "Customer.UserName" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "employee.customer&&employee.customer.userName", result.SafePropertyName );
        }

        /// <summary>
        /// 测试解析模型名称 - 未设置ModelAttribute
        /// </summary>
        [Fact]
        public void TestResolve_ModelName_1() {
            var expression = ModelExpressionHelper.Create<Customer>( "a" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "model", result.ModelName );
        }

        /// <summary>
        /// 测试解析模型名称 - 设置ModelAttribute
        /// </summary>
        [Fact]
        public void TestResolve_ModelName_2() {
            var expression = ModelExpressionHelper.Create<Employee>( "a" );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "employee", result.ModelName );
        }

        /// <summary>
        /// 测试解析显示名称
        /// </summary>
        [Fact]
        public void TestResolve_DisplayName_1() {
            var expression = ModelExpressionHelper.Create<Customer,string>( "a",t => t.Code );
            var result = _resolver.Resolve( expression );
            Assert.Equal( "编码", result.DisplayName );
        }

        /// <summary>
        /// 测试解析是否密码类型
        /// </summary>
        [Fact]
        public void TestResolve_IsPassword() {
	        var expression = ModelExpressionHelper.Create<Customer, string>( "a", t => t.Password );
	        var result = _resolver.Resolve( expression );
	        Assert.True( result.IsPassword );
        }

		/// <summary>
		/// 测试解析是否布尔类型
		/// </summary>
		[Fact]
        public void TestResolve_IsBool() {
            var expression = ModelExpressionHelper.Create<Customer, bool>( "a", t => t.Enabled );
            var result = _resolver.Resolve( expression );
            Assert.True( result.IsBool );
        }

        /// <summary>
        /// 测试解析是否枚举类型
        /// </summary>
        [Fact]
        public void TestResolve_IsEnum() {
            var expression = ModelExpressionHelper.Create<Customer, Gender?>( "a", t => t.Gender );
            var result = _resolver.Resolve( expression );
            Assert.True( result.IsEnum );
        }

        /// <summary>
        /// 测试解析是否日期类型
        /// </summary>
        [Fact]
        public void TestResolve_IsDate() {
            var expression = ModelExpressionHelper.Create<Customer, DateTime?>( "a", t => t.Birthday );
            var result = _resolver.Resolve( expression );
            Assert.True( result.IsDate );
        }

        /// <summary>
        /// 测试解析是否整型
        /// </summary>
        [Fact]
        public void TestResolve_IsInt() {
            var expression = ModelExpressionHelper.Create<Customer, int>( "a", t => t.Tel );
            var result = _resolver.Resolve( expression );
            Assert.True( result.IsInt );
        }

        /// <summary>
        /// 测试解析是否数值类型
        /// </summary>
        [Fact]
        public void TestResolve_IsNumber() {
            var expression = ModelExpressionHelper.Create<Customer, double>( "a", t => t.Age );
            var result = _resolver.Resolve( expression );
            Assert.True( result.IsNumber );
        }

        /// <summary>
        /// 测试解析是否必填项
        /// </summary>
        [Fact]
        public void TestResolve_IsRequired_1() {
            var expression = ModelExpressionHelper.Create<Customer, string>( "a", t => t.Code );
            var result = _resolver.Resolve( expression );
            Assert.True( result.IsRequired );
            Assert.Equal( "编码不能是空值", result.RequiredMessage );
        }

        /// <summary>
        /// 测试解析是否必填项
        /// </summary>
        [Fact]
        public void TestResolve_IsRequired_2() {
            var expression = ModelExpressionHelper.Create<Customer, string>( "a", t => t.Name );
            var result = _resolver.Resolve( expression );
            Assert.False( result.IsRequired );
            Assert.Null( result.RequiredMessage );
        }

        /// <summary>
        /// 测试解析StringLengthAttribute特性
        /// </summary>
        [Fact]
        public void TestResolve_StringLength() {
            var expression = ModelExpressionHelper.Create<Customer, string>( "a", t => t.Code );
            var result = _resolver.Resolve( expression );
            Assert.Equal( 50,result.MaxLength );
            Assert.Equal( 5, result.MinLength );
            Assert.Equal( "编码不能超过50位,也不能小于5位", result.MaxLengthMessage );
            Assert.Equal( "编码不能超过50位,也不能小于5位", result.MinLengthMessage );
        }

        /// <summary>
        /// 测试解析MaxLengthAttribute特性
        /// </summary>
        [Fact]
        public void TestResolve_MaxLength() {
            var expression = ModelExpressionHelper.Create<Customer, string>( "a", t => t.Name );
            var result = _resolver.Resolve( expression );
            Assert.Equal( 200, result.MaxLength );
            Assert.Equal( "姓名不能超过200位", result.MaxLengthMessage );
        }

        /// <summary>
        /// 测试解析MinLengthAttribute特性
        /// </summary>
        [Fact]
        public void TestResolve_MinLength() {
            var expression = ModelExpressionHelper.Create<Customer, string>( "a", t => t.Name );
            var result = _resolver.Resolve( expression );
            Assert.Equal( 2, result.MinLength );
            Assert.Equal( "姓名不能少于2位", result.MinLengthMessage );
        }

        /// <summary>
        /// 测试解析RangeAttribute特性
        /// </summary>
        [Fact]
        public void TestResolve_Range() {
            var expression = ModelExpressionHelper.Create<Customer, double>( "a", t => t.Age );
            var result = _resolver.Resolve( expression );
            Assert.Equal( 1.1, result.Min );
            Assert.Equal( "年龄从1.1到99.99", result.MinMessage );
            Assert.Equal( 99.99, result.Max );
            Assert.Equal( "年龄从1.1到99.99", result.MaxMessage );
        }

        /// <summary>
        /// 测试解析EmailAddressAttribute特性
        /// </summary>
        [Fact]
        public void TestResolve_Email() {
            var expression = ModelExpressionHelper.Create<Customer, string>( "a", t => t.Email );
            var result = _resolver.Resolve( expression );
            Assert.True( result.IsEmail );
            Assert.Equal( "电子邮件无效", result.EmailMessage );
        }

        /// <summary>
        /// 测试解析PhoneAttribute特性
        /// </summary>
        [Fact]
        public void TestResolve_Phone() {
            var expression = ModelExpressionHelper.Create<Customer, string>( "a", t => t.Phone );
            var result = _resolver.Resolve( expression );
            Assert.True( result.IsPhone );
            Assert.Equal( "手机号无效", result.PhoneMessage );
        }

        /// <summary>
        /// 测试解析IdCardAttribute特性
        /// </summary>
        [Fact]
        public void TestResolve_IdCard() {
            var expression = ModelExpressionHelper.Create<Customer, string>( "a", t => t.IdCard );
            var result = _resolver.Resolve( expression );
            Assert.True( result.IsIdCard );
            Assert.Equal( "身份证无效", result.IdCardMessage );
        }

        /// <summary>
        /// 测试解析UrlAttribute特性
        /// </summary>
        [Fact]
        public void TestResolve_Url() {
            var expression = ModelExpressionHelper.Create<Customer, string>( "a", t => t.Url );
            var result = _resolver.Resolve( expression );
            Assert.True( result.IsUrl );
            Assert.Equal( "网址无效", result.UrlMessage );
        }

        /// <summary>
        /// 测试解析RegularExpressionAttribute特性
        /// </summary>
        [Fact]
        public void TestResolve_RegularExpression() {
            var expression = ModelExpressionHelper.Create<Customer, string>( "a", t => t.Regular );
            var result = _resolver.Resolve( expression );
            Assert.True( result.IsRegularExpression );
            Assert.Equal( "a", result.Pattern );
            Assert.Equal( "正则表达式无效", result.RegularExpressionMessage );
        }
    }
}
