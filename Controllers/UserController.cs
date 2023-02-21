using Microsoft.ApplicationBlocks.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectManagerPlatformDb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagerPlatformDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        SqlConnection connection = new SqlConnection(@"server = server_name ; database = mytestdb; Integrated Security = true;");
        // GET: api/<UserController>s
        [HttpGet]
        public string Get()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [User]", connection);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data found";
            }
        }

        // GET api/<UserController>/5

        [HttpGet("{id}")]
        public string Get(int id)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [User] where Id = '"+id+"'", connection);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data found";
            }
        }

        // POST api/<UserController>
        [Route("AddUser")]
        [HttpPost]
        public string Post([FromBody] User user)
        {
            //var user = JsonConvert.DeserializeObject(value);
            SqlCommand sqlCommand = new SqlCommand(" INSERT INTO [User] (Name,Surname,Mail,Password)  VALUES ('"+user.Name+"','"+user.Surname+"','"+ user.Mail +"','"+user.Password+"');", connection);
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();
            if (i == 1)
            {
                return "Data saved";
            }
            else
            {
                return "Data could not be saved";
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] User user)
        {
            SqlCommand sqlCommand = new SqlCommand(" update [User] set Name = '"+user.Name+"' , Surname = '"+user.Surname+"' , Mail = '"+user.Mail+"' , Password = '"+user.Password+"' where Id = '"+id+"'", connection);
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();
            if (i == 1)
            {
                return "Data updated";
            }
            else
            {
                return "Data could not be updated";
            }
        }

        // DELETE api/<UserController>/5
        [Route("DeleteUser")]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            SqlCommand sqlCommand = new SqlCommand(" delete from [User] where Id = '" + id + "'", connection);
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();
            if (i == 1)
            {
                return "Data deleted";
            }
            else
            {
                return "Data could not be deleted";
            }
        }
    }
}
