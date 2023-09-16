namespace SLN7.UI.Interface
{
    public interface IUploadFile
    {
        Task<bool> UploadFileAsync(IFormFile file);
    }
}
