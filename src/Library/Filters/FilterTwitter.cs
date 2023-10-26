using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;

namespace CompAndDel.Filters
{
    public class FilterTwitter : TwitterImage
    {
        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            string result = twitter.PublishToTwitter("Luke el capo", @"lukeEditado2.jpg");
            Console.WriteLine(result);
            return image;

            
        }
    }
}