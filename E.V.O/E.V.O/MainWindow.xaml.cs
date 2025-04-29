using E.V.O_.ViewModels;
using System.Windows;

namespace E.V.O_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainVM();

        }
    }
}