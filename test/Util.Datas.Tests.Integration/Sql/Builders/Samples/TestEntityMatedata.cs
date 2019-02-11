using System;
using Util.Datas.Sql.Matedatas;

namespace Util.Datas.Tests.Sql.Builders.Samples {

    public class TestEntityMatedata : IEntityMatedata {
        public string GetTable( Type entity ) {
            return $"t_{entity.Name}";
        }

        public string GetSchema( Type entity ) {
            return $"as_{entity.Name}";
        }

        public string GetColumn( Type entity, string property ) {
            if ( property == "DecimalValue" )
                return property;
            return $"{entity.Name}_{property}";
        }
    }
}
