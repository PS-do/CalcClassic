using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calc
{
    internal class CalcModel : DependencyObject
    {
        public static readonly DependencyProperty TextProperty;
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }


        public static readonly DependencyProperty FlagActionProperty;
        public string FlagAction //для хранения активного действия
        {
            get => (string)GetValue(FlagActionProperty);
            set => SetValue(FlagActionProperty, value);
        }
        //private string flagActions= ""; //поле для хранения активного действия
        private bool flagEdited = false; // истина если уже производилась ранее корректировка значения
        private double previousNuber=0;
        private double сurrentNumber;
        private double rez;
        static CalcModel()
        {
            TextProperty = DependencyProperty.Register(
                            nameof(Text),
                            typeof(string),
                            typeof(CalcModel)
                            );
            FlagActionProperty = DependencyProperty.Register(
                            nameof(FlagAction),
                            typeof(string),
                            typeof(CalcModel)
                            );
        }

        private void AddNumber(string s)
        {

            if (flagEdited==true&&Text!="0")
            {
                Text =Text+s;
            }
            else if (flagEdited == false)
            { 
                Text = s;
                flagEdited = true;
            }
            
        }

        public void Action()
        {

            if (FlagAction == "+")
            {
                сurrentNumber = Convert.ToDouble(Text);
                rez = previousNuber + сurrentNumber;
                Text = Convert.ToString(rez);
                previousNuber = rez;
            }
            if (FlagAction == "-")
            {
                сurrentNumber = Convert.ToDouble(Text);
                rez = previousNuber - сurrentNumber;
                Text = Convert.ToString(rez);
                previousNuber = rez;
            }
            if (FlagAction == "*")
            {
                сurrentNumber = Convert.ToDouble(Text);
                rez = previousNuber * сurrentNumber;
                Text = Convert.ToString(rez);
                previousNuber = rez;
            }
            if (FlagAction == "÷")
            {
                сurrentNumber = Convert.ToDouble(Text);
                if (сurrentNumber == 0)
                {
                    MessageBox.Show("Деление на ноль не допустимо");
                    Text = "0";
                    flagEdited = false;
                    previousNuber = 0;
                    FlagAction = "";
                }
                else
                {
                    rez = previousNuber / сurrentNumber;
                    Text = Convert.ToString(rez);
                    previousNuber = rez;
                }
            }
            if (FlagAction == "")
            {
                previousNuber = Convert.ToDouble(Text);
            }

            flagEdited = false;


        }

        public void InS(string s)
        {
            if (s == "1") AddNumber(s);
            else if (s == "2") AddNumber(s);
            else if (s == "3") AddNumber(s);
            else if (s == "4") AddNumber(s);
            else if (s == "5") AddNumber(s);
            else if (s == "6") AddNumber(s);
            else if (s == "7") AddNumber(s);
            else if (s == "8") AddNumber(s);
            else if (s == "9") AddNumber(s);
            else if (s == "0") AddNumber(s);
            else if (s == ".") AddNumber(s);
            else if (s == "+/-") Text = Convert.ToString(Convert.ToDouble(Text) * (-1));
            else if (s == "←") Text = Text.Substring(0, Text.Length - 1);
            else if (s == "C") Text = "0";
            else if (s == "x²") Text = Convert.ToString(Math.Pow(Convert.ToDouble(Text), 2.0));
            else if (s == "|x|") Text = Convert.ToString(Math.Abs(Convert.ToDouble(Text)));
            else if (s == "CE")
            {
                Text = "0";
                flagEdited = false;
                previousNuber = 0;
                FlagAction = "";
            }
            else
            { 
                Action();
                FlagAction = s;
            }
        }
    }
    }
