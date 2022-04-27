using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace singleTypeOutputMatchSimulation
{
    public partial class Form1 : Form
    {
        public class InnerVariable
        {
            private double _value;
            //private string _name;

            //public InnerVariable(string name)
            //{ 
            //    this._name = name;
            //}

            public double Value
            {
                get
                {
                    return this._value;
                }
                set
                {
                    this._value = value;
                }
            }

            //public event EventHandler EventHandlerChangeByInnerVariable;

            //public void MethodChangeByInnerVariable()
            //{ 
            //    //EventHandlerChangeByInnerVariable?.DynamicInvoke(this, new EventArgs(), this._name);
            //    EventHandlerChangeByInnerVariable.Invoke(this, new EventArgs());
            //}
        }

        
        //void EventChangingByInnerVariable(object sender, EventArgs eventArgs)
        //{
        //    Console.WriteLine("aa");
        //    string a = "0";
        //    switch (a)
        //    {
        //        default:
        //            break;
        //        case "CalculatedC1":
        //            Console.WriteLine(CalculatedC1.Value.ToString() + "event");
        //            break;
        //        case "CalculatedXc1":
        //            break;
        //        case "CalculatedXl1":
        //            break;
        //        case "Xc1PlusXl1":
        //            break;

        //        case "CalculatedC2":
        //            break;
        //        case "CalculatedXc2":
        //            break;
        //        case "CalculatedTotalC2":
        //            break;
        //        case "CalculatedTotalXc2":
        //            break;
        //        case "CalculatedXl2":
        //            break;

        //        case "Vpeak":
        //            break;
        //        case "Irms":
        //            break;

        //        case "TotalLoadXl":
        //            break;

        //    }
        //}

        double dFrequency = 0;  // To verify that the input value is a real value
        double dPower = 0; // To verify that the input value is a real value
        double dL1 = 0; // To verify that the input value is a real value
        double dL2 = 0; // To verify that the input value is a real value
        double dR = 0;  // To verify that the input value is a real value
        double dX = 0;  // To verify that the input value is a real value

        InnerVariable CalculatedC1 = new InnerVariable();
        InnerVariable CalculatedXc1 = new InnerVariable();
        InnerVariable CalculatedXl1 = new InnerVariable();
        InnerVariable Xc1PlusXl1 = new InnerVariable();

        InnerVariable CalculatedC2 = new InnerVariable();
        InnerVariable CalculatedXc2 = new InnerVariable();
        InnerVariable CalculatedTotalC2 = new InnerVariable();
        InnerVariable CalculatedTotalXc2 = new InnerVariable();
        InnerVariable CalculatedXl2 = new InnerVariable();

        InnerVariable Vpeak = new InnerVariable();
        InnerVariable Irms = new InnerVariable();

        InnerVariable TotalLoadXl = new InnerVariable();

        public void fChangingByInnerVariable(string sInstanceName)
        {
            Console.WriteLine(sInstanceName);
            switch (sInstanceName)
            {
                default:
                    break;
                case "CalculatedC1":
                    Console.WriteLine(CalculatedC1.Value.ToString() + "event");
                    break;
                case "CalculatedXc1":
                    
                    break;
                case "CalculatedXl1":
                    break;
                case "Xc1PlusXl1":
                    break;

                case "CalculatedC2":
                    break;
                case "CalculatedXc2":
                    break;
                case "CalculatedTotalC2":
                    break;
                case "CalculatedTotalXc2":
                    break;
                case "CalculatedXl2":
                    break;

                case "Vpeak":
                    break;
                case "Irms":
                    break;

                case "TotalLoadXl":
                    break;

            }
        }
            public Form1()
        {
            InitializeComponent();
            //CalculatedC1.EventHandlerChangeByInnerVariable += new EventHandler(EventChangingByInnerVariable);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tBox_frequency_TextChanged(object sender, EventArgs e)
        {
            // To verify that the input value is a real value
            if (Double.TryParse(tBox_frequency.Text, out dFrequency) == true)
            {
                tBox_frequency.Text = tBox_frequency.Text;
                CalculatedC1.Value = double.Parse(tBox_frequency.Text);

                fChangingByInnerVariable("CalculatedC1");
            }
            else if (tBox_frequency.Text.EndsWith("."))
            {
                tBox_frequency.Text = tBox_frequency.Text;
            }
            else if (Double.TryParse(tBox_frequency.Text, out dFrequency) == false)
            {
                MessageBox.Show("Please input real number to Freq [MHz]");
            }
        }

        private void tBox_power_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_power.Text, out dPower) == true)
            {
                tBox_power.Text = tBox_power.Text;
            }
            else if (tBox_power.Text.EndsWith("."))
            {
                tBox_power.Text = tBox_power.Text;
            }
            else if (Double.TryParse(tBox_power.Text, out dPower) == false)
            {
                MessageBox.Show("Please input real number to power [W]");
            }


        }

        private void tBox_L1_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_L1.Text, out dL1) == true)
            {
                tBox_L1.Text = tBox_L1.Text;
            }
            else if (tBox_L1.Text.EndsWith("."))
            {
                tBox_L1.Text = tBox_L1.Text;
            }
            else if (Double.TryParse(tBox_L1.Text, out dL1) == false)
            {
                MessageBox.Show("Please input real number to L1 [µH]");
            }
        }

        private void tBox_L2_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_L2.Text, out dL2) == true)
            {
                tBox_L2.Text = tBox_L2.Text;
            }
            else if (tBox_L2.Text.EndsWith("."))
            {
                tBox_L2.Text = tBox_L2.Text;
            }
            else if (Double.TryParse(tBox_L2.Text, out dL2) == false)
            {
                MessageBox.Show("Please input real number to L2 [µH]");
            }

        }

        private void tBox_resistor_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_resistor.Text, out dR) == true)
            {
                tBox_resistor.Text = tBox_resistor.Text;
            }
            else if (tBox_resistor.Text.EndsWith("."))
            {
                tBox_resistor.Text = tBox_resistor.Text;
            }
            else if (Double.TryParse(tBox_resistor.Text, out dR) == false)
            {
                MessageBox.Show("Please input real number to r [Ω]"); //x [Ω]
            }

        }

        private void tBox_reactance_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_reactance.Text, out dX) == true)
            {
                tBox_reactance.Text = tBox_reactance.Text;
            }
            else if (tBox_reactance.Text.EndsWith("."))
            {
                tBox_reactance.Text = tBox_reactance.Text;
            }
            else if (Double.TryParse(tBox_reactance.Text, out dX) == false)
            {
                MessageBox.Show("Please input real number to x [Ω]"); //
            }

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
