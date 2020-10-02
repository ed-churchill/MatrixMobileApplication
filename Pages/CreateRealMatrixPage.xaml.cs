using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatrixMobileApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateRealMatrixPage : ContentPage
    {
        public CreateRealMatrixPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for when the 'Create Matrix' button is clicked. Navigates to the <see cref="RealMatrixEntryPage"/>
        /// </summary>
        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RealMatrixEntryPage(alphabet_stepper_cell.Letter, (int)RowStepper.Value, (int)ColumnStepper.Value));
        }
    }
}