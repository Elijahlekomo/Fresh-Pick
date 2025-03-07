
namespace VegStore.ViewModels
{
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllVegesViewModel: ObservableObject
    {
        private readonly VegetableService _vegetableService;
        public AllVegesViewModel(VegetableService vegetableService)
        {
            _vegetableService = vegetableService;
            Vegetables = new(_vegetableService.GetAllVegetables());
        }
        public ObservableCollection<Vegetable> Vegetables { get; set; }

        [ObservableProperty]
        private bool _fromSearch;

        [ObservableProperty]
        private bool _Searching;

        [RelayCommand]
        private async Task SearchVegetables(string searchTerm)
        {
            Vegetables.Clear();
            Searching = true;
            await Task.Delay(1000);
            foreach (var vegetable in _vegetableService.SearchVegetables(searchTerm))
            {
                Vegetables.Add(vegetable);
            }
            Searching = false;
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
