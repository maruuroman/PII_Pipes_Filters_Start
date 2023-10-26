using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;

namespace CompAndDel.Filters
{
    public class FilterTwitter : TwitterImage, IFilter
    {
        public IPicture Filter (IPicture picture)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("luke el capo", "lukeEditado2.jpg"));
            return picture;
        }
        public string UploadImageToTwitter(string text, string imagePath)
        {
            var twitter = new TwitterImage();
            return twitter.PublishToTwitter("luke el capo", "lukeEditado2.jpg");

        }
    }
}