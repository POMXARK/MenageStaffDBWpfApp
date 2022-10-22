﻿
using MenageStaffDBWpfAppNetCore.ViewModels;
using System;
using System.Reflection;
using System.Windows;


namespace MenageStaffDBWpfAppNetCore.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageViewModel();
        }
    }
}
