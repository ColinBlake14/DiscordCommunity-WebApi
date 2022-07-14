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
    public class FavoriteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private SqlDataReader myReader;

        public FavoriteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select FavoriteId, FavoriteUserName, FavoriteServerId from dbo.Favorites";
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
        public JsonResult Post(Favorite fv)
        {
            string query = @"
                    insert into dbo.Favorites
                    (FavoriteUserName, FavoriteServerId)
                    values
                    (
                    '" + fv.FavoriteUserName + @"'
                    ," + fv.FavoriteServerId + @"
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

            return new JsonResult("Favorite added Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.Favorites
                    where FavoriteId = " + id + @" 
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

            return new JsonResult("Favorite deleted Successfully");
        }

        [Route("GetFavoriteByUserServer")]
        public JsonResult GetFavoriteByUserServer(Favorite fv)
        {
            string query = @"
                    select FavoriteId, FavoriteUserName, FavoriteServerId from dbo.Favorites
                    where FavoriteUserName = '" + fv.FavoriteUserName + @"' and FavoriteServerId = " + fv.FavoriteServerId + @"
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

            if (table.Rows.Count > 0)
                return new JsonResult(table);
            else return new JsonResult("Favorite not exist");
        }

        [Route("GetFavoriteCount")]
        public JsonResult GetFavoriteCount(Favorite fv)
        {
            string query = @"
                    select FavoriteId, FavoriteUserName, FavoriteServerId from dbo.Favorites
                    where FavoriteServerId = " + fv.FavoriteServerId + @"
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

            return new JsonResult(table.Rows.Count);
        }

        [Route("GetFavoriteByUser")]
        public JsonResult GetFavoriteByUser(Favorite fv)
        {
            string query = @"
                    select FavoriteId, FavoriteUserName, FavoriteServerId from dbo.Favorites
                    where FavoriteUserName = '" + fv.FavoriteUserName + @"'
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

            if (table.Rows.Count > 0)
                return new JsonResult(table);
            else return new JsonResult("Favorite not exist");
        }
    }
}
