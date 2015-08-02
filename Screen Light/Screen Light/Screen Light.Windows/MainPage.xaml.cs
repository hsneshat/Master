using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Screen_Light
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {


            this.light.Opacity = (100 - e.NewValue) / 100;


        }

       

        private void Slider_ValueChanged_1(object sender, RangeBaseValueChangedEventArgs e)
        {
            int a = (int)((e.NewValue / 100) * ColorPicker.uintColors.Length);
            try
            {
                this.light.Background = new SolidColorBrush(ConvertStringToColor(ColorPicker.uintColors[a]));
            }
            catch (IndexOutOfRangeException)
            {
                a = a - 1;
                this.light.Background = new SolidColorBrush(ConvertStringToColor(ColorPicker.uintColors[a]));
            }


        }


        public Color ConvertStringToColor(String hex)
        {

            hex = hex.Replace("#", "");

            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;

            int start = 0;

            //handle ARGB strings (8 characters long) 
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }

            //convert RGB characters to bytes 
            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(a, r, g, b);
        }
    }
}
