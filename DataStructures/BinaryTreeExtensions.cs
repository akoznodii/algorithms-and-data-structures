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

        public static BinaryTreeNode<T> FindMaximum<T>(this BinaryTreeNode<T> node)
        {
            if (node == null) throw new ArgumentNullException();

            if (node.Right == null)
            {
                return node;
            }

            return FindMaximum<T>(node.Right);
        }
        
        public static BinaryTreeNode<T> FindMinimum<T>(this BinaryTreeNode<T> node)
        {
            if (node == null) throw new ArgumentNullException();

            if (node.Left == null)
            {
                return node;
            }

            return FindMinimum<T>(node.Left);
        }
        
        public static BinaryTreeNode<T> Successor<T>(this BinaryTreeNode<T> node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            
            if (node.Right != null)
            {
                return FindMaximum(node.Right);
            }

            var parent = node.Parent as BinaryTreeNode<T>;

            while (parent != null && node != parent.Left)
            {
                node = parent;
                parent = node.Parent as BinaryTreeNode<T>;
            }

            return parent;
        }
        
        
        public static BinaryTreeNode<T> Predecessor<T>(this BinaryTreeNode<T> node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            
            if (node.Left != null)
            {
                return FindMaximum(node.Left);
            }

            var parent = node.Parent as BinaryTreeNode<T>;

            while (parent != null && node != parent.Right)
            {
                node = parent;
                parent = node.Parent as BinaryTreeNode<T>;
            }

            return parent;
        }

        public static BinaryTreeNode<T> Search<T>(this BinaryTreeNode<T> node, T value) where T : IComparable<T>
        {
            var result = value.CompareTo(node.Value);

            if (result == 0)
            {
                return node;
            } 
            
            if (result == -1)
            {
                if (node.Left != null)
                {
                    return Search<T>(node.Left, value);
                }
            }
            else if (node.Right != null)
            {
                return Search<T>(node.Right, value);
            }
            
            return null;
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
