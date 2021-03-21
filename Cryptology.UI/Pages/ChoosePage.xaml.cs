using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Cryptology.UI
{
    /// <summary>
    /// Interaction logic for ChoosePage.xaml
    /// </summary>
    public partial class ChoosePage : Page
    {
        public ChoosePage()
        {
            this.InitializeComponent();
            this.DataContext = App.MainViewModel;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            App.MainViewModel.CurrentPage = ApplicationPage.CaesarAlgorithm;
        }
    }
}
