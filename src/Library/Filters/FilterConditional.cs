using System;
using CompAndDel;
using CompAndDel.Filters;
using CompAndDel.Pipes;
using System.Drawing;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    public class FilterConditional: IFilter
    {
        public bool FaceFound {get; private set; }
          
        public IPicture Filter(IPicture image)
        {
            CognitiveFace cog = new CognitiveFace();
            cog.Recognize(@"lukeEditado2.jpg"); 
            FaceFound = cog.FaceFound;
            return image;
        }
        
    }
}   