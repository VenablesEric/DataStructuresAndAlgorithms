using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataStructuresAndAlgorithms;
using System;


namespace DataStructuresAndAlgorithmsUnitTests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void MergeSort_NullList_ThrowArgumentNullException()
        {
            List<string> list = null;

            Action actual = () => Sorts.MergeSort<string>(list);

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void MergeSort_MissingIComparable_NotSupportedException()
        {
            List<EmptyTestClass> list = new List<EmptyTestClass>();

            Action actual = () => Sorts.MergeSort<EmptyTestClass>(list);

            Assert.ThrowsException<NotSupportedException>(actual);
        }

        [TestMethod]
        public void MergeSort_MixIComparableList_InvalidOperationException()
        {
            List<IComparable> list = new List<IComparable>() { 1, "SS" };

            Action actual = () => Sorts.MergeSort<IComparable>(list);

            Assert.ThrowsException<InvalidOperationException>(actual);
        }

        [TestMethod]
        public void MergeSort_EmptyIComparableString_ListIsTheSame()
        {
            List<string> list = new List<string>();

            list = Sorts.MergeSort<string>(list);

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void MergeSort_SingelElementList_ListIsTheSame()
        {
            var list = new List<string>() { "A" };
            var output = new List<string>() { "A" };

            list = Sorts.MergeSort<string>(list);

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void MergeSort_TwoElementsList_ListSorted()
        {
            var list = new List<string>() { "Zoe", "Alex" };
            var output = new List<string>() { "Alex", "Zoe" };

             list = Sorts.MergeSort<string>(list);

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void MergeSort_UnsortedList_ListSorted()
        {
            var list = new List<string>() { "Zoe", "Alex", "Catherine", "Kim", "3", "Alex", "alex" };
            var output = new List<string>(list);

            list = Sorts.MergeSort<string>(list);
            output.Sort();

            CollectionAssert.AreEqual(list, output);
        }

        [TestMethod]
        public void MergeSort_SortedList_ListSorted()
        {
            var sortedList = new List<string>() { "A", "B", "C", "D", "X", "Y", "Z" };
            sortedList.Sort();
            var list = new List<string>(sortedList);

            list = Sorts.MergeSort<string>(list);

            CollectionAssert.AreEqual(list, sortedList);
        }

        [TestMethod]
        public void MergeSort_ListWithNullElements_ListSortedNullsAtStart()
        {
            var list = new List<string>() { "A", "B", "C", null, "X", null, "Z" };
            var output = new List<string>(list);

            list = Sorts.MergeSort<string>(list);
            output.Sort();

            CollectionAssert.AreEqual(list, output);
        }
    }
}
