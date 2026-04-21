using Amazon.S3;
using Amazon.S3.Model;
using Arkitektur.Business.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Arkitektur.Business.Services.FileServices
{
    public class FileService(IAmazonS3 _s3Client,IConfiguration _configuration) : IFileService
    {

        private readonly string _bucketName = _configuration["AWS:BucketName"];

        public async Task<BaseResult<object>> UploadImageToS3Async(IFormFile? file)
        {
        
            if(file is null || file.Length == 0)
            {

                return BaseResult<object>.Fail("File is required");

            }


            await _s3Client.EnsureBucketExistsAsync(_bucketName); //bucket varlýðýndan emin ol

            var key = $"{Guid.NewGuid()}-{file.FileName}";//dosya isimi

            var request = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = key,
                InputStream = file.OpenReadStream(),
                CannedACL = S3CannedACL.PublicRead,//herkes resim dosyauýný gorsun demek


            };

            request.Metadata.Add("Content-Type",file.ContentType);

            var response = await _s3Client.PutObjectAsync(request);

            string fileUrl = $"https://{_bucketName}.s3.{_s3Client.Config.RegionEndpoint.SystemName}.amazonaws.com/{key}";

            return BaseResult<object>.Success(new {ImageUrl=fileUrl});




        }



    }
}
