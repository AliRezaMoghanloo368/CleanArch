using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.ViewModels
{
    public class CartViewModel
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public string ToolsName { get; set; }
        public string Description { get; set; }
        public float Rate { get; set; }
        public string Styles { get; set; }
    }
}
