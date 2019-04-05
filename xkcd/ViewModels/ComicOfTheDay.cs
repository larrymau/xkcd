using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xkcd.ViewModels
{
    public class ComicOfTheDay
    {
            public string month { get; set; }
            public int num { get; set; }
            public string link { get; set; }
            public string year { get; set; }
            public string news { get; set; }
            public string safe_title { get; set; }
            public string transcript { get; set; }
            public string alt { get; set; }
            public string img { get; set; }
            public string title { get; set; }
            public string day { get; set; }
            public int? prev { get; set; }
            public int? next { get; set; }



    }

    //{
    //"month": "1",
    //"num": 3,
    //"link": "",
    //"year": "2006",
    //"news": "",
    //"safe_title": "Island (sketch)",
    //"transcript": "[[A sketch of an Island]]\n{{Alt:Hello, island}}",
    //"alt": "Hello, island",
    //"img": "https://imgs.xkcd.com/comics/island_color.jpg",
    //"title": "Island (sketch)",
    //"day": "1"
    //}
}