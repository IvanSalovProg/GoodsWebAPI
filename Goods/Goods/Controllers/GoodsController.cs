using Goods.Models;
using Microsoft.AspNetCore.Mvc;

namespace Goods.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodsController : Controller
    {
        private GoodsAppContext _context;

        private readonly IMapper _mapper;

        public GoodsController(IMapper mapper, GoodsAppContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
        public void Put([FromBody] GoodsAddDto model)
        {
            var googs = _mapper.Map<GoogsAddDto, Googs>(model);

            _context.Googs.Add(googs);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Post(GoogsEditDto student)
        {
            var existStudent = _context.Googs.FirstOrDefault(x => x.Id == student.Id);

            if (existStudent != null)
            {
                _mapper.Map(student, existStudent);

                _context.Googs.Update(existStudent);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("GetOne")]
        public GoogsGetDto? Get(int id)
        {
            var googs = _context.Googs.Include(p => p.Group).FirstOrDefault(x => x.Id == id);

            if (googs == null) return null;

            return GoogsGetDto(googs);
        }

        [HttpPost]
        [Route("GetAll")]
        public GoogsGetAllDto GetAll([FromBody] GoogsFilterDto filter)
        {
            var query = _context.Googs.AsQueryable();

            if (filter.FirstName != null)
            {
                query = query.Where(x => x.FirstName.Contains(filter.FirstName));
            }

            if (filter.LastName != null)
            {
                query = query.Where(x => x.LastName.Contains(filter.LastName));
            }

            if (filter.Email != null)
            {
                query = query.Where(x => x.Email.Contains(filter.Email));
            }

            if (filter.GroupId != null)
            {
                query = query.Where(x => x.GroupId == filter.GroupId);
            }

            var Googs = query.ToList()
                .Select(googs => GoogsGetDto(googs))
                .ToList();

            var model = new GoogsGetAllDto
            {
                Googs = Googs,
                Groups = _context.Groups.Select(x => new GroupDto { Id = x.Id, Name = x.Name }).ToList()
            };

            return model;
        }

        private GoogsGetDto GoogsGetDto(Googs googs)
        {
            var result = _mapper.Map<GoogsGetDto>(googs);

            return result;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var googs = _context.Googs.FirstOrDefault(x => x.Id == id);

            if (googs != null)
            {
                _context.Googs.Remove(googs);
                _context.SaveChanges();
            }
        }
    }
}
