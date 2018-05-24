namespace Util.Signatures {
    /// <summary>
    /// 签名密钥
    /// </summary>
    public interface ISignKey {
        /// <summary>
        /// 获取私钥
        /// </summary>
        string GetKey();
        /// <summary>
        /// 获取公钥
        /// </summary>
        string GetPublicKey();
    }
}
