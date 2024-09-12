using OnlineCourseManagement.Domain.Common;

namespace OnlineCourseManagement.Domain
{
    public class Course : BaseEntity
    {
       public string Title {  get; set; } = string.Empty;
       public string Description {  get; set; } = string.Empty;
       public double Duration {  get; set; }
       public string Instructor { get; set; } = string.Empty ;
       public int CourseCategoryId { get; set; }
       public string CourseLink { get; set; } = string.Empty;
       //public CourseCategory? CourseCategory { get; set; } = new CourseCategory();
    }
}
