using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.SERVICE.IService
{
    public interface IUploadFile
    {
        //Task<bool> UploadImage(IFormFile file, string uploadPath);
        Task<bool> UploadImage(IFormFile file);
        Task<bool> UploadExcelInsertBulkRecords(IFormFile file);
    }
}
