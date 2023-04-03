using System;
using System.Collections.Generic;
using System.Reflection;

namespace Util.Ui.Expressions {
    /// <summary>
    /// 模型表达式信息
    /// </summary>
    public class ModelExpressionInfo {
        /// <summary>
        /// 模型类型
        /// </summary>
        public Type ModelType { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        public MemberInfo Property { get; set; }
        /// <summary>
        /// 原始属性名
        /// </summary>
        public string OriginalPropertyName { get; set; }
        /// <summary>
        /// 属性名,修正为驼峰形式,范例: 原始属性名为 Customer.Name,则该值为 customer.name
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 安全属性名,范例: 原始属性名为 Customer.Name,则该值为 model.customer&amp;&amp;model.customer.name
        /// </summary>
        public string SafePropertyName => GetSafePropertyName( ModelName );
        /// <summary>
        /// 最后一级属性名,范例: 原始属性名为 Customer.Name,则该值为 name
        /// </summary>
        public string LastPropertyName { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 模型名称,默认值: model
        /// </summary>
        public string ModelName { get; set; } = "model";
        /// <summary>
        /// 是否密码类型
        /// </summary>
        public bool IsPassword { get; set; }
		/// <summary>
		/// 是否布尔类型
		/// </summary>
		public bool IsBool { get; set; }
        /// <summary>
        /// 是否枚举类型
        /// </summary>
        public bool IsEnum { get; set; }
        /// <summary>
        /// 是否日期类型
        /// </summary>
        public bool IsDate { get; set; }
        /// <summary>
        /// 是否整型
        /// </summary>
        public bool IsInt { get; set; }
        /// <summary>
        /// 是否数值类型
        /// </summary>
        public bool IsNumber { get; set; }
        /// <summary>
        /// 是否必填项
        /// </summary>
        public bool IsRequired { get; set; }
        /// <summary>
        /// 必填项验证消息
        /// </summary>
        public string RequiredMessage { get; set; }
        /// <summary>
        /// 最小长度
        /// </summary>
        public int? MinLength { get; set; }
        /// <summary>
        /// 最小长度验证消息
        /// </summary>
        public string MinLengthMessage { get; set; }
        /// <summary>
        /// 最大长度
        /// </summary>
        public int? MaxLength { get; set; }
        /// <summary>
        /// 最大长度验证消息
        /// </summary>
        public string MaxLengthMessage { get; set; }
        /// <summary>
        /// 最小值
        /// </summary>
        public object Min { get; set; }
        /// <summary>
        /// 最小值验证消息
        /// </summary>
        public string MinMessage { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public object Max { get; set; }
        /// <summary>
        /// 最大值验证消息
        /// </summary>
        public string MaxMessage { get; set; }
        /// <summary>
        /// 是否电子邮件
        /// </summary>
        public bool IsEmail { get; set; }
        /// <summary>
        /// 电子邮件验证消息
        /// </summary>
        public string EmailMessage { get; set; }
        /// <summary>
        /// 是否手机号
        /// </summary>
        public bool IsPhone { get; set; }
        /// <summary>
        /// 手机号验证消息
        /// </summary>
        public string PhoneMessage { get; set; }
        /// <summary>
        /// 是否身份证
        /// </summary>
        public bool IsIdCard { get; set; }
        /// <summary>
        /// 身份证验证消息
        /// </summary>
        public string IdCardMessage { get; set; }
        /// <summary>
        /// 是否网址
        /// </summary>
        public bool IsUrl { get; set; }
        /// <summary>
        /// 网址验证消息
        /// </summary>
        public string UrlMessage { get; set; }
        /// <summary>
        /// 是否正则表达式
        /// </summary>
        public bool IsRegularExpression { get; set; }
        /// <summary>
        /// 正则表达式模式
        /// </summary>
        public string Pattern { get; set; }
        /// <summary>
        /// 正则表达式验证消息
        /// </summary>
        public string RegularExpressionMessage { get; set; }

        /// <summary>
        /// 获取安全属性名,范例: 原始属性名为 Customer.Name,则该值为 model.customer&amp;&amp;model.customer.name
        /// </summary>
        /// <param name="model">模型名称</param>
        public string GetSafePropertyName( string model = "model" ) {
            if ( OriginalPropertyName.IsEmpty() )
                return null;
            var result = new List<string>();
            var temp = new List<string> { model };
            var array = OriginalPropertyName.Split( '.' );
            foreach ( var item in array ) {
                temp.Add( ModelExpressionHelper.ConvertName( item ) );
                result.Add( temp.Join( separator: "." ) );
            }
            return result.Join( separator: "&&" );
        }
    }
}
