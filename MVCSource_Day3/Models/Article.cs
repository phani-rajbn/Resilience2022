using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcApp.Models
{
    public class Article
    {
        static int no = 0;
        public Article()
        {
            no++;
        }
        public int Id { get; private set; } = no;
        public string Title { get; set; }
        public string Content { get; set; }
        public string Reporter { get; set; }
        public DateTime Date { get; set; } = DateTime.Now; 
    }
}