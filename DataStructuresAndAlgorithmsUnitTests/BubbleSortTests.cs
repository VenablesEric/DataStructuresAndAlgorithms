using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataStructuresAndAlgorithms;
using System;

namespace DataStructuresAndAlgorithmsUnitTests
{
    [TestClass]
    public class BubbleSortTests
    {
        [TestMethod]
        public void BubbleSort_NullList_ThrowArgumentNullException()
        {
            List<string> list = null;
            
            Action actual = () => list.BubbleSort();

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void BubbleSort_MissingIComparable_NotSupportedException()
        {
            List<EmptyTestClass> list = new List<EmptyTestClass>();

            Action actual = () => list.BubbleSort();

            Assert.ThrowsException<NotSupportedException>(actual);
        }

        [TestMethod]
        public void BubbleSort_MixIComparableList_InvalidOperationException()
        {
            List<IComparable> list = new List<IComparable>() { 1, "SS"};

            Action actual = () => list.BubbleSort();

            Assert.ThrowsException<InvalidOperationException>(actual);
        }

        [TestMethod]
        public void BubbleSort_EmptyIComparableString_ListIsTheSame()
        {
            List<string> list = new List<string>();

            list.BubbleSort();

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void BubbleSort_SingelElementList_ListIsTheSame()
        {
            var list = new List<string>() { "A" };
            var output = new List<string>() { "A" };

            list.BubbleSort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void BubbleSort_TwoElementsList_ListSorted()
        {
            var list = new List<string>() { "Zoe", "Alex" };
            var output = new List<string>() { "Alex", "Zoe" };

            list.BubbleSort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void BubbleSort_UnsortedList_ListSorted()
        {
            var list = new List<string>() { "Zoe", "Alex", "Catherine", "Kim", "3", "Alex", "alex"};
            var output = new List<string>(list);

            list.BubbleSort();
            output.Sort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void BubbleSort_SortedList_ListSorted()
        {
            var sortedList = new List<string>() { "A", "B", "C", "D", "X", "Y", "Z" };
            sortedList.Sort();
            var list = new List<string>(sortedList);

            list.BubbleSort();

            CollectionAssert.AreEqual(list, sortedList);
        }

        [TestMethod]
        public void BubbleSort_ListWithNullElements_ListSortedNullsAtStart()
        {
            var list = new List<string>() { "A", "B", "C", null, "X", null, "Z" };
            var output = new List<string>(list);

            list.BubbleSort();
            output.Sort();

            CollectionAssert.AreEqual(list, output);
        }
    }
}
