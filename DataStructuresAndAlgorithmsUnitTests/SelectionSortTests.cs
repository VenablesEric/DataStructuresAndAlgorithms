using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataStructuresAndAlgorithms.Sorts;
using System;

namespace DataStructuresAndAlgorithmsUnitTests
{
    [TestClass]
    public class SelectionSortTests
    {
        [TestMethod]
        public void SelectionSort_NullList_ThrowArgumentNullException()
        {
            List<string> list = null;

            Action actual = () => list.SelectionSort();

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void SelectionSort_MissingIComparable_NotSupportedException()
        {
            List<EmptyTestClass> list = new List<EmptyTestClass>();

            Action actual = () => list.SelectionSort();

            Assert.ThrowsException<NotSupportedException>(actual);
        }

        [TestMethod]
        public void SelectionSort_MixIComparableList_InvalidOperationException()
        {
            List<IComparable> list = new List<IComparable>() { 1, "SS" };

            Action actual = () => list.SelectionSort();

            Assert.ThrowsException<InvalidOperationException>(actual);
        }

        [TestMethod]
        public void SelectionSort_EmptyIComparableString_ListIsTheSame()
        {
            List<string> list = new List<string>();

            list.SelectionSort();

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void SelectionSort_SingelElementList_ListIsTheSame()
        {
            var list = new List<string>() { "A" };
            var output = new List<string>() { "A" };

            list.SelectionSort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void SelectionSort_TwoElementsList_ListSorted()
        {
            var list = new List<string>() { "Zoe", "Alex" };
            var output = new List<string>() { "Alex", "Zoe" };

            list.SelectionSort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void SelectionSort_UnsortedList_ListSorted()
        {
            var list = new List<string>() { "Zoe", "Alex", "Catherine", "Kim", "3", "Alex", "alex" };
            var output = new List<string>(list);

            list.SelectionSort();
            output.Sort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void SelectionSort_SortedList_ListSorted()
        {
            var sortedList = new List<string>() { "A", "B", "C", "D", "X", "Y", "Z" };
            sortedList.Sort();
            var list = new List<string>(sortedList);

            list.SelectionSort();

            CollectionAssert.AreEqual(list, sortedList);
        }

        [TestMethod]
        public void SelectionSort_ListWithNullElements_ListSortedNullsAtStart()
        {
            var list = new List<string>() { "A", "B", "C", null, "X", null, "Z" };
            var output = new List<string>(list);

            list.SelectionSort();
            output.Sort();

            CollectionAssert.AreEqual(list, output);
        }
    }
}
