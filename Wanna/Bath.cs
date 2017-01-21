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
    class Bath
    {
        Vector2 res;
        Vector2 position;
        Vector2 positionDraw;
        int width, height;
        int speed;
        float angle;
        Texture2D bathTex1, bathTex2;
        float scale;
        KeyboardState keyboardState;
        float a, b, c;

        public Bath(Vector2 res)
        {
            this.res = res;
            position.X = res.X / 2;
            speed = (int)(res.X / 4);
            a = -res.Y/(res.X*res.X);
            b = res.Y / res.X;
            c = res.Y/2;
            
        }

        public void LoadContent(ContentManager Content)
        {
            bathTex1 = Content.Load<Texture2D>("wannaznow2");
            bathTex2 = Content.Load<Texture2D>("wannaznow");
            scale = (res.X / 5) / bathTex1.Width;
            width = (int)(bathTex1.Width * scale);
            height = (int)(bathTex1.Height * scale);

        }

        public void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            // chodzenie lewo-prawo
            if (keyboardState.IsKeyDown(Keys.Right))
                position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (keyboardState.IsKeyDown(Keys.Left))
                position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.Y = a * position.X * position.X + b * position.X + c;
            //position.Y = 100;
            positionDraw.X = position.X - width/2;
            positionDraw.Y = position.Y - height/2;

            angle = (float)Math.Atan( 2*a*position.X + b );


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(bathTex1, position, null, Color.White, angle, new Vector2(width, height), scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(bathTex2, position, null, Color.White, angle, new Vector2(width , height ), scale, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}

