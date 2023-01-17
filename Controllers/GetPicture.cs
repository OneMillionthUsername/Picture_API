using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;

namespace mvc_API.Controllers
{
    public class GetPicture : Controller
    {
        private readonly string path = @"c:\pictures";

        public IActionResult Info()
        {
            return View();
        }
        public IActionResult GetPic(string apiKey, string name, string file)
        {
            if (apiKey == "getPictures")
            {
                name = name + "." + file;
                if (System.IO.File.Exists(Path.Combine(path, name)))
                {
                    Byte[] b = System.IO.File.ReadAllBytes(Path.Combine(path, name));
                    return File(b, "image/jpg");
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            return View();
        }
        public IActionResult GetFiles(string apiKey, string req)
        {
            if (apiKey == "getPictures" && req == "get")
            {
                var files = System.IO.Directory.EnumerateFiles(path).ToList();
                return Json(files);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
