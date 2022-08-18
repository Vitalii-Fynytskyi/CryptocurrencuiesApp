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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CryptocurrencuiesApp.View;
using CryptocurrencuiesApp.Model;

namespace CryptocurrencuiesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void adjustWindowToScreen()
        {
            Width = SystemParameters.WorkArea.Width;
            Height = SystemParameters.WorkArea.Height;

            Top = 0;
            Left = 0;
        }
        public MainWindow()
        {
            InitializeComponent();
            adjustWindowToScreen();
            MainMenu mainMenu = new MainMenu();
            ViewBox.Child = mainMenu;
        }
    }
}
