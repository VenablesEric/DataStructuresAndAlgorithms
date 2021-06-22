using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.Sorts
{
    public static class Sorts
    {

        /// <summary>
        ///  A Bubble Sort for List<T> that implements the Icomparable interface.
        ///  A Bubble Sort will push the heighest number to the end of the array and keep looping untill sorted.
        ///  Time Complexity: Best- O(n) | Average- O(n^2) | Worst- O(n^2).
        ///  Space Complexity: O(1).
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <exception cref="System.ArgumentNullException"> Thrown when <paramref name="list"/> is null.</exception>
        /// <exception cref="System.NotSupportedException"> Thrown when T does not implements the Icomparable interface.</exception>
        /// <exception cref="System.InvalidOperationException"> Thrown when compaison fails.</exception>  
        public static void BubbleSort<T>(this List<T> list)
        {
            ValidateObjectType<T>(list);

            int lastIndex = list.Count - 1;

            bool isSorted = true;
            do
            {
                isSorted = true;

                for (int i = 0; i < lastIndex; i++)
                {
                    if (Compare<T>(list[i], list[i + 1]) > 0)
                    {
                        Swap<T>(list, i, i + 1);
                        isSorted = false;
                    }
                }

                lastIndex--;
            } while (!isSorted);
        }

        /// <summary>
        ///  A Selection Sort for List<T> that implements the Icomparable interface.
        ///  A Selection Sort will find the smallest value and put it at the begining of the list then move to the next smallest.
        ///  Time Complexity: Best-  O(n^2) | Average- O(n^2) | Worst- O(n^2).
        ///  Space Complexity: O(1).
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <exception cref="System.ArgumentNullException"> Thrown when <paramref name="list"/> is null.</exception>
        /// <exception cref="System.NotSupportedException"> Thrown when T does not implements the Icomparable interface.</exception>
        /// <exception cref="System.InvalidOperationException"> Thrown when compaison fails.</exception>  
        public static void SelectionSort<T>(this List<T> list)
        {
            ValidateObjectType<T>(list);

            for (int i = 0; i < (list.Count - 1); i++)
            {
                int smallestValueIndex = i;

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (Compare<T>(list[j], list[smallestValueIndex]) < 0)
                        smallestValueIndex = j;
                }

                if (i != smallestValueIndex)
                    Swap<T>(list, i, smallestValueIndex);
            }
        }

        /// <summary>
        ///  A Insertion Sort for List<T> that implements the Icomparable interface.
        ///  Loop through the list and move next element backwards to its sorted position.
        ///  Time Complexity: Best-  O(n) | Average- O(n^2) | Worst- O(n^2).
        ///  Space Complexity: O(1).
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <exception cref="System.ArgumentNullException"> Thrown when <paramref name="list"/> is null.</exception>
        /// <exception cref="System.NotSupportedException"> Thrown when T does not implements the Icomparable interface.</exception>
        /// <exception cref="System.InvalidOperationException"> Thrown when compaison fails.</exception>  
        public static void InsertionSort<T>(this List<T> list)
        {
            ValidateObjectType<T>(list);

            for (int i = 1; i < list.Count; i++)
            {
                T obj = list[i];
                int previousIndex = i - 1;

                while (previousIndex >= 0 && Compare<T>(list[previousIndex], obj) > 0)
                {
                    list[previousIndex + 1] = list[previousIndex];
                    previousIndex--;
                }

                list[previousIndex + 1] = obj;
            }
        }

        /// <summary>
        ///  A Merge Sort for List<T> that implements the Icomparable interface.
        ///  Continuously breake up the list then sort and merge the result untill the list is sorted.
        ///  Time Complexity: Best-  O(n log(n)) | Average- O(n log(n)) | Worst- O(n log(n)).
        ///  Space Complexity: O(n).
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <returns> Returns sorted list.</returns>
        /// <exception cref="System.ArgumentNullException"> Thrown when <paramref name="list"/> is null.</exception>
        /// <exception cref="System.NotSupportedException"> Thrown when T does not implements the Icomparable interface.</exception> 
        /// <exception cref="System.InvalidOperationException"> Thrown when compaison fails.</exception>  
        public static List<T> MergeSort<T>(List<T> list)
        {
            ValidateObjectType<T>(list);

            return SplitSortMerge<T>(list);
        }

        /// <summary>
        ///  A Merge Sort for List<T> that implements the Icomparable interface.
        ///  Continuously breake up the list then sort and merge the result untill the list is sorted.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <returns> Returns sorted list</returns>
        public static List<T> SplitSortMerge<T>(List<T> list)
        {
            if (list.Count <= 1)
                return list;

            int midPoint = list.Count / 2;

            List<T> leftSide = SplitSortMerge<T>(list.GetRange(0, midPoint));
            List<T> rightSide = SplitSortMerge<T>(list.GetRange(midPoint, list.Count - midPoint));

            List<T> sortedList = Merge<T>(leftSide, rightSide);

            return sortedList;
        }

        /// <summary>
        ///  Merge and sort left and right into a singel list.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="leftSide"> Left sorted list.</param>
        /// <param name="rightSide"> Right sorted list.</param>
        /// <returns> Returns sorted merged list</returns>
        private static List<T> Merge<T>(List<T> leftSide, List<T> rightSide)
        {
            List<T> sortedList = new List<T>();

            int leftSideIndex = 0;
            int rightSideIndex = 0;

            while (leftSideIndex < leftSide.Count || rightSideIndex < rightSide.Count)
            {
                if (leftSideIndex < leftSide.Count &&
                 (rightSideIndex >= rightSide.Count || Compare<T>(leftSide[leftSideIndex], rightSide[rightSideIndex]) <= 0))
                {
                    sortedList.Add(leftSide[leftSideIndex]);
                    leftSideIndex++;
                }
                else
                {
                    sortedList.Add(rightSide[rightSideIndex]);
                    rightSideIndex++;
                }
            }

            return sortedList;
        }

        /// <summary>
        ///  A Quick Sort for List<T> that implements the Icomparable interface.
        ///  Select a pivot and sort elements on each side of the list.
        ///  Time Complexity: Best-  O(n log(n)) | Average- O(n log(n)) | Worst- O(n^2).
        ///  Space Complexity: O(log(n)).
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <exception cref="System.ArgumentNullException"> Thrown when <paramref name="list"/> is null.</exception>
        /// <exception cref="System.NotSupportedException"> Thrown when T does not implements the Icomparable interface.</exception> 
        /// <exception cref="System.InvalidOperationException"> Thrown when compaison fails.</exception>  
        public static void QuickSort<T>(this List<T> list)
        {
            ValidateObjectType<T>(list);

            list.QuickSort(0, list.Count - 1);
        }

        /// <summary>
        ///  Select a pivot and sort elements on each side of the list.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <param name="startIndex"> Index of the first element in the section to sort.</param>
        /// <param name="lastIndex"> Index of the last element in the section to sort.</param>
        private static void QuickSort<T>(this List<T> list, int startIndex, int lastIndex)
        {
            if (startIndex < lastIndex)
            {
                int pivotIndex = Partition<T>(list, startIndex, lastIndex);

                list.QuickSort(startIndex, pivotIndex - 1);
                list.QuickSort(pivotIndex + 1, lastIndex);
            }
        }


        /// <summary>
        /// Finds a pivot and move smaller element to the left side and higher element to the right.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <param name="startIndex"> Index of the first element in the section to sort.</param>
        /// <param name="lastIndex"> Index of the last element in the section to sort.</param>
        /// <returns> Returns the index of the pivot.</returns>
        private static int Partition<T>(List<T> list, int startIndex, int lastIndex)
        {
            FindPivot<T>(list, startIndex, lastIndex);
            T pivot = list[lastIndex];
            int leftOfPivotIndex = (startIndex - 1);

            for (int i = startIndex; i < lastIndex; i++)
            {
                if (Compare<T>(list[i], pivot) <= 0)
                {
                    leftOfPivotIndex++;
                    Swap<T>(list, i, leftOfPivotIndex);
                }
            }

            leftOfPivotIndex++; 
            Swap<T>(list, leftOfPivotIndex, lastIndex);

            return leftOfPivotIndex; // Return pivot's index.
        }


        /// <summary>
        /// Low at the start, middle and end to find a good pivot and move it to the end of the section.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <param name="startIndex"> Index of the first element in the section to sort.</param>
        /// <param name="lastIndex"> Index of the last element in the section to sort.</param>
        private static void FindPivot<T>(List<T> list, int startIndex, int lastIndex)
        {
            if (list.Count < 3)
                return;

            int indexOfLowest;
            int indexOfHighest;

            if (Compare<T>(list[startIndex], list[lastIndex]) <= 0)
            {
                indexOfLowest = startIndex;
                indexOfHighest = lastIndex;
            }
            else
            {
                indexOfLowest = lastIndex;
                indexOfHighest = startIndex;
            }

            int indexOfMiddle = (lastIndex - startIndex) / 2;

            if (Compare<T>(list[indexOfLowest], list[indexOfMiddle]) > 0)
            {
                Swap<T>(list, startIndex, lastIndex);
                return;
            }
            if (Compare<T>(list[indexOfHighest], list[indexOfMiddle]) < 0)
            {
                return;
            }

            Swap<T>(list, indexOfMiddle, lastIndex);
        }

        /// <summary>
        /// Treat the list as a binary tree and move higher element to the top of the tree and then move the highest element to the end of the list.
        /// Time Complexity: Best- O(n log(n)) | Average- O(n log(n))) | Worst- O(n log(n)).
        /// Space Complexity: O(1).
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <exception cref="System.ArgumentNullException"> Thrown when <paramref name="list"/> is null.</exception>
        /// <exception cref="System.NotSupportedException"> Thrown when T does not implements the Icomparable interface.</exception> 
        /// <exception cref="System.InvalidOperationException"> Thrown when compaison fails.</exception>  
        public static void HeapSort<T>(this List<T> list)
        {
            ValidateObjectType<T>(list);

            // Build max heap by string at the seconds lowest row and working up the tree.
            for (int i = list.Count / 2 - 1; i >= 0; i--)
                Heapify(list, list.Count, i);

            for (int i = (list.Count - 1); i > 0; i--)
            {
                Swap<T>(list, 0, i);
                Heapify<T>(list, i, 0);
            }
        }

        /// <summary>
        /// Treat the list as a binary tree. Push lowest element down while bring the highest element up.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <param name="lastIndex"> Prevents looking past this point on the list.</param>
        /// <param name="parentIndex"> Index of the element to move.</param>
        private static void Heapify<T>(List<T> list, int lastIndex, int parentIndex)
        {
            bool isParentIndexSorted = true;
            do
            {
                isParentIndexSorted = true;

                int largestIndex = parentIndex;
                int leftChildIndex = 2 * parentIndex + 1; 
                int rightChildIndex = 2 * parentIndex + 2; 

                if (leftChildIndex < lastIndex && Compare<T>(list[leftChildIndex], list[largestIndex]) > 0)
                    largestIndex = leftChildIndex;

                if (rightChildIndex < lastIndex && Compare<T>(list[rightChildIndex], list[largestIndex]) > 0)
                    largestIndex = rightChildIndex;

                if (Compare<T>(list[largestIndex], list[parentIndex]) != 0)
                {
                    Swap<T>(list, parentIndex, largestIndex);
                    parentIndex = largestIndex;
                    isParentIndexSorted = false;
                }
            } while (!isParentIndexSorted);
        }

        /// <summary>
        /// Swap two elements in a list.
        /// </summary>
        /// <param name="list"> List.</param>
        /// <param name="index1"> Index of the value to swap.</param>
        /// <param name="index2"> Index of the value to swap.</param>
        private static void Swap<T>(List<T> list, int index1, int index2)
        {
            T swap = list[index1];
            list[index1] = list[index2];
            list[index2] = swap;
        }


        /// <summary>
        /// Check if list is not Null and implements the Icomparable interface.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to check.</param>
        /// <exception cref="System.ArgumentNullException"> Thrown when <paramref name="list"/> is null.</exception>
        /// <exception cref="System.NotSupportedException"> Thrown when T does not implements the Icomparable interface.</exception>  
        private static void ValidateObjectType<T>(List<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "is null.");

            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new NotSupportedException($"{nameof(T)} does not implements the {nameof(IComparable)} interface.");
        }

        /// <summary>
        /// Compare two objects using the ComparaTo method from Icomparable interface. Null objects are seen as the lowest value.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="obj1"> Object to be compared.</param>
        /// <param name="obj2"> Object to be compared.</param>
        /// <returns> Objects larger returns a number greater than 0, and a number less than 0 if smaller. 0 indicates the objects are of the same value. </returns>
        /// <exception cref="System.InvalidOperationException"> Thrown when comparison fails.</exception>  
        private static int Compare<T>(T obj1, T obj2)
        {
            if (obj1 == null && obj2 == null)
                return 0;

            if (obj1 == null)
                return -1;

            if (obj2 == null)
                return 1;

            try
            {
                return ((IComparable)obj1).CompareTo(obj2);
            }
            catch (ArgumentException e)
            {
                throw new InvalidOperationException($"{obj1.GetType()} and {obj2.GetType()} failed to compare.", e);
            }
        }
    }
}
