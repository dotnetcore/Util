namespace Util.Data.EntityFrameworkCore.Samples;

public interface ITest {
    /// <summary>
    /// 是否删除
    /// </summary>
    bool IsDeleted { get; set; }
}

public interface ITest2 {
    /// <summary>
    /// 租户标识
    /// </summary>
    string TenantId { get; set; }
}

public class Test:ITest,ITest2 {
    public bool IsDeleted { get; set; }
    public string TenantId { get; set; }
}

public class Test2 : ITest2 {
    public string TenantId { get; set; }
}