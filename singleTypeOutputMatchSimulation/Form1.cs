using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;


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

        public double fMathRoundToDouble(double value)
        {
            return Math.Round(value, 2);
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

        CStd_L_Type_DualOutput_for_NauraMatch nauraMatch = new CStd_L_Type_DualOutput_for_NauraMatch();
        public class CStd_L_Type_DualOutput_for_NauraMatch
        {
            public Queue<string> QueueCalList = new Queue<string>(); //

            public double dFrequency = 0;  // To verify that the input value is a real value
            public double dPower = 0; // To verify that the input value is a real value
            public double dL1 = 0; // To verify that the input value is a real value
            public double dL2 = 0; // To verify that the input value is a real value
            public double dOuterR = 0;  // To verify that the input value is a real value
            public double dOuterXl = 0;  // To verify that the input value is a real value
            public double dC3_pF = 0;
            public double dC4_pF = 0;
            public double dC5_percent = 0;
            public double dInnerR = 0;
            public double dInnerXl = 0;
            public double dTargetVVC = 0;

            public double dSourceVrms = 0;
            public double dSourceIrms = 0;
            public double dC1Vpeak = 0;
            public double dC1Irms = 0;
            public double dL1Vpeak = 0;
            public double dL1Irms = 0;

            public double dC2Vpeak = 0;
            public double dC2Irms = 0;
            public double dL2Vpeak = 0;
            public double dL2Irms = 0;
            //====================================================================================
            public double dC1 = 0;
            public double dInVar_CalculatedC1 = 0;
            public double dInVar_CalculatedXc1 = 0;
            public double dInVar_Xc1PlusXl1 = 0;

            public double dInVar_CalculatedXl1 = 0;
            //=====================================================================================
            public double dInVar_CalculatedC2 = 0;
            public double dInVar_CalculatedX_C2 = 0;
            public double dInVar_CalculatedTotalC2 = 0;
            public double dInVar_CalculatedTotalX_C2 = 0;

            public double dInVar_CalculatedX_L2 = 0;
            //=====================================================================================
            public Complex comInVar_Z_total = new Complex(0, 0);

            public double dInVar_Vtotal = 0;
            public double dInVar_Itotal = 0;

            public Complex comInVar_Z_OuterPart = new Complex(0, 0);  //!!!

            public double dOuterVpeak = 0;
            public double dOuterArms = 0;
            public double dOuterPower = 0;
            public double dOuterPhase = 0;

            public double dOuterV_R = 0;
            public double dOuterV_L = 0;
            public double dOuterV_C = 0;
            //====================================================================================
            public double dInVar_OuterXc = 0;
            public double dInVar_convert_C5_percent_To_pF = 0;

            public double dInVar_SizeofX_C4 = 0;
            //public Complex comInVar_Z_C4 = new Complex(0,0);
            public double dVpeak_C4 = 0;
            public double dArms_C4 = 0;

            public double dInVar_correctionFactor = 0;
            public double dInVar_C5pF_plus_CorrectionFactor = 0;
            public double dInVar_SizeOfX_C5 = 0;
            //public Complex comInVar_Z_C5 = new Complex(0, 0);
            public double dVpeak_C5 = 0;
            public double dArms_C5 = 0;

            public Complex comInVar_Z_sumOf_C5_InnerPart = new Complex(0, 0);
            public Complex comInVar_Z_sumOf_C4_C5_InnerPart = new Complex(0, 0); //!!!

            public double dInnerVpeak = 0;
            public double dInnerArms = 0;
            public double dInnerPower = 0;
            public double dInnerPhase = 0;

            public double dInnerV_R = 0;
            public double dInnerV_L = 0;

            //====================================================================================
            public Complex comInVar_Z_InnerPart = new Complex(0, 0); //
            //====================================================================================
            public double dCurrentRatio = 0;

            public double dC5Start_forCurrentRatioEtcCal = 0;
            public double dC5End_forCurrentRatioEtcCal = 0;
            public double dC5Interval_forCurrentRatioEtcCal = 0;

            public DataTable dtCalculatedCurrentRatioEtc = new DataTable();
            //===================Power============================================================
            public List<string> lSourceVrms = new List<string> { "Power" };
            public List<string> lSourceIrms = new List<string> { "Power" };
            public List<string> lC1Vpeak = new List<string> { "SourceVrms", "InVar_Xc1PlusXl1", "InVar_CalculatedXl1" };
            public List<string> lC1Irms = new List<string> { "SourceVrms", "InVar_Xc1PlusXl1", "InVar_CalculatedXl1" };
            public List<string> lL1Vpeak = new List<string> { "SourceVrms", "InVar_Xc1PlusXl1", "InVar_CalculatedXl1" };
            public List<string> lL1Irms = new List<string> { "SourceVrms", "InVar_Xc1PlusXl1", "InVar_CalculatedXl1" };

            public List<string> lC2Vpeak = new List<string> { "C2Irms", "InVar_CalculatedTotalX_C2" };
            public List<string> lC2Irms = new List<string> { "InVar_Itotal" };//
            public List<string> lL2Vpeak = new List<string> { "L2Irms", "InVar_CalculatedX_L2" };//
            public List<string> lL2Irms = new List<string> { "InVar_Itotal" };//

            public List<string> lC1 = new List<string> { "Frequency" , "InVar_Xc1PlusXl1" };
            public List<string> lInVar_CalculatedC1 = new List<string> { "Frequency", "InVar_Z_total" };
            public List<string> lInVar_CalculatedXc1 = new List<string> { "Frequency", "InVar_CalculatedC1" };//
            public List<string> lInVar_Xc1PlusXl1 = new List<string> { "InVar_CalculatedXc1", "InVar_CalculatedXl1" };//

            public List<string> lInVar_CalculatedXl1 = new List<string> { "Frequency", "L1" };//

            public List<string> lInVar_CalculatedC2 = new List<string> { "Frequency", "InVar_Z_total" };//
            public List<string> lInVar_CalculatedX_C2 = new List<string> { "Frequency", "InVar_CalculatedC2" };//
            public List<string> lInVar_CalculatedTotalC2 = new List<string> { "Frequency", "InVar_CalculatedX_L2", "InVar_Z_total" };//
            public List<string> lInVar_CalculatedTotalX_C2 = new List<string> { "Frequency", "InVar_CalculatedTotalC2" };//

            public List<string> lInVar_CalculatedX_L2 = new List<string> { "Frequency", "L2" };//

            public List<string> lInVar_Vtotal = new List<string> { "Power", "InVar_Z_total" };//
            public List<string> lInVar_Itotal = new List<string> { "Power", "InVar_Z_total" };//
            //===================Load_Impedance===============================================================
            public List<string> lInVar_Z_InnerPart = new List<string> { "InnerR", "InnerXl" };//

            public List<string> lInVar_convert_C5_percent_To_pF = new List<string> { "TargetVVC", "C5_percent"};//

            public List<string> lInVar_C5pF_plus_CorrectionFactor = new List<string> { "InVar_correctionFactor", "InVar_convert_C5_percent_To_pF" };//
            public List<string> lInVar_SizeOfX_C4 = new List<string> { "Frequency", "C4_pF" };//
            public List<string> lInVar_SizeOfX_C5 = new List<string> { "Frequency", "InVar_C5pF_plus_CorrectionFactor" };//
            public List<string> lInVar_Z_sumOf_C5_InnerPart = new List<string> { "InVar_SizeOfX_C5", "InVar_Z_InnerPart" };
            public List<string> lInVar_Z_sumOf_C4_C5_InnerPart = new List<string> { "InVar_SizeofX_C4", "InVar_Z_sumOf_C5_InnerPart" };

            public List<string> lInVar_OuterXc = new List<string> { "Frequency", "C3_pF" };//
            public List<string> lInVar_Z_OuterPart = new List<string> { "OuterR", "OuterXl", "InVar_OuterXc" };//

            public List<string> lInVar_Z_total = new List<string> { "InVar_Z_sumOf_C4_C5_InnerPart", "InVar_Z_OuterPart" };//
            //===================Voltage_Current_Power_Phase===========================================================
            public List<string> lOuterArms = new List<string> { "InVar_Vtotal", "InVar_Z_OuterPart" };//
            public List<string> lOuterVpeak = new List<string> { "OuterArms", "InVar_Z_OuterPart" };//
            public List<string> lOuterPhase = new List<string> { "OuterR", "OuterXl", "InVar_OuterXc" };//
            public List<string> lOuterPower = new List<string> { "OuterPhase", "OuterArms" , "OuterVpeak" };//

            public List<string> lInnerArms = new List<string> { "InnerVpeak", "InVar_Z_InnerPart" };//
            public List<string> lInnerVpeak = new List<string> { "Vpeak_C5" };//
            public List<string> lInnerPhase = new List<string> { "InnerR", "InnerXl" };//
            public List<string> lInnerPower = new List<string> { "InnerArms", "InnerPhase", "InnerVpeak" };//

            public List<string> lVpeak_C4 = new List<string> { "Arms_C4", "InVar_SizeofX_C4" };//
            public List<string> lArms_C4 = new List<string> { "InVar_Vtotal", "InVar_Z_sumOf_C4_C5_InnerPart" };//
            public List<string> lVpeak_C5 = new List<string> { "Arms_C4", "InVar_Z_sumOf_C5_InnerPart" };//
            public List<string> lArms_C5 = new List<string> { "Vpeak_C5", "InVar_SizeOfX_C5" };//

            public List<string> lOuterV_R = new List<string> { "OuterArms", "OuterR" };//
            public List<string> lOuterV_L = new List<string> { "OuterArms", "OuterXl" };//
            public List<string> lOuterV_C = new List<string> { "OuterArms", "InVar_OuterXc" };//

            public List<string> lInnerV_R = new List<string> { "InnerArms", "InnerR" };
            public List<string> lInnerV_L = new List<string> { "InnerArms", "InnerXl" };
            public List<string> lCurrentRatio = new List<string> { "InnerArms", "OuterArms" };
        }
        public void fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch()
        {
            string sQueueFrontMostElement = String.Empty;
            
            while (nauraMatch.QueueCalList.Count > 0)
            {
                sQueueFrontMostElement = nauraMatch.QueueCalList.Dequeue(); // 
                #region inputToQueue
                if (nauraMatch.lSourceVrms.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("SourceVrms");
                }
                if (nauraMatch.lSourceIrms.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("SourceIrms");
                }
                if (nauraMatch.lC1Vpeak.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("C1Vpeak");
                }
                if (nauraMatch.lC1Irms.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("C1Irms");
                }
                if (nauraMatch.lL1Vpeak.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("L1Vpeak");
                }
                if (nauraMatch.lL1Irms.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("L1Irms");
                }
                if (nauraMatch.lC2Irms.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("C2Irms");
                }
                if (nauraMatch.lC2Vpeak.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("C2Vpeak");
                }
                if (nauraMatch.lL2Vpeak.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("L2Vpeak");
                }
                if (nauraMatch.lL2Irms.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("L2Irms");
                }
                if (nauraMatch.lC1.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("C1");
                }
                if (nauraMatch.lInVar_CalculatedC1.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_CalculatedC1");
                }
                if (nauraMatch.lInVar_CalculatedXc1.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_CalculatedXc1");
                }
                if (nauraMatch.lInVar_CalculatedXl1.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_CalculatedXl1");
                }
                if (nauraMatch.lInVar_Xc1PlusXl1.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_Xc1PlusXl1");
                }
                if (nauraMatch.lInVar_CalculatedC2.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_CalculatedC2");
                }
                if (nauraMatch.lInVar_CalculatedX_C2.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_CalculatedX_C2");
                }
                if (nauraMatch.lInVar_CalculatedTotalC2.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_CalculatedTotalC2");
                }
                if (nauraMatch.lInVar_CalculatedTotalX_C2.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_CalculatedTotalX_C2");
                }
                if (nauraMatch.lInVar_CalculatedX_L2.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_CalculatedX_L2");
                }
                if (nauraMatch.lInVar_Vtotal.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_Vtotal");
                }
                if (nauraMatch.lInVar_Itotal.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_Itotal");
                }
                if (nauraMatch.lInVar_Z_InnerPart.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_Z_InnerPart");
                }
                if (nauraMatch.lInVar_convert_C5_percent_To_pF.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_convert_C5_percent_To_pF");
                }
                if (nauraMatch.lInVar_C5pF_plus_CorrectionFactor.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_C5pF_plus_CorrectionFactor");
                }
                if (nauraMatch.lInVar_SizeOfX_C4.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_SizeOfX_C4");
                }
                if (nauraMatch.lInVar_SizeOfX_C5.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_SizeOfX_C5");
                }
                if (nauraMatch.lInVar_Z_sumOf_C5_InnerPart.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_Z_sumOf_C5_InnerPart");
                }
                if (nauraMatch.lInVar_Z_sumOf_C4_C5_InnerPart.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_Z_sumOf_C4_C5_InnerPart");
                }
                if (nauraMatch.lInVar_OuterXc.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_OuterXc");
                }
                if (nauraMatch.lInVar_Z_OuterPart.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_Z_OuterPart");
                }
                if (nauraMatch.lInVar_Z_total.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InVar_Z_total");
                }
                if (nauraMatch.lOuterArms.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("OuterArms");
                }
                if (nauraMatch.lOuterVpeak.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("OuterVpeak");
                }
                if (nauraMatch.lOuterPhase.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("OuterPhase");
                }
                if (nauraMatch.lOuterPower.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("OuterPower");
                }
                if (nauraMatch.lInnerArms.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InnerArms");
                }
                if (nauraMatch.lInnerVpeak.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InnerVpeak");
                }
                if (nauraMatch.lInnerPhase.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InnerPhase");
                }
                if (nauraMatch.lInnerPower.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InnerPower");
                }
                if (nauraMatch.lVpeak_C4.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("Vpeak_C4");
                }
                if (nauraMatch.lArms_C4.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("Arms_C4");
                }
                if (nauraMatch.lVpeak_C5.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("Vpeak_C5");
                }
                if (nauraMatch.lArms_C5.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("Arms_C5");
                }
                if (nauraMatch.lOuterV_R.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("OuterV_R");
                }
                if (nauraMatch.lOuterV_L.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("OuterV_L");
                }
                if (nauraMatch.lOuterV_C.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("OuterV_C");
                }
                if (nauraMatch.lInnerV_R.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InnerV_R");
                }
                if (nauraMatch.lInnerV_L.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("InnerV_L");
                }
                if (nauraMatch.lCurrentRatio.Contains(sQueueFrontMostElement))
                {
                    nauraMatch.QueueCalList.Enqueue("CurrentRatio");
                }
                #endregion
                fParameterValueReset_Std_L_Type_DualOutput_for_NauraMatch(sQueueFrontMostElement);
            }

        }
        public void fParameterValueReset_Std_L_Type_DualOutput_for_NauraMatch(string sQueueFrontMostElement)
        {
            nauraMatch.dFrequency = double.Parse(tBox_singleFreqDualOutput_frequency.Text);
            nauraMatch.dPower = double.Parse(tBox_singleFreqDualOutput_power.Text);
            nauraMatch.dL1 = double.Parse(tBox_singleFreqDualOutput_L1.Text);
            nauraMatch.dL2 = double.Parse(tBox_singleFreqDualOutput_L2.Text);
            nauraMatch.dOuterR = double.Parse(tBox_singleFreqDualOutput_outerR.Text);
            nauraMatch.dOuterXl = double.Parse(tBox_singleFreqDualOutput_OuterXL.Text);
            nauraMatch.dC3_pF = double.Parse(tBox_singleFreqDualOutput_outerC3_pF.Text);
            nauraMatch.dC4_pF = double.Parse(tBox_singleFreqDualOutput_C4pF.Text);
            nauraMatch.dC5_percent = double.Parse(tBox_singleFreqDualOutput_C5_percent.Text);
            nauraMatch.dInnerR = double.Parse(tBox_singleFreqDualOutput_InnerR.Text);
            nauraMatch.dInnerXl = double.Parse(tBox_singleFreqDualOutput_InnerXl.Text);
            nauraMatch.dTargetVVC = double.Parse(tBox_singleFreqDualOutput_targetVVC.Text);

            //Console.WriteLine(sQueueFrontMostElement);
            switch (sQueueFrontMostElement)
            {
                default:
                    break;
                case "SourceVrms":
                    nauraMatch.dSourceVrms = Math.Sqrt(50 * nauraMatch.dPower);
                    lbl_singleFreqDualOutput_source_Vrms.Text = fMathRoundToString(nauraMatch.dSourceVrms);
                    break;
                case "SourceIrms":
                    nauraMatch.dSourceIrms = Math.Sqrt(nauraMatch.dPower / 50);
                    lbl_singleFreqDualOutput_source_Irms.Text = fMathRoundToString(nauraMatch.dSourceIrms);
                    break;
                case "C1Vpeak":
                    nauraMatch.dC1Vpeak = Math.Sqrt(2) * nauraMatch.dSourceVrms * (nauraMatch.dInVar_Xc1PlusXl1 / (nauraMatch.dInVar_Xc1PlusXl1 - nauraMatch.dInVar_CalculatedXl1));
                    lbl_singleFreqDualOutput_C1_Vpeak.Text = fMathRoundToString(nauraMatch.dC1Vpeak);//
                    break;
                case "C1Irms":
                    nauraMatch.dC1Irms = nauraMatch.dSourceVrms / (nauraMatch.dInVar_Xc1PlusXl1 - nauraMatch.dInVar_CalculatedXl1);
                    lbl_singleFreqDualOutput_C1_Irms.Text = fMathRoundToString(nauraMatch.dC1Irms);//
                    break;
                case "L1Vpeak":
                    nauraMatch.dL1Vpeak = Math.Sqrt(2) * nauraMatch.dSourceVrms * (nauraMatch.dInVar_CalculatedXl1 / (nauraMatch.dInVar_Xc1PlusXl1 - nauraMatch.dInVar_CalculatedXl1));
                    lbl_singleFreqDualOutput_L1_Vpeak.Text = fMathRoundToString(nauraMatch.dL1Vpeak);//
                    break;
                case "L1Irms":
                    nauraMatch.dL1Irms = nauraMatch.dSourceVrms / (nauraMatch.dInVar_Xc1PlusXl1 - nauraMatch.dInVar_CalculatedXl1);
                    lbl_singleFreqDualOutput_L1_Irms.Text = fMathRoundToString(nauraMatch.dL1Irms);//
                    break;


                case "C2Vpeak":
                    nauraMatch.dC2Vpeak = Math.Sqrt(2) * nauraMatch.dC2Irms * nauraMatch.dInVar_CalculatedTotalX_C2;
                    lbl_singleFreqDualOutput_C2_Vpeak.Text = fMathRoundToString(nauraMatch.dC2Vpeak);//
                    break;
                case "C2Irms":
                    nauraMatch.dC2Irms = Math.Sqrt(nauraMatch.dPower / nauraMatch.comInVar_Z_total.Real);
                    lbl_singleFreqDualOutput_C2_Irms.Text = fMathRoundToString(nauraMatch.dC2Irms);//
                    break;
                case "L2Vpeak":
                    nauraMatch.dL2Vpeak = Math.Sqrt(2) * nauraMatch.dL2Irms * nauraMatch.dInVar_CalculatedX_L2;
                    lbl_singleFreqDualOutput_L2_Vpeak.Text = fMathRoundToString(nauraMatch.dL2Vpeak);//
                    break;
                case "L2Irms":
                    nauraMatch.dL2Irms = Math.Sqrt(nauraMatch.dPower / nauraMatch.comInVar_Z_total.Real);
                    lbl_singleFreqDualOutput_L2_Irms.Text = fMathRoundToString(nauraMatch.dL2Irms);//
                    break;

                case "C1":
                    nauraMatch.dC1 = Math.Pow(10, 12) * (1 / (2 * Math.PI * nauraMatch.dFrequency * Math.Pow(10, 6) * nauraMatch.dInVar_Xc1PlusXl1  ));
                    lbl_singleFreqDualOutput_C1.Text = fMathRoundToString(nauraMatch.dC1);//
                    break;
                case "InVar_CalculatedC1":
                    nauraMatch.dInVar_CalculatedC1 = Math.Pow(10, 12) * (1 / (50 * 2 * Math.PI * nauraMatch.dFrequency * Math.Pow(10, 6)) * Math.Sqrt((50 - nauraMatch.comInVar_Z_total.Real) / nauraMatch.comInVar_Z_total.Real));
                    break;
                case "InVar_CalculatedXc1":
                    nauraMatch.dInVar_CalculatedXc1 = 1 / (2 * Math.PI * nauraMatch.dFrequency * Math.Pow(10, 6) * nauraMatch.dInVar_CalculatedC1 * Math.Pow(10, -12));//
                    break;
                case "InVar_Xc1PlusXl1":
                    nauraMatch.dInVar_Xc1PlusXl1 = nauraMatch.dInVar_CalculatedXc1 + nauraMatch.dInVar_CalculatedXl1;//
                    break;


                case "InVar_CalculatedXl1":
                    nauraMatch.dInVar_CalculatedXl1 = 2 * Math.PI * nauraMatch.dFrequency * Math.Pow(10, 6) * nauraMatch.dL1 * Math.Pow(10, -6);//
                    break;


                case "InVar_CalculatedC2":
                    nauraMatch.dInVar_CalculatedC2 = Math.Pow(10, 12) * (1 / ((2 * Math.PI * nauraMatch.dFrequency * Math.Pow(10, 6)) * (nauraMatch.comInVar_Z_total.Imaginary - Math.Sqrt((nauraMatch.comInVar_Z_total.Real * (50 - nauraMatch.comInVar_Z_total.Real))))));//
                    break;
                case "InVar_CalculatedX_C2":
                    nauraMatch.dInVar_CalculatedX_C2 = 1 / (2 * Math.PI * nauraMatch.dFrequency * Math.Pow(10, 6) * nauraMatch.dInVar_CalculatedC2 * Math.Pow(10, -12));//
                    break;
                case "InVar_CalculatedTotalC2":
                    nauraMatch.dInVar_CalculatedTotalC2 = Math.Pow(10, 12) * (1 / ((2 * Math.PI * nauraMatch.dFrequency * Math.Pow(10, 6)) * ((nauraMatch.dInVar_CalculatedX_L2 + nauraMatch.comInVar_Z_total.Imaginary) - Math.Sqrt((nauraMatch.comInVar_Z_total.Real * (50 - nauraMatch.comInVar_Z_total.Real))))));//
                    lbl_singleFreqDualOutput_C2.Text = fMathRoundToString(nauraMatch.dInVar_CalculatedTotalC2);//
                    break;
                case "InVar_CalculatedTotalX_C2":
                    nauraMatch.dInVar_CalculatedTotalX_C2 = 1 / (2 * Math.PI * nauraMatch.dFrequency * Math.Pow(10, 6) * nauraMatch.dInVar_CalculatedTotalC2 * Math.Pow(10, -12));//

                    if (nauraMatch.dInVar_CalculatedTotalX_C2 >= 0)
                    {
                        lbl_singleFreqDualOutput_C2Status.Text = "C2 [pF] - explicit solution";
                        lbl_singleFreqDualOutput_C2Status.BackColor = Color.Turquoise;
                    }
                    else
                    {
                        lbl_singleFreqDualOutput_C2Status.Text = "C2 [pF] - No explicit solution exists. You should add on L2 inductance level";
                        lbl_singleFreqDualOutput_C2Status.BackColor = Color.Tomato;
                    }
                    break;//


                case "InVar_CalculatedX_L2":
                    nauraMatch.dInVar_CalculatedX_L2 = 2 * Math.PI * nauraMatch.dFrequency * Math.Pow(10, 6) * nauraMatch.dL2 * Math.Pow(10, -6);//
                    break;


                case "InVar_Vtotal":
                    nauraMatch.dInVar_Vtotal = Math.Sqrt(2) * Math.Sqrt(nauraMatch.dPower * (Math.Pow(Complex.Abs(nauraMatch.comInVar_Z_total), 2)) / nauraMatch.comInVar_Z_total.Real);//
                    break;
                case "InVar_Itotal":
                    nauraMatch.dInVar_Itotal = Math.Sqrt(nauraMatch.dPower / nauraMatch.comInVar_Z_total.Real);//
                    break;
                //===================Load_Impedance===============================================================
                case "InVar_Z_InnerPart":
                    nauraMatch.comInVar_Z_InnerPart = new Complex(nauraMatch.dInnerR , nauraMatch.dInnerXl);//
                    break;


                case "InVar_convert_C5_percent_To_pF":
                    nauraMatch.dInVar_convert_C5_percent_To_pF = nauraMatch.dTargetVVC * (nauraMatch.dC5_percent /100);//
                    break;

                case "InVar_C5pF_plus_CorrectionFactor":
                    nauraMatch.dInVar_C5pF_plus_CorrectionFactor = nauraMatch.dInVar_convert_C5_percent_To_pF + nauraMatch.dInVar_correctionFactor;//
                    break;
                case "InVar_SizeOfX_C4":
                    nauraMatch.dInVar_SizeofX_C4 = 1 / (2 * Math.PI * nauraMatch.dFrequency * Math.Pow(10, 6) * nauraMatch.dC4_pF * Math.Pow(10, -12)); //
                    break;
                case "InVar_SizeOfX_C5":
                    nauraMatch.dInVar_SizeOfX_C5 = 1 / (2 * Math.PI * nauraMatch.dFrequency * Math.Pow(10, 6) * nauraMatch.dInVar_C5pF_plus_CorrectionFactor * Math.Pow(10, -12)); //
                    break;
                case "InVar_Z_sumOf_C5_InnerPart":
                    Complex comUpsideDownedZ = Complex.Add(Complex.Divide(1, nauraMatch.comInVar_Z_InnerPart), Complex.Divide(1, new Complex(0, (-1)*nauraMatch.dInVar_SizeOfX_C5)));//
                    nauraMatch.comInVar_Z_sumOf_C5_InnerPart = Complex.Divide(1,comUpsideDownedZ);//
                    break;
                case "InVar_Z_sumOf_C4_C5_InnerPart":
                    nauraMatch.comInVar_Z_sumOf_C4_C5_InnerPart = Complex.Add(new Complex(0,-nauraMatch.dInVar_SizeofX_C4),nauraMatch.comInVar_Z_sumOf_C5_InnerPart);//
                    break;


                case "InVar_OuterXc":
                    nauraMatch.dInVar_OuterXc = 1 / (2 * Math.PI * nauraMatch.dFrequency * Math.Pow(10, 6) * nauraMatch.dC3_pF * Math.Pow(10, -12));//
                    //Console.WriteLine(nauraMatch.dInVar_OuterXc.ToString());
                    break;
                case "InVar_Z_OuterPart":
                    nauraMatch.comInVar_Z_OuterPart = new Complex(nauraMatch.dOuterR,nauraMatch.dOuterXl-nauraMatch.dInVar_OuterXc);//
                    break;


                case "InVar_Z_total":
                    Complex comUpsideDownedZ_ = Complex.Add(Complex.Divide(1, nauraMatch.comInVar_Z_OuterPart), Complex.Divide(1, nauraMatch.comInVar_Z_sumOf_C4_C5_InnerPart));//
                    nauraMatch.comInVar_Z_total = Complex.Divide(1, comUpsideDownedZ_);//
                    break;
                //===================Voltage_Current_Power_Phase===========================================================
                case "OuterArms":
                    nauraMatch.dOuterArms = ((nauraMatch.dInVar_Vtotal / Math.Sqrt(2))) / (Complex.Abs(nauraMatch.comInVar_Z_OuterPart));
                    lbl_singleFreqDualOutput_outer_current_Arms.Text = fMathRoundToString(nauraMatch.dOuterArms);//
                    break;
                case "OuterVpeak":
                    nauraMatch.dOuterVpeak = Math.Sqrt(2) * nauraMatch.dOuterArms * Complex.Abs(nauraMatch.comInVar_Z_OuterPart);
                    lbl_singleFreqDualOutput_outer_Vpeak.Text = fMathRoundToString(nauraMatch.dOuterVpeak);//
                    break;
                case "OuterPhase":
                    nauraMatch.dOuterPhase = Math.Atan((nauraMatch.dOuterXl - nauraMatch.dInVar_OuterXc) / nauraMatch.dOuterR) * (180 / Math.PI) ;
                    //Console.WriteLine("{0}, {1}, {2}",nauraMatch.dOuterPhase.ToString(), nauraMatch.dOuterR.ToString(), nauraMatch.dOuterXl.ToString());
                    lbl_singleFreqDualOutput_outer_phase.Text = fMathRoundToString(nauraMatch.dOuterPhase);
                    break;
                case "OuterPower":
                    nauraMatch.dOuterPower = nauraMatch.dOuterArms * (nauraMatch.dOuterVpeak / Math.Sqrt(2)) * Math.Cos(nauraMatch.dOuterPhase * Math.PI / 180);
                    lbl_singleFreqDualOutput_outer_power.Text = fMathRoundToString(nauraMatch.dOuterPower);//
                    break;


                case "InnerArms":
                    nauraMatch.dInnerArms = (nauraMatch.dInnerVpeak / Complex.Abs(nauraMatch.comInVar_Z_InnerPart)) / Math.Sqrt(2);
                    lbl_singleFreqDualOutput_inner_current_Arms.Text = fMathRoundToString(nauraMatch.dInnerArms);//
                    break;
                case "InnerVpeak":
                    nauraMatch.dInnerVpeak = Math.Sqrt(2) * Complex.Abs(nauraMatch.comInVar_Z_sumOf_C5_InnerPart) * nauraMatch.dArms_C4;//
                    lbl_singleFreqDualOutput_inner_Vpeak.Text = fMathRoundToString(nauraMatch.dInnerVpeak);
                    break;
                case "InnerPhase":
                    nauraMatch.dInnerPhase = Math.Atan(nauraMatch.dInnerXl / nauraMatch.dInnerR) * 180 / Math.PI;
                    lbl_singleFreqDualOutput_inner_phase.Text = fMathRoundToString(nauraMatch.dInnerPhase);//
                    break;
                case "InnerPower":
                    nauraMatch.dInnerPower = nauraMatch.dInnerArms * (nauraMatch.dInnerVpeak / Math.Sqrt(2)) * Math.Cos(nauraMatch.dInnerPhase * Math.PI / 180);
                    lbl_singleFreqDualOutput_inner_power.Text = fMathRoundToString(nauraMatch.dInnerPower);//
                    break;


                case "Vpeak_C4":
                    nauraMatch.dVpeak_C4 = Math.Sqrt(2) * nauraMatch.dInVar_SizeofX_C4 * nauraMatch.dArms_C4;
                    lbl_singleFreqDualOutput_Vpeak_C4.Text = fMathRoundToString(nauraMatch.dVpeak_C4);//
                    break;
                case "Arms_C4":
                    nauraMatch.dArms_C4 = (nauraMatch.dInVar_Vtotal / Complex.Abs(nauraMatch.comInVar_Z_sumOf_C4_C5_InnerPart)) / Math.Sqrt(2);
                    lbl_singleFreqDualOutput_Arms_C4.Text = fMathRoundToString(nauraMatch.dArms_C4);//
                    break;
                case "Vpeak_C5":
                    nauraMatch.dVpeak_C5 = Math.Sqrt(2) * Complex.Abs(nauraMatch.comInVar_Z_sumOf_C5_InnerPart) * nauraMatch.dArms_C4;
                    lbl_singleFreqDualOutput_Vpeak_C5.Text = fMathRoundToString(nauraMatch.dVpeak_C5);//
                    break;
                case "Arms_C5":
                    nauraMatch.dArms_C5 = (nauraMatch.dVpeak_C5 / Math.Sqrt(2)) / nauraMatch.dInVar_SizeOfX_C5;
                    lbl_singleFreqDualOutput_Arms_C5.Text = fMathRoundToString(nauraMatch.dArms_C5);//
                    break;


                case "OuterV_R":
                    nauraMatch.dOuterV_R = Math.Sqrt(2) * nauraMatch.dOuterArms * nauraMatch.dOuterR;//
                    lbl_singleFreqDualOutput_outerR_Vpeak.Text = fMathRoundToString(nauraMatch.dOuterV_R);//
                    break;
                case "OuterV_L":
                    nauraMatch.dOuterV_L = Math.Sqrt(2) * nauraMatch.dOuterArms * nauraMatch.dOuterXl;
                    lbl_singleFreqDualOutput_outerL_Vpeak.Text = fMathRoundToString(nauraMatch.dOuterV_L);
                    break;
                case "OuterV_C":
                    nauraMatch.dOuterV_C = Math.Sqrt(2) * nauraMatch.dOuterArms * nauraMatch.dInVar_OuterXc;
                    lbl_singleFreqDualOutput_C3_Vrms.Text = fMathRoundToString(nauraMatch.dOuterV_C);
                    break;


                case "InnerV_R":
                    nauraMatch.dInnerV_R = Math.Sqrt(2) * nauraMatch.dInnerArms * nauraMatch.dInnerR;
                    lbl_singleFreqDualOutput_InnerR_Vpeak.Text = fMathRoundToString(nauraMatch.dInnerV_R);
                    break;
                case "InnerV_L":
                    nauraMatch.dInnerV_L = Math.Sqrt(2) * nauraMatch.dInnerArms * nauraMatch.dInnerXl;
                    lbl_singleFreqDualOutput_InnerL_Vpeak.Text = fMathRoundToString(nauraMatch.dInnerV_L);
                    break;

                case "CurrentRatio":
                    nauraMatch.dCurrentRatio = nauraMatch.dOuterArms / (nauraMatch.dInnerArms + nauraMatch.dOuterArms);
                    //Console.WriteLine(nauraMatch.dCurrentRatio);
                    lbl_singleFreqDualOutput_currentRatio.Text = fMathRoundToString(nauraMatch.dCurrentRatio);
                    break;

            }
        }

        public Form1()
        {
            InitializeComponent();
            lbl__C2Status.Text = "C2 [pF] - No explicit solution exists. You should add on L2 inductance level";
            lbl__C2Status.BackColor = Color.Tomato;
            //=========================for_Naura==============================================================================================
            #region for_Naura
            lbl_singleFreqDualOutput_C2Status.Text = "C2 [pF] - No explicit solution exists. You should add on L2 inductance level";
            lbl_singleFreqDualOutput_C2Status.BackColor = Color.Tomato;

            nauraMatch.dtCalculatedCurrentRatioEtc.Columns.Add("C5[%]",typeof(double));
            nauraMatch.dtCalculatedCurrentRatioEtc.Columns.Add("CurrentRatio",typeof(double));
            nauraMatch.dtCalculatedCurrentRatioEtc.Columns.Add("V_Outer", typeof(double));
            nauraMatch.dtCalculatedCurrentRatioEtc.Columns.Add("I_Outer", typeof(double));
            nauraMatch.dtCalculatedCurrentRatioEtc.Columns.Add("Power_Outer", typeof(double));
            nauraMatch.dtCalculatedCurrentRatioEtc.Columns.Add("Phase_Outer", typeof(double));
            nauraMatch.dtCalculatedCurrentRatioEtc.Columns.Add("V_Inner", typeof(double));
            nauraMatch.dtCalculatedCurrentRatioEtc.Columns.Add("I_Inner", typeof(double));
            nauraMatch.dtCalculatedCurrentRatioEtc.Columns.Add("Power_Inner", typeof(double));
            nauraMatch.dtCalculatedCurrentRatioEtc.Columns.Add("Phase_Inner", typeof(double));

            nauraMatch.dFrequency = double.Parse(tBox_singleFreqDualOutput_frequency.Text);
            nauraMatch.dPower = double.Parse(tBox_singleFreqDualOutput_power.Text);
            nauraMatch.dL1 = double.Parse(tBox_singleFreqDualOutput_L1.Text);
            nauraMatch.dL2 = double.Parse(tBox_singleFreqDualOutput_L2.Text);
            nauraMatch.dOuterR = double.Parse(tBox_singleFreqDualOutput_outerR.Text);
            nauraMatch.dOuterXl = double.Parse(tBox_singleFreqDualOutput_OuterXL.Text);
            nauraMatch.dC3_pF = double.Parse(tBox_singleFreqDualOutput_outerC3_pF.Text);
            nauraMatch.dC4_pF = double.Parse(tBox_singleFreqDualOutput_C4pF.Text);
            nauraMatch.dC5_percent = double.Parse(tBox_singleFreqDualOutput_C5_percent.Text);
            nauraMatch.dInnerR = double.Parse(tBox_singleFreqDualOutput_InnerR.Text);
            nauraMatch.dInnerXl = double.Parse(tBox_singleFreqDualOutput_InnerXl.Text);
            nauraMatch.dTargetVVC = double.Parse(tBox_singleFreqDualOutput_targetVVC.Text);
            nauraMatch.QueueCalList.Enqueue("L1");
            nauraMatch.QueueCalList.Enqueue("L2");
            nauraMatch.QueueCalList.Enqueue("OuterR");
            nauraMatch.QueueCalList.Enqueue("OuterXl");
            nauraMatch.QueueCalList.Enqueue("C3_pF");
            nauraMatch.QueueCalList.Enqueue("C4_pF");
            nauraMatch.QueueCalList.Enqueue("C5_percent");
            nauraMatch.QueueCalList.Enqueue("InnerR");
            nauraMatch.QueueCalList.Enqueue("InnerXl");
            nauraMatch.QueueCalList.Enqueue("TargetVVC");
            nauraMatch.QueueCalList.Enqueue("Frequency");
            nauraMatch.QueueCalList.Enqueue("Power");

            fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            #endregion
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

        #region Std-L-type-dualOutput_forNauraMatch
        private void tBox_singleFreqDualOutput_frequency_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_singleFreqDualOutput_frequency.Text, out nauraMatch.dFrequency) == true)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                nauraMatch.QueueCalList.Enqueue("Frequency");
                fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            }
            else if (tBox_singleFreqDualOutput_frequency.Text.EndsWith("."))
            {
                
            }
            else if (!String.IsNullOrEmpty(tBox_singleFreqDualOutput_frequency.Text) && Double.TryParse(tBox_singleFreqDualOutput_frequency.Text, out nauraMatch.dFrequency) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Frequency"); //
            }
        }

        private void tBox_singleFreqDualOutput_power_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_singleFreqDualOutput_power.Text, out nauraMatch.dPower) == true)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                nauraMatch.QueueCalList.Enqueue("Power");
                fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            }
            else if (tBox_singleFreqDualOutput_power.Text.EndsWith("."))
            {

            }
            else if (!String.IsNullOrEmpty(tBox_singleFreqDualOutput_power.Text) && Double.TryParse(tBox_singleFreqDualOutput_power.Text, out nauraMatch.dPower) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Frequency"); //
            }
        }

        private void tBox_singleFreqDualOutput_L1_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_singleFreqDualOutput_L1.Text, out nauraMatch.dL1) == true)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                nauraMatch.QueueCalList.Enqueue("L1");
                fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            }
            else if (tBox_singleFreqDualOutput_L1.Text.EndsWith("."))
            {

            }
            else if (!String.IsNullOrEmpty(tBox_singleFreqDualOutput_L1.Text) && Double.TryParse(tBox_singleFreqDualOutput_L1.Text, out nauraMatch.dL1) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Frequency"); //
            }
        }

        private void tBox_singleFreqDualOutput_L2_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_singleFreqDualOutput_L2.Text, out nauraMatch.dL2) == true)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                nauraMatch.QueueCalList.Enqueue("L2");
                fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            }
            else if (tBox_singleFreqDualOutput_L2.Text.EndsWith("."))
            {

            }
            else if (!String.IsNullOrEmpty(tBox_singleFreqDualOutput_L2.Text) && Double.TryParse(tBox_singleFreqDualOutput_L2.Text, out nauraMatch.dL2) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Frequency"); //
            }
        }

        private void tBox_singleFreqDualOutput_outerR_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_singleFreqDualOutput_outerR.Text, out nauraMatch.dOuterR) == true)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                nauraMatch.QueueCalList.Enqueue("OuterR");
                fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            }
            else if (tBox_singleFreqDualOutput_outerR.Text.EndsWith("."))
            {

            }
            else if (!String.IsNullOrEmpty(tBox_singleFreqDualOutput_outerR.Text) && Double.TryParse(tBox_singleFreqDualOutput_outerR.Text, out nauraMatch.dOuterR) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Frequency"); //
            }
        }

        private void tBox_singleFreqDualOutput_OuterXL_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_singleFreqDualOutput_OuterXL.Text, out nauraMatch.dOuterXl) == true)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                nauraMatch.QueueCalList.Enqueue("OuterXl");
                fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            }
            else if (tBox_singleFreqDualOutput_OuterXL.Text.EndsWith("."))
            {

            }
            else if (!String.IsNullOrEmpty(tBox_singleFreqDualOutput_OuterXL.Text) && Double.TryParse(tBox_singleFreqDualOutput_OuterXL.Text, out nauraMatch.dOuterXl) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Frequency"); //
            }
        }

        private void tBox_singleFreqDualOutput_C4pF_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_singleFreqDualOutput_C4pF.Text, out nauraMatch.dC4_pF) == true)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                nauraMatch.QueueCalList.Enqueue("C4_pF");
                fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            }
            else if (tBox_singleFreqDualOutput_C4pF.Text.EndsWith("."))
            {

            }
            else if (!String.IsNullOrEmpty(tBox_singleFreqDualOutput_C4pF.Text) && Double.TryParse(tBox_singleFreqDualOutput_C4pF.Text, out nauraMatch.dC4_pF) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Frequency"); //
            }
        }

        private void tBox_singleFreqDualOutput_outerC3_pF_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_singleFreqDualOutput_outerC3_pF.Text, out nauraMatch.dC3_pF) == true)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                nauraMatch.QueueCalList.Enqueue("C3_pF");
                fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            }
            else if (tBox_singleFreqDualOutput_outerC3_pF.Text.EndsWith("."))
            {

            }
            else if (!String.IsNullOrEmpty(tBox_singleFreqDualOutput_outerC3_pF.Text) && Double.TryParse(tBox_singleFreqDualOutput_outerC3_pF.Text, out nauraMatch.dC3_pF) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Frequency"); //
            }
        }

        private void tBox_singleFreqDualOutput_targetVVC_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_singleFreqDualOutput_targetVVC.Text, out nauraMatch.dTargetVVC) == true)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                nauraMatch.QueueCalList.Enqueue("TargetVVC");
                fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            }
            else if (tBox_singleFreqDualOutput_targetVVC.Text.EndsWith("."))
            {

            }
            else if (!String.IsNullOrEmpty(tBox_singleFreqDualOutput_targetVVC.Text) && Double.TryParse(tBox_singleFreqDualOutput_targetVVC.Text, out nauraMatch.dTargetVVC) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Frequency"); //
            }
        }

        private void tBox_singleFreqDualOutput_C5_percent_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_singleFreqDualOutput_C5_percent.Text, out nauraMatch.dC5_percent) == true)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                nauraMatch.QueueCalList.Enqueue("C5_percent");
                fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            }
            else if (tBox_singleFreqDualOutput_C5_percent.Text.EndsWith("."))
            {

            }
            else if (!String.IsNullOrEmpty(tBox_singleFreqDualOutput_C5_percent.Text) && Double.TryParse(tBox_singleFreqDualOutput_C5_percent.Text, out nauraMatch.dC5_percent) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Frequency"); //
            }
        }

        private void tBox_singleFreqDualOutput_InnerXl_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_singleFreqDualOutput_InnerXl.Text, out nauraMatch.dInnerXl) == true)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                nauraMatch.QueueCalList.Enqueue("InnerXl");
                fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            }
            else if (tBox_singleFreqDualOutput_InnerXl.Text.EndsWith("."))
            {

            }
            else if (!String.IsNullOrEmpty(tBox_singleFreqDualOutput_InnerXl.Text) && Double.TryParse(tBox_singleFreqDualOutput_InnerXl.Text, out nauraMatch.dInnerXl) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Frequency"); //
            }
        }

        private void tBox_singleFreqDualOutput_InnerR_TextChanged(object sender, EventArgs e)
        {
            // Verify that the input value is a real value
            if (Double.TryParse(tBox_singleFreqDualOutput_InnerR.Text, out nauraMatch.dInnerR) == true)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                nauraMatch.QueueCalList.Enqueue("InnerR");
                fSearchingParamInFomula_Std_L_Type_DualOutput_for_NauraMatch();
            }
            else if (tBox_singleFreqDualOutput_InnerR.Text.EndsWith("."))
            {

            }
            else if (!String.IsNullOrEmpty(tBox_singleFreqDualOutput_InnerR.Text) && Double.TryParse(tBox_singleFreqDualOutput_InnerR.Text, out nauraMatch.dInnerR) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Frequency"); //
            }
        }

        private void btn_singleFreqDualOutput_currentRatioCal_Click(object sender, EventArgs e)
        {
            nauraMatch.dtCalculatedCurrentRatioEtc.Clear();

            nauraMatch.dC5Start_forCurrentRatioEtcCal = double.Parse(tbox_singleFreqDualOutput_C5Start.Text);
            nauraMatch.dC5Interval_forCurrentRatioEtcCal= double.Parse(tbox_singleFreqDualOutput_C5Interval.Text);
            nauraMatch.dC5End_forCurrentRatioEtcCal = double.Parse(tbox_singleFreqDualOutput_C5End.Text);

            for (double i = nauraMatch.dC5Start_forCurrentRatioEtcCal; i <= nauraMatch.dC5End_forCurrentRatioEtcCal; i = i + nauraMatch.dC5Interval_forCurrentRatioEtcCal)
            { 
                tBox_singleFreqDualOutput_C5_percent.Text = i.ToString();
                DataRow dtRowCurrentRow = nauraMatch.dtCalculatedCurrentRatioEtc.NewRow();
                dtRowCurrentRow["C5[%]"] = fMathRoundToDouble(nauraMatch.dC5_percent);
                dtRowCurrentRow["CurrentRatio"] = fMathRoundToDouble(nauraMatch.dCurrentRatio);
                dtRowCurrentRow["V_Outer"] = fMathRoundToDouble(nauraMatch.dOuterVpeak);
                dtRowCurrentRow["I_Outer"] = fMathRoundToDouble(nauraMatch.dOuterArms);
                dtRowCurrentRow["Power_Outer"] = fMathRoundToDouble(nauraMatch.dOuterPower);
                dtRowCurrentRow["Phase_Outer"] = fMathRoundToDouble(nauraMatch.dOuterPhase);
                dtRowCurrentRow["V_Inner"] = fMathRoundToDouble(nauraMatch.dInnerVpeak);
                dtRowCurrentRow["I_Inner"] = fMathRoundToDouble(nauraMatch.dInnerArms);
                dtRowCurrentRow["Power_Inner"] = fMathRoundToDouble(nauraMatch.dInnerPower);
                dtRowCurrentRow["Phase_Inner"] = fMathRoundToDouble(nauraMatch.dInnerPhase);

                nauraMatch.dtCalculatedCurrentRatioEtc.Rows.Add(dtRowCurrentRow);
            }

            dgv_CalculatedCurrentRatioEtc.DataSource = null;
            dgv_CalculatedCurrentRatioEtc.DataSource = nauraMatch.dtCalculatedCurrentRatioEtc;
            dgv_CalculatedCurrentRatioEtc.AutoResizeColumns();
            dgv_CalculatedCurrentRatioEtc.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        }
        #endregion

        double dC5Start = 0;
        private void tbox_singleFreqDualOutput_C5Start_TextChanged(object sender, EventArgs e)
        {
            if (tbox_singleFreqDualOutput_C5Start.Text.EndsWith("."))
            {
                ;
            }
            else if (!String.IsNullOrEmpty(tbox_singleFreqDualOutput_C5Start.Text) && Double.TryParse(tbox_singleFreqDualOutput_C5Start.Text, out dC5Start) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to C5 Start[%]"); //
            }

        }

        double dInterval = 0;
        private void tbox_singleFreqDualOutput_C5Interval_TextChanged(object sender, EventArgs e)
        {
            if (tbox_singleFreqDualOutput_C5Interval.Text.EndsWith("."))
            {
                ;
            }
            else if (!String.IsNullOrEmpty(tbox_singleFreqDualOutput_C5Interval.Text) && Double.TryParse(tbox_singleFreqDualOutput_C5Interval.Text, out dInterval) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to Interval[%]"); //
            }

        }

        double dC5End = 0;
        private void tbox_singleFreqDualOutput_C5End_TextChanged(object sender, EventArgs e)
        {
            if (tbox_singleFreqDualOutput_C5End.Text.EndsWith("."))
            {
                ;
            }
            else if (!String.IsNullOrEmpty(tbox_singleFreqDualOutput_C5End.Text) && Double.TryParse(tbox_singleFreqDualOutput_C5End.Text, out dC5End) == false)
            {
                //Console.WriteLine(nauraMatch.dFrequency.ToString());
                MessageBox.Show("Please input real number to C5 End[%]"); //
            }

        }
    }
}
