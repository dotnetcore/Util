namespace Util.Security.Authorization {
    /// <summary>
    /// 授权辅助操作
    /// </summary>
    public static class AclPolicyHelper {
        /// <summary>
        /// 策略前缀
        /// </summary>
        public const string Prefix = "acl_";

        /// <summary>
        /// 获取授权要求
        /// </summary>
        public static AclRequirement GetRequirement( string policy ) {
            var json = policy.RemoveStart( Prefix );
            return Util.Helpers.Json.ToObject<AclRequirement>( json );
        }

        /// <summary>
        /// 获取授权策略
        /// </summary>
        /// <param name="uri">资源标识</param>
        /// <param name="ignore">是否忽略</param>
        public static string GetPolicy( string uri,bool ignore ) {
            var requirement = new AclRequirement {
                Uri = uri,
                Ignore = ignore
            };
            return $"{Prefix}{Util.Helpers.Json.ToJson( requirement )}";
        }
    }
}
