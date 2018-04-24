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
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for SelectedProjekt.xaml
    /// </summary>
    public partial class SelectedProjekt : Window
    {
        public SelectedProjekt()
        {
            InitializeComponent();
            
            DataContext = ProjektCollection._instance;
        }

        private void ArchiveProject_btn_Click(object sender,RoutedEventArgs e)
        {
            ProjektCollection._instance.ArchiveProject();
            MessageBox.Show("");



            
        }
    }
}
