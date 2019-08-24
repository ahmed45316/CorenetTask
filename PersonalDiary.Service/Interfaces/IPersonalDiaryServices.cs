using PersonalDiary.Service.Dto;
using PersonalDiary.Service.ReturnType;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDiary.Service.Interfaces
{
    public interface IPersonalDiaryServices
    {
        Task<ResponseResult<PersonalDiaryDto>> AddAsync(PersonalDiaryDto model);
        Task<ResponseResult<IEnumerable<PersonalDiaryDto>>> GetAllAsync();
        bool ModifyEndedNotes(out int count);
    }
}
