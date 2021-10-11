using AudioStreaming.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioStreaming.Dal.Seed
{
    public class ImageSeed
    {

        //public static async Task Seed(AudioStreamingDbContext context)
        //{
        //    if (!context.Images.Any())
        //    {
        //        var myImage = new Image();
                
        //        FileStream file = new FileStream("C:\\Users\\Stas\\Pictures\\image.jpg", FileMode.Open);
        //        byte[] fileData = new byte[file.Length];
        //        file.Read(fileData, 0, (int)file.Length);

        //        var image  = new Image();
        //        image.ImageName = "name";
        //        image.Data = fileData;
        //        SqlCommand cmd = new SqlCommand("insert into Images values(@Id, @ImageName, @Data)");
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@Id", image.Id);
        //        cmd.Parameters.AddWithValue("@ImageName", image.ImageName);
        //        cmd.Parameters.AddWithValue("@Data", image.Data);
        //        cmd.ExecuteNonQuery();
        //        context.Images.Add(image);
        //        await context.SaveChangesAsync();
        //    }
        //}
        //private async Task<byte[]> ConvertImageToByte(StorageFile file)
        //{
        //    using (var inputStream = await file.OpenSequentialReadAsync())
        //    {
        //        var readStream = inputStream.AsStreamForRead();

        //        var byteArray = new byte[readStream.Length];
        //        await readStream.ReadAsync(byteArray, 0, byteArray.Length);
        //        return byteArray;
        //    }

        //}

    }

}
