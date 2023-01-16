using System;

namespace Util.Tests.Configs {
    /// <summary>
    /// 测试配置
    /// </summary>
    public class TestConfig {
        /// <summary>
        /// 测试标识
        /// </summary>
        public static Guid Id { get; } = "08255312-DF8E-4F0C-AD4D-638B3A63D889".ToGuid();
        /// <summary>
        /// 测试值
        /// </summary>
        public static string Value { get; } = "abc";
        /// <summary>
        /// 测试整型值
        /// </summary>
        public static int IntValue { get; } = 123;
        /// <summary>
        /// 测试长整型值
        /// </summary>
        public static long LongValue { get; } = 123456789;
        /// <summary>
        /// 测试Guid值
        /// </summary>
        public static Guid GuidValue { get; } = "04255312-DF8E-4F0C-AD4D-638B3A63D868".ToGuid();
        /// <summary>
        /// 测试布尔值
        /// </summary>
        public static bool BoolValue { get; } = true;
        /// <summary>
        /// 测试float值
        /// </summary>
        public static float FloatValue { get; } = 123.45F;
        /// <summary>
        /// 测试double值
        /// </summary>
        public static double DoubleValue { get; } = 12345.67;
        /// <summary>
        /// 测试decimal值
        /// </summary>
        public static decimal DecimalValue { get; } = 12345.67M;
        /// <summary>
        /// 测试日期值
        /// </summary>
        public static DateTime? DateTimeValue { get; } = "2012-12-12 12:12:12".ToDateTime();
    }
}
