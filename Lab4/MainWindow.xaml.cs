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

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string c;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            c = vod.Text;

            stack.Items.Add(c);

            vod.Text = "";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text document (.txt)|*.txt";
            dlg.ShowDialog();

            string[] l = stack.Items.OfType<string>().ToArray();

            using (StreamWriter outputFile = new StreamWriter(dlg.FileName))
            {
                foreach (string line in l)
                    outputFile.WriteLine(line);
                
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text document (.txt)|*.txt";
            dlg.ShowDialog();

            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(dlg.FileName);

            while((line = file.ReadLine()) != null)
            {
                stack.Items.Add(line);
            }
            file.Close();
        }

        
    }
}
