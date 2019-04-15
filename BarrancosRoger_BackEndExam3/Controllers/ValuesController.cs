using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BarrancosRoger_BackEndExam3.Models;
using BarrancosRoger_BackEndExam3.Database_Access;

namespace BarrancosRoger_BackEndExam3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //GET api values
        [HttpGet]
        public IEnumerable<string> GetRebels()
        {
            string[] results;
            db connectDB = new db();
            results = connectDB.dbQuery("Select * from rebels");
            return results;
        }

        // POST api/values
        [HttpPost]
        public void AddRebel([FromBody] Rebel rebel)
        {
            db connectDB = new db();

            //Inserto y reviso con el boolean si lo ha hecho correctamente
            Boolean result = connectDB.insertRebel(rebel);

            //if (result) { Request.CreateResponse() } else { }
        }
    }
}
