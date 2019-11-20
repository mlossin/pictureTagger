using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureTagger.Common.Models
{
    public class Picture
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public string Filename { get; set; }
        public string Fileextension { get; set; }
    }
}
