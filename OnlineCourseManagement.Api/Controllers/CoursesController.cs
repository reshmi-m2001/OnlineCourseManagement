using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseManagement.Application.Features.Course.Commands.CreateCourse;
using OnlineCourseManagement.Application.Features.Course.Commands.DeleteCourse;
using OnlineCourseManagement.Application.Features.Course.Commands.UpdateCourse;
using OnlineCourseManagement.Application.Features.Course.Queries.GetAllCourses;
using OnlineCourseManagement.Application.Features.Course.Queries.GetCourseDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineCourseManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator) 
        {
            this._mediator = mediator;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<List<CourseDTO>> Get()
        {
            var Courses = await _mediator.Send(new GetCoursesQuery());
            return Courses;
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDetailsDTO>> Get(int id)
        {
            var Course = await _mediator.Send(new GetCourseDetailsQuery(id));
            return Ok(Course);
        }

        // POST api/<CoursesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateCourseCommand course)
        {
            var response = await _mediator.Send(course);
            return CreatedAtAction(nameof(Get), new {id=response});
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task <ActionResult> Put(UpdateCourseCommand course)
        {
            await _mediator.Send(course);
            return NoContent();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCourseCommand {Id = id};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
