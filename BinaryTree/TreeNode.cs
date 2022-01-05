namespace TerryAlgorithm.BinaryTree
{
    public class TreeNode<T>
    {
        public TreeNode()
        {

        }

        public TreeNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public TreeNode<T> Right { get; set; }

        public TreeNode<T> Left { get; set; }

        public bool IsLeaf
        {
            get
            {
                return this.Right == null && this.Left == null;
            }
        }
    }
}
