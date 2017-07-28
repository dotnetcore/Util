using System;
using System.ComponentModel.DataAnnotations;

namespace Util.Tests.Samples {
    /// <summary>
    /// 聚合根测试样例
    /// </summary>
    public class AggregateRootSample {
        /// <summary>
        /// 初始化聚合根测试样例
        /// </summary>
        public AggregateRootSample() {
        }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required( ErrorMessage = "姓名不能为空" )]
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        [Required( ErrorMessageResourceType = typeof( TestResource ), ErrorMessageResourceName = "EnglishNameIsEmpty" )]
        public string EnglishName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public int Tel { get; set; }
 
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
        /// 创建测试样例
        /// </summary>
        public static AggregateRootSample CreateSample() {
            return new AggregateRootSample() {
                Name = "TestName",
                EnglishName = "TestEnglishName",
                MobilePhone = "13012345678"
            };
        }
    }
}
