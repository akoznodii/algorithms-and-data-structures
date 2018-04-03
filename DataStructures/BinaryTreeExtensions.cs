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

        public static void BinarySearchTreeInsert<T>(this BinaryTreeNode<T> node, T value) where T : IComparable<T>
        {
            Contract.Requires(node != null);

            var result = value.CompareTo(node.Value);

            if (result == 0)
            {
                return;
            }
            else if (result == -1)
            {
                if (node.Left == null)
                {
                    node.AddLeft(value);
                }
                else
                {
                    BinarySearchTreeInsert(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.AddRight(value);
                }
                else
                {
                    BinarySearchTreeInsert(node.Right, value);
                }
            }
        }
    }
}
