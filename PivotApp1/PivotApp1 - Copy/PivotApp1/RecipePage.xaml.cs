using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PivotApp1
{
    public partial class SecondPage : PhoneApplicationPage
    {
        public SecondPage()
        {
            InitializeComponent();
            //this.TitleBlock.Text = Recipe.currentRec.title;
            recepie.Title = Recipe.currentRec.title;

            loadIng();
            loadrec();
        }

        private void loadrec()
        {
            recTextBox.Text = "";
            recTextBox.Text = Recipe.currentRec.rec;
        }


        private void loadIng()
        {
            ingridiantsTextBox.Text = "";
            foreach (string ing in Recipe.currentRec.ingridiants.Keys)
            {
                string value = "";
                Recipe.currentRec.ingridiants.TryGetValue(ing, out value);
                ingridiantsTextBox.Text = ingridiantsTextBox.Text + "\n" + ing + "  ...... " + value;
            }
        }
        
    }
}