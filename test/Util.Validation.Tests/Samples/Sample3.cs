using System.ComponentModel.DataAnnotations;

namespace Util.Validation.Tests.Samples {
    /// <summary>
    /// 验证样例3
    /// </summary>
    public class Sample3 {
        /// <summary>
        /// 验证身份证
        /// </summary>
        [IdCard( ErrorMessage = "IdCard" )]
        public string IdCard { get; set; }
    }
}
