using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjektSeznam
{
    internal class ListItem
    {
        public string Content;

        public DateTime Date;

        public ListItem Next;

        public bool Current;

        public ListItem Previous;

        public ListItem(string content, DateTime date)
        {
            Content = content;
            Date = date;
        }

        public override string ToString()
        {
            return $"Datum: {Date:dd.MM.yyyy}\n{Content}";
        }
    }
}
