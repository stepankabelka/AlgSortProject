using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace AlgSortProject
{
    internal class Program
    {
        private static Stopwatch stopwatch = new Stopwatch();
        static void Main(string[] args)
        {
            //string[] obsah = File.ReadAllLines("random_integers_10M.txt");
            //string[] obsah = { "10", "7", "8", "9", "1", "5" };
            //stopwatch.Start();

            //selectionSort(Array.ConvertAll(obsah, int.Parse));
            //foreach (string val in obsah)
            //{
            //    Console.Write(val + " ");

            //}
            //Console.WriteLine($"Čas: {stopwatch.ElapsedMilliseconds} m");
            //string[] obsah = File.ReadAllLines("random_integers_10M.txt");
            //string[] obsah = { "170", "-45", "75", "-90", "802", "24", "-2", "66" };
            //int[] arr1 = { 170, -45, 75, -90, 802, 24, -2, 66 };
            string[] obsah = File.ReadAllLines("random_words_10M.txt");
            //string[] obsah = { "zzzz", "ab", "acdz", "hmmm", "bab" };
            //int[] arr = Array.ConvertAll(obsah, int.Parse);
            int n = obsah.Length;
            //int n1 = arr1.Length;
            stopwatch.Start();
            //selectionSort(arr);
            selectionSortStrings(obsah);
            stopwatch.Stop();
            Console.WriteLine($"Čas: {stopwatch.ElapsedMilliseconds / 1000} s");
            //print(arr, 6);
            printStrings(obsah, n);
        }
        public static void print(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        public static void printStrings(string[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        static void selectionSortStrings(string[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (string.Compare(arr[j], arr[min_idx]) < 0)
                    {
                        min_idx = j;
                    }
                }
                string temp = arr[i];
                arr[i] = arr[min_idx];
                arr[min_idx] = temp;
            }
        }
        static void selectionSort(int[] arr)
            {
            

                int n = arr.Length;
                for (int i = 0; i < n - 1; i++)
                {


                    int min_idx = i;


                    for (int j = i + 1; j < n; j++)
                    {
                        if (arr[j] < arr[min_idx])
                        {

                            min_idx = j;
                        }
                    }


                    int temp = arr[i];
                    arr[i] = arr[min_idx];
                    arr[min_idx] = temp;
                }
        }
        public static bool TimeCheck(int[] arr)
        {
            if (stopwatch.Elapsed > TimeSpan.FromHours(1))
            {
                Console.WriteLine("Sorting aborted: Time limit exceeded.");
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Console.WriteLine($"Code reached {i / 100000}%");
                        return false;
                        
                    }
                }
            }
            return true;

        }
        public static bool TimeCheckStrings(string[] arr)
        {
            if (stopwatch.Elapsed > TimeSpan.FromHours(1))
            {
                Console.WriteLine("Sorting aborted: Time limit exceeded.");
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (string.Compare(arr[i], arr[i + 1]) > 0)
                    {
                        Console.WriteLine($"Code reached {i * 100.0 / arr.Length:F2}%");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

