using System;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace VegStore.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public ObservableCollection<Vegetable> Items { get; set; } = new();

        [ObservableProperty]
        private double _totalAmount;

        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);

        [RelayCommand]
        private void UpdateCartItem(Vegetable vegetable)
        {
            var item = Items.FirstOrDefault(i => i.Name == vegetable.Name);
            if (item is not null)
            {
                item.CartQuantity = vegetable.CartQuantity;
            }
            else
            {
                Items.Add(vegetable.Clone());
            }
            RecalculateTotalAmount();
        }

        [RelayCommand]
        private async void RemoveCartItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item is not null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();

                var snackbarOptions = new SnackbarOptions
                {
                    CornerRadius = 10,
                    BackgroundColor = Colors.PaleGreen
                };
                var snackbar = Snackbar.Make($"'{item.Name}' remove from cart",
                    () =>
                    {
                        Items.Add(item);
                        RecalculateTotalAmount();
                    }, "Undo", TimeSpan.FromSeconds(5), snackbarOptions);
                await snackbar.Show();
            }

        }

        [RelayCommand]
        private async Task ClearCart()
        {
            if(await Shell.Current.DisplayAlert("clear cart?", "clear cart?", "Yes", "No"))
            {
                Items.Clear();
                RecalculateTotalAmount();
                await Toast.Make("Cart Cleared", ToastDuration.Short).Show();
            }
            
        }

        [RelayCommand]
        private async Task PlaceOrder()
        {
            Items.Clear();
            RecalculateTotalAmount();
        }
    }
}
