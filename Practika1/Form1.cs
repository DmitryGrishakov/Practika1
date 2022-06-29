using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practika1
{
    public partial class PMIproj : Form
    {
        public PMIproj()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series.Add("PMIseries");
            chart1.Series.Add("Y");
            chart1.Series["PMIseries"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Y"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            button1.Text = "Рассчитать";
            
            
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            int[] mass = new int[n];
            Random rand = new Random();

            
            for (int i = 0; i < mass.Length; i++)
            {
                mass[i] = rand.Next(-20, 80);
            }


            listBox1.Items.Clear();
             for (int i = 0; i < mass.Length; i++)
            {
                listBox1.Items.Add(mass[i]);
            }
            
            chart1.Series["PMIseries"].Points.Clear();
            for (int i = 0; i < mass.Length; i++) chart1.Series["PMIseries"].Points.Add(mass[i]);

            int sumx = 0;
            int sumy = 0;
            int sumxy = 0;
            int sumxx = 0;
            for (int i = 0; i < mass.Length; i++) 
            {
                sumx += i;
                sumy += mass[i];
                sumxy += i * mass[i];
                sumxx += i * i;
            }
            double a = (mass.Length * sumxy - sumx * sumy) / (mass.Length * sumxx - Math.Pow(sumx, 2));
            double b = (sumy - a * sumx) / mass.Length;
            double y = 0;

            chart1.Series["Y"].Points.Clear();
            for (int i = 0; i < mass.Length; i++) 
            {
                y = a * i + b;
                chart1.Series["Y"].Points.Add(y);

            }            
            
        }
    }
}
