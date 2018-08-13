using System;
using Util.Datas.Matedatas;

namespace Util.Datas.Tests.Dapper.SqlServer.Samples {

    public class TestEntityMatedata : IEntityMatedata {
        public string GetTable( Type entity ) {
            return $"t_{entity.Name}";
        }

        public string GetSchema( Type entity ) {
            return $"as_{entity.Name}";
        }

        public string GetColumn( Type entity, string property ) {
            return $"{entity.Name}_{property}";
        }
    }
}
