using System;
using Xunit;
using src;
using FluentAssertions;

namespace test
{
    public class BtsTests
    {
        [Fact]
        public void Create_GivenValidArguments_ExpectSuccess()
        {
            //Given
            var tree = new BST();

            //When & Then
            Assert.Null(tree.Root);
        }

        [Fact]
        public void Add_GivenEmptyTree_ExpectRootData()
        {
            //Given
            var expectedRoot = new Node(3);
            var tree = new BST();

            //When
            tree.Add(3);

            //Then
            tree.Root.Should().BeEquivalentTo(expectedRoot);
        }

        [Fact]
        public void Add_GivenDataLessThanRoot_ExpectNewLeftChildOfRoot()
        {
            //Given
            var expected = new BST { Root = new Node(3) };
            expected.Root.Left = new Node(2);
            var tree = new BST { Root = new Node(3) };

            //When
            tree.Add(2);

            //Then
            tree.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Add_GivenDataGreaterThanRoot_ExpectNewRightChildOfRoot()
        {
            //Given
            var expected = new BST { Root = new Node(3) };
            expected.Root.Right = new Node(4);
            var tree = new BST { Root = new Node(3) };

            //When
            tree.Add(4);

            //Then
            tree.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Add_GivenDataLessThanRoot_ExpectNewNodeInLeftSubTree()
        {
            //Given
            var expected = new BST { Root = new Node(3) };
            expected.Root.Left = new Node(2);
            expected.Root.Right = new Node(4);
            expected.Root.Left.Left = new Node(1);
            var tree = new BST { Root = new Node(3) };
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(4);

            //When
            tree.Add(1);

            //Then
            tree.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Add_GivenDataLessThanRoot_ExpectNewNodeInLeftSubTree2()
        {
            //Given
            var expected = new BST { Root = new Node(3) };
            expected.Root.Left = new Node(2);
            expected.Root.Right = new Node(4);
            expected.Root.Left.Left = new Node(1);
            expected.Root.Left.Left.Left = new Node(0);
            var tree = new BST { Root = new Node(3) };
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(4);
            tree.Root.Left.Left = new Node(1);

            //When
            tree.Add(0);

            //Then
            tree.Should().BeEquivalentTo(expected);
        }
    }
}