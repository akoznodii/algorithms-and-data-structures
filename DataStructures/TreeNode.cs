using System.Collections.Generic;

namespace DataStructures
{
    public class TreeNode<T>
    {
        protected readonly List<TreeNode<T>> _childern;

        public TreeNode(T value, TreeNode<T> parent) 
        {
            Value = value;
            Parent = parent;
            _childern = new List<TreeNode<T>>();
        }

        public TreeNode<T> Parent { get; set; }

        public T Value { get; }

        public IEnumerable<TreeNode<T>> Children => _childern;
    }
}
