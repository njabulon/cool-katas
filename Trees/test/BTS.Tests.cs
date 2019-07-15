using System;
using System.Collections.Generic;
using FluentAssertions;
using src;
using Xunit;

namespace test {
    public class BtsTests {
        [Fact]
        public void Create_GivenValidArguments_ExpectSuccess () {
            //Given
            var tree = new BST ();

            //When & Then
            Assert.Null (tree.Root);
        }

        [Fact]
        public void Add_GivenEmptyTree_ExpectRootData () {
            //Given
            var expectedRoot = new Node (3);
            var tree = new BST ();

            //When
            tree.Add (3);

            //Then
            tree.Root.Should ().BeEquivalentTo (expectedRoot);
        }

        [Fact]
        public void Add_GivenDataLessThanRoot_ExpectNewLeftChildOfRoot () {
            //Given
            var expected = new BST { Root = new Node (3) };
            expected.Root.Left = new Node (2);
            var tree = new BST { Root = new Node (3) };

            //When
            tree.Add (2);

            //Then
            tree.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void Add_GivenDataGreaterThanRoot_ExpectNewRightChildOfRoot () {
            //Given
            var expected = new BST { Root = new Node (3) };
            expected.Root.Right = new Node (4);
            var tree = new BST { Root = new Node (3) };

            //When
            tree.Add (4);

            //Then
            tree.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void Add_GivenDataLessThanRoot_ExpectNewNodeInLeftSubTree () {
            //Given
            var expected = new BST { Root = new Node (3) };
            expected.Root.Left = new Node (2);
            expected.Root.Right = new Node (4);
            expected.Root.Left.Left = new Node (1);
            var tree = new BST { Root = new Node (3) };
            tree.Root.Left = new Node (2);
            tree.Root.Right = new Node (4);

            //When
            tree.Add (1);

            //Then
            tree.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void Add_GivenDataLessThanRoot_ExpectNewNodeInLeftSubTree2 () {
            //Given
            var expected = new BST { Root = new Node (3) };
            expected.Root.Left = new Node (2);
            expected.Root.Right = new Node (4);
            expected.Root.Left.Left = new Node (1);
            expected.Root.Left.Left.Left = new Node (0);
            var tree = new BST { Root = new Node (3) };
            tree.Root.Left = new Node (2);
            tree.Root.Right = new Node (4);
            tree.Root.Left.Left = new Node (1);

            //When
            tree.Add (0);

            //Then
            tree.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void PreOrderTravelsal_GivenValidTree_ExpectResult () {
            //Given
            var tree = new BST { Root = new Node (4) };
            tree.Root.Left = new Node (3);
            tree.Root.Right = new Node (5);
            tree.Root.Left.Left = new Node (1);
            tree.Root.Left.Right = new Node (2);
            tree.Root.Right.Left = new Node (6);
            tree.Root.Right.Right = new Node (7);

            var expected = new List<int> { 4, 3, 1, 2, 5, 6, 7 };

            //When
            var actual = Utilities.TreePreOrderTraversal (tree.Root);

            //Then
            actual.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void InOrderTravelsal_GivenValidTree_ExpectResult () {
            //Given
            var tree = new BST { Root = new Node (4) };
            tree.Root.Left = new Node (3);
            tree.Root.Right = new Node (5);
            tree.Root.Left.Left = new Node (1);
            tree.Root.Left.Right = new Node (2);
            tree.Root.Right.Left = new Node (6);
            tree.Root.Right.Right = new Node (7);

            var expected = new List<int> { 1, 3, 2, 4, 6, 5, 7 };

            //When
            var actual = Utilities.TreeInOrderTraversal (tree.Root);

            //Then
            actual.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void PostOrderTravelsal_GivenValidTree_ExpectResult () {
            //Given
            var tree = new BST { Root = new Node (4) };
            tree.Root.Left = new Node (3);
            tree.Root.Right = new Node (5);
            tree.Root.Left.Left = new Node (1);
            tree.Root.Left.Right = new Node (2);
            tree.Root.Right.Left = new Node (6);
            tree.Root.Right.Right = new Node (7);

            var expected = new List<int> { 1, 2, 3, 6, 7, 5, 4 };

            //When
            var actual = Utilities.TreePostOrderTraversal (tree.Root);

            //Then
            actual.Should ().BeEquivalentTo (expected);
        }

        [Fact]
        public void PostOrderTravelsal_GivenValidTree_ExpectResult2 () {
            //Given
            var tree = new BST { Root = new Node (20) };
            tree.Root.Left = new Node (15);
            tree.Root.Right = new Node (25);
            tree.Root.Left.Left = new Node (13);
            tree.Root.Left.Right = new Node (16);
            tree.Root.Right.Left = new Node (22);
            tree.Root.Right.Right = new Node (45);

            var expected = new List<int> { 13, 16, 15, 22, 45, 25, 20 };

            //When
            var actual = Utilities.TreePostOrderTraversal (tree.Root);

            //Then
            actual.Should ().BeEquivalentTo (expected);
        }
    }
}