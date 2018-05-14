using System.ComponentModel.DataAnnotations.Schema;
using Util.Exceptions;
using Util.Security.Encryptors;
using Util.Validations;

namespace Util.Security.Identity.Models {
    /// <summary>
    /// 用户
    /// </summary>
    public partial class User<TUser,TKey> {
        /// <summary>
        /// 加密器
        /// </summary>
        [NotMapped]
        public IEncryptor Encryptor { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init() {
            base.Init();
            InitUserName();
        }

        /// <summary>
        /// 初始化用户名
        /// </summary>
        private void InitUserName() {
            if ( UserName.IsEmpty() == false )
                return;
            if ( Email.IsEmpty() == false ) {
                UserName = Email;
                return;
            }
            if ( PhoneNumber.IsEmpty() == false )
                UserName = PhoneNumber;
        }

        /// <summary>
        /// 验证
        /// </summary>
        public override ValidationResultCollection Validate() {
            if( UserName.IsEmpty() )
                throw new Warning( Util.Security.SecurityResource.UserNameIsEmpty );
            return base.Validate();
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="storeOriginalPassword">是否存储原始密码</param>
        /// <param name="password">密码</param>
        public void SetPassword( bool? storeOriginalPassword, string password ) {
            if ( storeOriginalPassword == true ) {
                Password = GetEncryptor().Encrypt( password );
                return;
            }
            Password = null;
        }

        /// <summary>
        /// 获取加密器
        /// </summary>
        protected virtual IEncryptor GetEncryptor() {
            return Encryptor ?? NullEncryptor.Instance;
        }

        /// <summary>
        /// 设置安全码
        /// </summary>
        /// <param name="storeOriginalPassword">是否存储原始密码</param>
        /// <param name="password">安全码</param>
        public void SetSafePassword( bool? storeOriginalPassword, string password ) {
            if ( storeOriginalPassword == true ) {
                SafePassword = GetEncryptor().Encrypt( password );
                return;
            }
            SafePassword = null;
        }

        /// <summary>
        /// 获取密码
        /// </summary>
        public string GetPassword() {
            return GetEncryptor().Decrypt( Password );
        }

        /// <summary>
        /// 获取安全码
        /// </summary>
        public string GetSafePassword() {
            return GetEncryptor().Decrypt( SafePassword );
        }
    }
}