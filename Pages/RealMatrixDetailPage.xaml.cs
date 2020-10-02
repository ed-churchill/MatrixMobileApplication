using FirstApplication;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatrixMobileApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RealMatrixDetailPage : ContentPage
    {
        public RealMatrixDetailPage(RealMatrix current_matrix)
        {
            //Matrix at top
            //Number of rows
            //Number of columns
            //Row reduced form
            //Transpose
            //Rank
            //Nullity
            //Determinant
            //Inverse (if it exists)
            //Characteristic polynomial

            StackLayout s = new StackLayout { Spacing = 20, BackgroundColor = Color.FromHex("046875") };

            Label num_rows = new Label { Text = current_matrix.NumRows().ToString() + " rows", TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
            s.Children.Add(num_rows);

            Label num_columns = new Label { Text = current_matrix.NumColumns().ToString() + " columns", TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
            s.Children.Add(num_columns);

            Label rref = new Label { Text = "Row-Reduced Echelon Form:", TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
            s.Children.Add(rref);

            Label rref_matrix = new Label { Text = current_matrix.Rref().ToString(), TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
            s.Children.Add(rref_matrix);

            Label tranpose = new Label { Text = "Transpose(" + current_matrix.name + ") :", TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
            s.Children.Add(tranpose);

            Label transpose_matrix = new Label { Text = current_matrix.Transpose().ToString(), TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
            s.Children.Add(transpose_matrix);

            if (current_matrix.IsInvertible())
            {
                Label inv = new Label { Text = "Inverse", TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
                Label inverse_matrix = new Label { Text = current_matrix.Rref().ToString(), TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
                s.Children.Add(inv);
                s.Children.Add(inverse_matrix);
            }

            else
            {
                Label no_inv = new Label { Text = "The matrix has 0 determinant so has no inverse", TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
                s.Children.Add(no_inv);
            }

            Label rank = new Label { Text = "Rank(" + current_matrix.name + ") = " + current_matrix.Rank().ToString(), TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
            s.Children.Add(rank);

            Label nullity = new Label { Text = "Nullity(" + current_matrix.name + ") = " + current_matrix.Nullity().ToString(), TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
            s.Children.Add(nullity);

            Label det = new Label { Text = "det(" + current_matrix.name + ") = " + current_matrix.Det().ToString(), TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
            s.Children.Add(det);

            Label characteristic_polynomial = new Label { Text = "Characteristic(" + current_matrix.name + ") = " + current_matrix.CharPolynomial().ToString(), TextColor = Color.WhiteSmoke, HorizontalOptions = LayoutOptions.Center, FontSize = 16 };
            s.Children.Add(characteristic_polynomial);

            ScrollView scroll = new ScrollView { Content = s };
            Content = scroll;
        }
    }
}