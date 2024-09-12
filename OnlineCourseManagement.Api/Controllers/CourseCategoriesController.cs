using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseManagement.Application.Features.Course.Commands.UpdateCourse;
using OnlineCourseManagement.Application.Features.Course.Queries.GetAllCourses;
using OnlineCourseManagement.Application.Features.CourseCategory.Commands.CreateCourseCategory;
using OnlineCourseManagement.Application.Features.CourseCategory.Commands.DeleteCourseCategory;
using OnlineCourseManagement.Application.Features.CourseCategory.Commands.UpdateCourseCategory;
using OnlineCourseManagement.Application.Features.CourseCategory.Queries.GetAllCourseCategory;
using OnlineCourseManagement.Application.Features.CourseCategory.Queries.GetCourseCategoryDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineCourseManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseCategoriesController(IMediator mediator) 
        {
            this._mediator = mediator;
        }
        // GET: api/<CourseCategoriesController>
        [HttpGet]
        public async Task<List<CourseCategoryDTO>> Get()
        {
            var CourseCategories = await _mediator.Send(new GetCourseCategoriesQuery());
            return CourseCategories;
        }

        // GET api/<CourseCategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseCategoryDetailsDTO>> Get(int id)
        {
            var CourseCategory = await _mediator.Send(new GetCourseCategoryDetailsQuery(id));
            return Ok(CourseCategory);
        }

        // POST api/<CourseCategoriesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateCourseCategoryCommand courseCategory)
        {
            var response = await _mediator.Send(courseCategory);
            return CreatedAtAction(nameof(Get), new {id = response});
        }

        // PUT api/<CourseCategoriesController>/5

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCourseCategoryCommand courseCategory)
            {
            await _mediator.Send(courseCategory);
            return NoContent();

            }

        // DELETE api/<CourseCategoriesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCourseCategoryCommand {Id = id};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
