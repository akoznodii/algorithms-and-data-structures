using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace DataStructures
{
    public static class BinarySearchTreeExtensions
    {
        public static T Minimum<T>(this BinaryTreeNode<T> node)
        {
            return MinimumNode(node).Value;
        }

        public static BinaryTreeNode<T> MinimumNode<T>(this BinaryTreeNode<T> node)
        {
            Contract.Requires(node != null);

            if (node.Left == null)
            {
                return node;
            }

            return MinimumNode(node.Left);
        }

        public static T Maximum<T>(this BinaryTreeNode<T> node)
        {
            return MaximumNode(node.Right).Value;
        }

        public static BinaryTreeNode<T> MaximumNode<T>(this BinaryTreeNode<T> node)
        {
            Contract.Requires(node != null);

            if (node.Right == null)
            {
                return node;
            }

            return MaximumNode(node.Right);
        }

        public static BinaryTreeNode<T> Search<T>(this BinaryTreeNode<T> node, T value) where T : IComparable<T>
        {
            Contract.Requires(node != null);

            var result = value.CompareTo(node.Value);

            if (result == 0)
            {
                return node;
            }

            if (result == -1)
            {
                if (node.Left == null)
                {
                    return null;
                }

                return Search(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                {
                    return null;
                }

                return Search(node.Right, value);
            }

        }

        public static void Insert<T>(this BinaryTreeNode<T> node, T value) where T : IComparable<T>
        {
            Contract.Requires(node != null);

            var result = value.CompareTo(node.Value);

            if (result == 0)
            {
                return;
            }

            if (result == -1)
            {
                if (node.Left == null)
                {
                    node.AddLeft(value);
                }
                else
                {
                    Insert(node.Left, value);
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
                    Insert(node.Right, value);
                }
            }
        }

        public static BinaryTreeNode<T> Delete<T>(this BinaryTreeNode<T> node, T value) where T : IComparable<T>
        {
            Contract.Requires(node != null);

            var deleteNode = Search(node, value);

            if (deleteNode == null ||
                deleteNode.Parent == null)
            {
                return node;
            }

            if (deleteNode == node)
            {
                return null;
            }

            if (!deleteNode.Children.Any())
            {
                Replace(deleteNode, null);
            }
            else if (deleteNode.Children.Count() == 2)
            {
                var minimumNode = MinimumNode(deleteNode.Right);

                Replace(minimumNode, minimumNode.Right);
                Replace(deleteNode, minimumNode);

                deleteNode.Left.Parent = minimumNode;
                deleteNode.Right.Parent = minimumNode;

                minimumNode.Left = deleteNode.Left;
                minimumNode.Right = deleteNode.Right;
            }
            else
            {
                var childNode = deleteNode.Right ?? deleteNode.Left;

                Replace(deleteNode, childNode);
            }

            return node;
        }

        private static void Replace<T>(BinaryTreeNode<T> node, BinaryTreeNode<T> replace) where T : IComparable<T>
        {
            Contract.Requires(node != null);

            if (replace != null)
            {
                replace.Parent = node.Parent;
            }

            if (node.Parent != null)
            {
                var parentCompare = node.Parent.Value.CompareTo(node.Value);

                if (parentCompare > 0)
                {
                    node.Parent.Left = replace;
                }
                else
                {
                    node.Parent.Right = replace;
                }
            }

        }
    }
}
