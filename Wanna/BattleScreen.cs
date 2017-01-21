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
    class BattleScreen : Screen
    {
        Texture2D seaTex;
        Texture2D waterTex;
        Texture2D[] baths = new Texture2D[4];
        Texture2D bathFront;
        Texture2D cursorTex;
        Texture2D barTex;
        float scale;
        Vector2 res;
        Vector2 delta;
        Vector2 bathPos;
        Vector2 cursorPos;
        float cursorWidth;
        int bathWidth, bathHeight;
        int max;
        int waveSpeed;
        int waveSpeedY;
        int animFrame;
        float frameTime;
        int cursorSpeed;
        bool fatherDefeated = false;
        bool raped = false;
        KeyboardState keyboardState;
        KeyboardState prevState;


        public BattleScreen(Vector2 res)
        {
            scale = res.X / 1920;
            this.res = res;
            waveSpeed = (int)res.X / 30;
            max = (int)res.X / 20;
            bathWidth = 2 * (int)res.X / 3;
            bathHeight = 537 * bathWidth / 1280;
            bathPos.X = (res.X - bathWidth) / 2;
            bathPos.Y = 2 * res.Y / 3 - bathHeight / 2;
            animFrame = 0;
            cursorWidth = 65.0f * scale;
            cursorPos.X = (res.X - cursorWidth) / 2;
            cursorPos.Y = 0;
            cursorSpeed = (int)res.X / 10; ;
        }

        public override void LoadContent(ContentManager Content)
        {
            seaTex = Content.Load<Texture2D>("background");
            waterTex = Content.Load<Texture2D>("water");
            baths[0] = Content.Load<Texture2D>("battlefight1H");
            baths[1] = Content.Load<Texture2D>("battlefight2H");
            baths[2] = Content.Load<Texture2D>("battlefight3H");
            baths[3] = Content.Load<Texture2D>("battlefight4H");
            bathFront = Content.Load<Texture2D>("Bathtube2en");
            barTex = Content.Load<Texture2D>("Battlebar");
            cursorTex = Content.Load<Texture2D>("battlecursor");

            
        }

        public override void Update(GameTime gameTime)
        {
            frameTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (frameTime > 0.15f)
            {
                frameTime = 0;
                animFrame++;
                if (animFrame == 4)
                    animFrame = 0;
            }

            delta.X += waveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if ((delta.X > max && waveSpeed > 0) || (delta.X < -max && waveSpeed < 0))
                waveSpeed = waveSpeed * -1;

            waveSpeedY = (int)(waveSpeed * (delta.X / max));
            if(waveSpeed > 0)
                delta.Y += waveSpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else
                delta.Y -= waveSpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds;

            cursorPos.X += cursorSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            prevState = keyboardState;
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Space) && !prevState.IsKeyDown(Keys.Space))
                cursorPos.X -= 40 * scale ;

            if(cursorPos.X > (res.X/2 + (barTex.Width * scale) / 2  - cursorWidth))
            {
                cursorPos.X = (res.X / 2 + (barTex.Width * scale) / 2) - cursorWidth;
                cursorSpeed = 0;
                raped = true;
            }
            else if(cursorPos.X < (res.X / 2 - (barTex.Width * scale) / 2))
            {
                cursorPos.X = (res.X / 2 - (barTex.Width * scale) / 2);
                cursorSpeed = 0;
                fatherDefeated = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(seaTex, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(baths[animFrame], new Vector2(bathPos.X ,bathPos.Y + delta.Y), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(bathFront, new Vector2(bathPos.X, bathPos.Y + delta.Y), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(waterTex, new Vector2(-res.X / 2  + delta.X, 3 * res.Y / 4 + delta.Y), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(waterTex, new Vector2(res.X / 2 + delta.X, 3 * res.Y / 4 + delta.Y), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(barTex, new Vector2(res.X/2 - (barTex.Width * scale) / 2, 0 ), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(cursorTex, cursorPos , null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            spriteBatch.End();
        }

        public override bool GetCollisionState()
        {
            throw new NotImplementedException();
        }
    }
}
