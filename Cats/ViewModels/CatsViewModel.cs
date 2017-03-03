using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cats.ViewModels
{
	public class CatsViewModel : INotifyPropertyChanged
	{

		public CatsViewModel()
		{
			Cats = new ObservableCollection<Cats.Models.Cat>();
			GetCatsCommand = new Command(async () => await GetCats(), () => !IsBusy);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		private bool Busy;
		public bool IsBusy
		{
			get
			{
				return Busy;
			}
			set
			{
				Busy = value;
				OnPropertyChanged();
				GetCatsCommand.ChangeCanExecute();
			}
		}

		public Command GetCatsCommand { get; set; }


		public ObservableCollection<Cats.Models.Cat> Cats { get; set; }

		async Task GetCats()
		{
			if (!IsBusy)
			{
				Exception Error = null;
				try
				{
					IsBusy = true;
					var Repository = new Cats.Models.Repository();
					var Items = await Repository.GetCats();
					Cats.Clear();
					foreach (var Cat in Items)
					{
						Cats.Add(Cat);
					}
				}
				catch (Exception ex)
				{
					Error = ex;
				}
				finally
				{
					IsBusy = false;
					if (Error != null)
					{
						await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
						"Error!", Error.Message, "OK");
					}
				}
			}
			return;
		}
	}
}
