using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {

            var twitter = new TwitterImage();


            PictureProvider pProvider = new PictureProvider();
            IPicture beer = pProvider.GetPicture("beer.jpg");

            FilterGreyscale fGrayscale = new FilterGreyscale();
            FilterNegative fNegative = new FilterNegative();



            PipeNull pNull = new PipeNull();
            PipeSerial pSerial2 = new PipeSerial(fNegative, pNull);
            PipeSerial pSerial1 = new PipeSerial(fGrayscale, pSerial2);
            pSerial1.Send(beer);
            pProvider.SavePicture(pSerial1.Send(beer), "beerFGrayscale.jpg");
            pSerial2.Send(pSerial1.Send(beer));
            pProvider.SavePicture(pSerial2.Send(beer),"beerfNegative.jpg");

            pProvider.SavePicture(pSerial2.Send(pSerial1.Send(beer)), "beerAllFilters.jpg");

            Console.WriteLine(twitter.PublishToTwitter("test", "beerAllFilters.jpg"));

        


        }
    }
}
