using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PivotApp1
{
    public partial class Search : PhoneApplicationPage
    {
        ObservableCollection<Recipe> searchItems = new ObservableCollection<Recipe>();

        public Search()
        {
            InitializeComponent();
            searchResults.ItemsSource = searchItems;
            
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            searchItems = new ObservableCollection<Recipe>();
            List<Dictionary<string, Recipe>> recs = new List<Dictionary<string, Recipe>>();
            recs.Add(DataLoader.kebabs);
            recs.Add(DataLoader.Stews);
            recs.Add(DataLoader.rices);
            recs.Add(DataLoader.soups);
            recs.Add(DataLoader.deserts);
            recs.Add(DataLoader.torshi);
            if (!string.IsNullOrWhiteSpace(SearchBock.Text.Trim()))
            {
                foreach (Dictionary<string, Recipe> dictionary in recs)
                {

                    foreach (KeyValuePair<string, Recipe> keyValuePair in dictionary)
                    {
                        if (keyValuePair.Key.Contains(SearchBock.Text.Trim()))
                        {

                            searchItems.Add(keyValuePair.Value);

                        }
                    }
                }

                searchResults.ItemsSource = searchItems;
            }

        }

        private void SearchBock_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void searchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recipe avm = (Recipe)searchResults.SelectedItem;
            //MessageBox.Show(avm.LineOne);
          

            foreach (Recipe r in searchItems)
            {
                if (avm.title.Contains(r.title))
                {
                    Recipe.currentRec = r;
                    //loadRec(avm.LineOne, "soup");    
                    break;
                }
            }
            

            NavigationService.Navigate(new Uri("/RecipePage.xaml", UriKind.Relative));
        }

       
    }
}