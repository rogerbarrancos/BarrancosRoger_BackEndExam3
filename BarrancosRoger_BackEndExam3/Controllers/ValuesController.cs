using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BarrancosRoger_BackEndExam3.Models;
using BarrancosRoger_BackEndExam3.Database_Access;
using BarrancosRoger_BackEndExam3.Logging;

namespace BarrancosRoger_BackEndExam3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        Log log = new Log();

        //El protocolo GET no es necesario para esta implementacion, pendiente de borrar

        ////GET api values
        //[HttpGet]
        //public void GetRebels()
        //{
        ////{
        ////    string[] results;
        ////    db connectDB = new db();
        ////    functions fn = new functions();

        ////    //Pido que me traduzcan a un array el dataset que pido en la misma instruccion sobre el select de todos los rebeldes
        ////    results = fn.DataSetToStringArray(connectDB.dbQuery("Select * from rebels"));
        ////    List<string> lst = new List<string>();
        ////    lst= connectDB.dbQuery("Select * from rebels");
        ////    return ls;
        //Console.WriteLine("Success");
        //}



        // Inserto con valores proporcionados por POST, retornando un boolean dependiendo de si se ha hecho correctamente.

        // POST api/values
        [HttpPost]
        public bool AddRebel([FromBody] Rebel rebel)
        {
            db connectDB = new db();

            //Inserto y reviso con el boolean si lo ha hecho correctamente
            Boolean result = connectDB.insertRebel(rebel);
            return result;
        }

        //Prueba de Log en ruta api/values/add cuando envías un post. Registra a archivo pero no BD

        [Route("Add")]
        public string Post([FromBody]Rebel rebel)
        {
            //Logueo y muestro el resultado
            string message= string.Format("Rebelde {0} insertado correctamente", rebel.name); ;
            log.logToFile(message);
            return message;
        }
    }
}
