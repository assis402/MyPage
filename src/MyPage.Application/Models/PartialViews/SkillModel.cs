using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Models.PartialViews
{
    public class SkillModel
    {
        public SkillModel(string title, int level, int animationDelay)
        {
            Title = title;
            Level = level;
            AnimationDelay = animationDelay;
        }

        public string Title { get; set; }
        public int Level { get; set; }
        public int AnimationDelay { get; set; }
    }
}