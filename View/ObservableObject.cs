using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VoronovoStreet.View
{
	public class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(field, value))
				return false;

			field = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		public void OnPropertyChanged([CallerMemberName] string propertyname = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
		}
	}
}
