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
    class SeaScreen
    {
        Bath bath;
        List<Father> listOfFathers = new List<Father>();
        Texture2D seaTex;
        Texture2D fatherTex;
        Vector2 res;
        float scale;
        float time;
        Random rand;

        public SeaScreen(Vector2 res)
        {
            this.res = res;
            bath = new Bath(res);
            rand = new Random();
        }

        public void LoadContent(ContentManager Content)
        {
            seaTex = Content.Load<Texture2D>("background");
            fatherTex = Content.Load<Texture2D>("flyingFatherS");
            scale = res.Y / seaTex.Height;
            bath.LoadContent(Content);
        }

        public void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(time > 0.7)
            {
                time = 0;
                listOfFathers.Add(new Father((int)(rand.Next(0,7) * res.X) / 8, res, scale, fatherTex));
            }
            bath.Update(gameTime);
            for (int i = 0; i < listOfFathers.Count(); i++)
            {
                listOfFathers[i].Update(gameTime);
                if (listOfFathers[i].GetX() > res.X)
                    listOfFathers.Remove(listOfFathers[i]);

            }

            if(bath.CheckCollision(listOfFathers))
            {
                listOfFathers.Clear();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(seaTex, Vector2.Zero, null,
                Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.End();
            bath.Draw(spriteBatch);
            foreach (Father f in listOfFathers)
            {
                f.Draw(spriteBatch);
            }

        }
    }
}
