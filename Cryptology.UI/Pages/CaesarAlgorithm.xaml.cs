using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Cryptology.UI
{
    /// <summary>
    /// Interaction logic for CaesarAlgorithm.xaml
    /// </summary>
    public partial class CaesarAlgorithmPage : Page
    {
        private readonly CaesarViewModel viewModel;

        public CaesarAlgorithmPage()
        {
            this.InitializeComponent();
            this.viewModel = new CaesarViewModel();
            this.DataContext = this.viewModel;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void BtnProcessClick(object sender, RoutedEventArgs e)
        {
            this.viewModel.Process();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CbModeClick(object sender, RoutedEventArgs e)
        {
            this.viewModel.InputText = string.Empty;
            this.viewModel.OutputText = string.Empty;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void BtnAnalyzeClick(object sender, RoutedEventArgs e)
        {
            this.viewModel.Analyze();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void BtnDetailsClick(object sender, RoutedEventArgs e)
        {
            var detailsWindow = new AnalyzingDetailsWindow(this.viewModel.Analyzer);
            detailsWindow.Show();
        }
    }
}
