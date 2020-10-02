using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatrixMobileApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlphabetStepperCell : ViewCell
    {
        /// <summary>
        /// <see cref="BindableProperty"/> with default value "A" that will be the name of the Matrix 
        /// </summary>
        public static readonly BindableProperty LetterProperty = BindableProperty.Create("Letter", typeof(string), typeof(AlphabetStepperCell), defaultValue: Data.DynamicAlphabet[0]);
        public string Letter
        {
            get { return (string)GetValue(LetterProperty); }

            set { SetValue(LetterProperty, value); }
        }

        /// <summary>
        /// Constructor for <see cref="AlphabetStepperCell"/>
        /// </summary>
        public AlphabetStepperCell()
        {
            InitializeComponent();
            BindingContext = this;
            Letter = Data.DynamicAlphabet[0];
        }

        /// <summary>
        /// Event handler for when the 'Next' button is clicked. Changes <see cref="Letter"/> to the next letter in the dynamic alphabet
        /// </summary>
        private void Next_Button_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.DynamicAlphabet.Count; i++)
            {
                if (Data.DynamicAlphabet[i] == Letter)
                {
                    if (i == Data.DynamicAlphabet.Count - 1)
                    {
                        Letter = Data.DynamicAlphabet[0];
                    }

                    else
                    {
                        Letter = Data.DynamicAlphabet[i + 1];
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// Event handler for when the 'Prev' button is clicked. Changes <see cref="Letter"/> to the previous letter in the dynamic alphabet
        /// </summary>
        private void Prev_Button_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.DynamicAlphabet.Count; i++)
            {
                if (Data.DynamicAlphabet[i] == Letter)
                {
                    if (i == 0)
                    {
                        Letter = Data.DynamicAlphabet[Data.DynamicAlphabet.Count - 1];
                    }

                    else
                    {
                        Letter = Data.DynamicAlphabet[i - 1];
                    }

                    break;
                }
            }
        }
    }
}