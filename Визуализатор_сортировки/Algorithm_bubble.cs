using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Визуализатор_сортировки
{
    public class Algorithm_bubble : ISort
    {

        public List<(int, int, int, int)> Sort(int[] Numbers)
        {
            List<(int, int, int, int)> To_Return = new List<(int, int, int, int)>();
            int temp;
            int[] Numbers_ = new int[Numbers.Length];
            bool Need = false;
            for (int i = 0; i < Numbers_.Length; i++)
            {
                Numbers_[i] = Numbers[i];
            }

            var To_Write = (0,0,0,0);
            for (int i = 0; i < Numbers_.Length + 1; i++)
            {
                for (int j = i + 1; j < Numbers_.Length; j++)
                {
                    if (Numbers_[i] > Numbers_[j])
                    {
                        temp = Numbers_[i];
                        Numbers_[i] = Numbers_[j];
                        Numbers_[j] = temp;
                        To_Write = (i,j, Numbers_[i], Numbers_[j]);
                        To_Return.Add(To_Write);
                        Need = false;
                    }
                    if (Need)
                    {
                        To_Write = (i, j, Numbers_[i], Numbers_[j]);
                        To_Return.Add(To_Write);
                    }
                    Need = true;
                }
                if (i < Numbers_.Length)
                {
                    //To_Write = (i, 0, Numbers_[i], Numbers_[0]);
                    //To_Return.Add(To_Write);
                }
            }
            return To_Return;
        }
    }
}
