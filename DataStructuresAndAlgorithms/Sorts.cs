using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    class Sorts
    {
        /// <summary>
        ///  A Bubble Sort for generic lists that implements the Icomparable interface.
        ///  O notation O(N^2).
        /// </summary>
        /// <typeparam name="T">must implemnts the Icomparable interface</typeparam>
        /// <param name="unsortedList">will be shallow copied.</param>
        /// <returns>A new list that is sorted.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when parameter is null.</exception>
        /// <exception cref="System.NotSupportedException">Thrown when T does not implements the Icomparable interface.</exception>
        public static List<T> BubbleSort<T>(List<T> unsortedList)
        {
            // Null Exception
            if (unsortedList == null)
                throw new ArgumentNullException(nameof(unsortedList), "is null");

            // Non-implementation of Icomparable interface for generic exception
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new NotSupportedException($"{nameof(T)} does not implements the interface of {nameof(IComparable)}");

            // Shallow copy of inputed list will be sorted
            List<T> sortingList = new List<T>(unsortedList);

            // Keeps looping through the list until sorted
            bool isSorted = true;
            do
            {
                isSorted = true;

                for (int i = 0; i < (sortingList.Count - 1); i++)
                {
                    // Swap elements if bigger than the other
                    if (((IComparable)sortingList[i]).CompareTo(sortingList[i + 1]) > 0)
                    {
                        T tmp = sortingList[i];
                        sortingList[i] = sortingList[i + 1];
                        sortingList[i + 1] = tmp;
                        isSorted = false;
                    }
                }
            } while (!isSorted);

            return sortingList;
        }

        public static List<T> SelectionSort<T>(List<T> unsortedList)
        {
            // Null Exception
            if (unsortedList == null)
                throw new ArgumentNullException(nameof(unsortedList), "is null");

            // Non-implementation of Icomparable interface for generic exception
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new NotSupportedException($"{nameof(T)} does not implements the interface of {nameof(IComparable)}");

            // Shallow copy of inputed list will be sorted
            List<T> sortingList = new List<T>(unsortedList);

            for (int i = 0; i < (sortingList.Count - 1); i++)
            {
                int indexOfLowest = i;
                for (int j = i + 1; j < sortingList.Count; j++)
                {
                    // Swap elements if bigger than the other
                    if (((IComparable)sortingList[j]).CompareTo(sortingList[indexOfLowest]) < 0)
                    {
                        indexOfLowest = j;
                    }
                }

                if (i != indexOfLowest)
                {
                    T tmp = sortingList[i];
                    sortingList[i] = sortingList[indexOfLowest];
                    sortingList[indexOfLowest] = tmp;
                }
            }

            return sortingList;

        }

        public static List<T> InsertionSort<T>(List<T> unsortedList)
        {
            // Null Exception
            if (unsortedList == null)
                throw new ArgumentNullException(nameof(unsortedList), "is null");

            // Non-implementation of Icomparable interface for generic exception
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new NotSupportedException($"{nameof(T)} does not implements the interface of {nameof(IComparable)}");

            // Shallow copy of inputed list will be sorted
            List<T> sortingList = new List<T>(unsortedList);

            for (int i = 1; i < sortingList.Count; i++)
            {
                T tmp = sortingList[i];
                int j = i - 1;

                while (j >= 0 && ((IComparable)sortingList[j]).CompareTo(tmp) > 0)
                {
                    sortingList[j + 1] = sortingList[j];
                    j--;
                }

                sortingList[j + 1] = tmp;
            }

            return sortingList;
        }

        public static List<T> MergeSort<T>(List<T> unsortedList)
        {
            if (unsortedList.Count <= 1)
                return unsortedList;

            int midPoint = unsortedList.Count / 2;
            List<T> left = MergeSort<T>(unsortedList.GetRange(0, midPoint));
            List<T> right = MergeSort<T>(unsortedList.GetRange(midPoint, unsortedList.Count - midPoint));

            List<T> result = Merge<T>(left, right);

            return result;
        }

        private static List<T> Merge<T>(List<T> left, List<T> right)
        {
            List<T> result = new List<T>();

            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count || rightIndex < right.Count)
            {
                if (leftIndex < left.Count &&
                 (rightIndex >= right.Count || ((IComparable)left[leftIndex]).CompareTo(right[rightIndex]) <= 0))
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            return result;
        }

        public static List<T> QuickSort<T>(List<T> unsortedList)
        {
            List<T> sortingList = new List<T>(unsortedList);

            QuickSort<T>(sortingList, 0, unsortedList.Count - 1);

            return sortingList;
        }

        private static void QuickSort<T>(List<T> unsortedList, int start, int end)
        {
            if(start < end)
            {
                int pivotIndex = Partition<T>(unsortedList, start, end);
                QuickSort<T>(unsortedList, start, pivotIndex - 1);
                QuickSort<T>(unsortedList, pivotIndex + 1, end);
            }
        }

        private static int Partition<T>(List<T> unsortedList, int start, int end)
        {
            T pivot = unsortedList[start];

            for(int i = start; start <= end; i++)
            {

            }
        }


    }
}
