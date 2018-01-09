using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ListApp.Models;

namespace ListApp.ViewModels
{
    public class ListPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ListPageModel> data { get; set; }
        public ObservableCollection<ListPageModel> sorteddata { get; set; }

        public ListPageViewModel()
        {
            sorteddata = new ObservableCollection<ListPageModel>();
            data = new ObservableCollection<ListPageModel>()
            {
                new ListPageModel
                {
                    Name = "1Swapnil",
                    DateReceived =  DateTime.ParseExact("2009-05-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture),
                    Price = 1000
                },
                new ListPageModel
                {
                    Name = "2Swapnil",
                    DateReceived =  DateTime.ParseExact("2020-05-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture),
                    Price = 10
                },
                new ListPageModel
                {
                    Name = "3Swapnil",
                    DateReceived =  DateTime.ParseExact("2017-05-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture),
                    Price = 102
                },
                new ListPageModel
                {
                    Name = "4Swapnil",
                    DateReceived =  DateTime.ParseExact("2000-05-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture),
                    Price = 1
                },
                new ListPageModel
                {
                    Name = "5Swapnil",
                    DateReceived =  DateTime.ParseExact("2017-05-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture),
                    Price = 104
                },
                new ListPageModel
                {
                    Name = "6Swapnil",
                    DateReceived =  DateTime.ParseExact("2014-05-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture),
                    Price = 1050
                },
                new ListPageModel
                {
                    Name = "7Swapnil",
                    DateReceived =  DateTime.ParseExact("2018-01-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture),
                    Price = 10500
                }

            };

            sorteddata = data;
        }


        string name;
        public string Name 
        { 
            get
            {
                return name;  
            }

            set => SetProperty(ref name, value);
        }

        DateTime daterecevied;
        public DateTime DateReceived 
        { 
            get
            {
                return daterecevied;
            }

            set => SetProperty(ref daterecevied, value);
        }

        int price;
        public int Price 
        { 
            get
            {
                return price;
            }

            set
            {
                SetProperty(ref price, value);
            }
        }

        protected bool SetProperty<T>(
            ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {


            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;

            if (onChanged != null)
                onChanged();

            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
