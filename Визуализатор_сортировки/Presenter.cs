using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Визуализатор_сортировки
{
    public class Presenter
    {
        public ISort Algorithm = new Algorithm_bubble();
        private Random r = new Random();

        Chart Data = new Chart();
        private System.Windows.Forms.Label label_count { get; set; } = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label label_speed { get; set; } = new System.Windows.Forms.Label();

        private System.Windows.Forms.Label label_Bubble { get; set; } = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label label_Choose { get; set; } = new System.Windows.Forms.Label();

        private System.Windows.Forms.Label label_Comb { get; set; } = new System.Windows.Forms.Label();

        private System.Windows.Forms.Label label_Gnome { get; set; } = new System.Windows.Forms.Label();
        private System.Windows.Forms.Button Generate { get; set; } = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button Steps { get; set; } = new System.Windows.Forms.Button();
        private RichTextBox RCB {get; set; } = new RichTextBox();
        private System.Windows.Forms.TrackBar Trackbar1 { get; set; } = new System.Windows.Forms.TrackBar();
        private System.Windows.Forms.TrackBar Trackbar2 { get; set; } = new System.Windows.Forms.TrackBar();
        private CheckBox AlBubble = new CheckBox();
        private CheckBox AlChoose = new CheckBox();
        private CheckBox AlGnome = new CheckBox();
        private CheckBox AlComb = new CheckBox();
        private int Index = 0, Iters;

        private RadioButton WhatAlgoritm = new RadioButton();

        //public RadioButton DrawRadioButton()
        //{
        //    WhatAlgoritm.Location = new Point(600,350);
        //    Label L1 = new Label();
        //    L1.Text = "Алгоритм: ";
        //    L1.Location = new Point(550, 350);
        //    return WhatAlgoritm;
        //}

        public CheckBox DrawCheckBox1()
        {
            AlBubble.Enabled = true;
            AlBubble.Location = new Point(600, 350/*380*/);
            AlBubble.Checked= true;
            AlBubble.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AlBubble.CheckedChanged += (sender, e) =>
            {
                if (AlBubble.Checked) 
                {
                    AlChoose.Checked = false;
                    AlGnome.Checked = false;
                    AlComb.Checked = false;
                    Algorithm = new Algorithm_bubble();
                    Index = 0;
                }
            };

            return AlBubble;
        }

        public CheckBox DrawCheckBox2()
        {
            AlChoose.Enabled = true;
            AlChoose.Location = new Point(600, 410);
            AlChoose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AlChoose.CheckedChanged += (sender, e) =>
            {
                if (AlChoose.Checked)
                {
                    AlBubble.Checked = false;
                    AlGnome.Checked = false;
                    AlComb.Checked = false;
                    Algorithm = new Algorithm_choose();
                    Index = 1;
                }
            };
            return AlChoose;
        }

        public CheckBox DrawCheckBox3()
        {
            AlComb.Enabled = true;
            AlComb.Location = new Point(710, 350);
            AlComb.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AlComb.CheckedChanged += (sender, e) =>
            {
                if (AlComb.Checked)
                {
                    AlBubble.Checked = false;
                    AlChoose.Checked = false;
                    AlGnome.Checked = false;
                    Algorithm = new Algorithm_radix();
                    Index = 2;
                }
            };
            return AlComb;
        }

        public CheckBox DrawCheckBox4()
        {
            AlGnome.Enabled = true;
            AlGnome.Location = new Point(710, 410);
            AlGnome.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AlGnome.CheckedChanged += (sender, e) =>
            {
                if (AlGnome.Checked)
                {
                    AlBubble.Checked = false;
                    AlChoose.Checked = false;
                    AlComb.Checked = false;
                    Algorithm = new Algorithm_gnome();
                    Index = 3;
                }
            };
            return AlGnome;
        }



        public RichTextBox DrawRichTextBox()
        {
            RCB.Location = new Point(470, 60);
            RCB.Size = new Size(320, 250);
            RCB.Anchor =  AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            return RCB;
        }

        public System.Windows.Forms.TrackBar DrawTrackBar_1()
        {
            Trackbar1.Location = new Point(10, 340);
            Trackbar1.Size = new Size(500, 200);
            Trackbar1.Minimum = 0;
            Trackbar1.Maximum = 500;
            Trackbar1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            Trackbar1.ValueChanged += (sender, e) =>
            {
                label_count.Text = "Количество: " + Trackbar1.Value.ToString();
            };
            Trackbar1.TickFrequency = 100;
            return Trackbar1;
        }

        public System.Windows.Forms.TrackBar DrawTrackBar_2()
        {
            Trackbar2.Location = new Point(10, 400);
            Trackbar2.Size = new Size(300, 200);
            Trackbar2.Minimum = 0;
            Trackbar2.Maximum = 1000;
            Trackbar2.Anchor = AnchorStyles.Left |  AnchorStyles.Right | AnchorStyles.Bottom;
            Trackbar2.ValueChanged += (sender, e) =>
            {
                label_speed.Text = "Скорость (мс): " + Trackbar2.Value.ToString();
            };
            return Trackbar2;
        }

        public System.Windows.Forms.Button DrawButton()
        {
            Generate.Text = "Генерация чисел";
            Generate.Size = new Size(90, 50);
            Generate.Location = new Point(700, 10);
            Generate.Anchor =  AnchorStyles.Right | AnchorStyles.Top;
            //Task workTask = new Task(() => this.Work());
            Generate.Click += (sender, e) =>
            {

                //Task workTask = new Task(() => this.Work());
                Work();

                //workTask.Start();
            };
            return Generate;
        }

        public System.Windows.Forms.Button DrawButton1()
        {
            Steps.Text = "Далее";
            Steps.Size = new Size(80, 50);
            Steps.Location = new Point(620, 10);
            Steps.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            //Task workTask = new Task(() => this.Work());
            Steps.Click += (sender, e) =>
            {

                //Task workTask = new Task(() => this.Work());
                Simulate();

                //workTask.Start();
            };
            return Steps;
        }

        public Chart DrawChart()
        {
            Data.Location = new Point(10, 10);
            Data.Size = new Size(450, 300);
            Data.ChartAreas.Add(new ChartArea("area"));
            Data.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            // Настройка типа диаграммы
            Data.Series.Add(new Series("Сортировка"));
            Data.Series["Сортировка"].ChartType = SeriesChartType.Column;
            Data.Series.Add(new Series("Сравниваемый элемент 1"));
            Data.Series["Сравниваемый элемент 1"].ChartType = SeriesChartType.Column;
            Data.Series.Add(new Series("Сравниваемый элемент 2"));
            Data.Series["Сравниваемый элемент 2"].ChartType = SeriesChartType.Column;
            Data.Titles.Add("Сортировка");


            // Настройка меток осей
            Data.ChartAreas["area"].AxisX.Title = "Номера элементов";
            Data.ChartAreas["area"].AxisY.Title = "Значения элементов";
            return Data;
        }

        public System.Windows.Forms.Label DrawLabel1()
        {
            label_count.Size = new Size(150, 30);
            label_count.Anchor = AnchorStyles.Top| AnchorStyles.Right;
            label_count.Location = new Point(470, 10);
            label_count.Text = "Количество: " + Trackbar1.Value.ToString();
            return label_count;
        }


        public System.Windows.Forms.Label DrawLabel2()
        {
            label_speed.Size = new Size(150, 20);
            label_speed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_speed.Location = new Point(470, 40);
            label_speed.Text = "Скорость (мс): " + Trackbar2.Value.ToString();
            return label_speed;
        }

        public System.Windows.Forms.Label DrawLabel3()
        {
            label_Bubble.Size = new Size(70, 30);
            label_Bubble.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label_Bubble.Location = new Point(575, 330);
            label_Bubble.Text = "Пузырёк";
            return label_Bubble;
        }

        public System.Windows.Forms.Label DrawLabel4()
        {
            label_Choose.Size = new Size(70, 30);
            label_Choose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label_Choose.Location = new Point(580, 390);
            label_Choose.Text = "Выбор";
            return label_Choose;
        }

        public System.Windows.Forms.Label DrawLabel5()
        {
            label_Comb.Size = new Size(70, 30);
            label_Comb.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label_Comb.Location = new Point(683, 330);
            label_Comb.Text = "Разряды";
            return label_Comb;
        }

        public System.Windows.Forms.Label DrawLabel6()
        {
            label_Gnome.Size = new Size(70, 30);
            label_Gnome.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label_Gnome.Location = new Point(697, 390);
            label_Gnome.Text = "Гном";
            return label_Gnome;
        }


        private int[] Numbers;
        private bool Ok = false;
        private List<(int, int, int, int)> Path;
        private int I=0;
        private int[] Check2 = new int[4] {0,0,0,0 };
        public int[] Start_work(int Lenght)
        {
            Numbers = new int[Lenght];
            for (int i = 0; i < Lenght; i++)
            {
                Numbers[i] = r.Next(101);
            }
            return Numbers;
        }

        public string Return_String()
        {
            return (String.Join("\n", Numbers)); 
        }

        public void Work()
        {
            Start_work(Trackbar1.Value);
            Data.Series[0].Points.Clear();
            RCB.Clear();

            for (int i = 0; i < Numbers.Length; i++)
            {
                Data.Series[0].Points.AddXY(i, Numbers[i]);
            }
            Ok = true;
            Path = Algorithm.Sort(Numbers);
            I = 0;
            //List<(int, int, int, int)> Path = Algorithm.Sort(Numbers);

            //Iters = 0;
            //var Check = (0, 0, 0, 0);
            //bool floag = false;
            //double[] Element1 = new double[0];
            //double[] Element2 = new double[0];
            //foreach ((int, int, int, int) F in Path.ToArray())
            //{
            //    if (floag)
            //        RCB.Text += "Перестановка\n";
            //    if (Check.Item1 == F.Item1 &&  Check.Item3 != F.Item3)
            //    {
            //        RCB.Text += "Перестановка после: \n";
            //    }
            //    Iters++;
            //    Numbers[F.Item1] = F.Item3;
            //    Numbers[F.Item2] = F.Item4;
            //    Data.Series[0].Points.DataBindY(Numbers);
            //    Data.Series[0].Points[F.Item1].Color = Color.Red;
            //    Data.Series[0].Points[F.Item2].Color = Color.Green;
            //    Data.Update();
            //    RCB.Text += "Сравнение : [" + F.Item1 + "] " + F.Item3 + " и [" + F.Item2 + "] и " + F.Item4 + "\n";
            //    RCB.Update();
            //    Check = F;

            //    Task.Delay(Trackbar2.Value).GetAwaiter().GetResult();
            //}
            //RCB.Text += "Сортировка " + What_Kind() + " на " + Trackbar1.Value + " элементов завершена за " + Iters + " перестановок\n";
        }

        public void Simulate()
        {
            if (Ok)
            {
                //List<(int, int, int, int)> Path = Algorithm.Sort(Numbers);

                Iters = 0;
                var Check = (0, 0, 0, 0);
                bool floag = false;
                double[] Element1 = new double[0];
                double[] Element2 = new double[0];
                //if (Check.Item1 == Path[I].Item1 && Check.Item3 != Path[I].Item3)
                //{
                //    RCB.Text += "Перестановка после: \n";
                //}
                //if (Check2[0] == Path[I].Item1 && Check2[2] != Path[I].Item3)
                //{
                //    RCB.Text += "Перестановка после: \n";
                //    Check2[0] = Path[I].Item1;
                //    Check2[1] = Path[I].Item2;
                //    Check2[2] = Path[I].Item3;
                //    Check2[3] = Path[I].Item4;
                //}
                Iters++;
                    Numbers[Path[I].Item1] = Path[I].Item3;
                    Numbers[Path[I].Item2] = Path[I].Item4;
                    Data.Series[0].Points.DataBindY(Numbers);
                    Data.Series[0].Points[Path[I].Item1].Color = Color.Red;
                    Data.Series[0].Points[Path[I].Item2].Color = Color.Green;
                    Data.Update();
                    RCB.Text += "Сравнение : [" + Path[I].Item1 + "] " +  Path[I].Item3 + " и [" + Path[I].Item2 + "] и " + Path[I].Item4 + "\n";
                    RCB.Update();
                    Check = Path[I];
                //Check2[0] = Path[I].Item1;
                //Check2[1] = Path[I].Item2;
                //Check2[2] = Path[I].Item3;
                //Check2[3] = Path[I].Item4;
                I++;
                    //Task.Delay(Trackbar2.Value).GetAwaiter().GetResult();
                //}
            }
            if (I == Path.ToArray().Length)
            {
                I = 0;
                Ok = false;
                RCB.Text += "Сортировка завершена";
            }
            //Ok = false;
        }
        

        public string What_Kind()
        {
            switch (Index) 
            {
                case 0:
                    return "пузырьком";
                case 1:
                    return "выбором";
                case 2:
                    return "поразрядной сортировкой";
                case 3:
                    return "методом гнома";
            }
            return "";
        }
    }
}
