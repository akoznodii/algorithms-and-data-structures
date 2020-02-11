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
            var array = new int[] { 4, 3, 6, 1, 2, 8, 7 };

            var root = new BinaryTreeNode<int>(array[0], null);
            var idx = 1;

            for (idx = 1; idx < array.Length; idx++)
            {
                root.BinarySearchTreeInsert(array[idx]);
            }

            var expected = array.OrderBy(i => i).ToArray();

            idx = 0;
            root.InOrderTraversal((value) => { Assert.AreEqual<int>(expected[idx], value); idx++; });
            
            Assert.AreEqual(8, root.FindMaximum().Value);
            Assert.AreEqual(1, root.FindMinimum().Value);

            var node = root.Search(7);
            
            Assert.IsNotNull(node);
            Assert.AreEqual(7, node.Value);

            var predecessor = node.Predecessor();
            
            Assert.IsNotNull(predecessor);
            Assert.AreEqual(6, predecessor.Value);

            var successor = node.Successor();
            
            Assert.IsNotNull(successor);
            Assert.AreEqual(8, successor.Value);
        }
    }
}
