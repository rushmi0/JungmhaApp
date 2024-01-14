using JungmhaApp.form;
using JungmhaApp.service;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace JungmhaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        private ObservableCollection<WalkerForm.Walker> walkers;
        private DogWalkerAPIService DogWalker;

        public FilterPage()
        {
            InitializeComponent();

            walkers = new ObservableCollection<WalkerForm.Walker>();
            DogWalker = new DogWalkerAPIService();

            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                walkers.Clear();
                var newWalkers = await DogWalker.RefreshDataAsync();

                if (newWalkers != null)
                {
                    foreach (var walker in newWalkers)
                    {
                        walkers.Add(walker);
                    }
                    
                    walkerCollectionView.ItemsSource = walkers;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
