using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresAndAlgorithms.DataStructures.LinkedList;
using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithmsUnitTests.LinkedListTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void LinkedList_AddNullObject_ThrowArgumentNullException()
        {
            Action actual = () => new CustomLinkedList<string>(null);

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void LinkedList_AddString_AddToLinkedLIst()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>("Hello, World!");


            Assert.AreEqual("Hello, World!", linkedList.ToString());
        }

        [TestMethod]
        public void Add_AddNullObject_ThrowArgumentNullException()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            Action actual = () => linkedList.Add(null);

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void Add_AddStringWithEmptyConstructor_AddToLinkedLIst()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            linkedList.Add("Hello, World!");

            Assert.AreEqual("Hello, World!", linkedList.ToString());
        }

        [TestMethod]
        public void Add_AddingStrings_PrintObjectsInAddedOrder()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void Add_InsertNull_ThrowArgumentNullException()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            Action actual = () => linkedList.Add(1, null);

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void Add_InsertStringAtStart_ValueIsAtStart()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            linkedList.Add(0, list[0]);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void Add_InsertStringAtEnd_ValueIsAtEnd()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);

            linkedList.Add(5, list[5]);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void Add_InsertStringOverMaxCount_ValueIsAtEnd()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);

            linkedList.Add(365, list[5]);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void Add_InsertWithNegativeIndex_ThrowsIndexOutOfRangeException()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);

            Action actual = () => linkedList.Add(-1, list[5]);

            Assert.ThrowsException<IndexOutOfRangeException>(actual);
        }

        [TestMethod]
        public void AddFirst_AddNull_ThrowArgumentNullException()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            Action actual = () => linkedList.AddFirst(null);

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void AddFirst_AddStringToEmptyList_AddsToStart()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            linkedList.AddFirst("Hello, World!");

            Assert.AreEqual("Hello, World!", linkedList.ToString());
        }

        [TestMethod]
        public void AddFirst_AddString_AddsToStart()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            linkedList.AddFirst(list[0]);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void AddLast_AddNull__ThrowArgumentNullException()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            Action actual = () => linkedList.AddLast(null);

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void AddLast_AddStringToEmptyList_AddToEnd()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            linkedList.AddLast("Hello, World!");

            Assert.AreEqual("Hello, World!", linkedList.ToString());
        }

        [TestMethod]
        public void AddLast_AddString_AddToEnd()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);

            linkedList.AddLast(list[5]);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void Clear_ClearEmptyLinkedList_ReturnEmptyList()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            linkedList.Clear();

            CollectionAssert.AreEqual(new List<string>(), linkedList.ToList());
        }

        [TestMethod]
        public void Clear_ClearLinkedList_ReturnEmptyList()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            linkedList.Clear();

            CollectionAssert.AreEqual(new List<string>(), linkedList.ToList());
        }

        [TestMethod]
        public void Contains_Null_ThrowArgumentNullException()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            Action actual = () => linkedList.Contains(null);

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void Contains_ObjectInList_ReturnsTrue()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            Assert.IsTrue(linkedList.Contains("Bob"));
        }

        [TestMethod]
        public void Contains_ObjectNotInList_ReturnsFalse()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            Assert.IsFalse(linkedList.Contains("None"));
        }

        [TestMethod]
        public void Get_NegativeNumber_ThrowIndexOutOfRangeException()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            Action actual = () => linkedList.Get(-1);

            Assert.ThrowsException<IndexOutOfRangeException>(actual);
        }

        [TestMethod]
        public void Get_OutOfRange_ThrowIndexOutOfRangeException()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            Action actual = () => linkedList.Get(100);

            Assert.ThrowsException<IndexOutOfRangeException>(actual);
        }

        [TestMethod]
        public void Get_GetObjectByIndex_ReturnsCorrectObject()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            string output = linkedList.Get(3);

            Assert.AreEqual("Zoe", output);
        }

        [TestMethod]
        public void Get_GetFirstObjectByIndex_ReturnsCorrectObject()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            string output = linkedList.Get(0);

            Assert.AreEqual("Jane", output);
        }

        [TestMethod]
        public void Get_GetLastObjectByIndex_ReturnsCorrectObject()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            string output = linkedList.Get(5);

            Assert.AreEqual("James", output);
        }

        [TestMethod]
        public void GetFirst_EmptyLinkedList_ThrowIndexOutOfRangeException()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            Action actual = () => linkedList.GetFirst();

            Assert.ThrowsException<IndexOutOfRangeException>(actual);
        }

        [TestMethod]
        public void GetFirst_FullLinkedList_ReturnFirstValue()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            string output = linkedList.GetFirst();

            Assert.AreEqual(list[0], output);
        }

        [TestMethod]
        public void GetLast_EmptyinkedList_ThrowIndexOutOfRangeException()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            Action actual = () => linkedList.GetLast();

            Assert.ThrowsException<IndexOutOfRangeException>(actual);
        }

        [TestMethod]
        public void GetLast_FullLinkedList_ReturnLastValue()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            string output = linkedList.GetLast();

            Assert.AreEqual(list[5], output);
        }

        [TestMethod]
        public void IndexOf_NullValue_ThrowArgumentNullException()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            Action actual = () => linkedList.IndexOf(null);

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void IndexOf_EmptyListedList_ReturnNegativeValue()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            int output = linkedList.IndexOf("Hello, World!");

            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void IndexOf_ValueNotInLinkedList_ReturnNegativeValue()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            int output = linkedList.IndexOf("Hello, World!");

            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void IndexOf_ValueInLinkedList_ReturnValuesIndex()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            int output = linkedList.IndexOf("Bob");

            Assert.AreEqual(2, output);
        }

        [TestMethod]
        public void LastIndexOf_NullValue_ThrowArgumentNullException()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "Jane", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);
            linkedList.Add(list[6]);

            Action actual = () => linkedList.LastIndexOf(null);

            Assert.ThrowsException<ArgumentNullException>(actual);
        }

        [TestMethod]
        public void LastIndexOf_EmptyListedList_ReturnNegativeValue()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            int output = linkedList.LastIndexOf("Bob");

            Assert.AreEqual(-1, output);
        }

        [TestMethod]
        public void LastIndexOf_ValueNotInLinkedList_ReturnNegativeValue()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "Jane", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);
            linkedList.Add(list[6]);

            int output = linkedList.LastIndexOf("John");

            Assert.AreEqual(-1, output);
        }


        [TestMethod]
        public void LastIndexOf_OneValueInLinkedList_ReturnValuesIndex()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            int output = linkedList.LastIndexOf("Alex");

            Assert.AreEqual(4, output);
        }


        [TestMethod]
        public void LastIndexOf_TwoValueInLinkedList_ReturnValuesIndex()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "Jane", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);
            linkedList.Add(list[6]);

            int output = linkedList.LastIndexOf("Jane");

            Assert.AreEqual(5, output);
        }

        [TestMethod]
        public void Remove_NegativeValue_ThrowIndexOutOfRangeException()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            Action actual = () => linkedList.Remove(-1);

            Assert.ThrowsException<IndexOutOfRangeException>(actual);
        }

        [TestMethod]
        public void Remove_OutOfRangeIndex_ThrowIndexOutOfRangeException()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            Action actual = () => linkedList.Remove(10);

            Assert.ThrowsException<IndexOutOfRangeException>(actual);
        }

        [TestMethod]
        public void Remove_ValidIndex_RemovedObjectAtIndex()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            linkedList.Remove(2);
            list.RemoveAt(2);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void Remove_FirstIndex_RemovedObjectAtIndex()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            linkedList.Remove(0);
            list.RemoveAt(0);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void Remove_LastIndex_RemovedObjectAtIndex()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            linkedList.Remove(5);
            list.RemoveAt(5);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void Remove_NullObject_ThrowArgumentNullException()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            Assert.IsFalse(linkedList.Remove(null));
        }

        [TestMethod]
        public void Remove_EmptyList_ReturnFalse()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            Assert.IsFalse(linkedList.Remove("Hello, World!"));
        }

        [TestMethod]
        public void Remove_ValidObjectInList_RemoveObjectFromList()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            linkedList.Remove("Bob");
            list.RemoveAt(2);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void Remove_ObjectNotInList_ReturnNull()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            Assert.IsFalse(linkedList.Remove("Ben"));
        }

        [TestMethod]
        public void Remove_FirstObjectInList_RemoveObject()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            linkedList.Remove("Jane");
            list.RemoveAt(0);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void Remove_LastObjectInList_RemoveObject()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            linkedList.Remove("James");
            list.RemoveAt(5);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void RemoveFirst_NullList_ThrowsIndexOutOfRangeException()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            Action actual = () => linkedList.RemoveFirst();

            Assert.ThrowsException<IndexOutOfRangeException>(actual);
        }

        [TestMethod]
        public void RemoveFirst_FullList_RemovedFirstObject()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            linkedList.RemoveFirst();
            list.RemoveAt(0);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }

        [TestMethod]
        public void RemoveLast_NullList_ThrowsIndexOutOfRangeException()
        {
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            Action actual = () => linkedList.RemoveLast();

            Assert.ThrowsException<IndexOutOfRangeException>(actual);
        }

        [TestMethod]
        public void RemoveLast_FullList_RemovedLastObject()
        {
            List<string> list = new List<string> { "Jane", "Mike", "Bob", "Zoe", "Alex", "James" };
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>(list[0]);
            linkedList.Add(list[1]);
            linkedList.Add(list[2]);
            linkedList.Add(list[3]);
            linkedList.Add(list[4]);
            linkedList.Add(list[5]);

            linkedList.RemoveLast();
            list.RemoveAt(5);

            CollectionAssert.AreEqual(list, linkedList.ToList());
        }
    }
}
