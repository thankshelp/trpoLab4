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
        int c;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                c = int.Parse(vod.Text);
                if(easy(c) != true)
                {
                    throw new ArgumentException("Not a prime number");
                }
                stack.Items.Add(c);
                vod.Text = "";
            }
            catch (FormatException)
            {
                vod.Text = "Error";
            }
            catch (ArgumentException ex)
            {
                vod.Text = ex.Message;
            }
        }

        static bool easy(int c)
        {
            bool z;
            int q = 0;

            for(int i = 1; i < c; i++)
            {
                if (c % i == 0)
                    q++;
            }

            if (q < 3)
            {
                z = true;
                return z;
            }
            else
            {
                z = false;
                return z;
            }
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
