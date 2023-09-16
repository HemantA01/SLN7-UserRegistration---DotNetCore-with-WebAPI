using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Hosting;
using Serilog;
using SLN7.DATA.DBContext;
using SLN7.DATA.DBModel;
using SLN7.SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.Hosting;

namespace SLN7.SERVICE.Service
{
    public class UploadFile : IUploadFile
    {
        //private readonly IHostEnvironment _iwebhostenv;
        private readonly ApplicationContext _context;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _iwebhostenv;
        public UploadFile(ApplicationContext context, IWebHostEnvironment iwebhostenv, IConfiguration config)
        {
            _context = context;
            _iwebhostenv = iwebhostenv;
            _config = config;
        }
        //public async Task<bool> UploadImage(IFormFile file, string uploadPath)
        public async Task<bool> UploadImage(IFormFile file)
        {
            try
            {
                /*if (!file.ContentType.Contains("image"))
                {
                    return false;
                }*/
                if (file != null)
                {
                    string directoryPath = Path.Combine(this._iwebhostenv.WebRootPath, _config.GetSection("FileUploadPath").Value);
                    string filename = file.FileName.Split('.')[0] + "_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + file.FileName.Split(".")[1];
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    string filepath = Path.Combine(directoryPath, filename);
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    TblUploadFile objFile = new();
                    objFile.FilePath = filepath;
                    objFile.FileName = filename;
                    objFile.FileType = file.ContentType;
                    objFile.FileExtension = file.FileName.Split(".")[1];
                    objFile.CreatedDate= DateTime.Now;
                    _context.tblUploadFile.Add(objFile);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Information(ex.Message);
                throw;
            }
        }
        public async Task<bool> UploadExcelInsertBulkRecords(IFormFile file)
        {
            bool isUploaded = false;
            string filename;
            try
            {
                if (!file.ContentType.Contains("spreadsheet"))
                {
                    return false;
                }
                if (file != null)
                {
                    string directoryPath = Path.Combine(this._iwebhostenv.WebRootPath, "Uploads");
                    string extension =  "." + file.FileName.Split(".")[1];
                    filename = file.FileName.Split('.')[0] + "_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + extension;
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    string filepath = Path.Combine(directoryPath, filename);
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls":
                            conString= _config.GetConnectionString("Excel03ConString").ToString();
                            break;
                        case ".xlsx":
                            conString = _config.GetConnectionString("Excel07ConString").ToString();
                            break;
                    }
                    DataTable dt = new();
                    conString = string.Format(conString, filepath);
                    using (OleDbConnection conExcel = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmdExcel = new OleDbCommand())
                        {
                            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                            {
                                cmdExcel.Connection = conExcel;
                                //Get the name of 1st sheet
                                conExcel.Open();
                                DataTable dtExcelSchema;
                                dtExcelSchema= conExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                conExcel.Close();
                                //Read data from 1st sheet
                                conExcel.Open();
                                cmdExcel.CommandText = "select * from [" + sheetName + "]";
                                odaExcel.SelectCommand= cmdExcel;
                                odaExcel.Fill(dt);
                                conExcel.Close();
                            }
                        }
                    }
                    conString = _config.GetConnectionString("DbConn").ToString();
                    using (SqlConnection conn = new(conString))
                    {
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            //Set the database destination table name
                            bulkcopy.DestinationTableName = "dbo.Employee";
                            //map the Excel columns (source) with that of table column name (destination)
                            bulkcopy.ColumnMappings.Add("EmpFirstName", "EmpFName");
                            bulkcopy.ColumnMappings.Add("EmpLastName", "EmpLName");
                            bulkcopy.ColumnMappings.Add("Username", "EmpUserName");
                            bulkcopy.ColumnMappings.Add("EmailId", "EmpEmailId");
                            bulkcopy.ColumnMappings.Add("Password", "EmpPassword");
                            bulkcopy.ColumnMappings.Add("EmpMobileNo", "EmpMobileNo");
                            bulkcopy.ColumnMappings.Add("JoiningDate", "DOJ");
                            bulkcopy.ColumnMappings.Add("IsActive", "IsActive");
                            bulkcopy.ColumnMappings.Add("Branch", "Branch");
                            bulkcopy.ColumnMappings.Add("Position", "Position");
                            bulkcopy.ColumnMappings.Add("CTC per annum", "CTC_PA");
                            conn.Open();
                            bulkcopy.WriteToServer(dt);
                            conn.Close();
                        }
                    }

                    TblUploadFile objFile = new();
                    objFile.FilePath = filepath;
                    objFile.FileName = filename;
                    objFile.FileType = file.ContentType;
                    objFile.FileExtension = extension;
                    objFile.CreatedDate = DateTime.Now;
                    _context.tblUploadFile.Add(objFile);
                    await _context.SaveChangesAsync();

                    
                    isUploaded = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return isUploaded;
        }
    }
}
