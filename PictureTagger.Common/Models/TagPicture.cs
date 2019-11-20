using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureTagger.Common.Models
{
    public class TagPicture : SearchTag
    {

        public List<Picture> Pictures { get; set; }

        public TagPicture()
        {
            Pictures = new List<Picture>();
        }
    }
}
