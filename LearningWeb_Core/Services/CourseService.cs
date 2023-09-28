using DataLayer.Content;
using DataLayer.Entities.Course;

namespace LearningWeb_Core.Services
{
    public class CourseService:ICourseService
    {
        private readonly SiteContext _siteContext;

        public CourseService(SiteContext siteContext)
        {
            _siteContext = siteContext;
        }

        public List<CourseGroup> GetallCourse()
        {
            return _siteContext.CourseGroups.ToList();
        }
    }
}
