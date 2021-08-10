using System.Collections.Generic;
using Domain.School;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EFCore
{
    [ConnectionStringName("Default")]//连接字符串
    public class EFCoreDBContext:AbpDbContext<EFCoreDBContext>
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<StuResult> StuResult { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //添加种子数据
            //modelBuilder.Entity<Teacher>().HasData(new List<Teacher>()
            //{
            //    new Teacher(-1){TeachName = "张老师"}
            //    ,new Teacher(-1){TeachName = "杨老师"}
            //    ,new Teacher(-1){TeachName = "李老师"}
            //});
            //modelBuilder.Entity<Student>().HasData(new List<Student>()
            //{
            //    new  Student(-1){StuNo = "111",TeacherNo = 1,UserName = "小明"}
            //    ,new Student(-1){StuNo = "222",TeacherNo = 2,UserName = "张三"}
            //    ,new Student(-1){StuNo = "333",TeacherNo = 2,UserName = "王五"}
            //    ,new Student(-1){StuNo = "444",TeacherNo = 3,UserName = "李四"}
            //});
            //modelBuilder.Entity<StuResult>().HasData(new List<StuResult>()
            //{
            //     new StuResult(-1){chengji = (decimal) 12.4,KeCheng = "语文",StuId = 1}
            //    ,new StuResult(-1){chengji = (decimal) 149.4,KeCheng = "数学",StuId = 1}
            //    ,new StuResult(-1){chengji = (decimal) 126.4,KeCheng = "语文",StuId = 2}
            //    ,new StuResult(-1){chengji = (decimal) 128.4,KeCheng = "语文",StuId = 3}
            //    ,new StuResult(-1){chengji = (decimal) 127.4,KeCheng = "语文",StuId = 4}
            //});
            //modelBuilder.Entity<StuResult>().Ignore(o => o.student);
            //modelBuilder.Entity<Student>().Ignore(o => o.Results);
            //modelBuilder.Entity<Student>().Ignore(o => o.teacher);
        }

        public EFCoreDBContext(DbContextOptions<EFCoreDBContext> options) : base(options)
        {
        }

    }
}