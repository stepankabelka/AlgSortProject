using System.Diagnostics;

namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] obsah = File.ReadAllLines("random_integers_10M.txt");
            //var watch = Stopwatch.StartNew();

            //mergeSort(Array.ConvertAll(obsah, int.Parse), 0, obsah.Length - 1);
            //watch.Stop();
            //Console.WriteLine($"Čas: {watch.ElapsedMilliseconds / 60000} m");
            var watch = Stopwatch.StartNew();
            //string[] obsah = File.ReadAllLines("random_integers_10M.txt");
            string[] obsah = File.ReadAllLines("random_words_10M.txt");
            //string[] obsah = { "zzzz", "ab", "acdz", "hmmm", "bab" };
            //string[] obsah = { "170", "-45", "75", "-90", "802", "24", "-2", "66" };
            //int[] arr1 = { 170, -45, 75, -90, 802, 24, -2, 66 };
            //int[] arr = Array.ConvertAll(obsah, int.Parse);
            int n = obsah.Length;
            //int n1 = arr1.Length;
            //mergeSort(arr, 0, n - 1);
            mergeSortStrings(obsah, 0, n - 1);
            watch.Stop();
            Console.WriteLine($"Čas: {watch.ElapsedMilliseconds / 1000} s");
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

        static void mergeSortStrings(string[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                mergeSortStrings(arr, l, m);
                mergeSortStrings(arr, m + 1, r);
                mergeStrings(arr, l, m, r);
            }
        }
        static void mergeSort(int[] arr, int l, int r)
        {

            if (l < r)
            {


                int m = l + (r - l) / 2;


                mergeSort(arr, l, m);
                mergeSort(arr, m + 1, r);


                merge(arr, l, m, r);
            }
        }

        static void merge(int[] arr, int first, int mid, int last)
        {

            int arrLlength = mid - first + 1;
            int arrRlength = last - mid;


            int[] tempArrLeft = new int[arrLlength];
            int[] tempArrRight = new int[arrRlength];
            int arrLTempindex, arrRTempIndex;

            for (arrLTempindex = 0; arrLTempindex < arrLlength; ++arrLTempindex)
            { 
                tempArrLeft[arrLTempindex] = arr[first + arrLTempindex];
            }
            for (arrRTempIndex = 0; arrRTempIndex < arrRlength; ++arrRTempIndex)
            {
                tempArrRight[arrRTempIndex] = arr[mid + 1 + arrRTempIndex];
            }
            arrLTempindex = 0;
            arrRTempIndex = 0;

            int k = first;
            while (arrLTempindex < arrLlength && arrRTempIndex < arrRlength)
            {
                if (tempArrLeft[arrLTempindex] <= tempArrRight[arrRTempIndex])
                {
                    arr[k] = tempArrLeft[arrLTempindex];
                    arrLTempindex++;
                }
                else
                {
                    arr[k] = tempArrRight[arrRTempIndex];
                    arrRTempIndex++;
                }
                k++;
            }

           
            while (arrLTempindex < arrLlength)
            {
                arr[k] = tempArrLeft[arrLTempindex];
                arrLTempindex++;
                k++;
            }

            
            while (arrRTempIndex < arrRlength)
            {
                arr[k] = tempArrRight[arrRTempIndex];
                arrRTempIndex++;
                k++;
            }
        }
        static void mergeStrings(string[] arr, int first, int mid, int last)
        {
            int arrLlength = mid - first + 1;
            int arrRlength = last - mid;
            string[] tempArrLeft = new string[arrLlength];
            string[] tempArrRight = new string[arrRlength];
            int arrLTempindex, arrRTempIndex;
            for (arrLTempindex = 0; arrLTempindex < arrLlength; ++arrLTempindex)
            {
                tempArrLeft[arrLTempindex] = arr[first + arrLTempindex];
            }
            for (arrRTempIndex = 0; arrRTempIndex < arrRlength; ++arrRTempIndex)
            {
                tempArrRight[arrRTempIndex] = arr[mid + 1 + arrRTempIndex];
            }
            arrLTempindex = 0;
            arrRTempIndex = 0;
            int k = first;
            while (arrLTempindex < arrLlength && arrRTempIndex < arrRlength)
            {
                if (string.Compare(tempArrLeft[arrLTempindex], tempArrRight[arrRTempIndex]) <= 0)
                {
                    arr[k] = tempArrLeft[arrLTempindex];
                    arrLTempindex++;
                }
                else
                {
                    arr[k] = tempArrRight[arrRTempIndex];
                    arrRTempIndex++;
                }
                k++;
            }

            while (arrLTempindex < arrLlength)
            {
                arr[k] = tempArrLeft[arrLTempindex];
                arrLTempindex++;
                k++;
            }

            while (arrRTempIndex < arrRlength)
            {
                arr[k] = tempArrRight[arrRTempIndex];
                arrRTempIndex++;
                k++;
            }
        }



    }
}
