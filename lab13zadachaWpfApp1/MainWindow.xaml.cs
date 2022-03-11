using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace lab13zadachaWpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> styles = new List<string>() { "Светлая тема", "Темная тема" };
            styleBox.ItemsSource = styles;
            styleBox.SelectionChanged += ThemeChange;
            styleBox.SelectedIndex = 0;

        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            int styleIndex = styleBox.SelectedIndex;
            Uri uri = new Uri("LightTheme.xaml", UriKind.Relative);
            if (styleIndex == 1)
            {
                uri = new Uri("DarkTheme.xaml", UriKind.Relative);
            }
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void Size(string size)
        {
            if (size != "")
            {
                TextBox1.FontSize = Convert.ToInt32(size);
            }
        }

        private void FontName(string font)
        {
            TextBox1.FontFamily = new FontFamily(font);
        }

        private void FontProp()
        {
            bool u = (bool)U.IsChecked;
            bool i = (bool)I.IsChecked;
            bool b = (bool)B.IsChecked;

            TextBox1.FontStyle = FontStyles.Normal;
            if (u)
            {
                TextBox1.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                TextDecorationCollection defaults = new TextDecorationCollection();
                TextBox1.TextDecorations = defaults;
            }

            if (i)
            {
                TextBox1.FontStyle = FontStyles.Italic;
            }

            if (b)
            {
                TextBox1.FontWeight = FontWeights.UltraBold;
            }
            else
            {
                TextBox1.FontWeight = FontWeights.Normal;
            }

        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (TextBox1 != null)
            {
                if ((TextBox1.Background as SolidColorBrush).Color == Colors.Black)
                {
                    TextBox1.Foreground = Brushes.White;
                }
                else
                {
                    TextBox1.Foreground = Brushes.Black;
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TextBox1 != null)
            {
                Size(((sender as ComboBox).SelectedValue as TextBlock).Text);
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            FontProp();
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (TextBox1 != null)
            {
                FontName(((sender as ComboBox).SelectedValue as TextBlock).Text);
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (TextBox1 != null)
            {
                TextBox1.Foreground = Brushes.Red;
            }
        }


        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All types (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                TextBox1.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void OpenExec(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All types (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                TextBox1.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExec(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All types (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, TextBox1.Text);
            }
        }

        private void ExitExec(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
