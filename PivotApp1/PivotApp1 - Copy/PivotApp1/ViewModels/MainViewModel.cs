using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PivotApp1.Resources;

namespace PivotApp1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.ItemsDeserts = new ObservableCollection<ItemViewModel>();
            this.ItemsRice = new ObservableCollection<ItemViewModel>();
            this.ItemsSoup = new ObservableCollection<ItemViewModel>();
            this.ItemsTorshi = new ObservableCollection<ItemViewModel>();
            this.ItemsStew = new ObservableCollection<ItemViewModel>();
            this.ItemsOther = new ObservableCollection<ItemViewModel>();
            this.Itemskebab = new ObservableCollection<ItemViewModel>();
            this.Itemssearch = new ObservableCollection<ItemViewModel>();

            
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public ObservableCollection<ItemViewModel> ItemsDeserts { get; private set; }
        public ObservableCollection<ItemViewModel> ItemsRice { get; private set; }
        public ObservableCollection<ItemViewModel> ItemsSoup { get; private set; }
        public ObservableCollection<ItemViewModel> ItemsOther { get; private set; }
        public ObservableCollection<ItemViewModel> ItemsTorshi { get; private set; }
        public ObservableCollection<ItemViewModel> ItemsStew { get; private set; }
        public ObservableCollection<ItemViewModel> Itemskebab { get; private set; }
        public ObservableCollection<ItemViewModel> Itemssearch { get; private set; }



        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            DataLoader.LoadData();
            
            this.Itemssearch.Add(new ItemViewModel());

            this.ItemsStew = DataLoader.menuItems("stew");
            this.Itemskebab = DataLoader.menuItems("kebab");
            this.ItemsRice = DataLoader.menuItems("rice");
            this.ItemsSoup = DataLoader.menuItems("soup");
            this.ItemsOther = DataLoader.menuItems("others");
            this.ItemsTorshi = DataLoader.menuItems("torshi");
            this.ItemsDeserts = DataLoader.menuItems("desert");
            
            
            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}