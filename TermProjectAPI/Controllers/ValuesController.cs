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

        public List<Home> createList(DataSet ds)
        {
            List<Home> returnable = new List<Home>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                // issue is in here which needs to be adjusted
                Home addable = new Home();
                addable.Homeaddress = row[0].ToString();
                addable.State = row[1].ToString();
                addable.SellerUsername = row[2].ToString();
                addable.PropertyType = row[3].ToString();

                addable.HomeSize = int.Parse(row[4].ToString());
                addable.BedRoomNumber = int.Parse(row[5].ToString());
                addable.BathRoomNumber = int.Parse(row[6].ToString());
                addable.Amentities = row[7].ToString();
                addable.Utilities = row[8].ToString();
                addable.Yearbuilt = int.Parse(row[9].ToString());
                addable.Garage = row[10].ToString();
                addable.Description = row[11].ToString();
                addable.AskingPrice = int.Parse(row[12].ToString());
                addable.DateListed = row[13].ToString();
                addable.Photos = row[14].ToString();

                returnable.Add(addable);

            }


            return returnable;
        }


        [HttpGet("GetByLocationPriceRooms/{Location}/{Min}/{Max}/{Rooms}")]
        public List<Home> GetLocationPrice(String Location, int Min, int Max, int Rooms)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_LOCATIONPRICEROOMS";

            SqlParameter input = new SqlParameter("@state", Location);
            input.Direction = ParameterDirection.Input;
            input.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(input);

            input = new SqlParameter("@price", Min);
            input.Direction = ParameterDirection.Input;
            input.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(input);

            input = new SqlParameter("@max", Max);
            input.Direction = ParameterDirection.Input;
            input.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(input);


            input = new SqlParameter("@Rooms", Rooms);
            input.Direction = ParameterDirection.Input;
            input.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(input);

            return createList(objDB.GetDataSet(objCommand));
        }


        [HttpGet("GetByLocationPrice/{Location}/{Min}/{Max}")]
        public List<Home> GetLocationPrice(String Location, int Min, int Max)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GETHOMESLOCATIONPRICE";

            SqlParameter input = new SqlParameter("@state", Location);
            input.Direction = ParameterDirection.Input;
            input.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(input);

            input = new SqlParameter("@price", Min);
            input.Direction = ParameterDirection.Input;
            input.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(input);

            input = new SqlParameter("@max", Max);
            input.Direction = ParameterDirection.Input;
            input.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(input);





            return createList(objDB.GetDataSet(objCommand));
        }

        [HttpGet("GetByLocationPropertyTypePrice/{Location}/{PropertyType}/{Min}/{Max}")]
        public List<Home> GetLocationPropertyTypePrice(String Location, String PropertyType, int Min, int Max)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_LOCATIONPROPERTYTYPEPRICE";

            SqlParameter input = new SqlParameter("@state", Location);
            input.Direction = ParameterDirection.Input;
            input.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(input);

            input = new SqlParameter("@propertytype", PropertyType);
            input.Direction = ParameterDirection.Input;
            input.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(input);

            input = new SqlParameter("@price", Min);
            input.Direction = ParameterDirection.Input;
            input.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(input);

            input = new SqlParameter("@max", Max);
            input.Direction = ParameterDirection.Input;
            input.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(input);

            return createList(objDB.GetDataSet(objCommand));
        }


        [HttpGet]
        public List<Home> GetHomes()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_ALLHOMES";


            return createList(objDB.GetDataSet(objCommand));

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
