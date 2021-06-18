using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    static class Sorts
    {

        /// <summary>
        ///  A Bubble Sort for List<> that implements the Icomparable interface.
        ///  A Bubble Sort will push the heighest number to the end of the array and keep looping untill sorted.
        ///  O notation O(N^2).
        /// </summary>
        /// <typeparam name="T">must implemnts the Icomparable interface</typeparam>
        /// <param name="list"> to be sorted.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="list"/> is null.</exception>
        /// <exception cref="System.NotSupportedException">Thrown when T does not implements the Icomparable interface.</exception>
        public static void BubbleSort<T>(this List<T> list)
        {
            // Throw exception if list is null.
            if (list == null)
                throw new ArgumentNullException(nameof(list), "is null!");

            // Throw execption if list generic type does not implements Icomparable interface.
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new NotSupportedException($"{nameof(T)} does not implements the {nameof(IComparable)} interface!");

            // Each loop will push the next biggest number to the end of the list.
            // The list size to check can be shorten for each loop as the end of the list is sorted. 
            int listSize = list.Count - 1;

            // Keeps looping until list is sorted.
            bool isSorted = true;
            do
            {
                isSorted = true;

                // Loop through the list and push the heighest value to the end.
                for (int i = 0; i < listSize; i++)
                {
                    // Swap elements if bigger than the next element in the list.
                    if (((IComparable)list[i]).CompareTo(list[i + 1]) > 0)
                    {
                        Swap<T>(list,i, i + 1);
                        isSorted = false;
                        listSize--;
                    }
                }
            } while (!isSorted);
        }

        /// <summary>
        ///  A Selection Sort for List<> that implements the Icomparable interface.
        ///  A Selection Sort will find the smallest value and put it at the begining of the list then move to the next smallest.
        ///  O notation O(N^2).
        /// </summary>
        /// <typeparam name="T">must implemnts the Icomparable interface</typeparam>
        /// <param name="list"> to be sorted.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="list"/> is null.</exception>
        /// <exception cref="System.NotSupportedException">Thrown when T does not implements the Icomparable interface.</exception>
        public static void SelectionSort<T>(this List<T> list)
        {
            // Throw exception if list is null.
            if (list == null)
                throw new ArgumentNullException(nameof(list), "is null!");

            // Throw execption if list generic type does not implements Icomparable interface.
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new NotSupportedException($"{nameof(T)} does not implements the {nameof(IComparable)} interface!");


            // Sort the list by looking for the smallest value.
            for (int i = 0; i < (list.Count - 1); i++)
            {
                int currentMinimum = i;

                // Look for the smallest unsorted value.
                for (int j = i + 1; j < list.Count; j++)
                {
                    // Set currentMinimum to the new smallest value.
                    if (((IComparable)list[j]).CompareTo(list[currentMinimum]) < 0)
                        currentMinimum = j;
                }

                // Put currentMinimum into it's sorted place.
                if (i != currentMinimum)
                    Swap<T>(list, i, currentMinimum);
            }
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
            // Build max heap.
            // Starts at the seconds lowest row and pushs low numbers down and high numbers up.
            for (int i = list.Count / 2 - 1; i >= 0; i--)
                Heapify(list, list.Count, i);


            for (int i = (list.Count - 1); i > 0; i--)
            {
                Swap<T>(list, 0, i);
                // Bring the highest number to the top of the tree.
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
