using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domains;
using Util.Domains.Auditing;

namespace Util.Samples.Webs.Domains.Models {
    /// <summary>
    /// 应用程序
    /// </summary>
    [DisplayName( "应用程序" )]
    public class Application : AggregateRoot<Application>, IDelete, IAudited {
        /// <summary>
        /// 初始化应用程序
        /// </summary>
        public Application() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化应用程序
        /// </summary>
        /// <param name="id">应用程序标识</param>
        public Application( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 应用程序编码
        /// </summary>
        [DisplayName( "应用程序编码" )]
        [Required( ErrorMessage = "应用程序编码不能为空" )]
        [StringLength( 60, ErrorMessage = "应用程序编码输入过长，不能超过60位" )]
        public string Code { get; set; }
        /// <summary>
        /// 应用程序名称
        /// </summary>
        [DisplayName( "应用程序名称" )]
        [Required( ErrorMessage = "应用程序名称不能为空" )]
        [StringLength( 200, ErrorMessage = "应用程序名称输入过长，不能超过200位" )]
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName( "备注" )]
        [StringLength( 500, ErrorMessage = "备注输入过长，不能超过500位" )]
        public string Comment { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [DisplayName( "启用" )]
        [Required( ErrorMessage = "启用不能为空" )]
        public bool Enabled { get; set; }
        /// <summary>
        /// 启用注册
        /// </summary>
        [DisplayName( "启用注册" )]
        [Required( ErrorMessage = "启用注册不能为空" )]
        public bool RegisterEnabled { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName( "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        [DisplayName( "创建人编号" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DisplayName( "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        [DisplayName( "最后修改人编号" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName( "是否删除" )]
        [Required( ErrorMessage = "是否删除不能为空" )]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( "应用程序编号", Id );
            AddDescription( "应用程序编码", Code );
            AddDescription( "应用程序名称", Name );
            AddDescription( "备注", Comment );
            AddDescription( "启用", Enabled.Description() );
            AddDescription( "启用注册", RegisterEnabled.Description() );
            AddDescription( "创建时间", CreationTime );
            AddDescription( "创建人编号", CreatorId );
            AddDescription( "最后修改时间", LastModificationTime );
            AddDescription( "最后修改人编号", LastModifierId );
        }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Application other ) {
            AddChange( "Id", "应用程序编号", Id, other.Id );
            AddChange( "Code", "应用程序编码", Code, other.Code );
            AddChange( "Name", "应用程序名称", Name, other.Name );
            AddChange( "Comment", "备注", Comment, other.Comment );
            AddChange( "Enabled", "启用", Enabled, other.Enabled );
            AddChange( "RegisterEnabled", "启用注册", RegisterEnabled, other.RegisterEnabled );
            AddChange( "CreationTime", "创建时间", CreationTime, other.CreationTime );
            AddChange( "CreatorId", "创建人编号", CreatorId, other.CreatorId );
            AddChange( "LastModificationTime", "最后修改时间", LastModificationTime, other.LastModificationTime );
            AddChange( "LastModifierId", "最后修改人编号", LastModifierId, other.LastModifierId );
        }
    }
}