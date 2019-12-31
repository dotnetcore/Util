using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Util.Tests.Samples {
    public interface ISample {
    }

    /// <summary>
    /// 测试样例
    /// </summary>
    [Description( "测试样例" )]
    public class Sample : ISample {
        /// <summary>
        /// 初始化测试样例
        /// </summary>
        public Sample() {
            StringList = new List<string>();
            StringArray = StringList.ToArray();
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Display( Name = "测试值" )]
        [Required( ErrorMessage = "测试值不能为空" )]
        [StringLength( 20, ErrorMessage = "测试值长度不能超过20" )]
        [EmailAddress]
        [Url]
        public string TestValue { get; set; }
        /// <summary>
        /// 电子邮件验证
        /// </summary>
        [EmailAddress( ErrorMessage = "电子邮件不正确" )]
        public string Email { get; set; }
        /// <summary>
        /// 网址验证
        /// </summary>
        [Url( ErrorMessage = "网址不正确" )]
        public string Url { get; set; }
        /// <summary>
        /// 最大长度
        /// </summary>
        [MaxLength( 2, ErrorMessage = "最大长度是2" )]
        public string MaxLengthValue { get; set; }
        /// <summary>
        /// 长度验证
        /// </summary>
        [StringLength( 3, MinimumLength = 2, ErrorMessage = "最大长度是3,最小长度是2" )]
        public string StringLengthValue { get; set; }
        /// <summary>
        /// DisplayName
        /// </summary>
        [DisplayName( "DisplayNameValue值" )]
        public string DisplayNameValue { get; set; }
        /// <summary>
        /// Display
        /// </summary>
        [Display( Name = "DisplayValue值" )]
        public string DisplayValue { get; set; }
        /// <summary>
        /// string值
        /// </summary>
        [Display( Name = "字符串值" )]
        [StringLength( 20, ErrorMessage = "长度不能超过20" )]
        [Required( ErrorMessage = "不能为空" )]
        public string StringValue { get; set; }
        /// <summary>
        /// decimal值
        /// </summary>
        public decimal DecimalValue { get; set; }
        /// <summary>
        /// 可空decimal值
        /// </summary>
        public decimal? NullableDecimalValue { get; set; }
        /// <summary>
        /// float值
        /// </summary>
        public float FloatValue { get; set; }
        /// <summary>
        /// 可空float值
        /// </summary>
        public float? NullableFloatValue { get; set; }
        /// <summary>
        /// double值
        /// </summary>
        public double DoubleValue { get; set; }
        /// <summary>
        /// 可空double值
        /// </summary>
        public double? NullableDoubleValue { get; set; }
        /// <summary>
        /// bool值
        /// </summary>
        public bool BoolValue { get; set; }
        /// <summary>
        /// 可空bool值
        /// </summary>
        public bool? NullableBoolValue { get; set; }
        /// <summary>
        /// Enum值
        /// </summary>
        public EnumSample EnumValue { get; set; }
        /// <summary>
        /// 可空Enum值
        /// </summary>
        public EnumSample? NullableEnumValue { get; set; }
        /// <summary>
        /// DateTime值
        /// </summary>
        public DateTime DateValue { get; set; }
        /// <summary>
        /// 可空DateTime值
        /// </summary>
        public DateTime? NullableDateValue { get; set; }
        /// <summary>
        /// int值
        /// </summary>
        [Description( "IntValue" )]
        public int IntValue { get; set; }
        /// <summary>
        /// 可空int值
        /// </summary>
        public int? NullableIntValue { get; set; }
        /// <summary>
        /// short值
        /// </summary>
        public short ShortValue { get; set; }
        /// <summary>
        /// 可空short值
        /// </summary>
        public short? NullableShortValue { get; set; }
        /// <summary>
        /// long值
        /// </summary>
        public long LongValue { get; set; }
        /// <summary>
        /// 可空long值
        /// </summary>
        public long? NullableLongValue { get; set; }
        /// <summary>
        /// 字符串列表
        /// </summary>
        public List<string> StringList { get; set; }
        /// <summary>
        /// 字符串数据
        /// </summary>
        public string[] StringArray { get; set; }
        /// <summary>
        /// Guid值
        /// </summary>
        public Guid GuidValue { get; set; }

        /// <summary>
        /// 测试2
        /// </summary>
        public Sample2 Test2 { get; set; }

        /// <summary>
        /// 测试3
        /// </summary>
        public Sample3Copy Test3 { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public List<Sample3Copy> TestList { get; set; }

        /// <summary>
        /// 静态属性
        /// </summary>
        public static string StaticString => "TestStaticString";

        /// <summary>
        /// 静态对象
        /// </summary>
        public static Sample2 StaticSample => new Sample2 {StringValue = "TestStaticSample" };

        /// <summary>
        /// 创建测试实例1
        /// </summary>
        public static Sample Create1() {
            return new Sample { StringValue = "A" };
        }

        /// <summary>
        /// 创建测试实例2
        /// </summary>
        public static Sample Create2() {
            return new Sample { StringValue = "B" };
        }
    }
}
