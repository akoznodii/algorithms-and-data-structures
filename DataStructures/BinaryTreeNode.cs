using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace DataStructures
{
    public class BinaryTreeNode<T> : TreeNode<T>
    {
        public BinaryTreeNode(T value, TreeNode<T> parent)
            : base(value, parent)
        {
            _childern.Add(null);
            _childern.Add(null);
        }

        public BinaryTreeNode<T> Left
        {
            get => _childern[0] as BinaryTreeNode<T>;

            set
            {
                _childern[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get => _childern[1] as BinaryTreeNode<T>;

            set
            {
                _childern[1] = value;
            }
        }

        public new BinaryTreeNode<T> Parent
        {   
            get => base.Parent as BinaryTreeNode<T>;

            set
            {
                base.Parent = value;
            }
        }
        public BinaryTreeNode<T> AddLeft(T value)
        {
            return Left = new BinaryTreeNode<T>(value, this);
        }

        public BinaryTreeNode<T> AddRight(T value)
        {
            return Right = new BinaryTreeNode<T>(value, this);
        }

        public new IEnumerable<BinaryTreeNode<T>> Children => base.Children.OfType<BinaryTreeNode<T>>();
    }
}
