namespace FixitChicit.Page.DetailPage;

public partial class DetailPageShoe : ContentPage
{
	public DetailPageShoe()
	{
		InitializeComponent();
	}
    private async void Submit1_Clicked(object sender, EventArgs e)
{
    // ตรวจสอบว่าผู้ใช้ได้เลือกประเภทจาก Picker หรือไม่
    if (EntryType.SelectedItem != null)
    {
        // ดึงค่าที่เลือกจาก Picker
        string selectedType = EntryType.SelectedItem.ToString();

        // แสดง DisplayAlert
        await DisplayAlert(
            "Information", 
            $"Your order has been placed \n Name: {Name.Text} \n Phone: {Phone.Text} \n Address: {Address.Text} \n Type: {selectedType} \n Problems: {Problem.Text} \n File: {File.Text}", 
            "OK");

        // เมื่อผู้ใช้กด "OK", นำทางไปยังหน้าถัดไป
        await Navigation.PushAsync(new HistoryPage());  // แทนที่ "HistoryPage" ด้วยหน้าที่คุณต้องการไป
    }
    else
    {
        // ถ้าผู้ใช้ไม่ได้เลือกประเภทจาก Picker ให้แสดงข้อความแจ้งเตือน
        await DisplayAlert("Error", "Please select a category.", "OK");
    }
}
}