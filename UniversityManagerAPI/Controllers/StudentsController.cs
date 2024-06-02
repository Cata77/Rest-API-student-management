using Microsoft.AspNetCore.Mvc;
using UniversityManagerAPI.Data.Repository.Interfaces;
using UniversityManagerAPI.Entities;

namespace UniversityManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public StudentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = unitOfWork.Students.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = unitOfWork.Students.GetAll();
            return Ok(students);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            unitOfWork.Students.Add(student);
            unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Student student)
        {
            unitOfWork.Students.Update(student);
            unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var student = unitOfWork.Students.GetById(id);
            if (student != null)
            {
                unitOfWork.Students.Delete(student);
                unitOfWork.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
