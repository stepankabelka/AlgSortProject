using System.Diagnostics;

namespace BubbleSort
{

    internal class Program
    {

        private static Stopwatch stopwatch = new Stopwatch();

        static void Main(string[] args)
        {
            //string[] obsah = File.ReadAllLines("random_integers_10M.txt");
            string[] obsah = File.ReadAllLines("random_words_10M.txt");
            //string[] obsah = {"zzzz", "ab", "acdz", "hmmm", "bab"};

            stopwatch.Start();
            //bubbleSort(Array.ConvertAll(obsah, int.Parse));
            bubbleSortStrings(obsah);
            stopwatch.Stop();
            Console.WriteLine($"Čas: {stopwatch.ElapsedMilliseconds / 1000} s");
            //foreach(string str in obsah)
            //{
            //    Console.WriteLine(str);
            //}


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
                        return true;

                    }
                }
            }
            return false;

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
                        return true;
                    }
                }
            }
            return false;
        }
        static void bubbleSortStrings(string[] arr)
        {
            int n = arr.Length;
            int i, j;
            string temp;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                if (TimeCheckStrings(arr))
                    break;
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(arr[j], arr[j + 1]) > 0)
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;
            }
        }

        static void bubbleSort(int[] arr)
        {
            int n = arr.Length;
            int i, j, temp;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                if (TimeCheck(arr))
                    break;
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {

                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }


                if (swapped == false)
                    break;
            }
        }

    }
}
