using Exam.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exam.Model.Entities
{
    public class Student : CoreEntity
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool isAdmin { get; set; }
        public string Password { get; set; }
        public string ProfileImageURL { get; set; }
        public string ProfileBacgroundImageURL { get; set; }

        //Exams
        public int MidTermGrade { get; set; }
        public int FinalGrade { get; set; }
        public int RetakeForFinalGrade { get; set; }

        //Question
        public List<Question> Questions { get; set; }
    }
}
