using DramaReview.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DramaReview
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        private DramaViewModel dramaView;
        public MainWindow()
        {
            dramaView = new DramaViewModel();
            DataContext = dramaView;
            InitializeComponent();
            
        }
        //private void WczytajDane()
        //{
            
            
        //}

        private void DodajDrame_Click(object sender, RoutedEventArgs e)
        {
            Dodawanie oknoDodawania = new Dodawanie(dramaView);
            oknoDodawania.Show();
            

        }

        private void DramyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //WczytajDane();
        }

        private void ObczaNewbtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://mydramalist.com/search?adv=titles&ty=68&co=3&rt=4,10&so=newest");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.viki.com/");
        }

        private void PwrBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridWyl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
