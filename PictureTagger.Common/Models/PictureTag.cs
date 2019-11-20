using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureTagger.Common.Models
{
    public class PictureTag : Picture
    {
        public List<SearchTag> Tags { get; set; }

        public PictureTag()
        {
            Tags = new List<SearchTag>();
        }
    }
}
