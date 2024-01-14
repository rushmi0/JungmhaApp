using System;
using Xamarin.Forms;

namespace JungmhaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            toFilter.Clicked += ToFilterOnClicked;
        } 

        private void ToFilterOnClicked(object sender, EventArgs e)
        {
            var openFilterPage = new FilterPage();
            Navigation.PushAsync(openFilterPage);
        }

    }
}
