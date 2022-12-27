using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domain.Entities;

namespace Util.Domain.Tests.Samples {
    /// <summary>
    /// Guid聚合根测试样例
    /// </summary>
    public class AggregateRootSample : AggregateRoot<AggregateRootSample> {
        /// <summary>
        /// 初始化聚合根测试样例
        /// </summary>
        public AggregateRootSample()
            : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化聚合根测试样例
        /// </summary>
        /// <param name="id">标识</param>
        public AggregateRootSample( Guid id )
            : base( id ) {
            IntSamples = new List<IntAggregateRootSample>();
        }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required( ErrorMessage = "姓名不能为空" )]
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        [Required( ErrorMessageResourceType = typeof( TestResource ), ErrorMessageResourceName = "EnglishNameIsEmpty" )]
        public string EnglishName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Display(Name = "手机号" )]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Description( "电话" )]
        public int Tel { get; set; }

        /// <summary>
        /// decimal值
        /// </summary>
        public decimal DecimalValue { get; set; }
        /// <summary>
        /// 可空decimal值
        /// </summary>
        public decimal? NullableDecimalValue { get; set; }
        /// <summary>
        /// float值
        /// </summary>
        public float FloatValue { get; set; }
        /// <summary>
        /// 可空float值
        /// </summary>
        public float? NullableFloatValue { get; set; }
        /// <summary>
        /// double值
        /// </summary>
        public double DoubleValue { get; set; }
        /// <summary>
        /// 可空double值
        /// </summary>
        public double? NullableDoubleValue { get; set; }
        /// <summary>
        /// bool值
        /// </summary>
        public bool BoolValue { get; set; }
        /// <summary>
        /// 可空bool值
        /// </summary>
        public bool? NullableBoolValue { get; set; }
        /// <summary>
        /// Enum值
        /// </summary>
        public EnumSample EnumValue { get; set; }
        /// <summary>
        /// 可空Enum值
        /// </summary>
        public EnumSample? NullableEnumValue { get; set; }
        /// <summary>
        /// DateTime值
        /// </summary>
        public DateTime DateValue { get; set; }
        /// <summary>
        /// 可空DateTime值
        /// </summary>
        public DateTime? NullableDateValue { get; set; }
        /// <summary>
        /// int值
        /// </summary>
        public int IntValue { get; set; }
        /// <summary>
        /// 可空int值
        /// </summary>
        public int? NullableIntValue { get; set; }
        /// <summary>
        /// short值
        /// </summary>
        public short ShortValue { get; set; }
        /// <summary>
        /// 可空short值
        /// </summary>
        public short? NullableShortValue { get; set; }
        /// <summary>
        /// long值
        /// </summary>
        public long LongValue { get; set; }
        /// <summary>
        /// 可空long值
        /// </summary>
        public long? NullableLongValue { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public StringAggregateRootSample StringSample { get; set; }

        /// <summary>
        /// 导航属性集合
        /// </summary>
        public ICollection<IntAggregateRootSample> IntSamples { get; set; }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( AggregateRootSample other ) {
            AddChange( "Name", "姓名", Name, other.Name );
            AddChange( t => t.MobilePhone, other.MobilePhone );
            AddChange( t => t.Tel, other.Tel );
            AddChange( StringSample, other.StringSample );
            AddChange( IntSamples, other.IntSamples );
        }

        /// <summary>
        /// 创建测试样例
        /// </summary>
        public static AggregateRootSample CreateSample() {
            return CreateSample( Guid.NewGuid() );
        }

        /// <summary>
        /// 创建测试样例
        /// </summary>
        public static AggregateRootSample CreateSample( Guid id ) {
            return new AggregateRootSample( id ) {
                Name = "TestName",
                EnglishName = "TestEnglishName",
                MobilePhone = "13012345678"
            };
        }

        /// <summary>
        /// 创建测试样例2
        /// </summary>
        public static AggregateRootSample CreateSample2() {
            return CreateSample2( Guid.NewGuid() );
        }

        /// <summary>
        /// 创建测试样例2
        /// </summary>
        public static AggregateRootSample CreateSample2( Guid id ) {
            return new AggregateRootSample( id ) {
                Name = "TestName2",
                EnglishName = "TestEnglishName2",
                MobilePhone = "12012345678"
            };
        }
    }

    /// <summary>
    /// 聚合根测试样例2
    /// </summary>
    public class AggregateRootSample2 : AggregateRoot<AggregateRootSample> {
        /// <summary>
        /// 初始化聚合根测试样例
        /// </summary>
        /// <param name="id">标识</param>
        public AggregateRootSample2( Guid id )
            : base( id ) {
        }
    }
}
