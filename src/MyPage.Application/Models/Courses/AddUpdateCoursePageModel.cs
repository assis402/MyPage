namespace MyPage.Application.Models.Courses
{
    public class AddUpdateCoursePageModel
    {
        public AddUpdateCoursePageModel()
        {
            Action = "Add";
            Method = "post";
            PageTitle = "Add New Course";
            ConfirmButtonText = "add course";
            CourseCertificate = new();
        }

        public AddUpdateCoursePageModel(CourseCertificateModel courseCertificateModel)
        {
            Action = "Update";
            Method = "put";
            PageTitle = "Update Course";
            ConfirmButtonText = "update course";
            CourseCertificate = courseCertificateModel;
        }

        public string Action { get; set; }

        public string Method { get; set; }

        public string PageTitle { get; set; }

        public string ConfirmButtonText { get; set; }

        public CourseCertificateModel CourseCertificate { get; set; }
    }
}