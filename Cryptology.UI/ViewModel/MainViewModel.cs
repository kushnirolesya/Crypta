using System.Windows.Navigation;

namespace Cryptology.UI
{
    internal sealed class MainViewModel : ViewModelBase
    {
        private ApplicationPage currentPage = ApplicationPage.Choose;

        #region Constructors
        public MainViewModel()
        {
        }
        #endregion

        #region Properties
        public NavigationUIVisibility NavigationUIVisibility { get; set; } = NavigationUIVisibility.Hidden;

        public ApplicationPage CurrentPage
        {
            get
            {
                return this.currentPage;
            }
            set
            {
                if (this.currentPage != value)
                {
                    this.currentPage = value;
                    this.OnProtertyChanged();
                }
            }
        }
        #endregion
    }
}
