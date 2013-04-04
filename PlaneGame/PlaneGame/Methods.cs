using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlaneGame
{
    class Methods
    {

        public static int getRandom(int r)
        {   
            int rNumber;
            Random rnd = new Random();
            rNumber = rnd.Next(0, r);
            return rNumber;
        }


        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public Texture2D LoadRandomTexture(List<String> _TextureList, ContentManager content)
        {
            int i = Methods.getRandom(_TextureList.Count);
            Texture2D Tex = content.Load<Texture2D>(_TextureList[i]);
            return Tex;
        }
    }
}
