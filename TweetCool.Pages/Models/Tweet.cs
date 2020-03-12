using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TweetCool.Pages.Models
{
    public class Tweet
    {
        public string Poster { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }        
        public override string ToString() => JsonSerializer.Serialize<Tweet>(this);
        
    }
}
