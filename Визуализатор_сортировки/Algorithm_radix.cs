using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Визуализатор_сортировки
{
    internal class Algorithm_radix : ISort
    {

        public List<(int, int, int, int)> Sort(int[] Numbers)
        {
            List<(int, int, int, int)> To_Return = new List<(int, int, int, int)>();
            int[] Numbers_ = new int[Numbers.Length];
            for (int i = 0; i < Numbers_.Length; i++)
            {
                Numbers_[i] = Numbers[i];
            }
            /*
            double gap = Numbers_.Length;
            bool swapped = true;
            int temp;
            while (gap > 1 || swapped)
            {
                gap /= 1.247;
                if (gap < 1)
                {
                    gap = 1;
                }
                int i = 0;
                swapped = false;
                while (i + gap < Numbers_.Length)
                {
                    int j = i + (int)gap;
                    if (Numbers_[i] > Numbers_[j])
                    {
                        temp = Numbers_[i];
                        Numbers_[i] = Numbers_[j];
                        Numbers_[j] = temp;
                        //var To_Write = (i, j, Numbers_[i], Numbers_[j]);
                        //To_Return.Add(To_Write);
                        swapped = true;
                    }
                    var To_Write = (i, j, Numbers_[i], Numbers_[j]);
                    To_Return.Add(To_Write);
                    i++;
                }
                
            }


            return To_Return;*/


            int exp = 1;
            int max = Numbers_.Max();
            int cond = 0;

            while (true)
            {
                cond = max / exp;

                if (cond <= 0)
                    break;
                CountSort(Numbers_, exp, To_Return);

                exp = exp * 10;
            }
            return To_Return;
        }


        static void CountSort(int[] arr, int exp, List<(int, int, int, int)> To_Return)
        {
            int loop = 0;
            int length = arr.Length;

            int[] output = new int[length];
            int[] count = new int[10];

            for (loop = 0; loop < length; loop++)
                count[(arr[loop] / exp) % 10]++;

            for (loop = 1; loop < 10; loop++)
                count[loop] += count[loop - 1];

            for (loop = length - 1; loop >= 0; loop--)
            {
                output[count[(arr[loop] / exp) % 10] - 1] = arr[loop];
                count[(arr[loop] / exp) % 10]--;
            }

            for (loop = 0; loop < length; loop++)
            {
                arr[loop] = output[loop];
                var To_Write = (loop, loop, arr[loop], arr[loop]);
                To_Return.Add(To_Write);
            }
        }


    }
}
