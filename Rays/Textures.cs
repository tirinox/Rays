using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
using System.Drawing;

namespace Rays
{
    public class Texture
    {
        private int glTextureId = -1;
        public string Name = "";

        ~Texture()
        {
            if(glTextureId != -1)
                Gl.glDeleteTextures(1, new int[] { glTextureId });
        }

        public Texture(string Name)
        {
            Bitmap image = new Bitmap(Name);
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            System.Drawing.Imaging.BitmapData bitmapdata;
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int[] texture = new int[1];

            Gl.glGenTextures(1, texture);
            glTextureId = texture[0];
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[0]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height,
                0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri((int)Gl.GL_TEXTURE_2D, (int)Gl.GL_TEXTURE_MIN_FILTER, (int)Gl.GL_LINEAR);	
            Gl.glTexParameteri((int)Gl.GL_TEXTURE_2D, (int)Gl.GL_TEXTURE_MAG_FILTER, (int)Gl.GL_LINEAR);	
           

            image.UnlockBits(bitmapdata);
            image.Dispose();   
        }

        public void Bind()
        {
            if (glTextureId != -1)
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, glTextureId);
        }

        public static void ToggleTexturing(bool On)
        {
            if (On)
            {
                Gl.glEnable(Gl.GL_TEXTURE_2D);
            }
            else
            {
                Gl.glDisable(Gl.GL_TEXTURE_2D);
            }
        }
    }
}
