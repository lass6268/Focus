﻿using System;
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
    /// Interaction logic for ProjectOverviewMenu.xaml
    /// </summary>
    public partial class ProjectOverviewMenu : Window
    {
        public ProjectOverviewMenu()
        {
            InitializeComponent();
            DataContext = ProjektCollection._instance;
            ProjektCollection._instance.UpdateProjekts();
        }

        private void Return_btn_Click(object sender, RoutedEventArgs e)
        {
            OpretProjektMenu opretProjekt = new OpretProjektMenu();
            opretProjekt.Show();
            opretProjekt.Topmost = true;
            this.Close();
        }

        private void Projektview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            int index = Projektview.SelectedIndex;
            ProjektCollection._instance.FindProjekt(index);
            SelectedProjekt selectedProjekt = new SelectedProjekt();
            selectedProjekt.Show();
            selectedProjekt.Topmost = true;
  
        }

        private void Budget_btn_Click(object sender, RoutedEventArgs e)
        {
            BudgetMenu budgetMenu = new BudgetMenu();
            budgetMenu.Show();
            budgetMenu.Topmost = true;
            this.Close();
        }

        private void Archived_Projekt_btn_Click(object sender, RoutedEventArgs e)
        {
            ArchivedProjectsMenu archivedProjectsMenu = new ArchivedProjectsMenu();
            archivedProjectsMenu.Show();
            archivedProjectsMenu.Topmost = true;
            this.Close();
        }
    }
}
