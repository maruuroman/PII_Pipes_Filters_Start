using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel.Filters
{
    public class FilterGuardar : IFilter
    {
        public string SavePath { get; }
        public PictureProvider Provider { get; }

        public FilterGuardar(string savePath)
        {
            SavePath = savePath;
            Provider = new PictureProvider();
        }

        public IPicture Filter(IPicture image)
        {
            Provider.SavePicture(image, SavePath);
            return image;
        }

    }
}