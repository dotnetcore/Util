using Util.Data.Sql;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// MySql Sql��ѯ�������
    /// </summary>
    public partial class MySqlQueryTest {
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
        public MySqlQueryTest( ISqlExecutor sqlExecutor, ISqlQuery sqlQuery ) {
            _sqlExecutor = sqlExecutor;
            _sqlQuery = sqlQuery;
        }
    }
}
