using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Util.Helpers {
    /// <summary>
    /// 加密操作
    /// 说明：AES和RSA加密整理自支付宝SDK
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
            if( string.IsNullOrWhiteSpace( value ) )
                return string.Empty;
            var md5 = new MD5CryptoServiceProvider();
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
        public static string DesEncrypt( object value, string key ) {
            return DesEncrypt( value, key, Encoding.UTF8 );
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥,24位</param>
        /// <param name="encoding">编码</param>
        public static string DesEncrypt( object value, string key, Encoding encoding ) {
            string text = value.SafeString();
            if( ValidateDes( text, key ) == false )
                return string.Empty;
            using( var transform = CreateDesProvider( key ).CreateEncryptor() ) {
                return GetEncryptResult( text, encoding, transform );
            }
        }

        /// <summary>
        /// 验证Des加密参数
        /// </summary>
        private static bool ValidateDes( string text, string key ) {
            if( string.IsNullOrWhiteSpace( text ) || string.IsNullOrWhiteSpace( key ) )
                return false;
            return key.Length == 24;
        }

        /// <summary>
        /// 创建Des加密服务提供程序
        /// </summary>
        private static TripleDESCryptoServiceProvider CreateDesProvider( string key ) {
            return new TripleDESCryptoServiceProvider { Key = Encoding.ASCII.GetBytes( key ), Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
        }

        /// <summary>
        /// 获取加密结果
        /// </summary>
        private static string GetEncryptResult( string value, Encoding encoding, ICryptoTransform transform ) {
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
        public static string DesDecrypt( object value, string key ) {
            return DesDecrypt( value, key, Encoding.UTF8 );
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="value">加密后的值</param>
        /// <param name="key">密钥,24位</param>
        /// <param name="encoding">编码</param>
        public static string DesDecrypt( object value, string key, Encoding encoding ) {
            string text = value.SafeString();
            if( !ValidateDes( text, key ) )
                return string.Empty;
            using( var transform = CreateDesProvider( key ).CreateDecryptor() ) {
                return GetDecryptResult( text, encoding, transform );
            }
        }

        /// <summary>
        /// 获取解密结果
        /// </summary>
        private static string GetDecryptResult( string value, Encoding encoding, ICryptoTransform transform ) {
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
        public static string AesEncrypt( string value, string key ) {
            return AesEncrypt( value, key, Encoding.UTF8 );
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码</param>
        public static string AesEncrypt( string value, string key, Encoding encoding ) {
            if( string.IsNullOrWhiteSpace( value ) || string.IsNullOrWhiteSpace( key ) )
                return string.Empty;
            var rijndaelManaged = CreateRijndaelManaged( key );
            using ( var transform = rijndaelManaged.CreateEncryptor( rijndaelManaged.Key, rijndaelManaged.IV ) ) {
                return GetEncryptResult( value, encoding, transform );
            }
        }

        /// <summary>
        /// 创建RijndaelManaged
        /// </summary>
        private static RijndaelManaged CreateRijndaelManaged( string key ) {
            return new RijndaelManaged {
                Key = System.Convert.FromBase64String( key ),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                IV = Iv
            };
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
        public static string AesDecrypt( string value, string key ) {
            return AesDecrypt( value, key, Encoding.UTF8 );
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="value">加密后的值</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码</param>
        public static string AesDecrypt( string value, string key, Encoding encoding ) {
            if( string.IsNullOrWhiteSpace( value ) || string.IsNullOrWhiteSpace( key ) )
                return string.Empty;
            var rijndaelManaged = CreateRijndaelManaged( key );
            using( var transform = rijndaelManaged.CreateDecryptor( rijndaelManaged.Key, rijndaelManaged.IV ) ) {
                return GetDecryptResult( value, encoding, transform );
            }
        }

        #endregion

        #region RSA加密

        /// <summary>
        /// RSA加密，采用 SHA1 算法
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥</param>
        public static string Rsa( string value, string key ) {
            return Rsa( value, key, Encoding.UTF8 );
        }

        /// <summary>
        /// RSA加密，采用 SHA1 算法
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码</param>
        public static string Rsa( string value, string key, Encoding encoding ) {
            return Rsa( value, key, encoding, "RSA" );
        }

        /// <summary>
        /// RSA加密，采用 SHA256 算法
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥</param>
        public static string Rsa2( string value, string key ) {
            return Rsa2( value, key, Encoding.UTF8 );
        }

        /// <summary>
        /// RSA加密，采用 SHA256 算法
        /// </summary>
        /// <param name="value">待加密的值</param>
        /// <param name="key">密钥</param>
        /// <param name="encoding">编码</param>
        public static string Rsa2( string value, string key, Encoding encoding ) {
            return Rsa( value, key, encoding, "RSA2" );
        }

        /// <summary>
        /// Rsa加密
        /// </summary>
        private static string Rsa( string value, string key, Encoding encoding, string type ) {
            if( string.IsNullOrWhiteSpace( value ) || string.IsNullOrWhiteSpace( key ) )
                return string.Empty;
            var provider = CreateRsaProvider( key, type );
            var bytes = encoding.GetBytes( value );
            var result = provider.SignData( bytes, GetRsaAlgorithm( type ) );
            return System.Convert.ToBase64String( result );
        }

        /// <summary>
        /// 获取Rsa算法
        /// </summary>
        private static string GetRsaAlgorithm( string type ) {
            return type == "RSA2" ? "SHA256" : "SHA1";
        }

        /// <summary>
        /// 创建RSA提供程序
        /// </summary>
        private static RSACryptoServiceProvider CreateRsaProvider( string key, string type ) {
            using ( var stream = new MemoryStream( System.Convert.FromBase64String( key ) ) ) {
                using ( var reader = new BinaryReader( stream ) ) {
                    byte bt;
                    ushort twobytes;
                    int elems;
                    twobytes = reader.ReadUInt16();
                    if( twobytes == 0x8130 )
                        reader.ReadByte();
                    else if( twobytes == 0x8230 )
                        reader.ReadInt16();
                    else
                        return null;

                    twobytes = reader.ReadUInt16();
                    if( twobytes != 0x0102 )
                        return null;
                    bt = reader.ReadByte();
                    if( bt != 0x00 )
                        return null;

                    elems = GetSize( reader );
                    var modulus = reader.ReadBytes( elems );

                    elems = GetSize( reader );
                    var e = reader.ReadBytes( elems );

                    elems = GetSize( reader );
                    var d = reader.ReadBytes( elems );

                    elems = GetSize( reader );
                    var p = reader.ReadBytes( elems );

                    elems = GetSize( reader );
                    var q = reader.ReadBytes( elems );

                    elems = GetSize( reader );
                    var dp = reader.ReadBytes( elems );

                    elems = GetSize( reader );
                    var dq = reader.ReadBytes( elems );

                    elems = GetSize( reader );
                    var iq = reader.ReadBytes( elems );

                    var cspParameters = new CspParameters();
                    cspParameters.Flags = CspProviderFlags.UseMachineKeyStore;

                    int bitLen = 1024;
                    if( type == "RSA2" ) {
                        bitLen = 2048;
                    }

                    var rsa = new RSACryptoServiceProvider( bitLen, cspParameters );
                    var parameters = new RSAParameters {
                        Modulus = modulus,
                        Exponent = e,
                        D = d,
                        P = p,
                        Q = q,
                        DP = dp,
                        DQ = dq,
                        InverseQ = iq
                    };
                    rsa.ImportParameters( parameters );
                    return rsa;
                }
            }
        }

        /// <summary>
        /// 获取流长度
        /// </summary>
        private static int GetSize( BinaryReader reader ) {
            byte bt;
            int count;
            bt = reader.ReadByte();
            if( bt != 0x02 )
                return 0;
            bt = reader.ReadByte();

            if( bt == 0x81 )
                count = reader.ReadByte();
            else
            if( bt == 0x82 ) {
                var highByte = reader.ReadByte();
                var lowByte = reader.ReadByte();
                byte[] modint = { lowByte, highByte, 0x00, 0x00 };
                count = BitConverter.ToInt32( modint, 0 );
            }
            else {
                count = bt;
            }

            while( reader.ReadByte() == 0x00 ) {
                count -= 1;
            }
            reader.BaseStream.Seek( -1, SeekOrigin.Current );
            return count;
        }

        #endregion
    }
}
