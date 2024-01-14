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
    public partial class DogsPage : ContentPage
    {
        private ObservableCollection<DogForm> dogs;
        private DogAPIService _Dogs;
        
        public DogsPage()
        {
            InitializeComponent();

            dogs = new ObservableCollection<DogForm>();
            _Dogs = new DogAPIService();
            
            LoadData();
        }
        
        private async void LoadData()
        {
            try
            {
                dogs.Clear();
                var newDogs = await _Dogs.RefreshDataAsync();

                if (newDogs != null)
                {
                    foreach (var dog in newDogs)
                    {
                        dogs.Add(dog);
                    }

                    dogCollectionView.ItemsSource = dogs;
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