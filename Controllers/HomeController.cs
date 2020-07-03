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
        public async Task<JsonResult> Lista2 (int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/photos");
            var photoList = new List<PhotoModel>();
            photoList = JsonConvert.DeserializeObject<List<PhotoModel>>(json);
            var listaFiltrada = photoList.Where(p => p.albumid == id).ToList();
            // listaFiltrada = JsonConvert.SerializeObject(<List<Photos>>,json)

            return Json(listaFiltrada);
        }
        [HttpGet]
        public async Task<JsonResult> CommentsPhoto (int id)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/comments");
            var commentList = new List<CommentModel>();
            commentList = JsonConvert.DeserializeObject<List<CommentModel>>(json);
            var listaFiltrada = commentList.Where(c => c.postId == id).ToList();
            return Json(listaFiltrada);
        }
    }

}