using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Bath
{
    class Father
    {
        Texture2D fatherTex;
        Vector2 position;
        int width, height;
        int speed;
        Rectangle collisionBox;
        float scale;
        Random rand;


        public Father(int positionX, Vector2 res, float scale, Texture2D fatherTex)
        {
            this.scale = scale;
            position.X = positionX;
            width = (int)res.X / 8;
            height = width * fatherTex.Height / fatherTex.Width;
            position.Y = -height;
            this.fatherTex = fatherTex;
            speed = (int)res.Y / 2;
        }

       

        public void Update(GameTime gameTime)
        {
            collisionBox.X = (int)position.X + width / 4;
            collisionBox.Width = width/2;
            collisionBox.Y = (int)position.Y + height / 6;
            collisionBox.Height = 2 * height * 3;

            position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(fatherTex, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        public int GetX()
        {
            return (int)position.X;
        }
    }
}
