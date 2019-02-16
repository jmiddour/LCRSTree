using LCRSTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LCRSTreeTests
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void Tree_Enumerate()
        {
            // Arrange
        //    var child_sibling = new Node<int>() { Value = 3 };
            var root_child = new Node<int>() { Value = 2};
            var root_sibling = new Node<int>() { Value = 4 };

            var root = new Node<int>() { Value = 1,
                Child = root_child,
                Sibling = root_sibling };

            root_child.Parent = root;
     
            var t = new Tree<int>(root);

            // Act
            var enumer = t.GetEnumerator();
            enumer.MoveNext();

            // Assert
            Assert.AreEqual(1, enumer.Current.Value);
            enumer.MoveNext();
            Assert.AreEqual(2, enumer.Current.Value);
            enumer.MoveNext();
            Assert.AreEqual(4, enumer.Current.Value);
            
        }

        [TestMethod]
        public void Test_RootOnly()
        {
            //Arrange
            var root = new Node<int>() { Value = 1 };
            var t = new Tree<int>(root);

            //Act
            var enumer = t.GetEnumerator();
            enumer.MoveNext();
            var rootValue = enumer.Current.Value;
            var atEnd =!( enumer.MoveNext());

            //Assert

            Assert.AreEqual(1, rootValue);
            Assert.IsTrue(atEnd);
        }
    }
}
