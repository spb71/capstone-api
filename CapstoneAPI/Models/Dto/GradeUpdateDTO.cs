﻿using System.ComponentModel.DataAnnotations;

namespace CapstoneAPI.Models.Dto
{
    public class GradeUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Grade")]
        public string LetterGrade { get; set; }

        public StudentDto Student { get; set; }
        public CourseDto Course { get; set; }
    }
}
