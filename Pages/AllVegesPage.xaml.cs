namespace VegStore.Pages;

public partial class AllVegesPage : ContentPage
{
	private readonly AllVegesViewModel _allVegesViewModel;
	public AllVegesPage(AllVegesViewModel allVegesViewModel)
	{
		InitializeComponent();
		_allVegesViewModel = allVegesViewModel;
		BindingContext = _allVegesViewModel;
	}

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
		if(!string.IsNullOrWhiteSpace(e.OldTextValue)
			&&String.IsNullOrWhiteSpace(e.NewTextValue))
		{
			_allVegesViewModel.SearchVegetablesCommand.Execute(null);
		}
    }
}