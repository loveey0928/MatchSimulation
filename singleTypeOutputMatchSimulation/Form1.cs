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
        public class CInnerVariable
        {
            private double _value = 0;
            //private string _name;

            //public InnerVariable(string name)
            //{ 
            //    this._name = name;
            //}

            public CInnerVariable(double value)
            {
                this._value = value;
            }

            public double dValue
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
        /// <summary>
        ///     Initial setting 
        /// </summary>
        #region Single std L-type Variables, Parameter list
        double _dFrequency = 0;  // To verify that the input value is a real value
        double _dPower = 0; // To verify that the input value is a real value
        double _dL1 = 0; // To verify that the input value is a real value
        double _dL2 = 0; // To verify that the input value is a real value
        double _dR = 0;  // To verify that the input value is a real value
        double _dX = 0;  // To verify that the input value is a real value

        Queue<string> _QueueCalList = new Queue<string>(); //


        CInnerVariable _CalculatedC1 = new CInnerVariable(0); //
        CInnerVariable _CalculatedXc1 = new CInnerVariable(0);//
        CInnerVariable _CalculatedXl1 = new CInnerVariable(0);//
        CInnerVariable _Xc1PlusXl1 = new CInnerVariable(0);//

        CInnerVariable _CalculatedC2 = new CInnerVariable(0);//
        CInnerVariable _CalculatedXc2 = new CInnerVariable(0);//
        CInnerVariable _CalculatedTotalC2 = new CInnerVariable(0);//
        CInnerVariable _CalculatedTotalXc2 = new CInnerVariable(0);//
        CInnerVariable _CalculatedXl2 = new CInnerVariable(0);//

        CInnerVariable _Vpeak = new CInnerVariable(0);
        CInnerVariable _Irms = new CInnerVariable(0);

        CInnerVariable _TotalLoadX = new CInnerVariable(0);

        List<string> _lSourceVrms = new List<string> { "dPower" };
        List<string> _lSourceIrms = new List<string> { "dPower" };
        List<string> _lC1Vpeak = new List<string> { "SourceVrms", "Xc1PlusXl1", "CalculatedXl1" };
        List<string> _lC1Irms = new List<string> { "SourceVrms", "Xc1PlusXl1", "CalculatedXl1" };
        List<string> _lL1Vpeak = new List<string> { "SourceVrms", "Xc1PlusXl1", "CalculatedXl1" };
        List<string> _lL1Irms = new List<string> { "SourceVrms", "Xc1PlusXl1", "CalculatedXl1" };

        List<string> _lC2Vpeak = new List<string> { "C2Irms", "CalculatedTotalXc2" };
        List<string> _lC2Irms = new List<string> { "Irms" };
        List<string> _lL2Vpeak = new List<string> { "L2Irms", "CalculatedXl2" };
        List<string> _lL2Irms = new List<string> { "Irms" };
        //---------------------------------------------------

        List<string> _lCalculatedC1 = new List<string> { "dFrequency", "dR" };//
        List<string> _lCalculatedXc1 = new List<string> { "dFrequency", "CalculatedC1" };//
        List<string> _lCalculatedXl1 = new List<string> { "dFrequency", "dL1" };//
        List<string> _lXc1PlusXl1 = new List<string> { "CalculatedXc1", "CalculatedXl1" };//

        List<string> _lCalculatedC2 = new List<string> { "dFrequency", "dR", "dX" };//
        List<string> _lCalculatedXc2 = new List<string> { "dFrequency", "CalculatedC2" };//
        List<string> _lCalculatedTotalC2 = new List<string> { "dFrequency", "dR", "TotalLoadX" };//
        List<string> _lCalculatedTotalXc2 = new List<string> { "dFrequency", "CalculatedTotalC2" };//
        List<string> _lCalculatedXl2 = new List<string> { "dFrequency", "dL2" };//

        List<string> _lVpeak = new List<string> { "dPower", "dR", "dX" };//
        List<string> _lIrms = new List<string> { "dPower", "dR" };//

        List<string> _lTotalLoadX = new List<string> { "CalculatedXl2", "dX" };//

        public void fSearchingParamInFomula()
        {
            string sQueueFrontMostElement = String.Empty;

            while (_QueueCalList.Count > 0)
            {
                sQueueFrontMostElement = _QueueCalList.Dequeue(); // 

                if (_lSourceVrms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("SourceVrms");
                }
                if (_lSourceIrms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("SourceIrms");
                }
                if (_lC1Vpeak.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("C1Vpeak");
                }
                if (_lC1Irms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("C1Irms");
                }
                if (_lL1Vpeak.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("L1Vpeak");
                }
                if (_lL1Irms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("L1Irms");
                }
                if (_lC2Vpeak.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("C2Vpeak");
                }
                if (_lC2Irms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("C2Irms");
                }
                if (_lL2Vpeak.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("L2Vpeak");
                }
                if (_lL2Irms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("L2Irms");
                }
                if (_lCalculatedC1.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedC1");
                }
                if (_lCalculatedXc1.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedXc1");
                }
                if (_lCalculatedXl1.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedXl1");
                }
                if (_lXc1PlusXl1.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("Xc1PlusXl1");
                }
                if (_lCalculatedC2.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedC2");
                }
                if (_lCalculatedXc2.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedXc2");
                }
                if (_lCalculatedTotalC2.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedTotalC2");
                }
                if (_lCalculatedTotalXc2.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedTotalXc2");
                }
                if (_lCalculatedXl2.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedXl2");
                }
                if (_lVpeak.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("Vpeak");
                }
                if (_lIrms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("Irms");
                }
                if (_lTotalLoadX.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("TotalLoadX");
                }

                fParameterValueReset(sQueueFrontMostElement);
            }

        }

        public string fMathRoundToString(double value)
        {
            value = Math.Round(value, 2); // rounding off : 반올림
            return value.ToString();
        }

        public void fParameterValueReset(string sQueueFrontMostElement)
        {
            double dfrequency = double.Parse(tBox_frequency.Text);
            double dPower = double.Parse(tBox_power.Text);
            double dResistor = double.Parse(tBox_resistor.Text);
            double dReactance = double.Parse(tBox_reactance.Text);

            Console.WriteLine(sQueueFrontMostElement);
            switch (sQueueFrontMostElement)
            {
                default:
                    break;
                case "SourceVrms":
                    lbl_sourceVoltage.Text = fMathRoundToString(Math.Sqrt(50 * double.Parse(tBox_power.Text)));
                    break;
                case "SourceIrms":
                    lbl_sourceCurrent.Text = fMathRoundToString(Math.Sqrt(double.Parse(tBox_power.Text) / 50));
                    break;
                case "C1Vpeak":
                    lbl_C1Voltage.Text = fMathRoundToString(Math.Sqrt(2) * double.Parse(lbl_sourceVoltage.Text) * (_Xc1PlusXl1.dValue / (_Xc1PlusXl1.dValue - _CalculatedXl1.dValue)));
                    break;
                case "C1Irms":
                    lbl_C1Current.Text = fMathRoundToString(double.Parse(lbl_sourceVoltage.Text) / (_Xc1PlusXl1.dValue - _CalculatedXl1.dValue));
                    break;
                case "L1Vpeak":
                    lbl_L1Voltage.Text = fMathRoundToString(Math.Sqrt(2) * double.Parse(lbl_sourceVoltage.Text) * (_CalculatedXl1.dValue / (_Xc1PlusXl1.dValue - _CalculatedXl1.dValue)));
                    break;
                case "L1Irms":
                    lbl_L1Current.Text = fMathRoundToString(double.Parse(lbl_sourceVoltage.Text) / (_Xc1PlusXl1.dValue - _CalculatedXl1.dValue));
                    break;

                case "C2Vpeak":
                    lbl_C2Voltage.Text = fMathRoundToString(Math.Sqrt(2) * double.Parse(lbl_C2Current.Text) * _CalculatedTotalXc2.dValue);
                    break;
                case "C2Irms":
                    lbl_C2Current.Text = fMathRoundToString(_Irms.dValue);
                    break;
                case "L2Vpeak":
                    lbl_L2Voltage.Text = fMathRoundToString(Math.Sqrt(2) * double.Parse(lbl_L2Current.Text) * _CalculatedXl2.dValue);
                    break;
                case "L2Irms":
                    lbl_L2Current.Text = fMathRoundToString(_Irms.dValue);
                    break;

                case "CalculatedC1":
                    _CalculatedC1.dValue = Math.Pow(10, 12) * (1 / (50 * 2 * Math.PI * dfrequency * Math.Pow(10, 6)) * Math.Sqrt((50 - dResistor) / dResistor));
                    lbl_C1.Text = fMathRoundToString(_CalculatedC1.dValue);
                    break;
                case "CalculatedXc1":
                    _CalculatedXc1.dValue = 1 / (2 * Math.PI * dfrequency * Math.Pow(10, 6) * _CalculatedC1.dValue * Math.Pow(10, -12));
                    break;
                case "CalculatedXl1":
                    _CalculatedXl1.dValue = 2 * Math.PI * dfrequency * Math.Pow(10, 6) * double.Parse(tBox_L1.Text) * Math.Pow(10, -6);
                    break;
                case "Xc1PlusXl1":
                    _Xc1PlusXl1.dValue = _CalculatedXc1.dValue + _CalculatedXl1.dValue;
                    break;

                case "CalculatedC2":
                    _CalculatedC2.dValue = Math.Pow(10, 12) * (1 / ((2 * Math.PI * dfrequency * Math.Pow(10, 6)) * (dReactance - Math.Sqrt((dResistor * (50 - dResistor))))));
                    lbl_C2.Text = fMathRoundToString(_CalculatedC2.dValue);
                    break;
                case "CalculatedXc2":
                    _CalculatedXc2.dValue = 1 / (2 * Math.PI * dfrequency * Math.Pow(10, 6) * _CalculatedC2.dValue * Math.Pow(10, -12));
                    break;
                case "CalculatedTotalC2":
                    _CalculatedTotalC2.dValue = Math.Pow(10, 12) * (1 / ((2 * Math.PI * dfrequency * Math.Pow(10, 6)) * (_TotalLoadX.dValue - Math.Sqrt((dResistor * (50 - dResistor))))));
                    break;
                case "CalculatedTotalXc2":
                    _CalculatedTotalXc2.dValue = 1 / (2 * Math.PI * dfrequency * Math.Pow(10, 6) * _CalculatedTotalC2.dValue * Math.Pow(10, -12));

                    if (_CalculatedTotalXc2.dValue >= 0)
                    {
                        lbl__C2Status.Text = "C2 [pF] - explicit solution";
                        lbl__C2Status.BackColor = Color.Turquoise;
                    }
                    else
                    {
                        lbl__C2Status.Text = "C2 [pF] - No explicit solution exists. You should add on L2 inductance level";
                        lbl__C2Status.BackColor = Color.Tomato;
                    }

                    break;
                case "CalculatedXl2":
                    _CalculatedXl2.dValue = 2 * Math.PI * dfrequency * Math.Pow(10, 6) * double.Parse(tBox_L2.Text) * Math.Pow(10, -6);
                    break;

                case "Vpeak":
                    _Vpeak.dValue = Math.Sqrt(2) * Math.Sqrt(dPower * (Math.Pow(dResistor, 2) + Math.Pow(dReactance, 2)) / dResistor);
                    break;
                case "Irms":
                    _Irms.dValue = Math.Sqrt(double.Parse(tBox_power.Text) / dResistor);
                    break;

                case "TotalLoadX":
                    _TotalLoadX.dValue = _CalculatedXl2.dValue + dReactance;
                    break;

            }
        }
        #endregion

        public class CStd_L_Type_DualOutput 
        {
            Queue<string> _QueueCalList = new Queue<string>(); //

            double dFrequency = 0;  // To verify that the input value is a real value
            double dPower = 0; // To verify that the input value is a real value
            double dL1 = 0; // To verify that the input value is a real value
            double dL2 = 0; // To verify that the input value is a real value
            double dOuterR = 0;  // To verify that the input value is a real value
            double dOuterXl = 0;  // To verify that the input value is a real value
            double dC3_pF = 0;
            double dC4_pF = 0;
            double dC5_percent = 0;
            double dInnerR = 0;
            double dInnerXl = 0;
            double dTargetVVC = 0;
            //====================================================================================
            double dInVar_CalculatedC1 = 0;
            double dInVar_CalculatedXc1 = 0;
            double dInVar_Xc1PlusXl1 = 0;

            double dInVar_CalculatedXl1 = 0;
            //=====================================================================================
            double dInVar_CalculatedC2 = 0;
            double dInVar_CalculatedX_C2 = 0;
            double dInVar_CalculatedTotalC2 = 0;
            double dInVar_CalculatedTotalX_C2 = 0;

            double dInVar_CalculatedX_L2 = 0;
            //=====================================================================================
            double dInVar_Z_total = 0;

            double dInVar_Vtotal = 0;
            double dInVar_Itotal = 0;

            double dInVar_Z_Outer = 0;  //!!!
            //====================================================================================
            double dInVar_OuterXc = 0;
            double dInVar_convert_C5_percent_To_pF = 0;

            double dInVar_SizeofX_C4 = 0;
            double dInVar_Z_C4 = 0;

            double dInVar_correctionFactor = 32;
            double dInVar_C5pF_plus_CorrectionFactor = 0;
            double dInVar_SizeOfX_C5 = 0;
            double dInVar_Z_C5 = 0;

            double dInVar_Z_sumOf_C5_InnerPart = 0;
            double dInVar_Z_sumOf_C4_C5_InnerPart = 0; //!!!
            //====================================================================================
            double dInVar_Z_InnerPart = 0;

            //===================Power============================================================
            List<string> lSourceVrms = new List<string> { "dPower" };
            List<string> lSourceIrms = new List<string> { "dPower" };
            List<string> lC1Vpeak = new List<string> { "SourceVrms", "dInVar_Xc1PlusXl1", "dInVar_CalculatedXl1" };
            List<string> lC1Irms = new List<string> { "SourceVrms", "dInVar_Xc1PlusXl1", "dInVar_CalculatedXl1" };
            List<string> lL1Vpeak = new List<string> { "SourceVrms", "dInVar_Xc1PlusXl1", "dInVar_CalculatedXl1" };
            List<string> lL1Irms = new List<string> { "SourceVrms", "dInVar_Xc1PlusXl1", "dInVar_CalculatedXl1" };

            List<string> lC2Vpeak = new List<string> { "C2Irms", "dInVar_CalculatedTotalX_C2" };
            List<string> lC2Irms = new List<string> { "dInVar_Itotal" };//
            List<string> lL2Vpeak = new List<string> { "L2Irms", "dInVar_CalculatedX_L2" };//
            List<string> lL2Irms = new List<string> { "dInVar_Itotal" };//

            //
            List<string> lInVar_CalculatedC1 = new List<string> { "dFrequency", "dInVar_Z_total" };//
            List<string> lInVar_CalculatedXc1 = new List<string> { "dFrequency", "dInVar_CalculatedC1" };//
            List<string> lInVar_Xc1PlusXl1 = new List<string> { "dInVar_CalculatedXc1", "dInVar_CalculatedXl1" };//

            List<string> lInVar_CalculatedXl1 = new List<string> { "dFrequency", "dL1" };//

            List<string> lInVar_CalculatedC2 = new List<string> { "dFrequency", "dInVar_Z_total" };//
            List<string> lInVar_CalculatedX_C2 = new List<string> { "dFrequency", "dInVar_CalculatedC2" };//
            List<string> lInVar_CalculatedTotalC2 = new List<string> { "dFrequency", "dInVar_CalculatedX_L2", "dInVar_Z_total" };//
            List<string> lInVar_CalculatedTotalX_C2 = new List<string> { "dFrequency", "dInVar_CalculatedTotalC2" };//

            List<string> lInVar_CalculatedX_L2 = new List<string> { "dFrequency", "dL2" };//

            List<string> lInVar_Vtotal = new List<string> { "dPower", "dInVar_Z_total" };//
            List<string> lInVar_Itotal = new List<string> { "dPower", "dInVar_Z_total" };//
            //===================Load===============================================================
            List<string> lInVar_Z_InnerPart = new List<string> { "dInnerR", "dInnerXl" };//

            List<string> lInVar_convert_C5_percent_To_pF = new List<string> { "dTargetVVC", "dC5_percent"};/// <summary>
            /// 
            /// </summary>
            List<string> lInVar_C5pF_plus_CorrectionFactor = new List<string> { "dInVar_correctionFactor", "dInVar_convert_C5_percent_To_pF" };//
            List<string> lInVar_SizeOfX_C5 = new List<string> { "dFrequency", "dInVar_C5pF_plus_CorrectionFactor" };//
            List<string> lInVar_Z_sumOf_C5_InnerPart = new List<string> { "dInVar_SizeOfX_C5", "dInVar_Z_InnerPart" };
            List<string> lInVar_Z_sumOf_C4_C5_InnerPart = new List<string> { "dInVar_Z_C4", "dInVar_Z_sumOf_C5_InnerPart" };

            List<string> lInVar_OuterXc = new List<string> { "dFrequency", "dC3_pF" };//
            List<string> lInVar_Z_OuterPart = new List<string> { "dOuterR", "dOuterXl", "dInVar_OuterXc" };//

            List<string> lInVar_Z_total = new List<string> { "dInVar_Z_sumOf_C4_C5_InnerPart", "dInVar_Z_OuterPart" };//
        }
        public void fSearchingParamInFomula_Std_L_Type_DualOutput()
        {
            string sQueueFrontMostElement = String.Empty;

            while (_QueueCalList.Count > 0)
            {
                sQueueFrontMostElement = _QueueCalList.Dequeue(); // 

                if (_lSourceVrms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("SourceVrms");
                }
                if (_lSourceIrms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("SourceIrms");
                }
                if (_lC1Vpeak.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("C1Vpeak");
                }
                if (_lC1Irms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("C1Irms");
                }
                if (_lL1Vpeak.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("L1Vpeak");
                }
                if (_lL1Irms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("L1Irms");
                }
                if (_lC2Vpeak.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("C2Vpeak");
                }
                if (_lC2Irms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("C2Irms");
                }
                if (_lL2Vpeak.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("L2Vpeak");
                }
                if (_lL2Irms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("L2Irms");
                }
                if (_lCalculatedC1.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedC1");
                }
                if (_lCalculatedXc1.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedXc1");
                }
                if (_lCalculatedXl1.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedXl1");
                }
                if (_lXc1PlusXl1.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("Xc1PlusXl1");
                }
                if (_lCalculatedC2.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedC2");
                }
                if (_lCalculatedXc2.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedXc2");
                }
                if (_lCalculatedTotalC2.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedTotalC2");
                }
                if (_lCalculatedTotalXc2.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedTotalXc2");
                }
                if (_lCalculatedXl2.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("CalculatedXl2");
                }
                if (_lVpeak.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("Vpeak");
                }
                if (_lIrms.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("Irms");
                }
                if (_lTotalLoadX.Contains(sQueueFrontMostElement))
                {
                    _QueueCalList.Enqueue("TotalLoadX");
                }

                fParameterValueReset(sQueueFrontMostElement);
            }

        }

        public string fMathRoundToString_Std_L_Type_DualOutput(double value)
        {
            value = Math.Round(value, 2); // rounding off : 반올림
            return value.ToString();
        }

        public void fParameterValueReset_Std_L_Type_DualOutput(string sQueueFrontMostElement)
        {
            double dfrequency = double.Parse(tBox_frequency.Text);
            double dPower = double.Parse(tBox_power.Text);
            double dResistor = double.Parse(tBox_resistor.Text);
            double dReactance = double.Parse(tBox_reactance.Text);

            Console.WriteLine(sQueueFrontMostElement);
            switch (sQueueFrontMostElement)
            {
                default:
                    break;
                case "SourceVrms":
                    lbl_sourceVoltage.Text = fMathRoundToString(Math.Sqrt(50 * double.Parse(tBox_power.Text)));
                    break;
                case "SourceIrms":
                    lbl_sourceCurrent.Text = fMathRoundToString(Math.Sqrt(double.Parse(tBox_power.Text) / 50));
                    break;
                case "C1Vpeak":
                    lbl_C1Voltage.Text = fMathRoundToString(Math.Sqrt(2) * double.Parse(lbl_sourceVoltage.Text) * (_Xc1PlusXl1.dValue / (_Xc1PlusXl1.dValue - _CalculatedXl1.dValue)));
                    break;
                case "C1Irms":
                    lbl_C1Current.Text = fMathRoundToString(double.Parse(lbl_sourceVoltage.Text) / (_Xc1PlusXl1.dValue - _CalculatedXl1.dValue));
                    break;
                case "L1Vpeak":
                    lbl_L1Voltage.Text = fMathRoundToString(Math.Sqrt(2) * double.Parse(lbl_sourceVoltage.Text) * (_CalculatedXl1.dValue / (_Xc1PlusXl1.dValue - _CalculatedXl1.dValue)));
                    break;
                case "L1Irms":
                    lbl_L1Current.Text = fMathRoundToString(double.Parse(lbl_sourceVoltage.Text) / (_Xc1PlusXl1.dValue - _CalculatedXl1.dValue));
                    break;

                case "C2Vpeak":
                    lbl_C2Voltage.Text = fMathRoundToString(Math.Sqrt(2) * double.Parse(lbl_C2Current.Text) * _CalculatedTotalXc2.dValue);
                    break;
                case "C2Irms":
                    lbl_C2Current.Text = fMathRoundToString(_Irms.dValue);
                    break;
                case "L2Vpeak":
                    lbl_L2Voltage.Text = fMathRoundToString(Math.Sqrt(2) * double.Parse(lbl_L2Current.Text) * _CalculatedXl2.dValue);
                    break;
                case "L2Irms":
                    lbl_L2Current.Text = fMathRoundToString(_Irms.dValue);
                    break;

                case "CalculatedC1":
                    _CalculatedC1.dValue = Math.Pow(10, 12) * (1 / (50 * 2 * Math.PI * dfrequency * Math.Pow(10, 6)) * Math.Sqrt((50 - dResistor) / dResistor));
                    lbl_C1.Text = fMathRoundToString(_CalculatedC1.dValue);
                    break;
                case "CalculatedXc1":
                    _CalculatedXc1.dValue = 1 / (2 * Math.PI * dfrequency * Math.Pow(10, 6) * _CalculatedC1.dValue * Math.Pow(10, -12));
                    break;
                case "CalculatedXl1":
                    _CalculatedXl1.dValue = 2 * Math.PI * dfrequency * Math.Pow(10, 6) * double.Parse(tBox_L1.Text) * Math.Pow(10, -6);
                    break;
                case "Xc1PlusXl1":
                    _Xc1PlusXl1.dValue = _CalculatedXc1.dValue + _CalculatedXl1.dValue;
                    break;

                case "CalculatedC2":
                    _CalculatedC2.dValue = Math.Pow(10, 12) * (1 / ((2 * Math.PI * dfrequency * Math.Pow(10, 6)) * (dReactance - Math.Sqrt((dResistor * (50 - dResistor))))));
                    lbl_C2.Text = fMathRoundToString(_CalculatedC2.dValue);
                    break;
                case "CalculatedXc2":
                    _CalculatedXc2.dValue = 1 / (2 * Math.PI * dfrequency * Math.Pow(10, 6) * _CalculatedC2.dValue * Math.Pow(10, -12));
                    break;
                case "CalculatedTotalC2":
                    _CalculatedTotalC2.dValue = Math.Pow(10, 12) * (1 / ((2 * Math.PI * dfrequency * Math.Pow(10, 6)) * (_TotalLoadX.dValue - Math.Sqrt((dResistor * (50 - dResistor))))));
                    break;
                case "CalculatedTotalXc2":
                    _CalculatedTotalXc2.dValue = 1 / (2 * Math.PI * dfrequency * Math.Pow(10, 6) * _CalculatedTotalC2.dValue * Math.Pow(10, -12));

                    if (_CalculatedTotalXc2.dValue >= 0)
                    {
                        lbl__C2Status.Text = "C2 [pF] - explicit solution";
                        lbl__C2Status.BackColor = Color.Turquoise;
                    }
                    else
                    {
                        lbl__C2Status.Text = "C2 [pF] - No explicit solution exists. You should add on L2 inductance level";
                        lbl__C2Status.BackColor = Color.Tomato;
                    }

                    break;
                case "CalculatedXl2":
                    _CalculatedXl2.dValue = 2 * Math.PI * dfrequency * Math.Pow(10, 6) * double.Parse(tBox_L2.Text) * Math.Pow(10, -6);
                    break;

                case "Vpeak":
                    _Vpeak.dValue = Math.Sqrt(2) * Math.Sqrt(dPower * (Math.Pow(dResistor, 2) + Math.Pow(dReactance, 2)) / dResistor);
                    break;
                case "Irms":
                    _Irms.dValue = Math.Sqrt(double.Parse(tBox_power.Text) / dResistor);
                    break;

                case "TotalLoadX":
                    _TotalLoadX.dValue = _CalculatedXl2.dValue + dReactance;
                    break;

            }
        }

        public Form1()
        {
            InitializeComponent();
            lbl__C2Status.Text = "C2 [pF] - No explicit solution exists. You should add on L2 inductance level";
            lbl__C2Status.BackColor = Color.Tomato;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region Single_Std_L-type
        private void tBox_frequency_TextChanged(object sender, EventArgs e)
        {
            // To verify that the input value is a real value
            if (Double.TryParse(tBox_frequency.Text, out _dFrequency) == true)
            {
                // When, input value is a real value
                tBox_frequency.Text = tBox_frequency.Text;

                _QueueCalList.Enqueue("dFrequency");
                fSearchingParamInFomula();
            }
            else if (tBox_frequency.Text.EndsWith("."))
            {
                tBox_frequency.Text = tBox_frequency.Text;
            }
            //else if (String.IsNullOrEmpty(tBox_frequency.Text))
            //{
            //    tBox_frequency.Text = "0";
            //}
            else if (!String.IsNullOrEmpty(tBox_frequency.Text) && Double.TryParse(tBox_frequency.Text, out _dFrequency) == false)
            {
                MessageBox.Show("Please input real number to Freq [MHz]");
            }
        }

        private void tBox_power_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_power.Text, out _dPower) == true)
            {
                tBox_power.Text = tBox_power.Text;

                _QueueCalList.Enqueue("dPower");
                fSearchingParamInFomula();
            }
            else if (tBox_power.Text.EndsWith("."))
            {
                tBox_power.Text = tBox_power.Text;
            }
            //else if (String.IsNullOrEmpty(tBox_power.Text))
            //{
            //    tBox_power.Text = "0";
            //}
            else if (!String.IsNullOrEmpty(tBox_power.Text) && Double.TryParse(tBox_power.Text, out _dPower) == false)
            {
                MessageBox.Show("Please input real number to power [W]");
            }


        }

        private void tBox_L1_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_L1.Text, out _dL1) == true)
            {
                tBox_L1.Text = tBox_L1.Text;

                _QueueCalList.Enqueue("dL1");
                fSearchingParamInFomula();
            }
            else if (tBox_L1.Text.EndsWith("."))
            {
                tBox_L1.Text = tBox_L1.Text;
            }
            //else if (String.IsNullOrEmpty(tBox_L1.Text))
            //{
            //    tBox_L1.Text = "0";
            //}
            else if (!String.IsNullOrEmpty(tBox_L1.Text) && Double.TryParse(tBox_L1.Text, out _dL1) == false)
            {
                MessageBox.Show("Please input real number to L1 [µH]");
            }
        }

        private void tBox_L2_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_L2.Text, out _dL2) == true)
            {
                tBox_L2.Text = tBox_L2.Text;

                _QueueCalList.Enqueue("dL2");
                fSearchingParamInFomula();
            }
            else if (tBox_L2.Text.EndsWith("."))
            {
                tBox_L2.Text = tBox_L2.Text;
            }
            //else if (String.IsNullOrEmpty(tBox_L2.Text))
            //{
            //    tBox_L2.Text = "0";
            //}
            else if (!String.IsNullOrEmpty(tBox_L2.Text) && Double.TryParse(tBox_L2.Text, out _dL2) == false)
            {
                MessageBox.Show("Please input real number to L2 [µH]");
            }

        }

        private void tBox_resistor_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_resistor.Text, out _dR) == true)
            {
                tBox_resistor.Text = tBox_resistor.Text;

                _QueueCalList.Enqueue("dR");
                fSearchingParamInFomula();
            }
            else if (tBox_resistor.Text.EndsWith("."))
            {
                tBox_resistor.Text = tBox_resistor.Text;
            }
            //else if (String.IsNullOrEmpty(tBox_resistor.Text))
            //{
            //    tBox_resistor.Text = "0";
            //}
            else if (!String.IsNullOrEmpty(tBox_resistor.Text) && Double.TryParse(tBox_resistor.Text, out _dR) == false)
            {
                MessageBox.Show("Please input real number to r [Ω]"); //x [Ω]
            }

        }

        private void tBox_reactance_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_reactance.Text, out _dX) == true)
            {
                tBox_reactance.Text = tBox_reactance.Text;

                _QueueCalList.Enqueue("dX");
                fSearchingParamInFomula();
            }
            else if (tBox_reactance.Text.EndsWith("."))
            {
                tBox_reactance.Text = tBox_reactance.Text;
            }
            //else if (String.IsNullOrEmpty(tBox_reactance.Text))
            //{
            //    tBox_reactance.Text = "0";
            //}
            else if (!String.IsNullOrEmpty(tBox_reactance.Text) && Double.TryParse(tBox_reactance.Text, out _dX) == false)
            {
                MessageBox.Show("Please input real number to x [Ω]"); //
            }

        }

        #endregion

        private void tBox_singleFreqDualOutput_targetVVC_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
