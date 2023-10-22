using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

             //Creo los filtros
            IFilter filter1 = new FilterGreyscale(); // Primer filtro: Escala de grises
            IFilter filter2 = new FilterNegative();   // Segundo filtro: Negativo

            //Uso IPipe
            IPipe pipe1 = new PipeSerial(filter1, new PipeNull()); // Pipe para el primer filtro
            IPipe pipe2 = new PipeSerial(filter2, new PipeNull()); // Pipe para el segundo filtro

            //Uno los IPipe con las imagenes 
            pipe1.Send(picture); // Aplicar el primer filtro
            IPicture image = pipe2.Send(picture); // Aplicar el segundo filtro

            //Guardo la imagen con los filtros aplicados 
            provider.SavePicture(image, @"beer.jpg");
           
            Console.WriteLine("Proceso completado."); //chequo que este realizando el codigo
        }
    }
}