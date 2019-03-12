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
                if (easy(c) == false)
                {
                    MessageBox.Show("not as easy as it seems");
                }
                else stack.Items.Add(c);

                //stack.Items.Add(c);
                vod.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Error format");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static bool easy(int c)
        {
            if (c < 1) throw new ArgumentException("number must be > 1");

            for (int i = 1; i <= c; i++)
            {
                if (c % i == 0)
                    return false;
            }

            return true;

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

            try
            {
                using (StreamReader file = new StreamReader (dlg.FileName))
                {
                    string line;
                    
                        while ((line = file.ReadLine()) != null)
                        {
                            try
                            {
                                int c = int.Parse(line);
                                if (easy(c) == false)
                                {
                                    MessageBox.Show("not as easy as it seems");
                                }
                                else stack.Items.Add(c);
                           
                            }
                            catch (FormatException)
                            {
                            MessageBox.Show("Error format");
                            }
                            catch (ArgumentException ed)
                            {
                                MessageBox.Show(ed.Message);
                            }
                        }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("The file could not be read");
            }
        }
    }
}

        
    

