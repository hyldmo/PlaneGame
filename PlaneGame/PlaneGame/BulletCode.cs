using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace PlaneGame
{
    class BulletCode
    {
        private Vector2 _bulletPos;
        private Texture2D _bTexture;

        private int _bulletCooldown;

        public BulletCode() { }

        public void LoadContent(ContentManager content)
        {
            _bTexture = content.Load<Texture2D>("MG_Bullet");
        }

        public void Draw (SpriteBatch spriteBatch) {
            spriteBatch.Draw(
               _bTexture, //texture
               _bulletPos, //position 
               null, //A rectangle that specifies (in texels) the source texels from a texture. Use null to draw the entire texture.
               new Color(255, 220, 170), //The color to tint a sprite. Use Color.White for full color with no tinting.
               /*PlaneCode.getRotation()*/1, //Specifies the angle (in radians) to rotate the sprite about its center.
               new Vector2(0, 0), //The sprite origin; the default is (0,0) which represents the upper-left corner.
               1, //The scale of the object.
               SpriteEffects.None, //Effects to apply.
               0.5f //The depth of a layer. By default, 0 represents the front layer and 1 represents a back layer. Use SpriteSortMode if you want sprites to be sorted during drawing.
           );
        }
    }
}
