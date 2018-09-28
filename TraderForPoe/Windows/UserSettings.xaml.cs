﻿using Microsoft.Win32;
using System.Windows;
using TraderForPoe.Properties;

namespace TraderForPoe.Windows
{
    /// <summary>
    /// Interaktionslogik für UserSettings.xaml
    /// </summary>
    public partial class UserSettings : Window
    {
        public UserSettings()
        {
            InitializeComponent();
        }

        private void Click_SaveSettings(object sender, RoutedEventArgs e)
        {
            Settings.Default.Save();
            Settings.Default.Reload();
            System.Windows.MessageBox.Show("Settings saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Click_RestartApp(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            System.Windows.Application.Current.Shutdown();
        }

        private void Click_DeleteQuadStash(object sender, RoutedEventArgs e)
        {
            Settings.Default.QuadStash.Remove(lsb_QuadStash.SelectedItem.ToString());
        }

        private void Click_SearchFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                txt_PathToClientTxt.Text = openFileDialog.FileName;
                txt_PathToClientTxt.Focus();
                txt_PathToClientTxt.CaretIndex = txt_PathToClientTxt.Text.Length;
            }
        }

        private void Click_AddQuadStash(object sender, RoutedEventArgs e)
        {
            if (!Settings.Default.QuadStash.Contains(txt_QuadStash.Text))
            {
                Settings.Default.QuadStash.Add(txt_QuadStash.Text);
            }
        }
    }
}