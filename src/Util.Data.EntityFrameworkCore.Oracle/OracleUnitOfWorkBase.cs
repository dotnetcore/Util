using Microsoft.Extensions.Options;
using Util.Data.EntityFrameworkCore.ValueComparers;
using Util.Data.EntityFrameworkCore.ValueConverters;
using Util.Domain.Extending;
using Util.Properties;

namespace Util.Data.EntityFrameworkCore;

/// <summary>
/// Oracle工作单元基类
/// </summary>
public abstract class OracleUnitOfWorkBase : UnitOfWorkBase {
    /// <summary>
    /// 初始化Oracle工作单元
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="options">配置</param>
    protected OracleUnitOfWorkBase( IServiceProvider serviceProvider, DbContextOptions options )
        : base( serviceProvider, options ) {
    }

    /// <inheritdoc />
    protected override void ConfigTenantConnectionString( DbContextOptionsBuilder optionsBuilder, string connectionString ) {
        optionsBuilder.UseOracle( connectionString );
    }

    /// <summary>
    /// 配置扩展属性
    /// </summary>
    /// <param name="modelBuilder">模型生成器</param>
    /// <param name="entityType">实体类型</param>
    protected override void ApplyExtraProperties( ModelBuilder modelBuilder, IMutableEntityType entityType ) {
        if ( typeof( IExtraProperties ).IsAssignableFrom( entityType.ClrType ) == false )
            return;
        modelBuilder.Entity( entityType.ClrType )
            .Property( "ExtraProperties" )
            .HasColumnName( "ExtraProperties" )
            .HasComment( R.ExtraProperties )
            .HasColumnType( "CLOB" )
            .HasConversion( new ExtraPropertiesValueConverter() )
            .Metadata.SetValueComparer( new ExtraPropertyDictionaryValueComparer() );
    }

    /// <summary>
    /// 配置约定
    /// </summary>
    protected override void ConfigureConventions( ModelConfigurationBuilder configurationBuilder ) {
        base.ConfigureConventions( configurationBuilder );
        ConfigGuidToString( configurationBuilder );
    }

    /// <summary>
    /// 配置将Guid转换为字符串
    /// </summary>
    protected virtual void ConfigGuidToString( ModelConfigurationBuilder configurationBuilder ) {
        var options = ServiceProvider.GetService<IOptions<OracleEntityFrameworkCoreOptions>>();
        if ( options?.Value.IsGuidToString == false )
            return;
        configurationBuilder.Properties<Guid>().HaveConversion<string>();
        configurationBuilder.Properties<Guid?>().HaveConversion<string>();
    }
}