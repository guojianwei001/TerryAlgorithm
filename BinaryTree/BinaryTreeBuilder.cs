namespace TerryAlgorithm.BinaryTree
{
    public class BinaryTreeBuilder
    {
        private string preOrderExpress;
        private int pos = 0;
        private const char NULLNODE = '@';

        public BinaryTreeBuilder(string preOrderExpress)
        {
            this.preOrderExpress = preOrderExpress;
        }

        public TreeNode<string> Build()
        {
            var rootNode = PreorderTraverse();
            return rootNode;
        }

        private TreeNode<string> PreorderTraverse()
        {
            var ch = preOrderExpress[pos++];

            if (ch == NULLNODE)
            {
                return null;
            }

            var treeNode = new TreeNode<string>(ch.ToString());

            treeNode.Left = PreorderTraverse();
            treeNode.Right = PreorderTraverse();

            return treeNode;
        }

        //private TreeNode<string> InorderTraverse()
        //{
        //    var ch = preOrderExpress[this.pos++];

        //    if (ch == NULLNODE)
        //    {
        //        return null;
        //    }

        //    var treeNode = new TreeNode<string>();

        //    treeNode.Left = InorderTraverse();
        //    treeNode.Value = ch.ToString();
        //    treeNode.Right = InorderTraverse();

        //    return treeNode;
        //}

        //private TreeNode<string> InorderTraverseImpl()
        //{
        //    var ch = preOrderExpress[this.pos++];

        //    if (ch == NULLNODE)
        //    {
        //        return null;
        //    }

        //    var treeNode = new TreeNode<string>();

        //    treeNode.Left = InorderTraverse();
        //    treeNode.Value = ch.ToString();
        //    treeNode.Right = InorderTraverse();

        //    return treeNode;
        //}

        //private TreeNode<string> PostorderTraverse()
        //{
        //    var ch = preOrderExpress[this.pos++];

        //    if (ch == NULLNODE)
        //    {
        //        return null;
        //    }

        //    var treeNode = new TreeNode<string>();

        //    treeNode.Left = InorderTraverse();
        //    treeNode.Right = InorderTraverse();
        //    treeNode.Value = ch.ToString();

        //    return treeNode;
        //}
    }
}
