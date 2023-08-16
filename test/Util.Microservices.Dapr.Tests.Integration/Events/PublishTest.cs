using Util.Microservices.Dapr.Tests.Samples;

namespace Util.Microservices.Dapr.Tests.Events; 

/// <summary>
/// 事件发布测试
/// </summary>
public class PublishTest {

    [Fact]
    public void Test() {
        var customerEvent = new CustomerEvent( "a", "b" );
    }
}