using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SLN7.MODEL;
using SLN7.MODEL.ViewModel;
using SLN7.SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.SERVICE.Service
{
    public class OtherValues : IOtherValues
    {
        private readonly IConfiguration _config;
        public OtherValues(IConfiguration config)
        {
            _config = config;

        }
        //string conn = _config.GetSection("ConnectionStrings").GetSection("DbConn").Value;
        //string dbConn2 = _config.GetValue<string>("ConnectionStrings:DbConn");

        //private readonly string dbConn = Convert.ToString(Configuration.GetSection)
        public async Task<List<SaveSampleVals1>> GetData()
        {
            try
            {
                string conn = _config.GetConnectionString("DbConn");
                using (IDbConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    var param = new DynamicParameters();
                    param.Add("@Action", (int)GetActionValues.Read);
                    var result = await connection.QueryAsync<SaveSampleVals1>(Common.GetValues, param, null, 0, System.Data.CommandType.StoredProcedure);
                    connection.Close();

                    return result.ToList();
                }
                //return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> InsertData(List<SaveSampleVals1> lstData)
        {
            try
            {
                //List<SaveSampleVals1> lstData = new List<SaveSampleVals1>
                //{ vals1 };
                string conn = _config.GetConnectionString("DbConn");
                using (IDbConnection connection = new SqlConnection(conn))
                {
                    foreach (var project in lstData.Select(x => new { Name = x.Name, Gender = x.Gender }))
                    {
                        connection.Open();
                        var param = new DynamicParameters();
                        param.Add("@Action", (int)GetActionValues.Insert);
                        param.Add("@MyUDTableType", project);
                        var result = await connection.ExecuteAsync(Common.GetValues, param, null, 0, System.Data.CommandType.StoredProcedure);
                        connection.Close();
                    }
                    return true;
                }
                //return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


    }
}
