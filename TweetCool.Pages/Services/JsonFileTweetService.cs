using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TweetCool.Pages.Models;

namespace TweetCool.Pages.Services
{
    public class JsonFileTweetService
    {
        public JsonFileTweetService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "tweets.json"); }
        }
                
        public IEnumerable<Tweet> GetTweets()
        {
            try
            {
                using (var jsonFileReader = File.OpenText(JsonFileName))
                {
                    return JsonSerializer.Deserialize<Tweet[]>(jsonFileReader.ReadToEnd(),
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                }
            }
            catch { return new List<Tweet>(); }
        }
        public void AddTweet(string poster, string content)
        {
            List<Tweet> tweets = GetTweets().ToList();
            Tweet tweet = new Tweet();
            tweet.Poster = poster;
            tweet.Content = content;
            tweet.DateTime = DateTime.Now;
            
            tweets.Add(tweet);
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Tweet>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),tweets);
            }
        }
    }
}
