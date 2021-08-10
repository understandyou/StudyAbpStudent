using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Domain.School
{
    public class Student:Entity<int>
    {
        public Student()
        {
            
        }

        public Student(int id):base(id)
        {
            
        }
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string StuNo { get; set; }
        public int TeacherNo { get; set; }
    }
}