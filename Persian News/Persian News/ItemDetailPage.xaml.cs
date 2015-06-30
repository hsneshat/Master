using Persian_News.Common;
using Persian_News.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232

namespace Persian_News
{
    /// <summary>
    /// A page that displays details for a single item within a group.
    /// </summary>
    public sealed partial class ItemDetailPage : Persian_News.Common.LayoutAwarePage
    {

        //The url of our rss..
        //const string url = "http://www.naftemporiki.gr/news/rsscateg.asp?categ=FIN";
        //string url = "http://www.tabnak.ir/fa/rss/allnews";
        
        public ItemDetailPage()
        {
            this.InitializeComponent();
            
            
        }
       
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            
            this.RSSPageTitle2.Text = CurrentAgency.url;

            base.OnNavigatedTo(e);
            
            try
            {
                //List<FeedItem> feedData = await Util.getFeedsAsync(url);
                List<FeedItem> feedData = await Util.getFeedsAsync(CurrentAgency.url);
                listView1.ItemsSource = feedData;
                this.RSSPageTitle.Text = CurrentAgency.title;
                this.RSSPageTitle2.Text = CurrentAgency.url;
                this.RSSPageTitle2.Text = "";
                RSSPageTitle.FontSize = 48;
                RSSPageTitle.FontWeight = Windows.UI.Text.FontWeights.Bold;
            }
            catch (System.NullReferenceException)
            {
                this.RSSPageTitle.Text = "خطا - "+CurrentAgency.title;
                this.RSSPageTitle2.Text = "اشکالی در دریافت اخبار از این پایگاه وجود دارد، از اتصال دستگاه به اینترنت و نبود مانعی برای دسترسی‌ به سایت مطمئن شوید و دوباره امتحان کنید .";
                
            }
            
            

        }


        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            RSSPageTitle.FontSize = 40;
            RSSPageTitle2.Text = "در صورتی‌ که زمان زیادی صرف بارگذاری شده است، از اتصال دستگاه به اینترنت و نبود مانعی برای دسترسی‌ به سایت مطمئن شوید. .";

            //url = CurrentAgency.url;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void listView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as FeedItem;
                if (item == null) return;

            Launcher.LaunchUriAsync(item.Link);
            /*
                Util.currentURL = item.Link;
                Util.currentTitle = CurrentAgency.title +": "+ item.Title;
                this.Frame.Navigate(typeof(Browser));
             */
        }

       

    }
}