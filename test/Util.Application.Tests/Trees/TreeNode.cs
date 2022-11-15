namespace Util.Applications.Trees {
    public class TreeNode1 : TreeDtoBase {
        public string Text { get; set; }
        public TreeNode1() {
            Id = "1";
            Path = "1,";
        }
        public override string GetText() {
            return Text;
        }
    }

    public class TreeNode2 : TreeDtoBase {
        public string Text { get; set; }
        public TreeNode2() {
            Id = "2";
            ParentId = "1";
            Path = "1,2,";
        }
        public override string GetText() {
            return Text;
        }
    }

    public class TreeNode3 : TreeDtoBase {
        public string Text { get; set; }
        public TreeNode3() {
            Id = "3";
            ParentId = "2";
            Path = "1,2,3,";
        }
        public override string GetText() {
            return Text;
        }
    }

    public class TreeNode4 : TreeDtoBase {
        public string Text { get; set; }
        public TreeNode4() {
            Id = "4";
            ParentId = "2";
            Path = "1,2,4,";
        }
        public override string GetText() {
            return Text;
        }
    }

    public class TreeNode5 : TreeDtoBase {
        public string Text { get; set; }
        public TreeNode5() {
            Id = "5";
            ParentId = "4";
            Path = "1,2,4,5,";
        }
        public override string GetText() {
            return Text;
        }
    }
}
