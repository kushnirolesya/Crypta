using System.Windows;

namespace Cryptology.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static MainViewModel MainViewModel { get; } = new MainViewModel();
    }
}
