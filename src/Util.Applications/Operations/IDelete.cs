namespace Util.Applications.Operations {
    /// <summary>
    /// 删除操作
    /// </summary>
    public interface IDelete {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        void Delete( string ids );
    }
}