﻿using Microsoft.AspNetCore.Mvc;
using System;
using WilderMinds.RssSyndication;

namespace RssGenerator.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RssController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Blog()
        {
            var feed = new Feed()
            {
                Title = "Shawn Wildermuth's Blog",
                Description = "My Favorite Rants and Raves",
                Link = new Uri("http://wildermuth.com/feed"),
                Copyright = "(c) 2016"
            };

            var item1 = new Item()
            {
                Title = "Foo Bar",
                Body = "<p>Foo bar</p>",
                Link = new Uri("http://foobar.com/item#1"),
                Permalink = "http://foobar.com/item#1",
                PublishDate = DateTime.UtcNow,
                Author = new Author() { Name = "Shawn Wildermuth", Email = "shawn@foo.com" }
            };

            item1.Categories.Add("aspnet");
            item1.Categories.Add("foobar");

            item1.Comments = new Uri("http://foobar.com/item1#comments");

            feed.Items.Add(item1);

            var item2 = new Item()
            {
                Title = "Quux",
                Body = "<p>Quux</p>",
                Link = new Uri("http://quux.com/item#1"),
                Permalink = "http://quux.com/item#1",
                PublishDate = DateTime.UtcNow,
                Author = new Author() { Name = "Shawn Wildermuth", Email = "shawn@foo.com" }
            };

            item1.Categories.Add("aspnet");
            item1.Categories.Add("quux");

            feed.Items.Add(item2);

            var rss = feed.Serialize();
            return Content(rss,"text/xml");
        }
    }
}