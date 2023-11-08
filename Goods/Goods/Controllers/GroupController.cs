using Goods.Models;
using Microsoft.AspNetCore.Mvc;

namespace Goods.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : Controller
    {
        private GoodsAppContext _context;

        public GroupController(GoodsAppContext context)
        {
            _context = context;
        }

        [HttpPut]
        public void Put([FromBody] Group group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Post(Group group)
        {
            var existGroup = _context.Groups.AsNoTracking().FirstOrDefault(x => x.Id == group.Id);

            if (existGroup != null)
            {
                _context.Groups.Update(group);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("GetOne")]
        public Group? Get(int id)
        {
            return _context.Groups.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        [Route("GetAll")]
        public List<Group> GetAll([FromBody] GroupFilterDto group)
        {
            var query = _context.Groups.AsQueryable();

            if (group.Id != null)
            {
                query = query.Where(x => x.Id == group.Id);
            }

            if (group.Name != null)
            {
                query = query.Where(x => x.Name.Contains(group.Name));
            }

            return query.ToList();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var group = _context.Groups.FirstOrDefault(x => x.Id == id);

            if (group != null)
            {
                _context.Groups.Remove(group);
                _context.SaveChanges();
            }
        }
    }
}
