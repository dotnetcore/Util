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
            CreateReturnProcedure( database );
            CreateInsertProductProcedure( database );
        }

        /// <summary>
        /// 创建Proc_GetProductCode存储过程
        /// </summary>
        private static void CreateGetProductCodeProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure [Products].[Proc_GetProductCode] (
	                @productId uniqueidentifier
                )
                As
                Select [Code]
                From [Products].[Product]
                Where [ProductId] = @productId
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_GetProduct存储过程
        /// </summary>
        private static void CreateGetProductProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure [Products].[Proc_GetProduct] (
	                @productId uniqueidentifier
                )
                As
                Select *
                From [Products].[Product]
                Where [ProductId] = @productId
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_GetProducts存储过程
        /// </summary>
        private static void CreateGetProductsProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure [Products].[Proc_GetProducts] (
	                @productId uniqueidentifier,
                    @productId2 uniqueidentifier
                )
                As
                Select p.ProductId As Id,p.*
                From [Products].[Product] As p
                Where [ProductId] in ( @productId,@productId2 )
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_GetOrderItem存储过程
        /// </summary>
        private static void CreateGetOrderItemProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure [Sales].[Proc_GetOrderItem] (
	                @orderItemId uniqueidentifier
                )
                As
                Select i.OrderItemId As Id,i.*,o.OrderId As Id,o.*
                From [Sales].[OrderItem] As i
                Left Join [Sales].[Order] As o On o.OrderId=i.OrderId
                Where i.OrderItemId=@orderItemId
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_GetProductCode_Output存储过程
        /// </summary>
        private static void CreateGetProductCodeOutputProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure [Products].[Proc_GetProductCode_Output] (
	                @productId uniqueidentifier,
                    @code nvarchar(50) output
                )
                As
                Select @code=[Code]
                From [Products].[Product]
                Where [ProductId] = @productId
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_Return存储过程
        /// </summary>
        private static void CreateReturnProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure [Products].[Proc_Return] (
	                @productId uniqueidentifier
                )
                As
                If Exists(Select * From [Products].[Product] Where [ProductId] = @productId)
                    Return 1;
                Else
                    Return -1;
            ";
            database.ExecuteSqlRaw( sql );
        }

        /// <summary>
        /// 创建Proc_InsertProduct存储过程
        /// </summary>
        private static void CreateInsertProductProcedure( DatabaseFacade database ) {
            var sql = @"
                Create Procedure [Products].[Proc_InsertProduct] (
	                @productId uniqueidentifier,
                    @code nvarchar(50)
                )
                As
                Insert [Products].[Product](ProductId,Code)
                Values( @productId,@code )
            ";
            database.ExecuteSqlRaw( sql );
        }
    }
}
