using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Para.Api;
using Para.Base.Response;

namespace Pa.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private List<Book> list;
        private readonly IValidator<Book> bookValidator;

        public BooksController(IValidator<Book> validator)
        {
            bookValidator = validator;

            list = new List<Book>();
            list.Add(new Book() { Id = 1, Name = "Test1", Author = "Author1", PageCount = 993 });
            list.Add(new Book() { Id = 2, Name = "Test2", Author = "Author2", PageCount = 234 });
        }

        [HttpGet]
        public ApiResponse<List<Book>> Get()
        {
            return new ApiResponse<List<Book>>(list);
        }

        [HttpGet("{id}")]
        public ApiResponse<Book> Get(int id)
        {
            var item = list?.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return new ApiResponse<Book>("Item not found in system.");
            }

            return new ApiResponse<Book>(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book value)
        {
            ValidationResult result = bookValidator.Validate(value);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            list.Add(value);
            return Ok(new ApiResponse<List<Book>>(list));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book value)
        {
            ValidationResult result = bookValidator.Validate(value);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var item = list.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return NotFound(new ApiResponse<List<Book>>("Item not found in system."));
            }

            list.Remove(item);
            list.Add(value);
            return Ok(new ApiResponse<List<Book>>(list));
        }

        [HttpDelete("{id}")]
        public ApiResponse<List<Book>> Delete(int id)
        {
            var item = list.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return new ApiResponse<List<Book>>("Item not found in system.");
            }

            list.Remove(item);
            return new ApiResponse<List<Book>>(list);
        }
    }
}