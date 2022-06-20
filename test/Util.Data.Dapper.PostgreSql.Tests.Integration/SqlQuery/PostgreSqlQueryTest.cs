using Util.Data.Sql;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// PostgreSql Sql��ѯ�������
    /// </summary>
    public partial class PostgreSqlQueryTest {
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
        public PostgreSqlQueryTest( ISqlExecutor sqlExecutor, ISqlQuery sqlQuery ) {
            _sqlExecutor = sqlExecutor;
            _sqlQuery = sqlQuery;
        }
    }
}
