using System;
using Microsoft.AspNetCore.DataProtection;

namespace Util.Security.Encryptors {
    /// <summary>
    /// 基于数据保护提供程序的加密器
    /// </summary>
    public class DataProtectionEncryptor : IEncryptor {
        /// <summary>
        /// 数据保护器
        /// </summary>
        private readonly IDataProtector _dataProtector;

        /// <summary>
        /// 初始化加密器
        /// </summary>
        /// <param name="dataProtector">数据保护器</param>
        public DataProtectionEncryptor( IDataProtector dataProtector ) {
            _dataProtector = dataProtector ?? throw new ArgumentNullException( nameof( dataProtector ) );
        }

        /// <inheritdoc />
        public string Encrypt( string data ) {
            if ( data.IsEmpty() )
                return null;
            return _dataProtector.Protect( data );
        }

        /// <inheritdoc />
        public string Decrypt( string data ) {
            if ( data.IsEmpty() )
                return null;
            return _dataProtector.Unprotect( data );
        }
    }
}
