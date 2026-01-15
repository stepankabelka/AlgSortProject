using System.Diagnostics;

namespace RadixSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            //string[] obsah = File.ReadAllLines("random_integers_10M.txt");
            //string[] obsah = { "170", "-45", "75", "-90", "802", "24", "-2", "66" };
            //int[] arr1 = { 170, -45, 75, -90, 802, 24, -2, 66 };
            string[] obsah = File.ReadAllLines("random_words_10M.txt");
            //string[] obsah = { "zzzz", "ab", "acdz", "hmmm", "bab" };
            //int[] arr = Array.ConvertAll(obsah, int.Parse);
            int n = obsah.Length;
            //int n1 = arr1.Length;
            //radixsort(arr, n);
            radixsortStrings(obsah, n);

            watch.Stop();
            Console.WriteLine($"Čas: {watch.ElapsedMilliseconds / 1000} s");
            //printStrings(obsah, n);
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
        public static int getMaxAbs(int[] arr, int n)
        {
            int mx = Math.Abs(arr[0]);
            for (int i = 1; i < n; i++)
            {
                int abs = Math.Abs(arr[i]);
                if (abs > mx)
                    mx = abs;
            }
            return mx;
        }

        public static void sortStrings(string[] arr)
        {
            Array.Sort(arr);
        }
        
        
        public static void countSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n];
            int i;

            int[] count = new int[19];

            for (i = 0; i < 19; i++)
                count[i] = 0;

            for (i = 0; i < n; i++)
            {
                int digit = ((arr[i] / exp) % 10);
                count[digit + 9]++;
            }

            for (i = 1; i < 19; i++)
                count[i] += count[i - 1];

            for (i = n - 1; i >= 0; i--)
            {
                int digit = ((arr[i] / exp) % 10);
                output[count[digit + 9] - 1] = arr[i];
                count[digit + 9]--;
            }

            for (i = 0; i < n; i++)
                arr[i] = output[i];
        }
        public static void radixsortStrings(string[] arr, int n)
        {
            if (arr == null || arr.Length <= 1)
                return;

            string[] aux = new string[arr.Length];
            msdSort(arr, aux, 0, arr.Length - 1, 0);
        }

        
        public static void radixsort(int[] arr, int n)
        {
            int negCount = 0;
            int posCount = 0;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] < 0)
                    negCount++;
                else
                    posCount++;
            }

            int[] negatives = new int[negCount];
            int[] positives = new int[posCount];
            int negIdx = 0, posIdx = 0;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] < 0)
                    negatives[negIdx++] = Math.Abs(arr[i]);
                else
                    positives[posIdx++] = arr[i];
            }

            if (posCount > 0)
            {
                int m = getMaxAbs(positives, posCount);
                for (int exp = 1; m / exp > 0; exp *= 10)
                    countSort(positives, posCount, exp);
            }

            if (negCount > 0)
            {
                int m = getMaxAbs(negatives, negCount);
                for (int exp = 1; m / exp > 0; exp *= 10)
                    countSort(negatives, negCount, exp);

                Array.Reverse(negatives);
            }

            int idx = 0;
            for (int i = 0; i < negCount; i++)
                arr[idx++] = -negatives[i];
            for (int i = 0; i < posCount; i++)
                arr[idx++] = positives[i];
        }

        private static void msdSort(string[] arr, string[] aux, int lo, int hi, int d)
        {
            if (hi <= lo)
                return;

            int R = 256; 
            int[] count = new int[R + 2];

            for (int i = lo; i <= hi; i++)
            {
                int c = charAt(arr[i], d);
                count[c + 2]++;
            }

            for (int r = 0; r < R + 1; r++)
                count[r + 1] += count[r];

            for (int i = lo; i <= hi; i++)
            {
                int c = charAt(arr[i], d);
                aux[count[c + 1]++] = arr[i];
            }

            for (int i = lo; i <= hi; i++)
                arr[i] = aux[i - lo];

            for (int r = 0; r < R; r++)
                msdSort(arr, aux, lo + count[r], lo + count[r + 1] - 1, d + 1);
        }

        private static int charAt(string s, int d)
        {
            if (d < s.Length)
                return s[d];
            else
                return -1;
        }

    }


}

