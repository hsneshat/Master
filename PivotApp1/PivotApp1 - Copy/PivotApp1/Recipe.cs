using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PivotApp1
{
    class Recipe
    {
        private string _title;
        public string count;
        public Dictionary<string,string> ingridiants = new Dictionary<string, string>();
        public string rec;

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }



        //used for page navigation
        public static Recipe currentRec;
    }
}
