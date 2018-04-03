using System;
using System.Collections.Generic;
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

        public BinaryTreeNode<T> Left => _childern[0] as BinaryTreeNode<T>;

        public BinaryTreeNode<T> Right => _childern[1] as BinaryTreeNode<T>;
        
        public BinaryTreeNode<T> AddLeft(T value)
        {
            _childern[0] = new BinaryTreeNode<T>(value, this);

            return Left;
        }

        public BinaryTreeNode<T> AddRight(T value)
        {
            _childern[1] = new BinaryTreeNode<T>(value, this);

            return Right;
        }

        public new IEnumerable<BinaryTreeNode<T>> Children => base.Children.OfType<BinaryTreeNode<T>>();
    }
}
