using System.Text;
using System;
using System.Security.Cryptography;
using System.Linq;
using RSAExtensions;

namespace Util.Helpers {
    /// <summary>
    /// 加密操作
    /// </summary>
    public static class Encrypt {

        #region Md5加密

        /// <summary>
        /// Md5加密，返回16位结果
        /// </summary>
        /// <param name="value">值</param>
        public static string Md5By16( string value ) {
            return Md5By16( value, Encoding.UTF8 );
        }

        /// <summary>
        /// Md5加密，返回16位结果
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="encoding">字符编码</param>
        public static string Md5By16( string value, Encoding encoding ) {
            return Md5( value, encoding, 4, 8 );
        }

        /// <summary>
        /// Md5加密
        /// </summary>
        private static string Md5( string value, Encoding encoding, int? startIndex, int? length ) {
            if ( string.IsNullOrWhiteSpace( value ) )
                return string.Empty;
            var md5 = MD5.Create();
            string result;
            try {
                var hash = md5.ComputeHash( encoding.GetBytes( value ) );
                result = startIndex == null ? BitConverter.ToString( hash ) : BitConverter.ToString( hash, startIndex.SafeValue(), length.SafeValue() );
            }
            finally {
                md5.Clear();
            }
            return result.Replace( "-", "" );
        }

        /// <summary>
        /// Md5加密，返回32位结果
        /// </summary>
        /// <param name="value">值</param>
        public static string Md5By32( string value ) {
            return Md5By32( value, Encoding.UTF8 );
        }

        /// <summary>
        /// Md5加密，返回32位结果
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="encoding">字符编码</param>
        public static string Md5By32( string value, Encoding encoding ) {
            return Md5( value, encoding, null, null );
        }

        #endregion

        #region DES加密

