using System;


namespace VegStore.ViewModels
{
    [QueryProperty(nameof(Vegetable), nameof(Vegetable))]
    public partial class DetailsViewModel : ObservableObject
    {
        public DetailsViewModel()
        {
        }

        [ObservableProperty]
        private Vegetable _vegetable;

        [RelayCommand]
        private void AddToCart()
        {
            Vegetable.CartQuantity++;
        }
        
        [RelayCommand]
        private void RemoveFromCart()
        {
            if(Vegetable.CartQuantity > 0)
                Vegetable.CartQuantity--;
        }

        [RelayCommand]
        private async Task ViewCart()
        {
            if (Vegetable.CartQuantity > 0)
            {

            }
            else
            {
                await Toast.Make("Add item to cart", ToastDuration.Short).show();
            }
        }
    }
}
