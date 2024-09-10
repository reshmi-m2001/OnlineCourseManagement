﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Application.Features.Course.Queries.GetCourseDetails
{
    public class CourseDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Duration { get; set; }
        public string Instructor { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CourseLink { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}
