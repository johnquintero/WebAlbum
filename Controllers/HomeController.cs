using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAlbum.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace WebAlbum.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/albums");
            var albumList = new List<AlbumModel>();
            albumList = JsonConvert.DeserializeObject<List<AlbumModel>>(json);


            ViewBag.Datos = albumList;
            return View(albumList);
        }
        [HttpGet]
        public async Task<IActionResult> Lista2 (int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/photos");
            var photoList = new List<PhotoModel>();
            photoList = JsonConvert.DeserializeObject<List<PhotoModel>>(json);

            ViewBag.Photos = photoList.Where(p => p.albumid == id).ToList();

            return View();
        }
    }
//https://jsonplaceholder.typicode.com/comments
}