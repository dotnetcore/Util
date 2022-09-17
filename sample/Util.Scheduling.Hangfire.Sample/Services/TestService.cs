using Util.Dependency;
using Util.Helpers;

namespace Util.Scheduling.Hangfire.Sample.Services {
    public class TestService : ITestService {
        private readonly string _id;

        public TestService() {
            _id = Id.Create();
        }

        public string GetId() {
            return _id;
        }
    }

    public interface ITestService : IScopeDependency {
        string GetId();
    }
}
