using FixitChicit.Page.DetailPage;

namespace FixitChicit.Page;

public partial class CategoryPage : ContentPage
{
 public CategoryPage()
 {
  InitializeComponent();
 }

    private void GoToShirt(object sender, EventArgs e)
    {
  Navigation.PushAsync(new DetailPageShirt());
    }
    private void GoToSkirt(object sender, EventArgs e)
    {
  Navigation.PushAsync(new DetailPageSkirt());
    }
    private void GoToShoe(object sender, EventArgs e)
    {
  Navigation.PushAsync(new DetailPageShoe());
    }
    private void GoToBag(object sender, EventArgs e)
    {
  Navigation.PushAsync(new DetailPageBag());
    }
    private void GoToAccessory(object sender, EventArgs e)
    {
  Navigation.PushAsync(new DetailPageAccessory());
    }    private void GoToPant(object sender, EventArgs e)
    {
  Navigation.PushAsync(new DetailPagePant());
    }
        private void GoToHistory_Clicked(object sender, EventArgs e)
        {
   Navigation.PushAsync(new HistoryPage());
        }
      

}