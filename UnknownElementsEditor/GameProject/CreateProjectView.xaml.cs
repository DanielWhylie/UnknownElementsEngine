﻿using Microsoft.Win32;
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
using System.Windows.Navigation;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace UnknownElementsEditor.GameProject
{
    /// <summary>
    /// Interaction logic for CreateProjectView.xaml
    /// </summary>
    public partial class CreateProjectView : UserControl
    {
        public CreateProjectView()
        {
            InitializeComponent();
        }

        public void OnBrowseFileButtonClick(Object sender, RoutedEventArgs e)
        {
            if(sender == fileBrowseButton)
            {
                CommonOpenFileDialog fileBrowserDialog = new CommonOpenFileDialog();

                fileBrowserDialog.InitialDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\UnknownElements";
                fileBrowserDialog.IsFolderPicker = true;

                if (fileBrowserDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    projectPathEntry.Text = fileBrowserDialog.FileName;
                    Application.Current.Windows[1].Focus();
                }
                else
                {
                    Application.Current.Windows[1].Focus();
                }
            }
        }
    }
}
