using System;
using System.Text.Json.Serialization;

namespace Util.Tests.Samples {
    public class A {
        public string Name { get; set; }
        public B B { get; set; }
    }

    public class B {
        public string Name { get; set; }
        public C C { get; set; }
    }

    public class C {
        public string Name { get; set; }
        public A A { get; set; }
    }

    /// <summary>
    /// Json测试样例
    /// </summary>
    public class JsonTestSample {
        /// <summary>
        /// 名称,测试公共属性，且首字母大写
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 私有属性，应被忽略
        /// </summary>
        private string A { get; set; }
        /// <summary>
        /// 昵称，用来测试小写
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 用于测试JsonPropertyName特性
        /// </summary>
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        /// <summary>
        /// 测试null
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// Utc日期
        /// </summary>
        public DateTime? UtcDate { get; set; }
        /// <summary>
        /// 测试整型，不添加引号
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 测试布尔型
        /// </summary>
        public bool IsShow { get; set; }

        /// <summary>
        /// 创建客户
        /// </summary>
        public static JsonTestSample Create() {
            return new JsonTestSample() {
                Name = "a",
                A = "1",
                nickname = "b",
                FirstName = "c",
                Value = null,
                Date =  new DateTime( 2012,12,12,20,12,12, DateTimeKind.Local ),
                UtcDate = new DateTime( 2012, 12, 12, 12, 12, 12,DateTimeKind.Utc ),
                Age = 1,
                IsShow = true
            };
        }
    }
}
