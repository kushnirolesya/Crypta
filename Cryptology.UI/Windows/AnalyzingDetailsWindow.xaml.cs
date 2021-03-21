using System.Runtime.CompilerServices;
using System.Windows;
using Cryptology.Caesar.Algorithm;

namespace Cryptology.UI
{
    /// <summary>
    /// Interaction logic for AnalyzingDetailsWindow.xaml
    /// </summary>
    public partial class AnalyzingDetailsWindow : Window
    {
        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnalyzingDetailsWindow(CaesarFrequencyAnalyzer analyzer)
        {
            this.InitializeComponent();
            this.Analyzer = analyzer;
            this.DataContext = this;
            this.AnalyzingDetails = new AnalyzingDetailsModel(this.Analyzer);
        }
        #endregion

        public CaesarFrequencyAnalyzer Analyzer { get; }

        public AnalyzingDetailsModel AnalyzingDetails { get; set; }
    }
}
