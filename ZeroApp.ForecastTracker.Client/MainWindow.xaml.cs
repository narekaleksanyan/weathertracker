﻿using System.Windows;
using ZeroApp.ForecastTracker.Client.ViewModels;

namespace ZeroApp.ForecastTracker.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
