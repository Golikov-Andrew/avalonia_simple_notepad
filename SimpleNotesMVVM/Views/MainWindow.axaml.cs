using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Controls;
using Avalonia.Media;

namespace SimpleNotesMVVM.Views;

public partial class MainWindow : Window
{
    public string TopPanelColor;
    public MainWindow()
    {
        InitializeComponent();
        TopPanelColor = "#FFFFFF";
    }

    private void Window_OnClosing(object? sender, WindowClosingEventArgs e)
    {
        string[] lines = Text1.Text.Split("\n");
        List<string> result = new List<string>();
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] != "")
            {
                result.Add(lines[i]);
            }
        }
        File.WriteAllText(@"Source", string.Join("\n", result));
    }

    private void TopLevel_OnOpened(object? sender, EventArgs e)
    {
        try
        {
            Text1.Text = File.ReadAllText(@"Source");
        }
        catch (FileNotFoundException exception)
        {
        }
    }

    private void SelectingColor_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        try
        {
            switch (((Avalonia.Controls.ComboBoxItem) ((Avalonia.Controls.ComboBox) sender).SelectedValue).Content)
            {
                case "Белый":
                {
                    TopPanel.Background = Brushes.White;
                    break;
                }
                case "Оранжевый":
                {
                    TopPanel.Background = Brushes.Orange;
                    break;
                }
                case "Синий":
                {
                    TopPanel.Background = Brushes.Blue;
                    break;
                }
                case "Жёлтый":
                {
                    TopPanel.Background = Brushes.Yellow;
                    break;
                }
                case "Красный":
                {
                    TopPanel.Background = Brushes.Red;
                    break;
                }
                case "Зелёный":
                {
                    TopPanel.Background = Brushes.Green;
                    break;
                }
            }
        }
        catch (NullReferenceException exception)
        {
        }
        
    }
    private void SelectingFontFamily_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        try
        {
            Console.WriteLine((string)((Avalonia.Controls.ComboBoxItem)
                ((Avalonia.Controls.ComboBox) sender).SelectedValue).Content);
            Text1.FontFamily = new FontFamily((string)((Avalonia.Controls.ComboBoxItem)
                ((Avalonia.Controls.ComboBox) sender).SelectedValue).Content);
            // Text1.FontFamily = new FontFamily("avares://Fonts/Pacifico.ttf");
            Console.WriteLine(Text1.FontFamily);
        }
        catch (NullReferenceException exception)
        {
        }
        
    }
    private void SelectingFontSize_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        
        try
        {
            Text1.FontSize = Double.Parse((string)((Avalonia.Controls.ComboBoxItem) 
                ((Avalonia.Controls.ComboBox) sender).SelectedValue).Content);
        }
        catch (NullReferenceException exception)
        {
        }
        
    }
}