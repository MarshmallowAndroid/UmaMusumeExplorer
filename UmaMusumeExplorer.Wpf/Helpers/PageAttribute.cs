using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Wpf.Helpers
{
    [AttributeUsage(AttributeTargets.Class)]
    class PageAttribute : Attribute
    {
        public PageAttribute(string pageName)
        {
            PageName = pageName;
        }

        public string PageName { get; }
    }
}
