using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string Calculation { get; set; }

        private void Button15_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "0";
            }
            else
            {
                Calculation += "0";
                textBox1.Text = Calculation;
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "1";
            }
            else
            {
                Calculation += "1";
                textBox1.Text = Calculation;
            }
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "2";
            }
            else
            {
                Calculation += "2";
                textBox1.Text = Calculation;
            }
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "3";
            }
            else
            {
                Calculation += "3";
                textBox1.Text = Calculation;
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "4";
            }
            else
            {
                Calculation += "4";
                textBox1.Text = Calculation;
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "5";
            }
            else
            {
                Calculation += "5";
                textBox1.Text = Calculation;
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "6";
            }
            else
            {
                Calculation += "6";
                textBox1.Text = Calculation;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "7";
            }
            else
            {
                Calculation += "7";
                textBox1.Text = Calculation;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "8";
            }
            else
            {
                Calculation += "8";
                textBox1.Text = Calculation;
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "9";
            }
            else
            {
                Calculation += "9";
                textBox1.Text = Calculation;
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "+";
            }
            else
            {
                Calculation += "+";
                textBox1.Text = Calculation;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "-";
            }
            else
            {
                Calculation += "-";
                textBox1.Text = Calculation;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "*";
            }
            else
            {
                Calculation += "*";
                textBox1.Text = Calculation;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "/";
            }
            else
            {
                Calculation += "/";
                textBox1.Text = Calculation;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Calculation == "")
            {
                Calculation = "";
            }
            else
            {
                int ToRemove = Calculation.Count();
                Calculation = Calculation.Substring(ToRemove-1, ToRemove-1);
                textBox1.Text = Calculation;
            }
        }
        public void StringCalculation()
        {
            


            Calculation = BerekeningDeel1(Calculation, '*');
            Calculation = BerekeningDeel1(Calculation, '/');
            Calculation = BerekeningDeel1(Calculation, '+');
            Calculation = BerekeningDeel1(Calculation, '-');

            double resultaat = Convert.ToDouble(Calculation);
            textBox1.Text=resultaat.ToString();
        }
        public static string BerekeningDeel1(string berekening, char teken)
        {
            double resultaat = 0;
            int index = berekening.IndexOf(teken);
            while (index != -1)
            {
                //bool con = berekening[i].Equals('+');
                string getal1 = berekening.Substring(0, index);
                double getal1a = Convert.ToDouble(getal1);

                int eindPositieGetal2 = index + 1;

                while (berekening.Length > eindPositieGetal2 && IsOperator(berekening[index]))
                {
                    eindPositieGetal2++;
                }

                string getal2 = berekening.Substring(berekening.IndexOf(teken)+1, index); //hoeveel karakters ipv lengte vd string
                double getal2a = Convert.ToDouble(getal2);
                int IndexofGetal2 = berekening.LastIndexOf(getal2);

                resultaat = Calculate(getal1a, getal2a, teken);
                berekening = berekening.Replace(getal1 + teken + getal2, resultaat.ToString());


                berekening = BerekeningDeel1(berekening, teken);

                index = berekening.IndexOf(teken);

            }

            return berekening;
        }
        public static bool IsOperator(char letter)
        {
            bool result = false;
            if (letter == '*' || letter == '-' || letter == '/' || letter == '+')
            {
                result = true;
            }


            return result;
        }
        public static double Calculate(double getal1, double getal2, char teken)
        {
            double result = 0;

            if (teken == '+')
            {
                Plus plus = new Plus();
                result = plus.Berekening(getal1, getal2);
            }
            else if (teken == '-')
            {
                Min min = new Min();
                result = min.Berekening(getal1, getal2);
            }
            else if (teken == '*')
            {
                Maal maal = new Maal();
                result = maal.Berekening(getal1, getal2);
            }
            else if (teken == '/')
            {
                Delen delen = new Delen();
                result = delen.Berekening(getal1, getal2);
            }



            return result;
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            StringCalculation();
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            Calculation = " ";
            textBox1.Text = Calculation;
        }
    }
}
