using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JungmhaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Sharpnado.CollectionView.Initializer.Initialize(true, false);

            //Flyoutpage
            var fp = new FlyoutPage();
            fp.Flyout = new MenuBurgerPage();
            fp.Detail = new NavigationPage(new MainPage());

            MainPage = fp;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
