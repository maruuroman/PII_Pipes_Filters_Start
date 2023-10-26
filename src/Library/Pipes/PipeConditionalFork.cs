using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using System.Diagnostics;
using System.Drawing;
using CompAndDel.Filters;
using Ucu.Poo.Cognitive; 

namespace CompAndDel.Pipes
{
    public class PipeConditionalFork : IPipe
    {
        private IFilter filterIfFaceFound;
        private IFilter filterIfNoFaceFound;

        public PipeConditionalFork(IFilter filterIfFaceFound, IFilter filterIfNoFaceFound)
        {
            this.filterIfFaceFound = filterIfFaceFound;
            this.filterIfNoFaceFound = filterIfNoFaceFound;
        }

        public IPicture Send(IPicture image)
        {
            FilterConditional filterConditional = new FilterConditional();
            IPicture filteredImage = filterConditional.Filter(image); // Aplicamos el filtro

            // Verificamos si se encontró una cara en la imagen
            bool faceFound = filterConditional.FaceFound;

            if (faceFound)
            {
                return filterIfFaceFound.Filter(filteredImage);
            }
            else
            {
                return filterIfNoFaceFound.Filter(filteredImage);
            }
        }
    }
}