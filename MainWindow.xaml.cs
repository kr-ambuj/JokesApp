using JokesApp.DataServices;
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
using System.Windows.Shapes;

namespace JokesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DadJokesClass DadJokes;
        public MainWindow()
        {
            InitializeComponent();
            DadJokes = new DadJokesClass();
        }

        private void _btnGetRandomJoke_Click(object sender, RoutedEventArgs e)
        {
            _txtDisplayJoke.Text = DadJokes.GetARandomJoke().Result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
