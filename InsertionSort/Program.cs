using System.Diagnostics;

namespace InsertionSort
{
    internal class Program
    {
        private static Stopwatch stopwatch = new Stopwatch();

        static void Main(string[] args)
        {
            //string[] obsah = File.ReadAllLines("random_integers_10M.txt");
            //var watch = Stopwatch.StartNew();

            //insertionSort(Array.ConvertAll(obsah, int.Parse));
            //watch.Stop();
            //Console.WriteLine($"Čas: {watch.ElapsedMilliseconds / 60000} m");
            stopwatch.Start();
            //string[] obsah = File.ReadAllLines("random_integers_10M.txt");
            string[] obsah = File.ReadAllLines("random_words_10M.txt");
            //string[] obsah = { "zzzz", "ab", "acdz", "hmmm", "bab" };
            //string[] obsah = { "170", "-45", "75", "-90", "802", "24", "-2", "66" };
            //int[] arr1 = { 170, -45, 75, -90, 802, 24, -2, 66 };
            //int[] arr = Array.ConvertAll(obsah, int.Parse);
            int n = obsah.Length;
            //int n1 = arr1.Length;
            //insertionSort(arr);
            insertionSortStrings(obsah);
            stopwatch.Stop();
            Console.WriteLine($"Čas: {stopwatch.ElapsedMilliseconds / 1000} s");
            //print(arr, 6);
            printStrings(obsah, n);
        }
        public static void printStrings(string[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        public static void print(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
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

        static void insertionSortStrings(string[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                TimeCheckStrings(arr);
                string key = arr[i];
                int j = i - 1;

                while (j >= 0 && string.Compare(arr[j], key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        static void insertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                TimeCheck(arr);
                int key = arr[i];
                int j = i - 1;

                
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
    }
}
