using PictureTagger.Utilities;
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

namespace PictureTagger.Views
{
    /// <summary>
    /// Interaction logic for SearchTagView.xaml
    /// </summary>
    public partial class SearchTagView : UserControl
    {
        public SearchTagView()
        {
            DataContext = UiFactory.SearchTagViewModelGet();
            InitializeComponent();
        }

        private void TboxTagSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
