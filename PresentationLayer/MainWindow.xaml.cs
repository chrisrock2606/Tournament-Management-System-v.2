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
using PresentationLayer.ViewModels;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainVM viewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;

            viewModel = MainVM.Instance;
            DataContext = viewModel;
        }
    }
}
