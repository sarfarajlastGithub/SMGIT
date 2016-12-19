using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ArtWork
    {
        public int ArtWorkId { get; set; }
        public int ImageMimeType { get; set; }
        public byte[] ImageData { get; set; }
        public byte[] ArtworkThumbnail { get; set; }

    }
}
