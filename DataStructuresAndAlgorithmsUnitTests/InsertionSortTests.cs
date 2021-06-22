using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataStructuresAndAlgorithms.Sorts;
using System;

namespace DataStructuresAndAlgorithmsUnitTests
{
    [TestClass]
    public class InsertionSortTests
    {
        [TestMethod]
        public void InsertionSort_NullList_ThrowArgumentNullException()
        {
            List<string> list = null;

            Action actual = () => list.InsertionSort();

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void InsertionSort_MissingIComparable_NotSupportedException()
        {
            List<EmptyTestClass> list = new List<EmptyTestClass>();

            Action actual = () => list.InsertionSort();

            Assert.ThrowsException<NotSupportedException>(actual);
        }

        [TestMethod]
        public void InsertionSort_MixIComparableList_InvalidOperationException()
        {
            List<IComparable> list = new List<IComparable>() { 1, "SS" };

            Action actual = () => list.InsertionSort();

            Assert.ThrowsException<InvalidOperationException>(actual);
        }

        [TestMethod]
        public void InsertionSort_EmptyIComparableString_ListIsTheSame()
        {
            List<string> list = new List<string>();

            list.InsertionSort();

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void InsertionSort_SingelElementList_ListIsTheSame()
        {
            var list = new List<string>() { "A" };
            var output = new List<string>() { "A" };

            list.InsertionSort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void InsertionSort_TwoElementsList_ListSorted()
        {
            var list = new List<string>() { "Zoe", "Alex" };
            var output = new List<string>() { "Alex", "Zoe" };

            list.InsertionSort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void InsertionSort_UnsortedList_ListSorted()
        {
            var list = new List<string>() { "Zoe", "Alex", "Catherine", "Kim", "3", "Alex", "alex" };
            var output = new List<string>(list);

            list.InsertionSort();
            output.Sort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void InsertionSort_SortedList_ListSorted()
        {
            var sortedList = new List<string>() { "A", "B", "C", "D", "X", "Y", "Z" };
            sortedList.Sort();
            var list = new List<string>(sortedList);

            list.InsertionSort();

            CollectionAssert.AreEqual(list, sortedList);
        }

        [TestMethod]
        public void InsertionSort_ListWithNullElements_ListSortedNullsAtStart()
        {
            var list = new List<string>() { "A", "B", "C", null, "X", null, "Z" };
            var output = new List<string>(list);

            list.InsertionSort();
            output.Sort();

            CollectionAssert.AreEqual(list, output);
        }
    }
}
