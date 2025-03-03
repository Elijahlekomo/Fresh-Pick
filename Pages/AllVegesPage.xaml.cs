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
}