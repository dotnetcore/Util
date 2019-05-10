using System;
using System.Collections.Generic;

namespace Util.Tools.Offices.Tests.Integration.Exports {
    public class OfficeTest {
        public bool Test1 { get; set; }
        public int Test2 { get; set; }
        public DateTime Test3 { get; set; }
        public string Test4 { get; set; }
        public string Test5 { get; set; }
        public string Test6 { get; set; }
        public string Test7 { get; set; }
        public string Test8 { get; set; }
        public string Test9 { get; set; }
        public string Test10 { get; set; }
        public string Test11 { get; set; }
        public string Test12 { get; set; }
        public string Test13 { get; set; }
        public string Test14 { get; set; }
        public string Test15 { get; set; }
        public string Test16 { get; set; }

        public static List<OfficeTest> CreateList() {
            return new List<OfficeTest> {
                new OfficeTest {
                    Test1 = true,
                    Test2 = 2,
                    Test3 = DateTime.Now,
                    Test4 = "4a",
                    Test5 = "a5",
                    Test6 = "a6",
                    Test7 = "a7",
                    Test8 = "a8",
                    Test9 = "a9",
                    Test10 = "a10",
                    Test11 = "a11",
                    Test12 = "a12",
                    Test13 = "a13",
                    Test14 = "a14",
                    Test15 = "a15",
                    Test16 = "a16"
                },
                new OfficeTest {
                    Test1 = false,
                    Test2 = 2,
                    Test3 = DateTime.Now,
                    Test4 = "4a",
                    Test5 = "a5",
                    Test6 = "a6",
                    Test7 = "a7",
                    Test8 = "a8",
                    Test9 = "a9",
                    Test10 = "a10",
                    Test11 = "a11",
                    Test12 = "a12",
                    Test13 = "a13",
                    Test14 = "a14",
                    Test15 = "a15",
                    Test16 = "a16"
                }
            };
        }

        public static List<OfficeTest> CreateList2() {
            var list = new List<OfficeTest>();
            for( int i = 0; i < 50000; i++ ) {
                list.AddRange(CreateList());
            }
            return list;
        }
    }
}
