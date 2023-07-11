using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

namespace Alchemist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<ImageItem> ImageItems { get; set; }
        public MainWindow()
        {
            InitializeComponent();


            ImageItems = new ObservableCollection<ImageItem>();

            // Добавление элементов в список
            ImageItems.Add(new ImageItem { ImagePath = "Images/image1.jpg", Caption = "Картинка 1" });
            ImageItems.Add(new ImageItem { ImagePath = "Images/image2.jpg", Caption = "Картинка 2" });
            // и т.д.
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button)e.OriginalSource;

            Type type = this.GetType();
            Assembly assembly = type.Assembly;
            Window setWin = (Window)assembly.CreateInstance(
                type.Namespace + "." + cmd.Name);

            setWin.Show();
        }

    }

    public class ImageItem
    {
        public string ImagePath { get; set; }
        public string Caption { get; set; }
    }
}
