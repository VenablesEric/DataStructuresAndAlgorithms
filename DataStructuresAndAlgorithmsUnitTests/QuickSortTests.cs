using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataStructuresAndAlgorithms;
using System;

namespace DataStructuresAndAlgorithmsUnitTests
{
    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        public void QuickSort_NullList_ThrowArgumentNullException()
        {
            List<string> list = null;

            Action actual = () => list.QuickSort();

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void QuickSort_MissingIComparable_NotSupportedException()
        {
            List<EmptyTestClass> list = new List<EmptyTestClass>();

            Action actual = () => list.QuickSort();

            Assert.ThrowsException<NotSupportedException>(actual);
        }

        [TestMethod]
        public void QuickSort_MixIComparableList_InvalidOperationException()
        {
            List<IComparable> list = new List<IComparable>() { 1, "SS" };

            Action actual = () => list.QuickSort();

            Assert.ThrowsException<InvalidOperationException>(actual);
        }

        [TestMethod]
        public void QuickSort_EmptyIComparableString_ListIsTheSame()
        {
            List<string> list = new List<string>();

            list.QuickSort();

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void QuickSort_SingelElementList_ListIsTheSame()
        {
            var list = new List<string>() { "A" };
            var output = new List<string>() { "A" };

            list.QuickSort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void QuickSort_TwoElementsList_ListSorted()
        {
            var list = new List<string>() { "Zoe", "Alex" };
            var output = new List<string>() { "Alex", "Zoe" };

            list.QuickSort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void QuickSort_UnsortedList_ListSorted()
        {
            var list = new List<string>() { "Zoe", "Alex", "Catherine", "Kim", "3", "Alex", "alex" };
            var output = new List<string>(list);

            list.QuickSort();
            output.Sort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void QuickSort_SortedList_ListSorted()
        {
            var sortedList = new List<string>() { "A", "B", "C", "D", "X", "Y", "Z" };
            sortedList.Sort();
            var list = new List<string>(sortedList);

            list.QuickSort();

            CollectionAssert.AreEqual(list, sortedList);
        }

        [TestMethod]
        public void QuickSort_ListWithNullElements_ListSortedNullsAtStart()
        {
            var list = new List<string>() { "A", "B", "C", null, "X", null, "Z" };
            var output = new List<string>(list);

            list.QuickSort();
            output.Sort();

            CollectionAssert.AreEqual(list, output);
        }
    }
}
