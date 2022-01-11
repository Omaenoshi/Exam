using System;
using System.Linq;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            // var arr = new[] {6, 4, 2, 6, 8, 5, 3, 7 , 9};
            // var result = Sort.TreeSort(arr);
            // foreach (var item in result)
            // {
            //     Console.Write(item);
            // }
            // Console.WriteLine();

            Sort.MergeSort sort = new Sort.MergeSort();
            sort.MergeSorting("../../../A.txt");
        }
    }
}