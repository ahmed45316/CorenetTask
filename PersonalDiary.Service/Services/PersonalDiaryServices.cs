using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalDiary.Data.UnitOfWork;
using PersonalDiary.Service.Dto;
using PersonalDiary.Service.Interfaces;
using PersonalDiary.Service.ReturnType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDiary.Service.Services
{
    public class PersonalDiaryServices : IPersonalDiaryServices
    {
        private readonly IUnitOfWork<Entities.PersonalDiary> _unitOfWork;
        private readonly IMapper _mapper;
        public PersonalDiaryServices(IMapper mapper, IUnitOfWork<Entities.PersonalDiary> unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseResult<PersonalDiaryDto>> AddAsync(PersonalDiaryDto model)
        {
            try
            {
                var entity = _mapper.Map<Entities.PersonalDiary>(model);
                var result = await _unitOfWork.Repository.Add(entity);
                int affectedRows = await _unitOfWork.SaveChanges();
                if (affectedRows > 0)
                {
                    var returnResult = _mapper.Map<PersonalDiaryDto>(result);
                    return new ResponseResult<PersonalDiaryDto>(returnResult, HttpStatusCode.Created, "Data added successfuly");
                };
                return new ResponseResult<PersonalDiaryDto>(null, HttpStatusCode.BadRequest, "Data added faild");
            }
            catch (Exception e)
            {
                return new ResponseResult<PersonalDiaryDto>(null, HttpStatusCode.InternalServerError, e.Message);

            }
        }
        public virtual async Task<ResponseResult<IEnumerable<PersonalDiaryDto>>> GetAllAsync()
        {
            try
            {
                var query = await _unitOfWork.Repository.GetAllAsync(orderby: p => p.OrderByDescending(d => d.Date));
                var data = _mapper.Map<IEnumerable<PersonalDiaryDto>>(query);
                return new ResponseResult<IEnumerable<PersonalDiaryDto>>(data, HttpStatusCode.OK, "done");
            }
            catch (Exception e)
            {
                return new ResponseResult<IEnumerable<PersonalDiaryDto>>(null, HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
