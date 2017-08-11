namespace Util.Datas.Tests.SqlServer.UnitOfWorks {
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class SqlServerUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork, ISqlServerUnitOfWork {
        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        public SqlServerUnitOfWork() : base( "Server=.\\sql2014;Database=UtilTest;uid=sa;pwd=sa;" ) {
        }
    }
}