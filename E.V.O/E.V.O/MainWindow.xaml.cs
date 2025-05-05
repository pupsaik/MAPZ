using E.V.O_.GameManaging;
using E.V.O_.ViewModels;
using System.Windows;

namespace E.V.O_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;

        public MainWindow()
        {
            InitializeComponent();

            _game = new();
            DataContext = new MainVM(_game);

        }
    }
}