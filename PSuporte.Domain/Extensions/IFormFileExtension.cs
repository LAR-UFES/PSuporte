using System.IO;
using Microsoft.AspNetCore.Http;

namespace PSuporte.Domain.Extensions
{
    public static class IFormFileExtension
    {
        public static byte[] ToBytes(this IFormFile file)
        {
            byte[] FileBytes = null;
            using (var reader = new BinaryReader(file.OpenReadStream()))
            {
                FileBytes = reader.ReadBytes((int)file.Length);
            }

            return FileBytes;
        }
    }
}