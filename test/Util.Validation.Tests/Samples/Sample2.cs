using System.ComponentModel.DataAnnotations;

namespace Util.Validation.Tests.Samples {
    /// <summary>
    /// 验证样例2
    /// </summary>
    public class Sample2 {
        /// <summary>
        /// 验证身份证
        /// </summary>
        [IdCard]
        public string IdCard { get; set; }
    }
}
