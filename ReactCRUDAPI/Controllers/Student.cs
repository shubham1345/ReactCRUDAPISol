using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactCRUDAPI.Model;
using System.Linq;

namespace ReactCRUDAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Student : ControllerBase
    {
        private readonly StudentContext db;
        public Student(StudentContext _dbcontext)
        {
            db = _dbcontext;
        }
        [HttpGet]
        public ActionResult GetAll()
        {            
            return Ok(db.Tb_Student.ToList());
        }
        [HttpPost]
        public ActionResult Create(StudentModel std)
        {
            if(std == null)
            {
                return BadRequest(false);
            }
            else
            {
                if(std.StudentId == 0)
                {
                    db.Tb_Student.Add(std);
                }
                else
                {
                    db.Entry(std).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                db.SaveChanges();
                return Ok(true);
            }
        }
        [HttpGet("{Id}")]
        public ActionResult Edit(int Id)
        {
            if(Id != 0)
            {
                return Ok(db.Tb_Student.Where(x=>x.StudentId == Id));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{Id}")]
        public ActionResult Delete(int Id)
        {
            if (Id != 0)
            {
                var res = db.Tb_Student.Find(Id);
                if(res != null)
                {
                    db.Remove(res);
                    db.SaveChanges();
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
                
            }
            else
            {
                return NotFound();
            }
        }

    }
}
