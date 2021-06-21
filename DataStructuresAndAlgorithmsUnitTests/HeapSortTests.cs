using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataStructuresAndAlgorithms;
using System;

namespace DataStructuresAndAlgorithmsUnitTests
{
    [TestClass]
    public class HeapSortTests
    {
        [TestMethod]
        public void HeapSort_NullList_ThrowArgumentNullException()
        {
            List<string> list = null;

            Action actual = () => list.HeapSort();

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void HeapSort_MissingIComparable_NotSupportedException()
        {
            List<EmptyTestClass> list = new List<EmptyTestClass>();

            Action actual = () => list.HeapSort();

            Assert.ThrowsException<NotSupportedException>(actual);
        }

        [TestMethod]
        public void HeapSort_MixIComparableList_InvalidOperationException()
        {
            List<IComparable> list = new List<IComparable>() { 1, "SS" };

            Action actual = () => list.HeapSort();

            Assert.ThrowsException<InvalidOperationException>(actual);
        }

        [TestMethod]
        public void HeapSort_EmptyIComparableString_ListIsTheSame()
        {
            List<string> list = new List<string>();

            list.HeapSort();

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void HeapSort_SingelElementList_ListIsTheSame()
        {
            var list = new List<string>() { "A" };
            var output = new List<string>() { "A" };

            list.HeapSort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void HeapSort_TwoElementsList_ListSorted()
        {
            var list = new List<string>() { "Zoe", "Alex" };
            var output = new List<string>() { "Alex", "Zoe" };

            list.HeapSort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void HeapSort_UnsortedList_ListSorted()
        {
            var list = new List<string>() { "Zoe", "Alex", "Catherine", "Kim", "3", "Alex", "alex" };
            var output = new List<string>(list);

            list.HeapSort();
            output.Sort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void HeapSort_SortedList_ListSorted()
        {
            var sortedList = new List<string>() { "A", "B", "C", "D", "X", "Y", "Z" };
            sortedList.Sort();
            var list = new List<string>(sortedList);

            list.HeapSort();

            CollectionAssert.AreEqual(list, sortedList);
        }

        [TestMethod]
        public void HeapSort_ListWithNullElements_ListSortedNullsAtStart()
        {
            var list = new List<string>() { "A", "B", "C", null, "X", null, "Z" };
            var output = new List<string>(list);

            list.HeapSort();
            output.Sort();

            CollectionAssert.AreEqual(list, output);
        }
    }
}
