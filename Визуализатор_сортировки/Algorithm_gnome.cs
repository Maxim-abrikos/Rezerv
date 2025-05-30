using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Визуализатор_сортировки
{
    internal class Algorithm_gnome : ISort
    {
        public List<(int, int, int, int)> Sort(int[] Numbers)
        {
            int index = 0;
            List<(int, int, int, int)> To_Return = new List<(int, int, int, int)>();
            int[] Numbers_ = new int[Numbers.Length];
            bool flag = false;
            for (int i = 0; i < Numbers_.Length; i++)
            {
                Numbers_[i] = Numbers[i];
            }
            while (index < Numbers_.Length)
            {
                flag = false;
                if (index == 0) 
                {
                    index++;
                }

                if (Numbers_[index] >= Numbers_[index - 1])
                {
                    index++;
                }
                else
                {
                    int temp;
                    temp = Numbers_[index];
                    Numbers_[index] = Numbers_[index - 1];
                    Numbers_[index - 1] = temp;
                    var To_Write_ = (index, index - 1, Numbers_[index], Numbers_[index - 1]);
                    To_Return.Add(To_Write_);
                    index--;
                    flag = true;
                }
                if (flag) {//тут было что-то важное
                }
            }
            return To_Return;
        }
    }
}
