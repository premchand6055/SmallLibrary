using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmallLibrary.DAL;
using SmallLibrary.Models;
using System.Reflection.Metadata.Ecma335;

namespace SmallLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly MyAppDbContext _context;

        public BookController(MyAppDbContext context)
        {
            _context = context;
        }
        [HttpGet] //Read
        public IActionResult Get()
        {
            try
            {
                var books = _context.Books.ToList();
                if (books.Count == 0)
                    return NotFound("Books are not available");
                return Ok(books);
            }
            catch (Exception ex)
            {
             return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var book = _context.Books.Find(id);
                if (book == null)
                    return NotFound($"Book Details are not found with id {id}");
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]//create
        public IActionResult Post(Book model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Book Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Book model)
        {
            if (model == null || model.Id == 0)
            {
                if (model == null)
                    return BadRequest("Model data is invalid");
                else if (model.Id == 0)
                    return BadRequest($"Book Id {model.Id} is invalid");
            }
            try
            {
                var book = _context.Books.Find(model.Id);
                if (book == null)
                    return NotFound($"Book not found with id {model.Id} is invalid");
                book.Title = model.Title;
                book.Author = model.Author;
                book.Published_Year = model.Published_Year;
                _context.SaveChanges();
                return Ok("Book Details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var book = _context.Books.Find(id);
                if (book == null)
                    return NotFound($"Book not found with the id {id}");
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Ok("Book details Deleted.");

    }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
