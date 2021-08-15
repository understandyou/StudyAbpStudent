using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Domain.School;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace AbpWEbAPI.Controllers
{
    [Route("[controller]/[action]")]
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
        [HttpPost]
        [AllowAnonymous]
        public async Task<Teacher> GetTeacher(string name)
        {
            try
            {

                var tc = await _tcRepository.FindAsync(o => 
                 o.TeachName.Contains(name)
                );
                return tc;
            }
            catch (EntityNotFoundException fe)
            {
                throw fe;
            }
            catch (Exception e)
            {

                throw;
            }
            return null;
        }
        [HttpGet]
        public async Task<Teacher> GetTeacherToName(string name)
        {
            var tc = await _tcRepository.GetAsync(o => o.TeachName.Contains(name));
            return tc;
        }
    }
}
