using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //ejercicio 1 :)
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            //Creo los filtros
            IFilter filter1 = new FilterGreyscale(); // Primer filtro: Escala de grises
            IFilter filter2 = new FilterNegative();   // Segundo filtro: Negativo

            //Creo las IPipe
            IPipe pipe2 = new PipeSerial(filter2, new PipeNull()); // Pipe para el segundo filtro
            IPipe pipe1 = new PipeSerial(filter1, pipe2); // Pipe para el primer filtro

            //Uno los IPipe con las imagenes 
            //IPicture image1 =pipe1.Send(picture); // Aplicar el primer filtro
            IPicture image2 = pipe1.Send(picture); // Aplicar el segundo filtro

            //Guardo la imagen con los filtros aplicados 
            //provider.SavePicture(image1, @"lukeEditado.jpg");
            provider.SavePicture(image2, @"lukeEditado2.jpg");
           
            Console.WriteLine("Proceso completado."); //chequo que este realizando el codigo
            
            /*
            //ejercicio 2 :)
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            //Creo los filtros
            IFilter filter1 = new FilterGreyscale(); // Primer filtro: Escala de grises
            IFilter filter2 = new FilterNegative();   // Segundo filtro: Negativo

            //Creo las IPipe
            IPipe pipe2 = new PipeSerial(filter2, new PipeNull()); // Pipe para el segundo filtro
            IPipe pipe1 = new PipeSerial(filter1, pipe2); // Pipe para el primer filtro

            // Conectar las pipes en secuencia
            IPipe resultPipe = pipe1; // Inicialmente, el resultado se almacena en resultPipe

            // Aplicar el primer filtro y guardar el resultado
            IPicture result1 = resultPipe.Send(picture);
            provider.SavePicture(result1, @"lukeEj2_1.jpg");

            // Luego, aplicar el segundo filtro y guardar el resultado
            resultPipe = pipe2; // Cambiamos el resultado al segundo filtro
            IPicture result2 = resultPipe.Send(result1);
            provider.SavePicture(result2, @"lukeEj2_2.jpg");

            Console.WriteLine("Proceso completado");
            */
        }
    }
}