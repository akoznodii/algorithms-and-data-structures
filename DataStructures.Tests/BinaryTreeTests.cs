using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void TraverseTests()
        {
            var root = new BinaryTreeNode<int>(1, null);
            var left = root.AddLeft(2); left.AddRight(5); left.AddLeft(4);
            root.AddRight(3);

            var inOrderArray = new int[] { 4, 2, 5, 1, 3 };
            var preOrderArray = new int[] { 1, 2, 4, 5, 3 };
            var postOrderArray = new int[] { 4, 5, 2, 3, 1 };

            var idx = 0;

            root.InOrderTraversal((value) => { Assert.AreEqual<int>(inOrderArray[idx], value); idx++; });
            idx = 0;
            root.PreOrderTraversal((value) => { Assert.AreEqual<int>(preOrderArray[idx], value); idx++; });
            idx = 0;
            root.PostOrderTraversal((value) => { Assert.AreEqual<int>(postOrderArray[idx], value); idx++; });
        }

        [TestMethod]
        public void BinarySearchTreeTest()
        {
            var array = new List<int> { 4, 3, 6, 1, 2, 8, 7, 10, 9, 12, 11 };

            var root = new BinaryTreeNode<int>(array[0], null);
            var idx = 1;

            for (idx = 1; idx < array.Count; idx++)
            {
                root.Insert(array[idx]);
            }

            var expected = array.OrderBy(i => i).ToList();

            idx = 0;
            root.InOrderTraversal((value) => { Assert.AreEqual<int>(expected[idx], value); idx++; });

            var minimum = root.Minimum();

            Assert.AreEqual(1, minimum);

            var maximum = root.Maximum();

            Assert.AreEqual(12, maximum);

            DeleteBinarySearchTree(root, 8, expected);
            DeleteBinarySearchTree(root, 2, expected);
            DeleteBinarySearchTree(root, 9, expected);
        }

        private void DeleteBinarySearchTree(BinaryTreeNode<int> root, int value, IList<int> expected)
        {
            root.Delete(value);

            expected.Remove(value);

            var idx = 0;
            root.InOrderTraversal((v) => { Assert.AreEqual<int>(expected[idx], v); idx++; });
        }
    }
}
