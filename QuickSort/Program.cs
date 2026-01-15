using System.Diagnostics;

namespace QuickSort
{
    internal class Program
    {
        static Stopwatch stopwatch = new Stopwatch();
        static void Main(string[] args)
        {
           
            stopwatch.Start();
            //string[] obsah = File.ReadAllLines("random_integers_10M.txt");
            string[] obsah = File.ReadAllLines("random_words_10M.txt");
            //string[] obsah = { "zzzz", "ab", "acdz", "hmmm", "bab" };
            //string[] obsah = { "170", "-45", "75", "-90", "802", "24", "-2", "66" };
            //int[] arr1 = { 170, -45, 75, -90, 802, 24, -2, 66 };
            //int[] arr = Array.ConvertAll(obsah, int.Parse);
            int n = obsah.Length;
            //int n1 = arr1.Length;
            //quickSortInt(arr, 0, n - 1);
            quickSortStrings(obsah, 0, n - 1);
            stopwatch.Stop();
            Console.WriteLine($"Čas: {stopwatch.ElapsedMilliseconds / 1000} s");
            //print(arr, 6);
            //printStrings(obsah, n);

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
        static void quickSortStrings(string[] arr, int low, int high)
        {
            if (low < high)
            {
                if (TimeCheckStrings(arr))
                {
                    return;
                }
                int pi = partitionStrings(arr, low, high);
                quickSortStrings(arr, low, pi - 1);
                quickSortStrings(arr, pi + 1, high);
            }
        }
        static void quickSortInt(int[] arr, int low, int high)
        {
            
                if (low < high)
            {


                int pi = partition(arr, low, high);

                quickSortInt(arr, low, pi - 1);
                quickSortInt(arr, pi + 1, high);
            }
        }

        static int partition(int[] arr, int low, int high)
        {

            int pivot = arr[high];

            
            int i = low - 1;

            
            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    swap(arr, i, j);
                }
            }

            swap(arr, i + 1, high);
            return i + 1;
        }
        static int partitionStrings(string[] arr, int low, int high)
        {
            string pivot = arr[high];

            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {
                if (string.Compare(arr[j], pivot) < 0)
                {
                    i++;
                    swapStrings(arr, i, j);
                }
            }
            swapStrings(arr, i + 1, high);
            return i + 1;
        }

        static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static void swapStrings(string[] arr, int i, int j)
        {
            string temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        
        public static bool TimeCheckStrings(string[] arr)
        {
            if (stopwatch.Elapsed > TimeSpan.FromSeconds(50))
            {
                Console.WriteLine("Sorting aborted: Time limit exceeded.");
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (string.Compare(arr[i], arr[i + 1]) > 0)
                    {
                        Console.WriteLine($"Code reached {i * 100.0 / arr.Length:F2}%");
                        return true;
                    }
                }
            }
            return false;
        }


    }

}
