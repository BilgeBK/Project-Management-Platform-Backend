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
    public class CustomerController : ControllerBase
    {
        SqlConnection connection = new SqlConnection(@"server = server_name ; database = mytestdb; Integrated Security = true;");
        // GET: api/<CustomerController>
        [HttpGet]
        public string Get()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Customer]", connection);
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

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Customer] WHERE Id = '"+id+"'", connection);
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

        // POST api/<CustomerController>
        [HttpPost]
        public string Post([FromBody] Customer customer)
        {
            SqlCommand sqlCommand = new SqlCommand(" INSERT INTO [Customer] (CompanyName, Mail)  VALUES ('" + customer.CompanyName + "','" + customer.Mail + "');", connection);
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

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Customer customer)
        {
            SqlCommand sqlCommand = new SqlCommand(" UPDATE  [Customer]  SET CompanyName = '" + customer.CompanyName + "', Mail = '" + customer.Mail + "' WHERE Id = '"+id+"';", connection);
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

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            SqlCommand sqlCommand = new SqlCommand(" DELETE FROM [Customer] WHERE Id = '" + id + "';", connection);
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
