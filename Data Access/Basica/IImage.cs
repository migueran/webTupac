using System.Collections.Generic;
using System;
using System.IO;
using System.Web;


namespace Basica
{
    public interface IImage
    {
        int Id { get; set; }
        HttpPostedFile FU { get; set; }
        string Directory { get; set; }
        string Prefix { get; set; }
        void SaveImage();
        void DeleteImage();
        void ChangePrefix();
        void InitPrefix();
        string Path { get; }
        string URL { get; }
   
    }
}