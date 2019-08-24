using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalDiary.Service.Dto;
using PersonalDiary.Service.Interfaces;
using PersonalDiary.Service.ReturnType;

namespace PersonalDiary.API.Controllers
{
    /// <inheritdoc />
    [Route("[controller]/[Action]")]
    [ApiController]
    public class PersonalDiaryController : ControllerBase
    {
        private readonly IPersonalDiaryServices _personalDiaryServices;
        /// <inheritdoc />
        public PersonalDiaryController(IPersonalDiaryServices personalDiaryServices)
        {
            _personalDiaryServices = personalDiaryServices;
        }
        /// <summary>
        /// Add data 
        /// </summary>
        /// <param name="model">Object content</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseResult<PersonalDiaryDto>> Add(PersonalDiaryDto model)
        {
            return await _personalDiaryServices.AddAsync(model);
        }
        /// <summary>
        /// GetAll Data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseResult<IEnumerable<PersonalDiaryDto>>> GetAll()
        {
            return await _personalDiaryServices.GetAllAsync();
        }
    }
}