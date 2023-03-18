using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Models
{
    public class ProjectsPageModel
    {
        public ProjectsPageModel(ICollection<GitHubRepositoryModel> projectList)
        {
            ProjectList = projectList;
        }

        public ICollection<GitHubRepositoryModel> ProjectList { get; private set; }

        public void GetProjectListByCurrentFilter(string searchString)
        {
            ProjectList = ProjectList.Where(project => project.Contains(searchString)).ToList();
        }
    }
}
