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
            CreateGetProductCodeProcedure( database );
            CreateGetProductProcedure( database );
            CreateGetProductsProcedure( database );
            CreateGetOrderItemProcedure( database );
            CreateGetProductCodeOutputProcedure( database );
            CreateInsertProductProcedure( database );
        }

        /// <summary>
        /// 创建Proc_GetProductCode存储过程
        /// </summary>
        private static void CreateGetProductCodeProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure Proc_GetProductCode (
	                id char(36)
                )
                Begin
                    Select Code
                    From Product
                    Where ProductId = id;
                End
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_GetProduct存储过程
        /// </summary>
        private static void CreateGetProductProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure Proc_GetProduct (
	                id char(36)
                )
                Begin
                    Select *
                    From Product
                    Where ProductId = id;
                End
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_GetProducts存储过程
        /// </summary>
        private static void CreateGetProductsProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure Proc_GetProducts (
	                id char(36),
                    id2 char(36)
                )
                Begin
                    Select p.ProductId As Id,p.*
                    From Product As p
                    Where p.ProductId in ( id,id2 );
                End
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_GetOrderItem存储过程
        /// </summary>
        private static void CreateGetOrderItemProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure Proc_GetOrderItem (
	                id char(36)
                )
                Begin
                    Select i.OrderItemId As Id,i.*,o.OrderId As Id,o.*
                    From OrderItem As i
                    Left Join `Order` As o On o.OrderId=i.OrderId
                    Where i.OrderItemId=id;
                End
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_GetProductCode_Output存储过程
        /// </summary>
        private static void CreateGetProductCodeOutputProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure Proc_GetProductCode_Output (
	                id char(36),
                    out code_output varchar(50)
                )
                Begin
                    Select `Code` into code_output
                    From `Product`
                    Where `ProductId` = id;
                End
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_InsertProduct存储过程
        /// </summary>
        private static void CreateInsertProductProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure Proc_InsertProduct (
	                id char(36),
                    codeValue varchar(50)
                )
                Begin
                    Insert Into Product(ProductId,Code)
                    Values( id,codeValue );
                End
            ";
            database.ExecuteSqlRaw( sql );
        }
    }
}
