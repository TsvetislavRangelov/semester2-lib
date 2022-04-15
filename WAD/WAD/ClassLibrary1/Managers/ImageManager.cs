using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Managers
{
   public class ImageManager
    {
        public virtual string ConvertImage(byte[] img)
        {
            if (img == null)
            {
                return null;
            }
            else
            {
                var base64 = Convert.ToBase64String(img);
                var mangaImg = String.Format("data:image/.*;base64,{0}", base64);
                return mangaImg;
            }
        }
    }
}
