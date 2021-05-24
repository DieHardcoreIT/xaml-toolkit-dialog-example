using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows;
using xaml_toolkit_dialog_example.Dialog.DialogControls;

namespace xaml_toolkit_dialog_example
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RunSampleDialogAsync();
        }

        private async Task RunSampleDialogAsync()
        {
            var view = new SampleDialog
            {
                DataContext = new SampleDialogViewModel()
            };

            var result = await DialogHost.Show(view, SampleDialogClosingEventHandler);

            var sampleDialogData = (SampleDialogViewModel)view.DataContext;

            MessageBox.Show(sampleDialogData.Name);
        }

        private void SampleDialogClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");
        }
    }
}