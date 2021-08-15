using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.School;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace EFCore
{
    public class InitDataService : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Teacher> _teachersRepository;
        private readonly IRepository<Student> _stuRepository;
        private readonly IRepository<StuResult> _resultRepository;

        public InitDataService(IRepository<Teacher> teachersRepository, IRepository<Student> stuRepository, IRepository<StuResult> resultRepository)
        {
            _teachersRepository = teachersRepository;
            _stuRepository = stuRepository;
            _resultRepository = resultRepository;
        }
        public Task SeedAsync(DataSeedContext context)
        {
            new List<Teacher>()
            {
                 new Teacher(){TeachName = "张老师"}
                ,new Teacher(){TeachName = "杨老师"}
                ,new Teacher(){TeachName = "李老师"}
            }.ForEach(async (o)=> await _teachersRepository.InsertAsync(o));
            new List<Student>()
            {
                new  Student(){StuNo = "111",TeacherNo = 1,UserName = "小明"}
                ,new Student(){StuNo = "222",TeacherNo = 2,UserName = "张三"}
                ,new Student(){StuNo = "333",TeacherNo = 2,UserName = "王五"}
                ,new Student(){StuNo = "444",TeacherNo = 3,UserName = "李四"}
            }.ForEach(async (o) => await _stuRepository.InsertAsync(o)); ;
            new List<StuResult>()
            {
                 new StuResult(){chengji = (decimal) 12.4,KeCheng = "语文",StuId = 1}
                ,new StuResult(){chengji = (decimal) 149.4,KeCheng = "数学",StuId = 1}
                ,new StuResult(){chengji = (decimal) 126.4,KeCheng = "语文",StuId = 2}
                ,new StuResult(){chengji = (decimal) 128.4,KeCheng = "语文",StuId = 3}
                ,new StuResult(){chengji = (decimal) 127.4,KeCheng = "语文",StuId = 4}
            }.ForEach(async (o) => await _resultRepository.InsertAsync(o)); ;

            return null;
        }
    }
}