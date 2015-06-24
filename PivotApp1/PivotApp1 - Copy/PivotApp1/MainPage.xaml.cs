using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml.Serialization;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PivotApp1.Resources;
using PivotApp1.ViewModels;

namespace PivotApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        // Constructor
        public MainPage()
        {

           Recipe.currentRec = new Recipe();
            InitializeComponent();



            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            List<String> ss = new List<string>();
            ss.Add("test");

            

        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ItemViewModel avm = (ItemViewModel)stewsMenue.SelectedItem;
            
            loadRec(avm.LineOne,"stew");

            NavigationService.Navigate(new Uri("/RecipePage.xaml", UriKind.Relative));
           
        }

        
        private void kebabMenue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemViewModel avm = (ItemViewModel)kebabMenue.SelectedItem;
            //MessageBox.Show(avm.LineOne);
            loadRec(avm.LineOne,"kebab");

            NavigationService.Navigate(new Uri("/RecipePage.xaml", UriKind.Relative));
        }

        private void riceMenue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemViewModel avm = (ItemViewModel)riceMenue.SelectedItem;
            //MessageBox.Show(avm.LineOne);
            loadRec(avm.LineOne,"rice");

            NavigationService.Navigate(new Uri("/RecipePage.xaml", UriKind.Relative));
        }

        private void soupMenue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ItemViewModel avm = (ItemViewModel)soupMenue.SelectedItem;
            //MessageBox.Show(avm.LineOne);
            loadRec(avm.LineOne,"soup");

            NavigationService.Navigate(new Uri("/RecipePage.xaml", UriKind.Relative));
        }

        private void torshiMenue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemViewModel avm = (ItemViewModel)torshiMenue.SelectedItem;
            //MessageBox.Show(avm.LineOne);
            loadRec(avm.LineOne,"torshi");

            NavigationService.Navigate(new Uri("/RecipePage.xaml", UriKind.Relative));
        }

        private void desertMenue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemViewModel avm = (ItemViewModel)desertMenue.SelectedItem;
            //MessageBox.Show(avm.LineOne);
            loadRec(avm.LineOne,"desert");

            
            NavigationService.Navigate(new Uri("/RecipePage.xaml", UriKind.Relative));
        }

        /// <summary>
        /// loads Recipe
        /// </summary>
        private void loadRec(string name, string type)
        {
            if (type == "stew")
            {

                if (!DataLoader.Stews.TryGetValue(name, out Recipe.currentRec))
                {

                }
                //Recipe.currentRec.title = name;
                
            }
            if (type == "kebab")
            {
                DataLoader.kebabs.TryGetValue(name, out Recipe.currentRec);
            }
            if (type == "rice")
            {
                DataLoader.rices.TryGetValue(name, out Recipe.currentRec);
            }
            if (type == "torshi")
            {
                DataLoader.torshi.TryGetValue(name, out Recipe.currentRec);
            }
            if (type == "desert")
            {
                DataLoader.deserts.TryGetValue(name, out Recipe.currentRec);
            }
            if (type == "soup")
            {
                DataLoader.soups.TryGetValue(name, out Recipe.currentRec);
            }


        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/about.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Search.xaml", UriKind.Relative));
        }
        //NavigationService.Navigate(new Uri("/ about.xaml", UriKind.Relative));


    }
}