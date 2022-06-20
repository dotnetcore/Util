using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domain.Entities;

namespace Util.Tests.Models {
    /// <summary>
    /// 操作日志
    /// </summary>
    [Description( "操作日志" )]
    public class OperationLog : AggregateRoot<OperationLog, long> {
        /// <summary>
        /// 初始化操作日志
        /// </summary>
        public OperationLog() : this( 0 ) {
        }

        /// <summary>
        /// 初始化操作日志
        /// </summary>
        /// <param name="id">操作日志标识</param>
        public OperationLog( long id ) : base( id ) {
        }

        /// <summary>
        /// 日志名称
        ///</summary>
        [Description( "日志名称" )]
        [Required( ErrorMessage = "日志名称不能为空" )]
        [MaxLength( 50 )]
        public string LogName { get; set; }
        /// <summary>
        /// 操作时间
        ///</summary>
        [Description( "操作时间" )]
        public DateTime? OperationTime { get; set; }
        /// <summary>
        /// 标题
        ///</summary>
        [Description( "标题" )]
        [MaxLength( 200 )]
        public string Caption { get; set; }
        /// <summary>
        /// 内容
        ///</summary>
        [Description( "内容" )]
        public string Content { get; set; }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( OperationLog other ) {
            AddChange( t => t.LogName, other.LogName );
            AddChange( t => t.OperationTime, other.OperationTime );
            AddChange( t => t.Caption, other.Caption );
            AddChange( t => t.Content, other.Content );
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init() {
            OperationTime = DateTime.Now;
        }
    }
}