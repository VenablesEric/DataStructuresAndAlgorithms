using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfWords = new List<string>() {"Zoe" , "Alex" , "Jack" ,"Bob" ,"Jim" ,"Mat" };
            List<int> listOfNumber = new List<int>() { 99,1,34,100,54};
            List<string> emptyList = new List<string>();
            List<string> nullList;

            List<string> sorted = Sorts.QuickSort<string>(listOfWords);
            sorted.ForEach(Console.WriteLine);

        }
    }

   public class MyTest
    {

    }
}
