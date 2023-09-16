using Newtonsoft.Json;
using Serilog;
using SLN7.DATA.DBContext;
using SLN7.UI.Helpers;
using SLN7.UI.Interface;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SLN7.UI.Service
{
    public class UploadFile : IUploadFile
    {
        private readonly ApplicationContext _context;
        private readonly HelpersApi aPIHelper;
         
        public UploadFile(ApplicationContext context) 
        { 
            _context = context;
            this.aPIHelper = new HelpersApi();
        }
        public async Task<bool> UploadFileAsync(IFormFile file)
        {
            try
            {
                var filePath = Path.GetTempFileName();
                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                bool getStatus = false;
                var client = aPIHelper.Initial();
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var request = new HttpRequestMessage(HttpMethod.Post, "/api/UploadFile/upload-image");
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(File.OpenRead(filePath)), "file", file.FileName);
                request.Content = content;
                var response = await client.SendAsync(request);
                var result1 = response.Content.ReadAsStringAsync().Result;
                var respcontent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    getStatus = JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
                return getStatus;
            }
            catch (Exception ex)
            {
                Log.Information(ex.Message);
                throw;
            }
        }
    }
}
