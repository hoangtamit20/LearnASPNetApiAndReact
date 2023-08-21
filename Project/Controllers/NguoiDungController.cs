using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Entity;
using Project.Repository;
using Project.Repository.IRepository;
using Project.Services;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungRepository _nguoiDungRepository;
        private readonly ILogger<NguoiDungController> _logger;
        public NguoiDungController(INguoiDungRepository nguoiDungRepository, ILogger<NguoiDungController> logger)
        {
            _nguoiDungRepository = nguoiDungRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult NguoiDungs()
        {
            _logger.LogInformation("Hello các bạn nhỏ ahii!");
            if (_nguoiDungRepository.nguoiDungs() == null)
                return BadRequest(new ResponseService()
                {
                    Success = false,
                    Message = "NguoiDungs is null",
                    Data = null
                });
            return Ok(new ResponseService()
            {
                Success = true,
                Message = "Get all NguoiDungs success!",
                Data = _nguoiDungRepository.nguoiDungs()
            });
        }

        [HttpPost]
        public IActionResult CreateNguoiDung(NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                if (_nguoiDungRepository.addNguoiDung(nguoiDung))
                {
                    return Ok(new ResponseService()
                    {
                        Success = true,
                        Message = "Add NguoiDung success!",
                        Data = nguoiDung
                    });
                }
                return BadRequest(new ResponseService()
                {
                    Success = false,
                    Message = "Add NguoiDung failed!",
                    Data = nguoiDung
                });
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNguoiDung(int id, NguoiDung nguoiDung)
        {
            if (nguoiDung.Id != id)
            {
                return BadRequest(new ResponseService()
                {
                    Success = false,
                    Message = "Invalid token!",
                    Data = nguoiDung
                });
            }
            if (_nguoiDungRepository.updateNguoiDung(nguoiDung))
            {
                return Ok(new ResponseService()
                {
                    Success = true,
                    Message = "Update NguoiDung success!",
                    Data = nguoiDung
                });
            }
            return BadRequest(new ResponseService()
            {
                Success = false,
                Message = "Invalid token!",
                Data = null
            });
        }
    }
}