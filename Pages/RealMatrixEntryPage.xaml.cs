using FirstApplication;
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
    public partial class RealMatrixEntryPage : ContentPage
    {
        /// <summary>
        /// <see cref="BindableProperty"/> representing the name of the matrix that will be created on this <see cref="RealMatrixEntryPage"/>
        /// </summary>
        public static readonly BindableProperty MatrixNameProperty = BindableProperty.Create("MatrixName", typeof(string), typeof(RealMatrixEntryPage));
        public string MatrixName
        {
            get { return (string)GetValue(MatrixNameProperty); }

            set { SetValue(MatrixNameProperty, value); }
        }

        /// <summary>
        /// <see cref="BindableProperty"/> representing the number of rows of the matrix that will be created on this <see cref="RealMatrixEntryPage"/>
        /// </summary>
        public static readonly BindableProperty RowsProperty = BindableProperty.Create("Rows", typeof(int), typeof(RealMatrixEntryPage));
        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }

            set { SetValue(RowsProperty, value); }
        }

        /// <summary>
        /// <see cref="BindableProperty"/> representing the number of columns of the matrix that will be created on this <see cref="RealMatrixEntryPage"/>
        /// </summary>
        public static readonly BindableProperty ColumnsProperty = BindableProperty.Create("Columns", typeof(int), typeof(RealMatrixEntryPage));
        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }

            set { SetValue(ColumnsProperty, value); }
        }

        /// <summary>
        /// 2D array of Entries containing the entries of the matrix.
        /// </summary>
        public Entry[,] matrix_entries;

        /// <summary>
        /// Constructor for <see cref="CreateRealMatrixPage"/>
        /// </summary>
        public RealMatrixEntryPage(string matrix_name, int _rows, int _columns)
        {
            InitializeComponent();
            BindingContext = this;
            MatrixName = matrix_name;
            Rows = _rows;
            Columns = _columns;

            // Here we define the parent StackLayout
            StackLayout main_stack = new StackLayout
            {
                Spacing = 20,
                Padding = new Thickness { Bottom = 0, Top = 20, Left = 0, Right = 0 }
            };

            // Here we define a horizontal StackLayout that will contain the left bracket(as a grid), the matrix(as a grid), and the right bracket(as a grid)
            StackLayout matrix = new StackLayout
            {
                Padding = new Thickness(20, 0),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center
            };


            RowDefinitionCollection rowDefinitions = new RowDefinitionCollection();
            for (int i = 0; i < _rows; i++)
            {
                rowDefinitions.Add(new RowDefinition());
            }

            ColumnDefinitionCollection columnDefinitions = new ColumnDefinitionCollection();
            for (int j = 0; j < _columns; j++)
            {
                columnDefinitions.Add(new ColumnDefinition());
            }

            // Here we define the Grid that contains the entries for the matrix elements.We then add this grid to the StackLayout matrix

            Grid entries = new Grid
            {
                RowDefinitions = rowDefinitions,
                ColumnDefinitions = columnDefinitions,
                VerticalOptions = LayoutOptions.Start,
            };

            // Initialises the 2d array storing the Matrix Entries
            matrix_entries = new Entry[_rows, _columns];

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    Entry entry_ij = new Entry
                    {
                        Keyboard = Keyboard.Numeric,
                        TextColor = Color.WhiteSmoke,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 20,
                        HorizontalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        WidthRequest = 70
                    };

                    entries.Children.Add(entry_ij, j, i);
                    matrix_entries[i, j] = entry_ij;
                }
            }

            matrix.Children.Add(entries);

            //The matrix name at the top of the page
            main_stack.Children.Add(new Label
            {
                Text = "Matrix " + matrix_name,
                TextColor = Color.WhiteSmoke,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                FontSize = 50,
            });

            main_stack.Children.Add(matrix);

            Button create = new Button
            {
                Text = "Create",
                TextColor = Color.WhiteSmoke,
                BackgroundColor = Color.Red,
                VerticalOptions = LayoutOptions.EndAndExpand

            };
            create.Clicked += Create_Button_Clicked;
            main_stack.Children.Add(create);


            Content = main_stack;
        }

        /// <summary>
        /// event handler for whent the 'Create' button is clicked. adds the Matrix to the relavant list of matrices and navigates to the <see cref="MatrixListPage"/>
        /// </summary>
        private async void Create_Button_Clicked(object sender, System.EventArgs e)
        {
            double[,] real_matrix = new double[Rows, Columns];
            bool AllNumbersValid = true;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    double element_ij;
                    bool IsANumber = double.TryParse(matrix_entries[i, j].Text, out element_ij);

                    if (IsANumber)
                        real_matrix[i, j] = element_ij;
                    else
                    {
                        AllNumbersValid = false;
                        goto NumberCheck;
                    }
                }
            }

        NumberCheck:

            // If all numbers are valid, adds the Matrix and its name to the relevant lists and removes the matrix name from the dynamic alphabet so it's no longer available.
            if (AllNumbersValid)
            {
                RealMatrix realmatrix = new RealMatrix(real_matrix) { name = MatrixName };
                Data.MatrixList.Add(realmatrix);
                Data.DynamicAlphabet.Remove(MatrixName);
                await Navigation.PushAsync(new MatrixListPage());
            }

            else
            {
                await DisplayAlert("Number Invalid", "Please ensure all numbers are valid", "OK");
            }

        }
    }
}