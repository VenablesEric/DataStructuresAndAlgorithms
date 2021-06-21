using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
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
            // Check if list is not Null and implements the Icomparable interface.
            CheckListValidity<T>(list);

            // Each loop will push the next biggest number to the end of the list.
            // The list size to check can be shorten for each loop as the end of the list is sorted. 
            int lastIndex = list.Count - 1;

            // Keeps looping until list is sorted.
            bool isSorted = true;
            do
            {
                isSorted = true;

                // Loop through the list and push the heighest value to the end.
                for (int i = 0; i < lastIndex; i++)
                {
                    // Swap elements if bigger than the next element in the list.
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
            // Check if list is not Null and implements the Icomparable interface.
            CheckListValidity<T>(list);

            // Sort the list by looking for the smallest value.
            for (int i = 0; i < (list.Count - 1); i++)
            {
                int currentMinimum = i;

                // Look for the smallest unsorted value.
                for (int j = i + 1; j < list.Count; j++)
                {
                    // Set currentMinimum to the new smallest value.
                    if (Compare<T>(list[j], list[currentMinimum]) < 0)
                        currentMinimum = j;
                }

                // Put currentMinimum into it's sorted place.
                if (i != currentMinimum)
                    Swap<T>(list, i, currentMinimum);
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
            // Check if list is not Null and implements the Icomparable interface.
            CheckListValidity<T>(list);

            // Looping through the list and move elements backwards to the correct posistion.
            for (int i = 1; i < list.Count; i++)
            {
                T value = list[i];
                int j = i - 1; // Use to navigate backwards through the list.

                // Move elements up to make room to insert value in the correct position.
                while (j >= 0 && Compare<T>(list[j], value) > 0)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                // Insert value in correct position.
                list[j + 1] = value;
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
            // Check if list is not Null and implements the Icomparable interface.
            CheckListValidity<T>(list);

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
            // Returns if the list can not be split.
            if (list.Count <= 1)
                return list;

            // Mid point of the list.
            int midPoint = list.Count / 2;

            List<T> left = SplitSortMerge<T>(list.GetRange(0, midPoint)); // Left side of the split.
            List<T> right = SplitSortMerge<T>(list.GetRange(midPoint, list.Count - midPoint)); // right side of the split.

            // Merge and sort the two sides.
            List<T> result = Merge<T>(left, right);

            return result;
        }

        /// <summary>
        ///  Merge and sort left and right into a singel list.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="left"> Left sorted list.</param>
        /// <param name="right"> Right sorted list.</param>
        /// <returns> Returns sorted merged list</returns>
        private static List<T> Merge<T>(List<T> left, List<T> right)
        {
            // List to store the merge
            List<T> result = new List<T>();

            int leftIndex = 0;
            int rightIndex = 0;

            // Look for the next lowest value from each of the lists then add it to the results.
            while (leftIndex < left.Count || rightIndex < right.Count)
            {
                // If left list still has values left and right list is empty or values from left list is lower, add to results
                if (leftIndex < left.Count &&
                 (rightIndex >= right.Count || Compare<T>(left[leftIndex], right[rightIndex]) <= 0))
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                // Add right side to the list.
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            return result;
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
            // Check if list is not Null and implements the Icomparable interface.
            CheckListValidity<T>(list);

            // Start the quick sort with the first and last index of the list
            list.QuickSort(0, list.Count - 1);
        }

        /// <summary>
        ///  Select a pivot and sort elements on each side of the list.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <param name="low"> Index of the first element in the section to sort.</param>
        /// <param name="high"> Index of the last element in the section to sort.</param>
        private static void QuickSort<T>(this List<T> list, int low, int high)
        {
            // If more than one element in the section.
            if (low < high)
            {
                // Select pivot and put pivot in it's sorted place by moving
                // smaller element to the left side and higher element to the right.
                int pivotIndex = Partition<T>(list, low, high);

                // Sort left side of the pivot.
                list.QuickSort(low, pivotIndex - 1);
                // Sort right side of the pivot.
                list.QuickSort(pivotIndex + 1, high);
            }
        }


        /// <summary>
        /// Find a pivot and move smaller element to the left side and higher element to the right.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <param name="low"> Index of the first element in the section to sort.</param>
        /// <param name="high"> Index of the last element in the section to sort.</param>
        /// <returns> Returns the index of the pivot.</returns>
        private static int Partition<T>(List<T> list, int low, int high)
        {
            // Find a good pivot to try and prevent worst case time complexity.
            // Moves the pivot to the end of the section.
            FindPivot<T>(list, low, high);
            T pivot = list[high]; // Get the pivot.
            int i = (low - 1); // Use to find the sorted position for the pivot


            // Check each element apart from the pivot to find the pivots sorted place,
            for (int j = low; j < high; j++)
            {
                // Move elements smaller than the pivot to the left side of i.
                if (Compare<T>(list[j], pivot) <= 0)
                {
                    i++; // Update possible pivot position.
                    // Move smaller element to the left.
                    Swap<T>(list, j, i);
                }
            }

            i++; // The next element spot will be the sorted position for the pivot.
            // Swap the pivot to it's sorted place.
            Swap<T>(list, i, high);

            return i; // Return pivots index.
        }


        /// <summary>
        /// Low at the start, middle and end to find a good pivot.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <param name="low"> Index of the first element in the section to sort.</param>
        /// <param name="high"> Index of the last element in the section to sort.</param>
        private static void FindPivot<T>(List<T> list, int low, int high)
        {
            // Should only be used with a list bigger than 2.
            if (list.Count < 3)
                return;

            int indexOfLowest; // Index of the lowest value.
            int indexOfHighest; // Index of the highest value.


            // Is the value at the start of the list bigger than the end?
            if (Compare<T>(list[low], list[high]) <= 0)
            {
                indexOfLowest = low; // Set index of lowest value.
                indexOfHighest = high; // Set index of heighest value.
            }
            else
            {
                indexOfLowest = high; // Set index of lowest value
                indexOfHighest = low; // Set index of heighest value
            }

            // Find the index of the middle value.
            int indexOfMiddle = (high - low) / 2;

            // Find which value out of the 3 is the medium.
            if (Compare<T>(list[indexOfLowest], list[indexOfMiddle]) > 0)
            {
                // Move selected pivot to the end of the section.
                Swap<T>(list, low, high);
                return;
            }
            if (Compare<T>(list[indexOfHighest], list[indexOfMiddle]) < 0)
            {
                return;
            }

            // Move selected pivot to the end of the section.
            Swap<T>(list, indexOfMiddle, high);
        }

        /// <summary>
        /// Treat the list as a binary tree and move higher element to the top of the tree and put them in their sorted place.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <exception cref="System.ArgumentNullException"> Thrown when <paramref name="list"/> is null.</exception>
        /// <exception cref="System.NotSupportedException"> Thrown when T does not implements the Icomparable interface.</exception> 
        /// <exception cref="System.InvalidOperationException"> Thrown when compaison fails.</exception>  
        public static void HeapSort<T>(this List<T> list)
        {
            // Check if list is not Null and implements the Icomparable interface.
            CheckListValidity<T>(list);

            // Build max heap.
            // Starts at the seconds lowest row and pushs low element down and high element up.
            for (int i = list.Count / 2 - 1; i >= 0; i--)
                Heapify(list, list.Count, i);


            // Bring highest element to the stop of the tree.
            // Move it to it's sorted place (right to left).
            // Bring next heighest element to the top of the tree.
            // Repeat untill sorted.
            for (int i = (list.Count - 1); i > 0; i--)
            {
                // Move heighest value to it's sorted place.
                Swap<T>(list, 0, i);

                // Bring the next highest number to the top of the tree.
                Heapify<T>(list, i, 0);
            }

        }

        /// <summary>
        /// Push lowest element down the tree while bring the highest element up.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to be sorted.</param>
        /// <param name="lastIndex"> Prevents looking past this point on the list.</param>
        /// <param name="index"> Index of the element to move.</param>
        private static void Heapify<T>(List<T> list, int lastIndex, int index)
        {
            // Is selected element at it's lowest point in the tree
            bool isAtLowestPoint = false;
            do
            {
                isAtLowestPoint = false;
                int left = 2 * index + 1; // Get index of left child node
                int right = 2 * index + 2; // Get index of right child node
                int largest = index; // Index of the current largest value.

                // Is there a left child node and is the child node bigger than selected node.
                if (left < lastIndex && Compare<T>(list[largest], list[left]) < 0)
                    largest = left;

                // Is there a right child node and is the child node bigger than selected node.
                if (right < lastIndex && Compare<T>(list[largest], list[right]) < 0)
                    largest = right;

                // Swap parent and child node and loop agian
                if (Compare<T>(list[index], list[largest]) < 0)
                {
                    Swap<T>(list, index, largest);
                    index = largest; // Get new index of selectd node.
                    isAtLowestPoint = true;
                }

            } while (isAtLowestPoint);
        }

        /// <summary>
        /// Swaps two elements in a list.
        /// </summary>
        /// <param name="list"> List.</param>
        /// <param name="indexA"> Index of the value to swap.</param>
        /// <param name="indexB"> Index of the value to swap.</param>
        private static void Swap<T>(List<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }


        /// <summary>
        /// Check if list is not Null and implements the Icomparable interface.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="list"> List to check.</param>
        /// <exception cref="System.ArgumentNullException"> Thrown when <paramref name="list"/> is null.</exception>
        /// <exception cref="System.NotSupportedException"> Thrown when T does not implements the Icomparable interface.</exception>  
        private static void CheckListValidity<T>(List<T> list)
        {
            // Throw exception if list is null.
            if (list == null)
                throw new ArgumentNullException(nameof(list), "is null.");

            // Throw execption if list generic type does not implements Icomparable interface.
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new NotSupportedException($"{nameof(T)} does not implements the {nameof(IComparable)} interface.");
        }

        /// <summary>
        /// Compara two objects using the ComparaTo method. Null objects are seen as the lowest value.
        /// </summary>
        /// <typeparam name="T"> Must implements the Icomparable interface.</typeparam>
        /// <param name="a"> Object to be compared.</param>
        /// <param name="b"> Object to be compared.</param>
        /// <returns> Objects larger returns a number greater than 0, and a number less than 0 if smaller. 0 indicates the objects are of the same value. </returns>
        /// <exception cref="System.InvalidOperationException"> Thrown when compaison fails.</exception>  
        private static int Compare<T>(T a, T b)
        {
            // a is smaller than b.
            if (a == null)
                return b == null ? 0 : -1;

            // b is smaller than a.
            if (b == null)
                return a == null ? 0 : 1;

            // Attempt a comparison of a and b. 
            try
            {
                return ((IComparable)a).CompareTo(b);
            }
            catch (ArgumentException e)
            {
                throw new InvalidOperationException($"{a.GetType()} and {b.GetType()} failed to compare.", e);
            }
        }
    }
}
