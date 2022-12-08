using AutoMapper;
using Azure;
using CapstoneAPI.Models;
using CapstoneAPI.Models.Dto;
using CapstoneAPI.Repo.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace CapstoneAPI.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ICourseRepo _dbCourse;
        private readonly IMapper _mapper;
        public CourseController(ICourseRepo dbCourse, IMapper mapper)
        {
            _dbCourse = dbCourse;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetCourses(
            int pageSize = 0, int pageNumber = 1)
        {
            try
            {

                IEnumerable<Course> courseList;

                courseList = await _dbCourse.GetAllAsync(pageSize: pageSize,
                    pageNumber: pageNumber);

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));
                _response.Result = _mapper.Map<List<CourseDto>>(courseList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
