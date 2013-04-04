using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PlaneGame
{
    class Background
    {
        private Vector2 _FG1pos;
        private Vector2 _FG2pos;
        private Texture2D _BG;
        private Texture2D _FG1;

        private float _FG2scale;
        private float _FGspeedCalc;
        private float _FG1point = 0;
        private int _FGspeed;
        private List<String> _ForegroundTextureList = new List<String>();
        private List<String> _BackgroundTextureList = new List<String>();

        public Background()
        {
        }

        public void Initialize () 
        {
            _ForegroundTextureList.Add("Foreground");
            _ForegroundTextureList.Add("Foreground2");

            _BackgroundTextureList.Add("Background");
            _BackgroundTextureList.Add("Background");

            _FG2scale = 0.70f;
            _FGspeed = 10;
            _FG1point = -1000;
            _FGspeedCalc = (_FG1point / (100f / (_FGspeed / 10)));
            //* (1000 / -_FG1point);
            _FG1pos = new Vector2(100, 270);
            _FG2pos = new Vector2(0, 300 - 18);

        }

        
        public void LoadContent(ContentManager content)
        {
            
            int r = Methods.getRandom(_ForegroundTextureList.Count);
            _BG = content.Load<Texture2D>(_BackgroundTextureList[r]);
            _FG1 = content.Load<Texture2D>(_ForegroundTextureList[r]);
        }
        

        public void Update(GameTime gameTime)
        {
            //FG1
            if (_FG1pos.X < (_FG1point - (_FGspeedCalc * 2)) - 50)//Moving foreground
            {
                _FG1pos.X = -50;
            }
            else
            {
                _FG1pos.X += _FGspeedCalc;
            }

            //_FG2
            if (_FG2pos.X < (_FG1point * _FG2scale - (_FGspeedCalc * 2) * _FG2scale))//Moving foreground
            {
                _FG2pos.X = -_FGspeedCalc * _FG2scale;
            }
            else
            {
                _FG2pos.X += _FGspeedCalc * _FG2scale;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            //Draws background
            spriteBatch.Draw(_BG, new Vector2(0, 0), Color.White);

            //Draws the back foreground (behind the plane)
            spriteBatch.Draw(
                _FG1, //texture
                _FG2pos, //position 
                null, //A rectangle that specifies (in texels) the source texels from a texture. Use null to draw the entire texture.
                new Color(220 + 20, 187 + 20, 4 + 10), //The color to tint a sprite. Use Color.White for full color with no tinting.
                0,
                new Vector2(0, 0), //The sprite origin; the default is (0,0) which represents the upper-left corner.
                _FG2scale, //The scale of the object.
                SpriteEffects.None, //Effects to apply.
                0.25f //The depth of a layer. By default, 0 represents the front layer and 1 represents a back layer. Use SpriteSortMode if you want sprites to be sorted during drawing.
            );

            //Draws the main foreground (in front of the plane)
            spriteBatch.Draw(
                _FG1,               //texture
                _FG1pos,          //position 
                null,               //A rectangle that specifies (in texels) the source texels from a texture. Use null to draw the entire texture.
                Color.White,        //The color to tint a sprite. Use Color.White for full color with no tinting.
                0,                  
                new Vector2(0, 0),  //The sprite origin; the default is (0,0) which represents the upper-left corner.
                1,                  //The scale of the object.
                SpriteEffects.None, //Effects to apply.
                1f                  //The depth of a layer. By default, 0 represents the front layer and 1 represents a back layer. Use SpriteSortMode if you want sprites to be sorted during drawing.
            );
        }

    }
}
