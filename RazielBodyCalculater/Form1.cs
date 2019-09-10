using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RazielBodyCalculater
{
    public partial class Form1 : Form
    {
        private decimal myweight = 0;
        private decimal maxweightlost = 0;
        private decimal daysforweightlost = 0;
        private decimal daysforonekglost = 0;
        private decimal myheight = 0;
        private decimal weightwish = 0;
        private decimal bmi = 0;
        private decimal bmr = 0;
        private decimal mydde = 0;
        private decimal dde25 = 0;
        private decimal pal = 0;
        private decimal bmi25 = 0;
        private int age = 0;


        public Form1()
        {
            InitializeComponent();
            
        }

        private bool PreConditions()
        {
            try
            {
                myweight = decimal.Parse(mtbWeight.Text);
                weightwish = decimal.Parse(mtbWeightWish.Text);
                myheight = decimal.Parse(mtbHeight.Text) / 100;
                age = int.Parse(tbAge.Text);
                if (rbCorrection1.Checked)
                {
                    pal = decimal.Parse(mtbCorrection1.Text) / 1000;
                }
                if (rbCorrection2.Checked)
                {
                    pal = decimal.Parse(mtbCorrection2.Text) / 1000;
                }
                if (rbCorrection3.Checked)
                {
                    pal = decimal.Parse(mtbCorrection3.Text) / 1000;
                }
                if (rbCorrection4.Checked)
                {
                    pal = decimal.Parse(mtbCorrection4.Text) / 1000;
                }
                if (rbCorrection5.Checked)
                {
                    pal = decimal.Parse(mtbCorrection5.Text) / 1000;
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        private decimal CalculateBMI()
        {
            bmi = (myweight / (myheight * myheight));
            return bmi;
        }

        private decimal CalculateWeightBMI25()
        {
            bmi25 = (25 * (myheight * myheight));
            return bmi25;
        }

        private decimal CalculateBMR(decimal weight)
        {
            if (rbMan.Checked)
            {
                if (rbHB.Checked)
                {
                    bmr = (10 * weight) + ((decimal)6.25 * (myheight * 100)) - (5 * age) + 5;
                }
                if (rbNNR.Checked)
                {
                    if (age >= 0 && age < 3)
                    {
                        bmr = ((((decimal)0.255 * weight) - (decimal)0.141) * 1000) / (decimal)4.18;
                    }
                    if (age >= 3 && age <= 10)
                    {
                        bmr = ((((decimal)0.0937 * weight) + (decimal)2.15) * 1000) / (decimal)4.18;
                    }
                    if (age >= 11 && age <= 18)
                    {
                        bmr = ((((decimal)0.0769 * weight) + (decimal)2.43) * 1000) / (decimal)4.18;
                    }
                    if (age >= 19 && age <= 30)
                    {
                        bmr = ((((decimal)0.0669 * weight) + (decimal)2.28) * 1000) / (decimal)4.18;
                    }
                    if (age >= 31 && age <= 60)
                    {
                        bmr = ((((decimal)0.0592 * weight) + (decimal)2.48) * 1000) / (decimal)4.18;
                    }
                    if (age >= 61 && age <= 70)
                    {
                        bmr = ((((decimal)0.0543 * weight) + (decimal)2.37) * 1000) / (decimal)4.18;
                    }
                    if (age > 70)
                    {
                        bmr = ((((decimal)0.0573 * weight) + (decimal)2.01) * 1000) / (decimal)4.18;
                    }
                }
                
            }
            if (rbWoman.Checked)
            {
                if (rbHB.Checked)
                {
                    bmr = (10 * weight) + ((decimal)6.25 * (myheight * 100)) - (5 * age) - 161;
                }
                if (rbNNR.Checked)
                {
                    if (age >= 0 && age < 3)
                    {
                        bmr = ((((decimal)0.246 * weight) - (decimal)0.0965) * 1000) / (decimal)4.18;
                    }
                    if (age >= 3 && age <= 10)
                    {
                        bmr = ((((decimal)0.0842 * weight) + (decimal)2.12) * 1000) / (decimal)4.18;
                    }
                    if (age >= 11 && age <= 18)
                    {
                        bmr = ((((decimal)0.0465 * weight) + (decimal)3.18) * 1000) / (decimal)4.18;
                    }
                    if (age >= 19 && age <= 30)
                    {
                        bmr = ((((decimal)0.0546 * weight) + (decimal)2.33) * 1000) / (decimal)4.18;
                    }
                    if (age >= 31 && age <= 60)
                    {
                        bmr = ((((decimal)0.0407 * weight) + (decimal)2.90) * 1000) / (decimal)4.18;
                    }
                    if (age >= 61 && age <= 70)
                    {
                        bmr = ((((decimal)0.0429 * weight) + (decimal)2.39) * 1000) / (decimal)4.18;
                    }
                    if (age > 70)
                    {
                        bmr = ((((decimal)0.0417 * weight) + (decimal)2.41) * 1000) / (decimal)4.18;
                    }
                }
            }
            return bmr;
        }

        private decimal CalculateDDE()
        {
            mydde = bmr * pal;
            return mydde;
        }

        private decimal CalculateDDE25()
        {
            dde25 = bmr * pal;
            return dde25;
        }

        private decimal CalculateMaxWeightLost()
        {
            maxweightlost = mydde - bmr;
            return maxweightlost;
        }

        private decimal CalculateOneKgLost()
        {
            daysforonekglost = 7000 / maxweightlost;
            return daysforonekglost;
        }

        private decimal CalculateDaysForWeightLost()
        {
            daysforweightlost = ((myweight - weightwish) * daysforonekglost);
            return daysforweightlost;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (PreConditions())
            {
                tbBMI.Text = CalculateBMI().ToString("N2");
                tbBMI25Weight.Text = CalculateWeightBMI25().ToString("N2");
                tbBMR.Text = CalculateBMR(myweight).ToString("N2");
                tbDDE.Text = CalculateDDE().ToString("N2");
                tbMaxWeightLost.Text = CalculateMaxWeightLost().ToString("N2");
                tbOneKgInDays.Text = CalculateOneKgLost().ToString("N2");
                tbIdealWeightInDays.Text = CalculateDaysForWeightLost().ToString("N2");
                if (bmi >= 30)
                {
                    tbTheoreticalBMR.Text = CalculateBMR(bmi25).ToString("N2");
                    tbTheoreticalDDE.Text = CalculateDDE25().ToString("N2");
                }
                else
                {
                    tbTheoreticalBMR.Text = "";
                    tbTheoreticalDDE.Text = "";
                }
            }
        }
    }
}
