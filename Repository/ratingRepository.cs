using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repository
{
    public class ratingRepository:IratingRepository
    {
        private readonly WebElectricStoreContext _WebElectricStoreContext;
        private readonly IConfiguration _configuration;


        public ratingRepository(WebElectricStoreContext WebElectricStoreContext, IConfiguration configuration)
        {
            _WebElectricStoreContext = WebElectricStoreContext;
            _configuration = configuration;

        }
        //string connectionString)

        public async Task addRating(Rating rating)
        {
            {
                DateTime RecordDate;
                string Host, Method, Path, Referer,UserAgent;
                Host = rating.Host;
                Method = rating.Method;
                Path = rating.Path;
                RecordDate = (DateTime)rating.RecordDate;
                Referer = rating.Referer;
                UserAgent = rating.UserAgent;




                string query = "INSERT INTO RATING(HOST, METHOD, PATH, Record_Date,REFERER,USER_AGENT)" +
                             "VALUES (@HOST, @METHOD, @PATH, @Record_Date, @REFERER,@USER_AGENT)";

                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("WebElectricStore")))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@HOST", SqlDbType.NChar, 50).Value = Host;
                    cmd.Parameters.Add("@METHOD", SqlDbType.NChar, 10).Value = Method;
                    cmd.Parameters.Add("@PATH", SqlDbType.NChar, 50).Value = Path;
                    cmd.Parameters.Add("@Record_Date", SqlDbType.DateTime ).Value = RecordDate;
                    cmd.Parameters.Add("@REFERER", SqlDbType.NChar, 100).Value = Referer;
                    cmd.Parameters.Add("@USER_AGENT", SqlDbType.NChar, 50).Value = UserAgent;


                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                }


            }




        }
    }
}
