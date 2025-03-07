
namespace VegStore.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly VegetableService _vegetableService;
        public HomeViewModel(VegetableService vegetableService)
        {
            _vegetableService = vegetableService;
            Vegetables = new(_vegetableService.GetPopularVegetables());
        }

        public ObservableCollection<Vegetable> Vegetables { get; set; }

        [RelayCommand]
        private async Task GoToAllVegetablesPage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(AllVegesViewModel.FromSearch)] = fromSearch
            };

            await Shell.Current.GoToAsync(nameof(AllVegesPage), animate: true, parameters);
        }

        [RelayCommand]
        private async Task GoToDetailsPage(Vegetable vegetable)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Vegetable)] = vegetable
            };

            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }
    }
}
