using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Cats.Views
{
	public partial class DetailsPage : ContentPage
	{
		Models.Cat SelectedCat;
		public DetailsPage(Models.Cat selectedCat)
		{
			InitializeComponent();
			this.SelectedCat = selectedCat;
			BindingContext = this.SelectedCat;
			ButtonWebSite.Clicked += ButtonWebSite_Clicked;
		}

		private void ButtonWebSite_Clicked(object sender, EventArgs e)
		{
			if (SelectedCat.WebSite.StartsWith("http"))
			{
				Device.OpenUri(new Uri(SelectedCat.WebSite));
			}
		}
	}
}
