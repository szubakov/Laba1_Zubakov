using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICore.Models;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarkController : Controller
    {
        private СarsAppContext _context;

        public MarkController(СarsAppContext context)
        {
            _context = context;
        }

        [HttpPut]
        public void Put([FromBody] Marks mark)
        {
            _context.MarksCars.Add(mark);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Post(Marks mark)
        {
            var existMark = _context.MarksCars.AsNoTracking().FirstOrDefault(x => x.Id == mark.Id);

            if (existMark != null)
            {
                _context.MarksCars.Update(mark);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("GetOne")]
        public Marks? Get(int id)
        {
            return _context.MarksCars.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        [Route("GetAll")]
        public List<Marks> GetAll([FromBody]MarksFilterDto mark )
        {
            var query = _context.MarksCars.AsQueryable();

            if (mark.Id != null)
            {
                query = query.Where(x => x.Id == mark.Id);

            }

            if (mark.Name != null)
            {
                query = query.Where(x => x.Name.Contains(mark.Name));

            }

            return query.ToList();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var marks = _context.MarksCars.FirstOrDefault(x => x.Id == id);

            if (marks != null)
            {
                _context.MarksCars.Remove(marks);
                _context.SaveChanges();
            }
        }
    }
}