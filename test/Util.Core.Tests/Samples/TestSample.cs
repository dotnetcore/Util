namespace Util.Tests.Samples {
    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestSample : ITestSample2 {
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestSample2 : ITestSample3 {
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestSample3 {
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestSample4 {
    }

    /// <summary>
    /// 测试服务接口
    /// </summary>
    public interface ITestSample5 : ITestSample4 {
    }

    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestSample : ITestSample, ITestSample5 {
    }
}
