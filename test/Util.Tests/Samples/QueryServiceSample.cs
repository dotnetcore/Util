using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Util.Applications;
using Util.Applications.Dtos;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace Util.Tests.Samples {
    /// <summary>
    /// 数据传输对象样例
    /// </summary>
    public class DtoSample : DtoBase {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空" )]
        public string Name { get; set; }

        /// <summary>
        /// 创建空集合
        /// </summary>
        public static List<DtoSample> EmptyList() {
            return new List<DtoSample>();
        }
    }

    /// <summary>
    /// 查询服务样例
    /// </summary>
    public class QueryServiceSample : QueryServiceBase<EntitySample, DtoSample, QueryParameterSample> {
        public QueryServiceSample( IRepositorySample repository ) : base( repository ) {
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="parameter">查询参数</param>
        protected override IQueryBase<EntitySample> CreateQuery( QueryParameterSample parameter ) {
            return new Query<EntitySample>( parameter ).WhereIfNotEmpty( t => t.Name == parameter.Name );
        }

        /// <summary>
        /// 查询时是否跟踪对象
        /// </summary>
        protected override bool IsTracking => true;
    }
}
