using form_cv;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace form_cv
{
    public partial class CVPage : ContentPage
    {
        public CVPage(CVModel cv)
        {
            InitializeComponent();

            BindingContext = cv;
        }
    }
}