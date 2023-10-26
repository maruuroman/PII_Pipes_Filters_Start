using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;
using Ucu.Poo.Cognitive;
using System.Drawing;
using SixLabors.ImageSharp;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Color = System.Drawing.Color;


namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //EJERCICIO 1 
            /*
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            //Creo los filtros
            IFilter filter1 = new FilterGreyscale(); // Primer filtro: Escala de grises
            IFilter filter2 = new FilterNegative();   // Segundo filtro: Negativo

            //Creo las IPipe
            IPipe pipe2 = new PipeSerial(filter2, new PipeNull()); // Pipe para el segundo filtro
            IPipe pipe1 = new PipeSerial(filter1, pipe2); // Pipe para el primer filtro

            //Uno los IPipe con las imagenes 
            //IPicture image1 =pipe2.Send(picture); // Aplicar el primer filtro
            IPicture image2 = pipe1.Send(picture); // Aplicar el segundo filtro

            //Guardo la imagen con los filtros aplicados 
            //provider.SavePicture(image1, @"lukeEditado.jpg");
            provider.SavePicture(image2, @"lukeEditado2.jpg");
           
            Console.WriteLine("Proceso completado."); //chequo que este realizando el codigo
            */
            
            
        //--------------------------------------------------------------------------------------------------------------------------
            //EJERCICIO 2
            
            /*
            //opcion usando la clase FilterPersistent
            
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            provider.SavePicture(picture, "ImagenOriginal.jpg"); //guardo la imagen original como parte del proceso 
        
            // Crear y aplicar el filtro blanco y negro
            IFilter filter1 = new FilterGreyscale();
            IPicture grayscalePicture = filter1.Filter(picture);

            // Usar FilterGuardar para guardar la imagen en blanco y negro
            IFilter filterGuardar1 = new FilterGuardar("PathToGreyscaleImage.jpg");
            IPicture intermediatePicture = filterGuardar1.Filter(grayscalePicture);

            // Aplicar el filtro negativo
            IFilter filter2 = new FilterNegative();
            IPicture negativePicture = filter2.Filter(intermediatePicture);

            // Usar FilterGuardar para guardar la imagen negativa
            IFilter filterGuardar2 = new FilterGuardar("PathToNegativeImage.jpg");
            IPicture finalPicture = filterGuardar2.Filter(negativePicture);

            // Guardar la imagen final
            provider.SavePicture(finalPicture, "PathToFinalImage.jpg");
            
            */

        //-------------------------------------------------------------------------------------------------------------------------
            //EJERCICIO 3
            /*
    
            var filterTwitter = new FilterTwitter();
            string text = "Luke el capo";
            string pathToImage = @"lukeEditado2.jpg";

            Console.WriteLine(filterTwitter.UploadImageToTwitter(text, pathToImage));

            Console.WriteLine("Proceso completado.");

            */

        //-------------------------------------------------------------------------------------------------------------------------
            //EJERCICIO 4
           
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            cog.Recognize(@"luke.jpg");
            FoundFace(cog);
            cog.Recognize(@"beer.jpg");
            FoundFace(cog);
            cog.Recognize(@"Dwayne.jpg");
            FoundFace(cog);

            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            FilterConditional filterConditional= new FilterConditional();
            FilterTwitter filterTwitter = new FilterTwitter();

            IFilter filter = new FilterNegative();   // filtro: Negativo
            IPipe pipe= new PipeSerial(filter, new PipeNull());

            
            static void FoundFace(CognitiveFace cog)
            {
                if (cog.FaceFound)
                {
                    Console.WriteLine("Face Found!");
                    if (cog.GlassesFound)
                    {
                        Console.WriteLine("Has glasses 🤓");
                    }
                    else
                    {
                        Console.WriteLine("No glasses");
                    }
                }
                else
                {
                    Console.WriteLine("No Face Found");
                    IFilter filter = new FilterNegative();   // filtro: Negativo
                    IPipe pipe= new PipeSerial(filter, new PipeNull());
                    
                }    
            }
        }
    }
}