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
    class PlaneCode
    {
        private Vector2 _planePos;
        private Vector2 _TG;

        private Texture2D _plane;

        private Vector2 _bulletPos;
        private Texture2D _bTexture;

        private double _speed;
        private double _RSP;
        private double _yDis;
        private double _xDis;
        private double _rotation;
        private double _cm;
        private double _rp;
        private float _maxRot = 85f;


        public PlaneCode() {}

        public void Initialize()
        {
            _maxRot = (float)Methods.DegreeToRadian(_maxRot);//Converts the initial value to radians
            _speed = 20;//Max speed = 100 (Same speed as mouse);
            _RSP = _speed * (5 / 3); //Rotation Speed
        }


        public void LoadContent(ContentManager content)
        {
            _plane = content.Load<Texture2D>("Plane1");
            _bTexture = content.Load<Texture2D>("MG_Bullet");
        }


        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine("Shiiiiiiiiiiiiieeeeeeeeeeeeeeeet");
                BulletCode.Draw(
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
            _cm = Methods.DegreeToRadian(_yDis / 100 * _RSP);

            //Sets a rotation limit for the plane, the double variables prevent the plane's rotation from changing when over the limit
            if (_rp < -_maxRot)
            {
                _rp = (float)_cm;
                _rotation = -_maxRot;
            }
            else if (_rp > _maxRot)
            {
                _rp = (float)_cm;
                _rotation = _maxRot;
            }
            else
            {
                _rotation = _rp;
                _rp = _cm;
            }

            //Calculates center of plane (for mouse movement)
            _TG.X = mouseState.X - (_plane.Bounds.Width / 3);
            _TG.Y = mouseState.Y - (_plane.Bounds.Height / 2);

            //Calculates distance between plane and cursor
            _xDis = _TG.X - _planePos.X;
            _yDis = _TG.Y - _planePos.Y;

            //Moves plane according to distance
            _planePos.X += (float)Math.Round(_xDis / 100 * _speed);
            _planePos.Y += (float)Math.Round(_yDis / 100 * _speed);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
               _plane, //texture
               _planePos, //position 
               null, //A rectangle that specifies (in texels) the source texels from a texture. Use null to draw the entire texture.
               new Color(255, 220, 170), //The color to tint a sprite. Use Color.White for full color with no tinting.
               getRotation(), //Specifies the angle (in radians) to rotate the sprite about its center.
               new Vector2(0, 0), //The sprite origin; the default is (0,0) which represents the upper-left corner.
               1, //The scale of the object.
               SpriteEffects.None, //Effects to apply.
               0.5f //The depth of a layer. By default, 0 represents the front layer and 1 represents a back layer. Use SpriteSortMode if you want sprites to be sorted during drawing.
           );
        }

        public float getRotation()
        {
            return (float)this._rotation;
        }
    }
}
