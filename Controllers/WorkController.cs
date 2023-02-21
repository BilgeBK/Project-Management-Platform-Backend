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
    public class WorkController : ControllerBase
    {
        SqlConnection connection = new SqlConnection(@"server = server_name ; database = mytestdb; Integrated Security = true;");
        // GET: api/<WorkController>
        [HttpGet]
        public string  Get()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Work]", connection);
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

        // GET api/<WorkController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Work] Where Id = '"+id+"'", connection);
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

        // POST api/<WorkController>
        [HttpPost]
        public string Post([FromBody] Work work)
        {
            SqlCommand sqlCommand = new SqlCommand(" INSERT INTO [Work] (Title,Content, UserId,IsComplete)  VALUES ('" + work.Title + "','" + work.Content + "','" + work.UserId + "','false');", connection);
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

        // PUT api/<WorkController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Work work)
        {
            SqlCommand sqlCommand = new SqlCommand(" Update [Work] Set Title = '"+work.Title+"',Content = '"+work.Content+"',UserId = '"+work.UserId+"',IsComplete = '"+work.IsComplete+"' Where Id = '"+id+"'",connection);
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

        // DELETE api/<WorkController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete From [Work] where Id = '" + id + "'", connection);
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();
            if(i == 1)
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
