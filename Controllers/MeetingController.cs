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
    public class MeetingController : ControllerBase
    {
        SqlConnection connection = new SqlConnection(@"server = server_name ; database = mytestdb; Integrated Security = true;");
        // GET: api/<MeetingController>

        [HttpGet]
        public string Get()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Meeting]", connection);
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

        // GET api/<MeetingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Meeting] WHERE Id = '"+id+"'", connection);
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

        // POST api/<MeetingController>
        [HttpPost]
        public string Post([FromBody] Meeting meeting)
        {
            SqlCommand sqlCommand = new SqlCommand(" INSERT INTO [Meeting] (Title,Content, DateTime , ParticipantList)  VALUES ('" + meeting.Title + "','" + meeting.Content + "','" + meeting.DateTime + "','" + meeting.ParticipantList + "');", connection);
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

        // PUT api/<MeetingController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Meeting meeting)
        {
            SqlCommand sqlCommand = new SqlCommand(" update [Meeting] set Title = '" + meeting.Title + "' , Content = '" + meeting.Content+ "' , DateTime = '" + meeting.DateTime + "' , ParticipantList = '" + meeting.ParticipantList + "' where Id = '" + id + "'", connection);
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

        // DELETE api/<MeetingController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            SqlCommand sqlCommand = new SqlCommand(" DELETE FROM [Meeting] WHERE Id = '" + id + "'", connection);
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
