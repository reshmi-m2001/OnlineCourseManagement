using OnlineCourseManagement.Domain.Common;

namespace OnlineCourseManagement.Domain
{
    public class CourseCategory : BaseEntity
    {
        public string CategoryName { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
