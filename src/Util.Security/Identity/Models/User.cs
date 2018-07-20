using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Util.Exceptions;
using Util.Security.Encryptors;
using Util.Validations;

namespace Util.Security.Identity.Models {
    /// <summary>
    /// 用户
    /// </summary>
    public partial class User<TUser, TKey> {
        /// <summary>
        /// 声明列表
        /// </summary>
        private readonly List<Claim> _claims;

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
            if( UserName.IsEmpty() == false )
                return;
            if( Email.IsEmpty() == false ) {
                UserName = Email;
                return;
            }
            if( PhoneNumber.IsEmpty() == false )
                UserName = PhoneNumber;
        }

        /// <summary>
        /// 验证
        /// </summary>
        public override ValidationResultCollection Validate() {
            if( UserName.IsEmpty() )
                throw new Warning( Util.Security.Properties.SecurityResource.UserNameIsEmpty );
            return base.Validate();
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="storeOriginalPassword">是否存储原始密码</param>
        /// <param name="password">密码</param>
        public void SetPassword( bool? storeOriginalPassword, string password ) {
            if( storeOriginalPassword == true ) {
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
            if( storeOriginalPassword == true ) {
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

        /// <summary>
        /// 获取声明列表
        /// </summary>
        public virtual List<Claim> GetClaims() {
            return _claims;
        }

        /// <summary>
        /// 获取声明列表
        /// </summary>
        public void AddClaim( Claim claim ) {
            if( claim == null )
                return;
            if( claim.Value.IsEmpty() )
                return;
            if( _claims.Exists( t => t.Type.SafeString().ToLower() == claim.Type.SafeString().ToLower() ) )
                return;
            _claims.Add( claim );
        }

        /// <summary>
        /// 添加声明
        /// </summary>
        public void AddClaim( string type, string value ) {
            if( type.IsEmpty() || value.IsEmpty() )
                return;
            AddClaim( new Claim( type, value ) );
        }

        /// <summary>
        /// 添加用户声明
        /// </summary>
        public virtual void AddUserClaims() {
            AddClaim( Util.Security.Claims.ClaimTypes.Mobile, PhoneNumber );
            AddClaim( Util.Security.Claims.ClaimTypes.Email, Email );
        }
    }
}