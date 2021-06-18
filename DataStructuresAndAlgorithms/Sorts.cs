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

        private static void QuickSort<T>(List<T> unsortedList, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition<T>(unsortedList, low, high);
                QuickSort<T>(unsortedList, low, pivotIndex - 1);
                QuickSort<T>(unsortedList, pivotIndex + 1, high);
            }
        }

        private static int Partition<T>(List<T> unsortedList, int low, int high)
        {
            FindPivot<T>(unsortedList, low, high);
            T pivot = unsortedList[high];;
            int i = (low - 1);


            for (int j = low; j < high; j++)
            {
                if (((IComparable)unsortedList[j]).CompareTo(pivot) <= 0)
                {
                    i++;
                    Swap<T>(unsortedList,j,i);
                }
            }

            Swap<T>(unsortedList,i + 1, high);
            return i + 1;
        }

        private static void FindPivot<T>(List<T> unsortedList, int low, int high)
        {
            if (unsortedList.Count < 3)
                return;
            
            int indexOfLowest;
            int indexOfHighest;


            if (((IComparable)unsortedList[low]).CompareTo(unsortedList[high]) < 0)
            {
                indexOfLowest = low;
                indexOfHighest = high;
            }
            else
            {
                indexOfLowest = high;
                indexOfHighest = low;
            }

            int indexOfMiddle = unsortedList.Count / 2;

            if (((IComparable)unsortedList[indexOfLowest]).CompareTo(unsortedList[indexOfMiddle]) > 0)
            {
                Swap<T>(unsortedList, low, high);
                return;
            }
            if (((IComparable)unsortedList[indexOfHighest]).CompareTo(unsortedList[indexOfMiddle]) < 0)
            {
                return;
            }

            Swap<T>(unsortedList, indexOfMiddle, high);
        }

        private static void Swap<T>(List<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        public static void HeapSort<T>(List<T> list)
        {
            // Build max heap
            for (int i = list.Count / 2 - 1; i >= 0; i--)
                Heapify(list, list.Count, i);


            for (int i = (list.Count - 1); i > 0; i--)
            {
                Swap<T>(list, 0, i);
                Heapify<T>(list,i,0);
            }
            
        }

        private static void BuildMaxHeap<T>(List<T> list)
        {
            for(int i = 1; i < list.Count; i++)
            {
                bool t;
                int index = i;
                do
                {
                    t = false;
                    int parentIndex = (index - 1) / 2;

                    if (((IComparable)list[index]).CompareTo(list[parentIndex]) > 0)
                    {
                        Swap<T>(list, index, parentIndex);
                        t = true;
                        index = parentIndex;
                    }
                } while (t);
            }
        }

        private static void Heapify<T>(List<T> list, int lastIndex, int index)
        {
            bool isDone = false;
            do
            {
                isDone = false;
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int largest = index;

                if (left < lastIndex && ((IComparable)list[largest]).CompareTo(list[left]) < 0)
                    largest = left;
             
                if(right < lastIndex && ((IComparable)list[largest]).CompareTo(list[right]) < 0)
                    largest = right;

                if (((IComparable)list[index]).CompareTo(list[largest ]) < 0)
                {
                    Swap<T>(list, index, largest );
                    index = largest;
                    isDone = true;
                }

            } while (isDone);
        }

    }
}
