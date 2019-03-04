namespace Util.Datas.Sql.Matedatas {
    /// <summary>
    /// 表数据库
    /// </summary>
    public interface ITableDatabase {
        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <param name="table">表</param>
        string GetDatabase( string table );
    }
}
