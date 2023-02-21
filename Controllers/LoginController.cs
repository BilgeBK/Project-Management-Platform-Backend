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

namespace ProjectManagementPlatformDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        SqlConnection connection = new SqlConnection(@"server = server_name ; database = mytestdb; Integrated Security = true;");

        // POST api/<LoginController>
        [HttpPost]
        public string Post([FromBody] User user)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [User] Where Mail = '"+user.Mail+"' and Password = '"+user.Password+"'", connection);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return "Login success";
            }
            else
            {
                return "No data found";
            }
        }

        }
        
    }

