using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Calc.Text = "0";
            Calc.FlagAction = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Calc.InS((String)((Button)sender).Content);
            //Calc.Text = (String)((Button)sender).Content;
            //Calc.Text = btnContent;
            //Calc.Text +="123";
        }
    }
}
