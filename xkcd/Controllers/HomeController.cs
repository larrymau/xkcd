using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using xkcd.ViewModels;

namespace xkcd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string url = "https://xkcd.com/info.0.json";
            //string url = "https://xkcd.com/404/info.0.json";
            using (HttpClient client = new HttpClient())
            {
                //https://xkcd.com/404/info.0.json
                //https://xkcd.com/info.0.json
                //var xkcdJsonData = client.DownloadString("https://xkcd.com/info.0.json");
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var xkcdJsonData = response.Content.ReadAsStringAsync().Result;
                    ComicOfTheDay data = JsonConvert.DeserializeObject<ComicOfTheDay>(xkcdJsonData);
                    data.prev = data.num - 1;
                    data.next = data.num + 1;
                    return View(data);
                }
                else
                {
                    return View();
                }

            }
            
        }

        public ActionResult SpecifiComic(int comicId)
        {
            //string url = "https://xkcd.com/info.0.json";
            string url = "https://xkcd.com/"+comicId+"/info.0.json";
            using (HttpClient client = new HttpClient())
            {
                //https://xkcd.com/404/info.0.json
                //https://xkcd.com/info.0.json
                //var xkcdJsonData = client.DownloadString("https://xkcd.com/info.0.json");
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var xkcdJsonData = response.Content.ReadAsStringAsync().Result;
                    ComicOfTheDay data = JsonConvert.DeserializeObject<ComicOfTheDay>(xkcdJsonData);
                    data.prev = data.num - 1;
                    data.next = data.num + 1;


                    if (!client.GetAsync("https://xkcd.com/" + data.prev + "/info.0.json").Result.IsSuccessStatusCode)
                    {
                        data.prev--;
                    }

                    if (!client.GetAsync("https://xkcd.com/" + data.next + "/info.0.json").Result.IsSuccessStatusCode)
                    {
                        data.next++;
                    }
                    


                    return View(data);
                }
                else
                {
                    return Index();
                }

            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}