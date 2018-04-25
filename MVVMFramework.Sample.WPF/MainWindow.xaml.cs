using MVVMFramework.Sample.WPF.ViewModels;
using System.Windows;

namespace MVVMFramework.Sample.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestViewModel vm;

        public MainWindow()
        {
            InitializeComponent();

            this.vm = new TestViewModel();
            this.vm.Init();
            this.DataContext = this.vm;
        }
    }
}
