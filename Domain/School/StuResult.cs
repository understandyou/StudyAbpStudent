using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Domain.School
{
    public class StuResult:Entity<int>
    {
   
        public int StuId { get; set; }
        public decimal chengji { get; set; }
        [MaxLength(10)]
        public string KeCheng { get; set; }
    }
}