﻿using API_Payroll.Contracts;
using API_Payroll.Models;
using API_Payroll.ViewModels.Others;
using API_Payroll.ViewModels.Overtimes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_Payroll.Controllers
{
    [ApiController]
    [Route("API-Payroll/[controller]")]
    
    public class OvertimeController : BaseController<Overtime, OvertimeVM>
    {
        private readonly IEmployeeOvertimeRepository _overtimeRepository;
        private readonly IMapper<Overtime, OvertimeVM> _mapper;

        public OvertimeController(IEmployeeOvertimeRepository overtimeRepository, IMapper<Overtime, OvertimeVM> mapper) : base(overtimeRepository, mapper)
        {
            _overtimeRepository = overtimeRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Employee")]
        [HttpPost("OvertimeRequest")]
        public IActionResult Created(OvertimeVM modelVM)
        {
            var model = _mapper.Map(modelVM);
            var result = _overtimeRepository.CreateRequest(model);
            if (result is null)
            {
                return NotFound(new ResponseVM<OvertimeVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Gagal Ditambahkan"
                });
            }

            return Ok(new ResponseVM<Overtime>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data Berhasil Ditambahkan",
                Data = result
            });
        }
        
        [Authorize(Roles = "Manager")]
        [HttpPut("OvertimeApproval/{guid}")]
        public IActionResult Update(Guid guid, OvertimeVM modelVM) {
            try
            {
                var model = _mapper.Map(modelVM);
                var result = _overtimeRepository.ApprovalOvertime(model,guid);
                if (result == 1)
                {
                    return Ok(new ResponseVM<Overtime>
                    {
                        Code = StatusCodes.Status200OK,
                        Status = HttpStatusCode.OK.ToString(),
                        Message = "Data Berhasil Update"

                    });
                }
                return NotFound(new ResponseVM<OvertimeVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Gagal Diupdate"
                });
            }
            catch {
                return BadRequest();
            }
        }
        
        [Authorize(Roles = "Manager")]
        [HttpGet("ByManager/{guid}")]
        public IActionResult ListOvertimeByManagerId(Guid guid) {

            var overtimes = _overtimeRepository.ListOvertimeByIdManager(guid);
            if (!overtimes.Any()) {
                return NotFound(new ResponseVM<OvertimeVM>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Seluruh Data Tidak Berhasil Ditampilkan"
                });
            }
            return Ok(new ResponseVM<List<OvertimeVM>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Seluruh Data Berhasil Ditampilkan",
                Data = overtimes
            });
        }
        
        [Authorize(Roles = "Employee")]
        [HttpGet("ByEmployee/{guid}")]
        public IActionResult ListOvertimeByEmployeeId(Guid guid) {
            try
            {
                var overtimes =  _overtimeRepository.ListOvertimeByIdEmployee(guid);
                if (overtimes is null)
                {
                    return NotFound(new ResponseVM<OvertimeVM>
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Seluruh Data Tidak Berhasil Ditampilkan"
                    });
                }
                return Ok(new ResponseVM<IEnumerable<OvertimeVM>>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Seluruh Data Berhasil Ditampilkan",
                    Data = overtimes
                });
            }
            catch {
                return null;
            }
        }
    }
}