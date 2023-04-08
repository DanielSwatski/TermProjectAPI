using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace TermProjectAPI.Controllers
{
    [Route("HomesAPI/")]
    [Produces("application/json")]
    public class ValuesController : ControllerBase
    {


        [HttpGet]
        public List<Home> GetHomes()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_ALLHOMES";


            DataSet ds = objDB.GetDataSet(objCommand);

            List<Home> returnable = new List<Home>();

            
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Home addable = new Home();
                addable.Homeaddress = row[0].ToString();
                
                returnable.Add(addable);

            }

            return returnable;

        }

        /*
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
