using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Domain.School;
using Volo.Abp.Domain.Repositories;

namespace AbpWEbAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private IRepository<Teacher> _tcRepository;
        public StudentAPIController(IRepository<Teacher> tcRepository)
        {
            _tcRepository = tcRepository;
        }
        [HttpGet]
        public async Task<Teacher> AddTeacher()
        {
            Teacher tc = new Teacher(){TeachName = "aaa"};
            var isok = await _tcRepository.InsertAsync(tc);
            return isok;
        }
    }
}
