using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace _5_WPF_Homework
{
    /// <summary>
    ///     <MyNamespace:ToDo/>
    ///
    /// </summary>
    public class ToDo : Control
    {
        private string name_;
        private DateTime date_;
        private string description_;
        private bool doing_;

        public string Name { get; set; }
        public DateTime Date { get { return date_; } }
        public string Description { get { return description_; } }
        public bool Doing
        {
            get => doing_;
            set => doing_ = value;
        }

        public ToDo(string name, DateTime date, string description)
        {
            name_ = name;
            date_ = date;
            description_ = description;
            doing_ = false;
        }
    }

}
