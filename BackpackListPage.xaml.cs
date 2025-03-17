namespace FamilyToDoApp;

public partial class BackpackListPage : ContentPage
{
	public List<string> BackpackItem { get; set; }

	public BackpackListPage()
	{
		InitializeComponent();
		BackpackItem = GetItemsForToday();
		BackpackListView.ItemsSource = BackpackItem;
	}

	//Olika listor beroende på om det är torsdag eller söndag

	private List<string> GetItemsForToday()
	{
		var items = new List<string>();
		var today = DateTime.Now.DayOfWeek;

		if(today == DayOfWeek.Thursday)
		{
			items.Add("Badbyxor");
			items.Add("Handduk");
			items.Add("Duschtvål");
			items.Add("Nya kläder");
			items.Add("Extra frukt");
		}
		else if(today == DayOfWeek.Sunday)
		{
			items.Add("Sittunderlag");
			items.Add("Matsäck");
			items.Add("Kåsa");
			items.Add("Spork");
		}
		else
		{
			items.Add("Frukt!");
		}
		return items;
	}
}