using DramaReview.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace DramaReview
{
    /// <summary>
    /// Logika interakcji dla klasy Dodawanie.xaml
    /// </summary>
    public partial class Dodawanie : Window
    {
        //private string zdjecieFilePath = "";
        public DramaViewModel _dramaView;
        public Dodawanie(DramaViewModel dramaView)
        {
            _dramaView = dramaView;
            InitializeComponent();
        }
        
        //public static byte[] WezZdjecie(string filePath)
        //{
        //    FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //    BinaryReader reader = new BinaryReader(stream);

        //    byte[] zdjecie = reader.ReadBytes((int)stream.Length);

        //    reader.Close();
        //    stream.Close();

        //    return zdjecie;
        //}
        private void DodajDrameButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                DramaModel d = new DramaModel();
                d.Tytul = TytulTextBox.Text;
                d.Zdjecie = SciezkaTxtBox.Text;
                d.OcenaAktorstwo = Int32.Parse(AktorstwoTextBox.Text);
                d.OcenaFabula = Int32.Parse(FabulaTextBox.Text);
                d.OcenaOST = Int32.Parse(OSTTextBox.Text);
                d.OcenaZakonczenie = Int32.Parse(ZakonczenieTextBox.Text);
                d.OcenaWizualna = Int32.Parse(WizualnaTextBox.Text);

                d.OcenaSrednia = (d.OcenaAktorstwo + d.OcenaFabula + d.OcenaOST + d.OcenaZakonczenie + d.OcenaWizualna) / 5;

                GlobalConfig.Connection.DodajDrame(d);
                _dramaView.TwojeDramy.Add(d);
                //dramaView.TwojeDramy = GlobalConfig.Connection.GetDramas();

                if(d.ID != 0)
                {
                    MessageBox.Show($"Dodano drame {d.Tytul}");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Uzupełnij Dane");
            }

            //_dodana.GotowaDrama(d);
            
        }

        private bool ValidateForm()
        {
            if(TytulTextBox.Text.Length == 0)
            {
                return false;
            }
            if(AktorstwoTextBox.Text.Length == 0)
            {
                return false;
            }
            if(FabulaTextBox.Text.Length == 0)
            {
                return false;
            }
            if(OSTTextBox.Text.Length == 0)
            {
                return false;
            }
            if(ZakonczenieTextBox.Text.Length == 0)
            {
                return false;
            }
            if(WizualnaTextBox.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        
        private void AktorstwoTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void FabulaTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OSTTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ZakonczenieTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void WizualnaTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ClrBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void GridWyl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        //private void ZaladujImage_Click(object sender, RoutedEventArgs e)
        //{
        //    //OpenFileDialog ofd = new OpenFileDialog();
        //    //ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
        //    //if(ofd.ShowDialog() == DialogResult.Value == true)
        //    //{
        //    //    zdjecieFilePath = ofd.FileName.ToString();
        //    //    LadowanyImage.Im = zdjecieFilePath;
        //    //}


        //}
    }
}
