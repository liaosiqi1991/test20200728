using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.BusinessBase
{
    public class ItemBind
    {

        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public object Tag { get; set; }

        public object Data { get; set; }

        public ItemBind()
        {

        }

        public ItemBind(string name, string value)
            : this(name, value, null)
        {

        }

        public ItemBind(string name, string value, object tag)
        {
            Name = name;
            DisplayName = name;
            Value = value;
            Tag = tag;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
