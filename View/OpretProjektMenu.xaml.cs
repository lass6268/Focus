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
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for OpretProjektMenu.xaml
    /// </summary>
    public partial class OpretProjektMenu:Window
    {
        public OpretProjektMenu()
        {
            InitializeComponent();
        }

        private void FinalCreateProjekt_btn_Click(object sender,RoutedEventArgs e)
        {
            string projectName = Name_txtbox.Text;
            int minimum = int.Parse(Min_txtbox.Text);
            int maximum = int.Parse(Max_txtbox.Text);
            string startDate = StartDate_txtbox.Text;
            string finishDate = FinishDate_txtbox.Text;
            
             
        }

       
    }
}
