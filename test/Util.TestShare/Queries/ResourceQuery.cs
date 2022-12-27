using System;
using System.ComponentModel;
using Util.Data.Trees;

namespace Util.Tests.Queries {
    /// <summary>
    /// 资源查询参数
    /// </summary>
    public class ResourceQuery : TreeQueryParameter {
        /// <summary>
        /// 资源标识
        ///</summary>
        [Description( "资源标识" )]
        public Guid? ResourceId { get; set; }
        /// <summary>
        /// 资源标识符
        ///</summary>
        [Description( "资源标识符" )]
        public string Uri { get; set; }
        /// <summary>
        /// 资源名称
        ///</summary>
        [Description( "资源名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 备注
        ///</summary>
        [Description( "备注" )]
        public string Remark { get; set; }
    }
}