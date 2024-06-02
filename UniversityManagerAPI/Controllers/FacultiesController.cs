using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using UniversityManagerAPI.Auth;
using UniversityManagerAPI.Data.Repository.Interfaces;
using UniversityManagerAPI.DTO;
using UniversityManagerAPI.Entities;

namespace UniversityManagerAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FacultiesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public FacultiesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = unitOfWork.Faculties.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var faculty = unitOfWork.Faculties.GetById(id);
            if(faculty == null)
            {
                return NotFound();
            }
            return Ok(faculty);
        }

        [HttpGet("{id}/students")]
        public IActionResult GetWithStudents(int id)
        {
            var faculty = unitOfWork.Faculties.GetByIdWithStudents(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return Ok(faculty);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FacultyRequestPostDTO facultyDTO)
        {
            var entity = mapper.Map<Faculty>(facultyDTO);
            unitOfWork.Faculties.Add(entity);
            unitOfWork.SaveChanges();
            return Ok(entity);
        }

        [HttpPut]
        public IActionResult Put([FromBody] FacultyRequestPutDTO facultyDTO)
        {
            var entity2 = mapper.Map<Faculty>(facultyDTO);

            var facultyDB = unitOfWork.Faculties.GetById(facultyDTO.Id);
            var entity = mapper.Map(facultyDTO, facultyDB);
            unitOfWork.Faculties.Update(entity);
            unitOfWork.SaveChanges();
            return Ok(entity);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var faculty = unitOfWork.Faculties.GetById(id);
            if(faculty == null)
            {
                return NotFound();
            }
            unitOfWork.Faculties.Delete(faculty);
            unitOfWork.SaveChanges();
            return NoContent();
        }
    }
}
