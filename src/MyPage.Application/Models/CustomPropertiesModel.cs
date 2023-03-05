using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Models
{
    public class CustomPropertiesModel
    {
        public DescriptionModel Description { get; set; }

        public string VideoUrl { get; set; }
    }

    public class DescriptionModel
    {
        public string PT_BR { get; set; }

        public string EN_US { get; set; }
    }
}
