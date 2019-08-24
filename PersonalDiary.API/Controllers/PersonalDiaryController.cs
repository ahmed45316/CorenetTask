using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using PersonalDiary.Service;
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
        private readonly IHubContext<NotifyHub> _hub;
        /// <inheritdoc />
        public PersonalDiaryController(IPersonalDiaryServices personalDiaryServices, IHubContext<NotifyHub> hub)
        {
            _personalDiaryServices = personalDiaryServices;
            _hub = hub;
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> IsNoteEnded()
        {
            int count = 0;
            if (_personalDiaryServices.ModifyEndedNotes(out count))
            {
                await _hub.Clients.All.SendAsync("NotifyMe", count);
            }
            else
            {
                await _hub.Clients.All.SendAsync("NoData", count);
            }
            return Ok(true);
        }
    }
}