using System;
using System.Diagnostics.Contracts;

namespace DataStructures
{
    public static class BinaryTreeExtensions
    {
        public static void PreOrderTraversal<T>(this BinaryTreeNode<T> node, Action<T> visitAction)
        {
            Contract.Requires(visitAction != null);

            if (node == null)
            {
                return;
            }

            visitAction(node.Value);
            PreOrderTraversal(node.Left, visitAction);
            PreOrderTraversal(node.Right, visitAction);
        }

        public static void InOrderTraversal<T>(this BinaryTreeNode<T> node, Action<T> visitAction)
        {
            Contract.Requires(visitAction != null);

            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.Left, visitAction);
            visitAction(node.Value);
            InOrderTraversal(node.Right, visitAction);
        }


        public static void PostOrderTraversal<T>(this BinaryTreeNode<T> node, Action<T> visitAction)
        {
            Contract.Requires(visitAction != null);

            if (node == null)
            {
                return;
            }

            PostOrderTraversal(node.Left, visitAction);
            PostOrderTraversal(node.Right, visitAction);
            visitAction(node.Value);
        }
    }
}
