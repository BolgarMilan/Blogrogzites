using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blogfelhasznalok.Models;
using static Blogfelhasznalok.Models.Dto;

namespace Blogfelhasznalok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            using (var context = new UserDbContext())
            {
                return StatusCode(201, context.Adat.ToList());
            }
        }

        [HttpGet("{azon}")]
        public ActionResult<User> GetId(Guid azon)
        {
            using (var context = new UserDbContext())
            {
                return StatusCode(201, context.Adat.FirstOrDefault(x => x.Id == azon));
            }
        }
        [HttpPost]
        public ActionResult<User> Post(CreateUserDto CreateUserDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Title = CreateUserDto.title,
                Description = CreateUserDto.description,
                CreatedTime = CreateUserDto.createdtime,
                LastUpdated = CreateUserDto.lastupdate
            };

            using (var context = new UserDbContext())
            {
                context.Adat.Add(user);
                context.SaveChanges();
                return StatusCode(201, user);
            }
        }

        [HttpPut("{azon}")]
        public ActionResult<User> Put(Guid azon, UpdateUserDto updateUserDto)
        {
            using (var context = new UserDbContext())
            {

                var existingUser = context.Adat.FirstOrDefault(x => x.Id == azon);

                if (existingUser != null)
                {
                    existingUser.Title = updateUserDto.title;
                    existingUser.Description = updateUserDto.description;
                    existingUser.CreatedTime = updateUserDto.createdtime;

                    context.Adat.Update(existingUser);
                    context.SaveChanges();
                }

                return StatusCode(200, existingUser);

            }
        }

        [HttpDelete]
        public ActionResult<object> Delete(Guid azon)
        {
            using (var context = new UserDbContext())
            {
                var existingUser = context.Adat.FirstOrDefault(x => x.Id == azon);

                if (existingUser == null)
                {
                    return NotFound(new { message = "Felhasználó nem található!" });
                }

                context.Adat.Remove(existingUser);
                context.SaveChanges();

                return StatusCode(200, new { message = "Sikeres törlés!" });
            }
        }
    }
}
