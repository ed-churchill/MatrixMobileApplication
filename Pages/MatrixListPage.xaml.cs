using FirstApplication;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatrixMobileApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatrixListPage : ContentPage
    {
        /// <summary>
        /// Constructor for <see cref="MatrixListPage"/>
        /// </summary>
        public MatrixListPage()
        {
            InitializeComponent();
            matrix_list_view.ItemsSource = Data.MatrixList;
        }

        /// <summary>
        /// Event handler for when the 'Add Matrix' button is pressed. Navigates to the <see cref="CreateMatrixPage"/>
        /// </summary>
        private async void Add_Matrix_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateRealMatrixPage());
        }

        private void matrix_list_view_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            matrix_list_view.SelectedItem = null;
        }

        private async void matrix_list_view_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            RealMatrix tapped_matrix = e.Item as RealMatrix;
            await Navigation.PushAsync(new RealMatrixDetailPage(tapped_matrix));
        }
    }
}