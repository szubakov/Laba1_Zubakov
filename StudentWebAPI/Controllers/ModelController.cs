using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICore.Models;
using WebAPI.Models;
using System.Drawing;
using System.Data;
using AutoMapper;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController : Controller
    {
        private СarsAppContext _context;
        private readonly IMapper _mapper;

        public ModelController( IMapper mapper, СarsAppContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
        public void Put([FromBody] ModelsAddDto model)
        {
            //_context.Entry(student.Group).State = EntityState.Unchanged;

            var cars = _mapper.Map<ModelsAddDto, ModelsCar>(model);
            _context.ModelsCars.Add(cars);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Post(ModelsEditDto cars)
        {
            var existmodels = _context.ModelsCars.FirstOrDefault(x => x.Id == cars.Id);

            if (existmodels != null)
            {
                _mapper.Map(cars, existmodels);
                _context.ModelsCars.Update(existmodels);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("GetOne")]
        public ModelsGetDto? Get(int id)
        {
            var car= _context.ModelsCars.Include(p => p.Mark).FirstOrDefault(x => x.Id == id);

            if (car == null) return null;

            return ModelsGetDto(car);
        }

        [HttpPost]
        [Route("GetAll")]
         public ModelsGetAllDto GetAll([FromBody] ModelsFilterDto filter)
        {

            var query  = _context.ModelsCars.AsQueryable();

            if (filter.Name !=null)
            {
                query = query.Where(x => x.Name.Contains(filter.Name));
            }
            if (filter.privod != null)
            {
                query = query.Where(x => x.privod.Contains(filter.privod));
            }
            if (filter.kuzov != null)
            {
                query = query.Where(x => x.kuzov.Contains(filter.kuzov));
            }
            if (filter.markid != null)
            {
                query = query.Where(x => x.markID == filter.markid);
            }

            var models = query.ToList()
                    .Select(modelcar => ModelsGetDto(modelcar))
                    .ToList();

            var cars = new ModelsGetAllDto
            {
                Models = models,
                Marks = _context.MarksCars.Select(x => new Marks { Id = x.Id, Name = x.Name }).ToList()
            };


            return cars;
        }

        private ModelsGetDto ModelsGetDto(ModelsCar models)
        {
            var result = _mapper.Map<ModelsGetDto>(models);

            return result;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var model = _context.ModelsCars.FirstOrDefault(x => x.Id == id);

            if (model != null)
            {
                _context.ModelsCars.Remove(model);
                _context.SaveChanges();
            }
        }
    }
}