        /// <summary>
        /// DES密钥,24位字符串
        /// </summary>
        public static string DesKey = "#s^un2ye21fcv%|f0XpR,+vh";

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="value">待加密的值</param>
        public static string DesEncrypt( object value ) {
            return DesEncrypt( value, DesKey );
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥,24位</param>
        /// <param name="encoding">编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="paddingMode">填充模式</param>
        public static string DesEncrypt( object value, string key, Encoding encoding = null, CipherMode cipherMode = CipherMode.ECB, PaddingMode paddingMode = PaddingMode.PKCS7 ) {
            string text = value.SafeString();
            if ( ValidateDes( text, key ) == false )
                return string.Empty;
            using var transform = CreateDesProvider( key, cipherMode, paddingMode ).CreateEncryptor();
            return GetEncryptResult( text, encoding, transform );
        }

        /// <summary>
        /// 验证Des加密参数
        /// </summary>
        private static bool ValidateDes( string text, string key ) {
            if ( text.IsEmpty() || key.IsEmpty() )
                return false;
            return key.Length == 24;
        }

        /// <summary>
        /// 创建Des加密服务提供程序
        /// </summary>
        private static TripleDES CreateDesProvider( string key, CipherMode cipherMode, PaddingMode paddingMode ) {
            var result = TripleDES.Create();
            result.Key = Encoding.ASCII.GetBytes( key );
            result.Mode = cipherMode;
            result.Padding = paddingMode;
            return result;
        }

        /// <summary>
        /// 获取加密结果
        /// </summary>
        private static string GetEncryptResult( string value, Encoding encoding, ICryptoTransform transform ) {
            encoding ??= Encoding.UTF8;
            var bytes = encoding.GetBytes( value );
            var result = transform.TransformFinalBlock( bytes, 0, bytes.Length );
            return System.Convert.ToBase64String( result );
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="value">加密后的值</param>
        public static string DesDecrypt( object value ) {
            return DesDecrypt( value, DesKey );
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="value">加密后的值</param>
        /// <param name="key">密钥,24位</param>
        /// <param name="encoding">编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="paddingMode">填充模式</param>
        public static string DesDecrypt( object value, string key, Encoding encoding = null, CipherMode cipherMode = CipherMode.ECB, PaddingMode paddingMode = PaddingMode.PKCS7 ) {
            string text = value.SafeString();
            if ( !ValidateDes( text, key ) )
                return string.Empty;
            using var transform = CreateDesProvider( key, cipherMode, paddingMode ).CreateDecryptor();
            return GetDecryptResult( text, encoding, transform );
        }

        /// <summary>
        /// 获取解密结果
        /// </summary>
        private static string GetDecryptResult( string value, Encoding encoding, ICryptoTransform transform ) {
            encoding ??= Encoding.UTF8;
            var bytes = System.Convert.FromBase64String( value );
            var result = transform.TransformFinalBlock( bytes, 0, bytes.Length );
            return encoding.GetString( result );
        }

        #endregion

        #region AES加密

        /// <summary>
        /// 128位0向量
        /// </summary>
        private static byte[] _iv;
        /// <summary>
        /// 128位0向量
        /// </summary>
        private static byte[] Iv {
            get {
                if ( _iv == null ) {
                    var size = 16;
                    _iv = new byte[size];
                    for ( int i = 0; i < size; i++ )
                        _iv[i] = 0;
                }
                return _iv;
            }
        }

        /// <summary>
        /// AES密钥
        /// </summary>
        public static string AesKey = "QaP1AF8utIarcBqdhYTZpVGbiNQ9M6IL";

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="value">待加密的值</param>
        public static string AesEncrypt( string value ) {
            return AesEncrypt( value, AesKey );
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <param name="iv">初始化向量</param>
        public static string AesEncrypt( string value, string key, Encoding encoding = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7, byte[] iv = null ) {
            if ( value.IsEmpty() || key.IsEmpty() )
                return string.Empty;
            iv ??= Iv;
            var aes = CreateAes( key, cipherMode, paddingMode, iv );
            using var transform = aes.CreateEncryptor( aes.Key, aes.IV );
            return GetEncryptResult( value, encoding, transform );
        }

        /// <summary>
        /// 创建Aes
        /// </summary>
        private static Aes CreateAes( string key, CipherMode cipherMode, PaddingMode paddingMode, byte[] iv ) {
            var result = Aes.Create();
            result.Key = Encoding.ASCII.GetBytes( key );
            result.Mode = cipherMode;
            result.Padding = paddingMode;
            result.IV = iv;
            return result;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="value">加密后的值</param>
        public static string AesDecrypt( string value ) {
            return AesDecrypt( value, AesKey );
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="value">加密后的值</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码</param>
        /// <param name="cipherMode">加密模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <param name="iv">初始化向量</param>
        public static string AesDecrypt( string value, string key, Encoding encoding = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7, byte[] iv = null ) {
            if ( value.IsEmpty() || key.IsEmpty() )
                return string.Empty;
            iv ??= Iv;
            var aes = CreateAes( key, cipherMode, paddingMode, iv );
            using var transform = aes.CreateDecryptor( aes.Key, aes.IV );
            return GetDecryptResult( value, encoding, transform );
        }

        #endregion

        #region HmacSha256加密

        /// <summary>
        /// HMACSHA256加密
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">字符编码</param>
        public static string HmacSha256( string value, string key, Encoding encoding = null) {
            if ( value.IsEmpty() || key.IsEmpty() )
                return string.Empty;
            encoding ??= Encoding.UTF8;
            var sha256 = new HMACSHA256( Encoding.ASCII.GetBytes( key ) );
            var hash = sha256.ComputeHash( encoding.GetBytes( value ) );
            return string.Join( "", hash.ToList().Select( t => t.ToString( "x2" ) ).ToArray() );
        }

        #endregion

        #region RSA加密

        /// <summary>
        /// RSA签名
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="privateKey">私钥</param>
        /// <param name="encoding">编码</param>
        /// <param name="hashAlgorithm">加密算法,默认值: HashAlgorithmName.SHA1</param>
        /// <param name="rsaKeyType">Rsa密钥类型,默认值: Pkcs1</param>
        public static string RsaSign( string value, string privateKey, Encoding encoding = null, HashAlgorithmName? hashAlgorithm = null, RSAKeyType rsaKeyType = RSAKeyType.Pkcs1 ) {
            if ( value.IsEmpty() || privateKey.IsEmpty() )
                return string.Empty;
            var rsa = RSA.Create();
            ImportPrivateKey( rsa, privateKey, rsaKeyType );
            encoding ??= Encoding.UTF8;
            hashAlgorithm ??= HashAlgorithmName.SHA1;
            var result = rsa.SignData( encoding.GetBytes( value ), hashAlgorithm.Value, RSASignaturePadding.Pkcs1 );
            return System.Convert.ToBase64String( result );
        }

        /// <summary>
        /// 导入私钥
        /// </summary>
        private static void ImportPrivateKey( RSA rsa, string privateKey, RSAKeyType rsaKeyType ) {
            rsa.ImportPrivateKey( rsaKeyType, privateKey );
        }

        /// <summary>
        /// Rsa验签
        /// </summary>
        /// <param name="value">待验签的值</param>
        /// <param name="publicKey">公钥</param>
        /// <param name="sign">签名</param>
        /// <param name="encoding">编码</param>
        /// <param name="hashAlgorithm">加密算法,默认值: HashAlgorithmName.SHA1</param>
        public static bool RsaVerify( string value, string publicKey, string sign, Encoding encoding= null, HashAlgorithmName? hashAlgorithm = null ) {
            if ( value.IsEmpty() || publicKey.IsEmpty() || sign.IsEmpty() )
                return false;
            var rsa = RSA.Create();
            ImportPublicKey( rsa, publicKey );
            encoding ??= Encoding.UTF8;
            var signData = System.Convert.FromBase64String( sign );
            hashAlgorithm ??= HashAlgorithmName.SHA1;
            return rsa.VerifyData( encoding.GetBytes( value ), signData, hashAlgorithm.Value, RSASignaturePadding.Pkcs1 );
        }

        /// <summary>
        /// 导入公钥
        /// </summary>
        private static void ImportPublicKey( RSA rsa, string publicKey ) {
            var key = System.Convert.FromBase64String( publicKey );
            rsa.ImportSubjectPublicKeyInfo( key,out _ );
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="publicKey">公钥</param>
        public static string RsaEncrypt( string value, string publicKey ) {
            if ( value.IsEmpty() || publicKey.IsEmpty() )
                return string.Empty;
            var rsa = RSA.Create();
            ImportPublicKey( rsa, publicKey );
            return rsa.EncryptBigData( value, RSAEncryptionPadding.Pkcs1 );
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="value">加密后的值</param>
        /// <param name="privateKey">私钥</param>
        public static string RsaDecrypt( string value, string privateKey ) {
            if ( value.IsEmpty() || privateKey.IsEmpty() )
                return string.Empty;
            var rsa = RSA.Create();
            ImportPrivateKey( rsa, privateKey, RSAKeyType.Pkcs1 );
            return rsa.DecryptBigData( value, RSAEncryptionPadding.Pkcs1 );
        }

        #endregion
    }
}
