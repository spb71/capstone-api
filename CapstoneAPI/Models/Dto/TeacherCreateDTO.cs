﻿using System.ComponentModel.DataAnnotations;

namespace CapstoneAPI.Models.Dto
{
    public class TeacherCreateDTO
    {
      
        [Required]
        public string Name { get; set; }

        public virtual ICollection<CourseDto> Courses { get; set; }
    }
}
