using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace WebService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : Controller
    {
        private string Host = "192.168.101.51";
        private int Port = 3306;
        private string DBName = "Workshop";
        private string UserName = "WSUser";
        private string Password = "WSPass123";

        // GET api/member
        [HttpGet]
        public string Get()
        {
            return "Hello World!";
        }

        // GET api/member/1
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value " + id;
        }

        // POST api/member
        [HttpPost]
        public ActionResult<Models.Response> Post([FromBody] Models.Request value)
        {
            var Response = new Models.Response() { Id = value.Id };

            string _connectionString = $"Data Source={Host};Port={Port};Database={DBName};User ID={UserName};Password={Password}";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string Query = $"SELECT sName, sMail, sDepartment FROM members WHERE Id = {value.Id}";

                try
                {
                    MySqlCommand dbCmd = new MySqlCommand(Query, connection);

                    connection.Open();

                    MySqlDataReader reader = dbCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Response.Name = reader.GetString("sName");
                        Response.Email = reader.GetString("sMail");
                        Response.Department = reader.GetString("sDepartment");
                    }

                    reader.Close();
                }
                catch (Exception e) { }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return Response;
        }

        // PUT api/member/
        [HttpPut]
        public ActionResult<string> Put([FromBody] Models.Request value)
        {
            var Response = string.Empty;

            string _connectionString = $"Data Source={Host};Port={Port};Database={DBName};User ID={UserName};Password={Password}";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string Query = $"INSERT INTO `Workshop`.`members` (`sName`, `sMail`, `sDepartment`) VALUES ('{value.Name}', '{value.Email}', '{value.Department}');";

                try
                {
                    MySqlCommand dbCmd = new MySqlCommand(Query, connection);

                    connection.Open();

                    var Result = dbCmd.ExecuteNonQuery();

                    dbCmd.CommandText = "SELECT LAST_INSERT_ID();";

                    var id = dbCmd.ExecuteScalar();

                    if (!id.Equals(0))
                    {
                        Response = $"OK. New Id: {id}";
                    }
                    else
                    {
                        Response = $"Failed.";
                    }
                }
                catch (Exception e)
                {
                    Response = $"Failed. {e.Message}";
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return Response;
        }
    }
}