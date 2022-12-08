using AutoMapper;
using CapstoneAPI.Models;
using CapstoneAPI.Models.Dto;
using CapstoneAPI.Repo.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace CapstoneAPI.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {




        protected APIResponse _response;
        private readonly IStudentRepo _dbStudent;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepo dbStudent, IMapper mapper)
        {
            _dbStudent = dbStudent;
            _mapper = mapper;
            _response = new();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetStudents()
        {
            try
            {
                IEnumerable<Student> studentList;

                studentList = await _dbStudent.GetAllAsync();



                _response.Result = _mapper.Map<List<StudentDto>>(studentList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
