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

	//Olika listor beroende p� om det �r torsdag eller s�ndag

	private List<string> GetItemsForToday()
	{
		var items = new List<string>();
		var today = DateTime.Now.DayOfWeek;

		if(today == DayOfWeek.Thursday)
		{
			items.Add("Badbyxor");
			items.Add("Handduk");
			items.Add("Duschtv�l");
			items.Add("Nya kl�der");
			items.Add("Extra frukt");
		}
		else if(today == DayOfWeek.Sunday)
		{
			items.Add("Sittunderlag");
			items.Add("Mats�ck");
			items.Add("K�sa");
			items.Add("Spork");
		}
		else
		{
			items.Add("Frukt!");
		}
		return items;
	}
}