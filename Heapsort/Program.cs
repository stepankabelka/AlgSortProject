using System.Diagnostics;

namespace Heapsort
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string[] obsah = File.ReadAllLines("random_integers_10M.txt");
            //var watch = Stopwatch.StartNew();

            //heapSort(new List<int>(Array.ConvertAll(obsah, int.Parse)));
            //watch.Stop();
            //Console.WriteLine($"Čas: {watch.ElapsedMilliseconds / 60000} m");
            var watch = Stopwatch.StartNew();
            //string[] obsah = File.ReadAllLines("random_integers_10M.txt");
            //string[] obsah = { "170", "-45", "75", "-90", "802", "24", "-2", "66" };
            //int[] arr1 = { 170, -45, 75, -90, 802, 24, -2, 66 };
            string[] obsah = File.ReadAllLines("random_words_10M.txt");
            //string[] obsah = { "zzzz", "ab", "acdz", "hmmm", "bab" };
            //int arr = Array.ConvertAll(obsah, int.Parse);
            //List<int> list = new List<int>(Array.ConvertAll(obsah, int.Parse));
            int n = obsah.Length;
            List<string> list = new List<string>(obsah);
            //int n1 = arr1.Length;
            //heapSort(list);
            heapSortStrings(list);
            watch.Stop();
            Console.WriteLine($"Čas: {watch.ElapsedMilliseconds / 1000} s");
            //print(list, 6);
            //printStrings(list, n);
        }
        public static void printStrings(List<string> arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        public static void print(List<int> arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        static void heapSortStrings(List<string> arr)
        {
            int n = arr.Count;
            for (int i = n / 2 - 1; i >= 0; i--)
                heapifyStrings(arr, n, i);
            for (int i = n - 1; i > 0; i--)
            {
                string temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapifyStrings(arr, i, 0);
            }
        }

        static void heapSort(List<int> arr)
        {
            int n = arr.Count;

            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);

            for (int i = n - 1; i > 0; i--)
            {

                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                heapify(arr, i, 0);
            }
        }
        static void heapifyStrings(List<string> arr, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < n && string.Compare(arr[l], arr[largest]) > 0)
                largest = l;
            if (r < n && string.Compare(arr[r], arr[largest]) > 0)
                largest = r;
            if (largest != i)
            {
                string temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;
                heapifyStrings(arr, n, largest);
            }
        }
        static void heapify(List<int> arr, int n, int i)
        {

            int largest = i;

            int l = 2 * i + 1;

            int r = 2 * i + 2;

            if (l < n && arr[l] > arr[largest])
                largest = l;

            if (r < n && arr[r] > arr[largest])
                largest = r;

            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                heapify(arr, n, largest);
            }
        }
    }
}
