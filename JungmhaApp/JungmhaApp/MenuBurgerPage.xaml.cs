using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JungmhaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuBurgerPage : ContentPage
    {
        public MenuBurgerPage()
        {
            InitializeComponent();
            Filterbutton.Clicked += Filterbutton_Clicked;
            DogListbutton.Clicked += DogListbutton_Clicked;
            Homebutton.Clicked += Homebutton_Clicked;
        }

        private void Homebutton_Clicked(object sender, EventArgs e)
        {
            var mp = Parent as FlyoutPage;
            mp.Detail = new NavigationPage(new MainPage());
            mp.IsPresented = false;
        }

        private void DogListbutton_Clicked(object sender, EventArgs e)
        {
            var mp = Parent as FlyoutPage;
            mp.Detail = new NavigationPage(new DogsPage());
            mp.IsPresented = false;
        }

        private void Filterbutton_Clicked(object sender, EventArgs e)
        {
            var mp = Parent as FlyoutPage;
            mp.Detail = new NavigationPage(new FilterPage());
            mp.IsPresented = false;
        }
    }

}