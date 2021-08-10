using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace Domain.School
{
    public class Teacher:Entity<int>
    {
        public Teacher()
        {
            
        }

        public Teacher(int Id):base(Id)
        {
            
        }
        [MaxLength(10)]
        public string TeachName { get; set; }
    }
}