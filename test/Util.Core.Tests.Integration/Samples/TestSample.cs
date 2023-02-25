using Util.Dependency;

namespace Util.Tests.Samples {
    /// <summary>
    /// 测试查找接口
    /// </summary>
    public interface IA : IB {
        string Value { get; set; }
    }

    /// <summary>
    /// 测试查找接口
    /// </summary>
    public interface IB {
    }

    /// <summary>
    /// 测试查找接口
    /// </summary>
    public interface IC {
    }

    /// <summary>
    /// 测试查找接口
    /// </summary>
    public interface IG<T> {
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    public class A : IA, IB {
        public string Value { get; set; }
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    public class B : IB, IC {
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    public abstract class C : IB, IC {
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    public class D<T> : IC {
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    public class E : IG<E> {
    }

    /// <summary>
    /// 测试类型
    /// </summary>
    public class F<T> : IG<T> {
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService : ITestService {
        public string Value { get; set; }
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestService {
        string Value { get; set; }
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService2 : ITestService2 {
        public string Value { get; set; }
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestService2 {
        string Value { get; set; }
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService3 : ITestService3 {
        public string Value { get; set; }
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestService3 {
        string Value { get; set; }
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService4 : ITestService2,ITestService5 {
        public string Value { get; set; }
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestService4: ITestService3, ISingletonDependency {
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestService5 : ITestService4 {
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestService6<T> : ISingletonDependency {
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService5<T> : ITestService6<T> {
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestService7 : ISingletonDependency {
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    [Ioc( -2 )]
    public class TestService7 : ITestService7 {
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    [Ioc( -1 )]
    public class TestService8 : ITestService7 {
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestService70 : ISingletonDependency {
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    [Ioc( 2 )]
    public class TestService70 : ITestService70 {
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    [Ioc( 1 )]
    public class TestService80 : ITestService70 {
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService90 : ITestService70 {
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestService8 : ISingletonDependency {
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService9 : ITestService8 {
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService10 : ITestService8 {
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    [Ioc( 2 )]
    public class TestService11 : ITestService8 {
    }
}
