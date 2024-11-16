namespace FixitChicit.Page;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    
    private void GoToCategory_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new CategoryPage());
    }
	
}