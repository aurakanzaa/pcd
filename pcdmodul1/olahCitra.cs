using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pcdmodul1
{
    public class olahCitra
    {
        public static bool keBrightness(Bitmap b)
        {
            for (int i = 0;i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {

                    Color c1 = b.GetPixel(i, j);
                    int r1 = c1.R + 255;
                    int g1 = c1.G + 255;
                    int b1 = c1.B + 255;
                    b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                }
            }
            return true;
        }
    }
}