#if IOS
using UIKit;
#endif
namespace VegStore.Pages;

public partial class DetailPage : ContentPage
{
	private readonly DetailsViewModel _detailsViewModel;
	public DetailPage(DetailsViewModel detailsViewModel)
	{
		_detailsViewModel = detailsViewModel;
		InitializeComponent();
		BindingContext = _detailsViewModel;
	}
	protected override void OnAppearing()
	{
        base.OnAppearing();
#if IOS
		var bottom = 
			UIApplication.SharedApplication.Delegate.GetWindow().SafeAreaInsets.Bottom;

			bottomBox.Margin = new Thickness(-1, 0, -1, (bottom+1)*-1);
#endif
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("..", animate: true);
    }

	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{
		base.OnNavigatingFrom(args);
		Behaviors.Add(new
			CommunityToolkit.Maui.Behaviors.StatusBarBehavior
		{
			StatusBarColor = Colors.LightGreen,
			StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.LightContent
		});
	}
}