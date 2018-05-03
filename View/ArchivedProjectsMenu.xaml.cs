﻿using Model;
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

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Project).ProjectName.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
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