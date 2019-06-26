using System;
using System.ComponentModel.DataAnnotations;
using Util.Datas.Queries;

namespace Util.Samples.Service.Queries.Systems {
    /// <summary>
    /// 应用程序查询实体
    /// </summary>
    public class ApplicationQuery : QueryParameter {
        /// <summary>
        /// 应用程序编号
        /// </summary>
        [Display( Name = "应用程序" )]
        public Guid? ApplicationId { get; set; }

        private string _code = string.Empty;
        /// <summary>
        /// 应用程序编码
        /// </summary>
        [Display( Name = "应用程序编码" )]
        public string Code {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }

        private string _name = string.Empty;
        /// <summary>
        /// 应用程序名称
        /// </summary>
        [Display( Name = "应用程序名称" )]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }

        private string _comment = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        [Display( Name = "备注" )]
        public string Comment {
            get => _comment == null ? string.Empty : _comment.Trim();
            set => _comment = value;
        }
        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "启用" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 启用注册
        /// </summary>
        [Display( Name = "启用注册" )]
        public bool? RegisterEnabled { get; set; }
        /// <summary>
        /// 起始创建时间
        /// </summary>
        [Display( Name = "起始创建时间" )]
        public DateTime? BeginCreationTime { get; set; }
        /// <summary>
        /// 结束创建时间
        /// </summary>
        [Display( Name = "结束创建时间" )]
        public DateTime? EndCreationTime { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        [Display( Name = "创建人编号" )]
        public Guid? CreatorId { get; set; }
    }
}