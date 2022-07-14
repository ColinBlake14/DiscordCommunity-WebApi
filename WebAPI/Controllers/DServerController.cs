using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DServerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private SqlDataReader myReader;

        public DServerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select DServerId, DServerName, DServerGame, DServerText, DServerURL,
                    DServerAuthor, DServerDate, DServerUI, DServerOnline, DServerUPD, DServerStatus from dbo.DServers";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DisComAppCon");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(DServer ds)
        {
            string query = @"
                    insert into dbo.DServers
                    (DServerName, DServerGame, DServerText, DServerURL,
                    DServerAuthor, DServerDate, DServerUI, DServerStatus)
                    values
                    (
                    '" + ds.DServerName + @"'
                    ,'" + ds.DServerGame + @"'
                    ,'" + ds.DServerText + @"'
                    ,'" + ds.DServerURL + @"'
                    ,'" + ds.DServerAuthor + @"'
                    ,'" + ds.DServerDate + @"'
                    ,'" + ds.DServerUI + @"'
                    ,'" + ds.DServerStatus + @"'
                    )
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DisComAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("DServer added Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.DServers
                    where DServerId = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DisComAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("DServer deleted Successfully");
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"
                    select DServerId, DServerName, DServerGame, DServerText, DServerURL,
                    DServerAuthor, DServerDate, DServerUI, DServerOnline, DServerUPD, DServerStatus from dbo.DServers
                    where DServerId = " + id + @"
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DisComAppCon");

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPut]
        public JsonResult Put(DServer ds)
        {
            string query = @"
                    update dbo.DServers set 
                    DServerName = '" + ds.DServerName + @"',
                    DServerGame = '" + ds.DServerGame + @"',
                    DServerText = '" + ds.DServerText + @"',
                    DServerURL = '" + ds.DServerURL + @"',
                    DServerDate = '" + ds.DServerDate + @"',
                    DServerUI = '" + ds.DServerUI + @"'
                    where DServerId = " + ds.DServerId + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DisComAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("DServer updated Successfully");
        }

        [Route("UpdateDServerOnlineData")]
        public JsonResult UpdateDServerOnlineData(DServer ds)
        {
            string query = @"
                    update dbo.DServers set 
                    DServerUPD = '" + ds.DServerUPD + @"',
                    DServerOnline = '" + ds.DServerOnline + @"'
                    where DServerUI = '" + ds.DServerUI + @"'
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DisComAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("DServer online data updated Successfully");
        }

        [Route("UpdateDServerStatusData")]
        public JsonResult UpdateDServerStatusData(DServer ds)
        {
            string query = @"
                    update dbo.DServers set 
                    DServerStatus = '" + ds.DServerStatus + @"'
                    where DServerId = " + ds.DServerId + @"
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DisComAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("DServer status data updated Successfully");
        }

        [Route("GetDServersDataByUser")]
        public JsonResult GetDServersDataByUser(DServer ds)
        {
            string query = @"
                    select DServerId, DServerName, DServerGame, DServerText, DServerURL,
                    DServerAuthor, DServerDate, DServerUI, DServerOnline, DServerUPD, DServerStatus from dbo.DServers
                    where DServerAuthor = '" + ds.DServerAuthor + @"'
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DisComAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
