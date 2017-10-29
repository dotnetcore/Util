using System.ComponentModel.DataAnnotations.Schema;

namespace Util.Biz.Addresses {
    /// <summary>
    /// 空地址
    /// </summary>
    [NotMapped]
    public class NullAddress : Address{
    }
}
