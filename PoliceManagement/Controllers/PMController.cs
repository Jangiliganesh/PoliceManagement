using PoliceManagement.DBContext;
using PoliceManagement.Entities;
using PoliceManagement.Services;
using PoliceManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace PoliceManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PMController : ControllerBase
    {
        private readonly IPMService _pmservice;

        public PMController(IPMService pmservice)
        {
            _pmservice = pmservice;
        }


        [HttpGet]
        [Route("getalldetails")]
        public IActionResult GetAll()
        {
            return Ok(_pmservice.GetAll());
        }




        [HttpGet]
        [Route("Getbyid/{id}")]
        public IActionResult GetById(Guid id)
        {

            var data = _pmservice.GetById(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);

        }



        [HttpPost]
        [Route("Adding")]
        public IActionResult Insert(PMViewModel record)
        {

            _pmservice.Add(record);

            return Ok("Inserted Successfully");
   
        }


        [HttpPut]
        [Route("Update")]

        public IActionResult Update(PMViewModel Newdata)
        {
            _pmservice.Update(Newdata);
            return Ok("Updated successfully");

        }

        [HttpDelete]

        [Route("Delete")]

        public IActionResult Delete(Guid id)
        {

            _pmservice.Delete(id);
            return Ok("Deleted Successfully");

        }

        [HttpPatch]
        [Route("Patchfornamechange")]
        public IActionResult UpdateName(PatchNameViewModel NewName)
        {
            _pmservice.UpdateName(NewName);
            return Ok("Officer Name Updated Successfully");
        }

        
    }
}
