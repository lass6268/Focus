﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ProjectOverviewMenu.xaml
    /// </summary>
    public partial class ProjectOverviewMenu : Window
    {
        public IEnumerable ItemsSource { get; set; }

        public ProjectOverviewMenu()
        {
            InitializeComponent();
            DataContext = ProjektCollection._instance;
            ProjektCollection._instance.UpdateProjekts();
            TotalBudgetbar.DataContext = ProjektCollection._instance;
            Projektview.ItemsSource = ProjektCollection._instance.Projects;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Projektview.ItemsSource);
            view.Filter = UserFilter;

        }

        private void Return_btn_Click(object sender, RoutedEventArgs e)
        {
            OpretProjektMenu opretProjekt = new OpretProjektMenu();

            opretProjekt.Top = 160;
            opretProjekt.Left = 400;

            opretProjekt.Show();
            opretProjekt.Topmost = true;
            this.Close();
        }

        private void Projektview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            int index = Projektview.SelectedIndex;
           
            ProjektCollection._instance.FindProjekt(Projektview.SelectedItem);
            SelectedProjekt selectedProjekt = new SelectedProjekt();

            selectedProjekt.Top = 160;
            selectedProjekt.Left = 400;

            selectedProjekt.Show();

            this.Close();
  
        }

        private void Budget_btn_Click(object sender, RoutedEventArgs e)
        {
            BudgetMenu budgetMenu = new BudgetMenu();

            budgetMenu.Top = 160;
            budgetMenu.Left = 400;

            budgetMenu.Show();
            budgetMenu.Topmost = true;
            this.Close();
        }

        private void Archived_Projekt_btn_Click(object sender, RoutedEventArgs e)
        {
            ArchivedProjectsMenu archivedProjectsMenu = new ArchivedProjectsMenu();

            archivedProjectsMenu.Top = 160;
            archivedProjectsMenu.Left = 400;

            archivedProjectsMenu.Show();
            this.Close();
        }

        public bool UserFilter(object item)
        {

            return ProjektCollection._instance.UserFilter(item,txtFilter.Text);
        }


        private void TxtFilter_TextChanged(object sender,TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Projektview.ItemsSource).Refresh();
        }

        private void Leaderboard_btn_Click(object sender,RoutedEventArgs e)
        {
            DataManagementOverview dataManagementOverview = new DataManagementOverview();

            dataManagementOverview.Top = 160;
            dataManagementOverview.Left = 400;

            dataManagementOverview.Show();
            dataManagementOverview.Topmost = true;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employeebudget employeebudget = new Employeebudget();
            employeebudget.Show();
            employeebudget.Topmost = true;
            
        }
    }
}
