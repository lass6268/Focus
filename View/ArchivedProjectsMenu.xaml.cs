using System;
using System.Collections;
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
    /// Interaction logic for ArchivedProjectsMenu.xaml
    /// </summary>
    public partial class ArchivedProjectsMenu : Window
    {
        public IEnumerable ItemsSource { get; set; }
        public ArchivedProjectsMenu()
        {
            InitializeComponent();
            DataContext = ProjektCollection._instance;
            ProjektCollection._instance.ShowArchivedProjects();
            Projektview.ItemsSource = ProjektCollection._instance.Projekts;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Projektview.ItemsSource);
            view.Filter = UserFilter;
        }
        private void Projektview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = Projektview.SelectedIndex;
            ProjektCollection._instance.FindProjekt(Projektview.SelectedItem);
            SelectedArchivedProject selectedArchivedProject = new SelectedArchivedProject();
            selectedArchivedProject.Show();
            selectedArchivedProject.Topmost = true;

        }
        public bool UserFilter(object item)
        {

            return ProjektCollection._instance.UserFilter(item,txtFilter.Text);
        }

        private void TxtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Projektview.ItemsSource).Refresh();
        }



        private void Archived_Return_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();         
        }

    }
}
