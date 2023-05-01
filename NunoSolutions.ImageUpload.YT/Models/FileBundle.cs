namespace NunoSolutions.ImageUpload.YT.Models
{
    public class FileBundle
    {
        #region constructor
        public FileBundle(HttpRequest request)
        {
            this.request = request;
        }
        private HttpRequest request { get; set; }
        #endregion
        public int ReturnCode { get; set; }
        public string? ReturnMessage { get; set; }
        public string? FileName
        {
            get
            {
                var customFileName = request.Form["customFileName"];
                if (!string.IsNullOrEmpty(customFileName))
                {
                    return customFileName;
                }
                else
                {
                    return PostedFile.FileName;
                }
            }
        }

        private IFormFile? PostedFile
        {
            get
            {
                if (request.Form.Files.Count > 0)
                {
                    return request.Form.Files[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public void SaveAs(string filePath)
        {
            if (PostedFile == null) return;
            var fileStream = File.Create(filePath);
            PostedFile.OpenReadStream().CopyTo(fileStream);
            fileStream.Close();
        }
    }
}
