using System;
using System.Collections.Generic;

namespace TerryAlgorithm.BinaryTree
{
    public static class TreeTraversal<T>
    {
        public static void PreorderRecursive(TreeNode<T> treeNode)
        {
            if (treeNode == null)
            {
                return;
            }

            Visit(treeNode);

            PreorderRecursive(treeNode.Left);

            PreorderRecursive(treeNode.Right);
        }

        public static void InorderRecursive(TreeNode<T> treeNode)
        {
            if (treeNode == null)
            {
                return;
            }

            InorderRecursive(treeNode.Left);

            Visit(treeNode);

            InorderRecursive(treeNode.Right);
        }

        public static void PostorderRecursive(TreeNode<T> treeNode)
        {
            if (treeNode == null)
            {
                return;
            }

            PostorderRecursive(treeNode.Left);

            PostorderRecursive(treeNode.Right);

            Visit(treeNode);
        }

        public static void PreorderNoRecursive(TreeNode<T> treeNode)
        {
            var stack = new Stack<TreeNode<T>>();
            stack.Push(treeNode);

            while (stack.Count > 0)
            {
                var top = stack.Pop();
                Console.Write(top.Value);

                if (top.Right != null)
                {
                    stack.Push(top.Right);
                }

                if (top.Left != null)
                {
                    stack.Push(top.Left);
                }
            }
        }

        public static void InorderNoRecursive(TreeNode<T> treeNode)
        {
            var stack = new Stack<TreeNode<T>>();
            stack.Push(treeNode);

            while (stack.Count > 0)
            {
                var top = stack.Peek();

                if (top.Left != null)
                {
                    stack.Push(top.Left);
                }
                else
                {
                    stack.Pop();
                    Console.Write(top.Value);

                    if (top.Right != null)
                    {
                        stack.Push(top.Right);
                    }
                    else
                    {
                        if (stack.Count > 0)
                        {
                            var parent = stack.Pop();
                            Console.Write(parent.Value);

                            if (parent.Right != null)
                            {
                                stack.Push(parent.Right);
                            }
                        }
                    }
                }
            }
        }

        public static void PostorderNoRecursive(TreeNode<T> treeNode)
        {
            var stack = new Stack<TreeNode<T>>();
            var node = treeNode;
            TreeNode<T> lastVisitedNode = null;

            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    // left
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    var peekNode = stack.Peek();

                    if (peekNode.Right != null && peekNode.Right != lastVisitedNode)
                    {
                        // right
                        node = peekNode.Right;
                    }
                    else
                    {
                        // visit
                        Visit(peekNode);
                        lastVisitedNode = stack.Pop();
                    }
                }
            }
        }

        private static void Visit(TreeNode<T> node)
        {
            Console.Write(node.Value);
        }
    }

    // refer to https://en.wikipedia.org/wiki/Tree_traversal
    /*
     * 
------------------------------------------------------------------------------

     ### Pre-order :

    procedure preorder(node)
    if node = null
        return
    visit(node)
    preorder(node.left)
    preorder(node.right) 

    procedure iterativePreorder(node)
    if node = null
        return
    stack ← empty stack
    stack.push(node)
    while not stack.isEmpty()
        node ← stack.pop()
        visit(node)
        // right child is pushed first so that left is processed first
        if node.right ≠ null
            stack.push(node.right)
        if node.left ≠ null
            stack.push(node.left)

------------------------------------------------------------------------------

    ### Post-order

    procedure postorder(node)
    if node = null
        return
    postorder(node.left)
    postorder(node.right)
    visit(node)

    procedure iterativePostorder(node)
    stack ← empty stack
    lastNodeVisited ← null
    while not stack.isEmpty() or node ≠ null
        if node ≠ null
            stack.push(node)
            node ← node.left
        else
            peekNode ← stack.peek()
            // if right child exists and traversing node
            // from left child, then move right
            if peekNode.right ≠ null and lastNodeVisited ≠ peekNode.right
                node ← peekNode.right
            else
                visit(peekNode)
                lastNodeVisited ← stack.pop()

------------------------------------------------------------------------------

    ### In-order

    procedure inorder(node)
    if node = null
        return
    inorder(node.left)
    visit(node)
    inorder(node.right)

    procedure iterativeInorder(node)
    stack ← empty stack
    while not stack.isEmpty() or node ≠ null
        if node ≠ null
            stack.push(node)
            node ← node.left
        else
            node ← stack.pop()
            visit(node)
            node ← node.right

------------------------------------------------------------------------------

     */

}
