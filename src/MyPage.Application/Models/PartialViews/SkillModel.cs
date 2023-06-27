using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Models.PartialViews
{
    public class SkillModel
    {
        public SkillModel(string title, int level)
        {
            Title = title;
            Level = level;
        }

        public string Title { get; set; }
        public int Level { get; set; }
    }
}