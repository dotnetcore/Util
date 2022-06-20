using Util.Data.Sql;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// Sql Server Sql��ѯ�������
    /// </summary>
    public partial class SqlServerSqlQueryTest {
        /// <summary>
        /// Sqlִ����
        /// </summary>
        private readonly ISqlExecutor _sqlExecutor;
        /// <summary>
        /// Sql��ѯ����
        /// </summary>
        private readonly ISqlQuery _sqlQuery;

        /// <summary>
        /// ���Գ�ʼ��
        /// </summary>
        public SqlServerSqlQueryTest( ISqlExecutor sqlExecutor, ISqlQuery sqlQuery ) {
            _sqlExecutor = sqlExecutor;
            _sqlQuery = sqlQuery;
        }
    }
}
