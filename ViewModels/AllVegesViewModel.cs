
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

        private async Task SearchVegetables(string searchTerm)
        {
            Vegetables.Clear();
            Searching = true;
            foreach (var vegetable in _vegetableService.SearchVegetables(searchTerm))
            {
                Vegetables.Add(vegetable);
            }
            Searching = false;
        }
    }

}
