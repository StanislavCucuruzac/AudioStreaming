using AudioStreaming.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UploadSong()
        {
            List<Song> songlist = new List<Song>();
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllAudioFile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Song song = new Song();
                    song.Id = Convert.ToInt32(rdr["ID"]);
                    song.Name = rdr["Name"].ToString();
                    song.FileSize = Convert.ToInt32(rdr["FileSize"]);
                    song.FilePath = rdr["FilePath"].ToString();

                    songlist.Add(song);
                }
            }
            return View(songlist);

        }
        [HttpPost]
        public async Task<ActionResult> UploadSong(List<IFormFile> filesUpload)
        {
            if (filesUpload != null)
            {
                long size = filesUpload.Sum(f => f.Length);
               
                // full path to file in temp location
                var fileName= Path.GetTempFileName();

                foreach (var formFile in filesUpload)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(fileName, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }

                string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spAddNewAudioFile", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Name", fileName);
                    cmd.Parameters.AddWithValue("@FileSize", size);
                    cmd.Parameters.AddWithValue("FilePath", "~/AudioFileUpload/" + fileName);
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction("UploadSong");
        }
    }
}
