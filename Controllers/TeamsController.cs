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
    public class TeamsController : ControllerBase
    {
        SqlConnection connection = new SqlConnection(@"server = server_name ; database = mytestdb; Integrated Security = true;");

        // GET: api/<TeamsController>
        [HttpGet]
        public string Get()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Teams]", connection);
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

        // GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Teams] WHERE Id = '"+id+"'",connection);
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

        // POST api/<TeamsController>
        [HttpPost]
        public string Post([FromBody] Teams teams)
        {
            SqlCommand sqlCommand = new SqlCommand(" INSERT INTO [Teams] (TeamTitle,TeamList)  VALUES ('"+teams.TeamTitle+"','"+teams.TeamList+"');", connection);
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

        // PUT api/<TeamsController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Teams teams)
        {
            SqlCommand sqlCommand = new SqlCommand(" update [Teams] set TeamTitle = '" + teams.TeamTitle+ "' , TeamList = '" + teams.TeamList + "' where Id = '" + id + "'", connection);
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();
            if(i == 1)
            {
                return "Data updated";
            }
            else
            {
                return "Data could not be update";
            }
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM [Teams] WHERE Id = '"+id+"'", connection);
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
