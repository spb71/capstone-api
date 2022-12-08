using AutoMapper;
using CapstoneAPI.Models;
using CapstoneAPI.Repo.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
