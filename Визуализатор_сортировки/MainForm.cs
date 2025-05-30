using System;
using System.Windows.Forms;


namespace Визуализатор_сортировки
{
    public partial class MainForm : Form 
    {
        private Presenter P;

        public MainForm(Presenter P_)
        {
            P=P_;

            this.Controls.Add(P.DrawChart());

            this.Controls.Add(P.DrawLabel1());

            this.Controls.Add(P.DrawLabel2());

            this.Controls.Add(P.DrawButton());

            this.Controls.Add(P.DrawButton1());

            this.Controls.Add(P.DrawRichTextBox());

            this.Controls.Add(P.DrawTrackBar_1());

            this.Controls.Add(P.DrawTrackBar_2());

            this.Controls.Add(P.DrawCheckBox1());

            this.Controls.Add(P.DrawCheckBox2());

            this.Controls.Add(P.DrawCheckBox3());

            this.Controls.Add(P.DrawCheckBox4());

            this.Controls.Add(P.DrawLabel3());

            this.Controls.Add(P.DrawLabel4());

            this.Controls.Add(P.DrawLabel5());

            this.Controls.Add(P.DrawLabel6());
            //this.Controls.Add(P.DrawRadioButton());

            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Визуализатор работы алгоритмов сортировки";
        }
    }
}
