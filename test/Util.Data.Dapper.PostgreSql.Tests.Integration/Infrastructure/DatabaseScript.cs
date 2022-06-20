using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Util.Data.Dapper.Tests.Infrastructure {
    /// <summary>
    /// 数据库初始化脚本
    /// </summary>
    public class DatabaseScript {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void InitProcedures( DatabaseFacade database ) {
            CreateGetProductCodeFunction( database );
            CreateGetProductFunction( database );
            CreateGetProductsFunction( database );
            CreateGetProductCodeOutputProcedure( database );
            CreateInsertProductProcedure( database );
        }

        /// <summary>
        /// 创建Func_GetProductCode函数
        /// </summary>
        private static void CreateGetProductCodeFunction( DatabaseFacade database ) {
            var sql = @"
                Create Or Replace Function ""Products"".""Func_GetProductCode""(
	                ""productId"" uuid
                )
                Returns varchar
                As $$
                Declare
                    code varchar;
                Begin
                    Select ""Code"" Into code
                    From ""Products"".""Product""
                    Where ""ProductId"" = ""productId"";
                    Return code;
                End;$$
                Language plpgsql
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Func_GetProduct函数
        /// </summary>
        private static void CreateGetProductFunction( DatabaseFacade database ) {
            var sql = @"
                Create Or Replace Function ""Products"".""Func_GetProduct""(
	                ""productId"" uuid
                )
                Returns setof ""Products"".""Product""
                As $$
                Begin
                    Return Query
                    Select *
                    From ""Products"".""Product""
                    Where ""ProductId"" = ""productId"";
                End;$$
                Language plpgsql
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Func_GetProducts函数
        /// </summary>
        private static void CreateGetProductsFunction( DatabaseFacade database ) {
            var sql = @"
                Create Or Replace Function ""Products"".""Func_GetProducts""(
	                ""productId"" uuid,
                    ""productId2"" uuid
                )
                Returns Table( ""Id"" uuid,""Code"" varchar )
                As $$
                Begin
                    Return Query
                    Select p.""ProductId"" As ""Id"", p.""Code""
                    From ""Products"".""Product"" As p
                    Where ""ProductId"" in ( ""productId"",""productId2"");
                End;$$
                Language plpgsql
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_GetProductCode_Output存储过程
        /// </summary>
        private static void CreateGetProductCodeOutputProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Or Replace Procedure ""Products"".""Proc_GetProductCode_Output""(
	                ""productId"" uuid,
                    ""code"" in out varchar
                )
                As $$
                Begin
                    Select ""Code"" into code
                    From ""Products"".""Product""
                    Where ""ProductId"" = ""productId"";
                End;$$
                Language plpgsql
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_InsertProduct存储过程
        /// </summary>
        private static void CreateInsertProductProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Or Replace Procedure ""Products"".""Proc_InsertProduct""(
	                ""productId"" uuid,
                    ""code"" varchar
                )
                As $$
                Begin
                    Insert Into ""Products"".""Product""(""ProductId"",""Code"")
                    Values( ""productId"",code );
                End;$$
                Language plpgsql
            ";
            database.ExecuteSqlRaw( sql );
        }
    }
}
