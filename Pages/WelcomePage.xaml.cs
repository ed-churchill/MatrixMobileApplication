using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatrixMobileApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        /// <summary>
        /// Constructor for <see cref="WelcomePage"/>
        /// </summary>
        public WelcomePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for when the 'Continue to App' button is pressed. Navigates to the (blank) <see cref="MatrixListPage"/>
        /// </summary>
        private async void Continue_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MatrixListPage());
        }
    }
}