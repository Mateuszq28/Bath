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
    class SeaScreen : Screen
    {
        Bath bath;
        List<Father> listOfFathers = new List<Father>();
        Texture2D seaTex;
        Texture2D fatherTex;
        Texture2D fatherTex2;
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

        public override void LoadContent(ContentManager Content)
        {
            seaTex = Content.Load<Texture2D>("background");
            fatherTex = Content.Load<Texture2D>("flyingFatherS");
            fatherTex2 = Content.Load<Texture2D>("flyingFather2S");
            scale = res.Y / seaTex.Height;
            bath.LoadContent(Content);
        }

        public override void Update(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(time > 0.7)
            {
                time = 0;
                listOfFathers.Add(new Father((int)(rand.Next(0,7) * res.X) / 8, res, scale, fatherTex, fatherTex2));
            }
            bath.Update(gameTime);
            for (int i = 0; i < listOfFathers.Count(); i++)
            {
                listOfFathers[i].Update(gameTime);
                if (listOfFathers[i].GetX() > res.X)
                    listOfFathers.Remove(listOfFathers[i]);

            }
        }

        public override void Draw(SpriteBatch spriteBatch)
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

        public override bool GetCollisionState()
        {
            return bath.CheckCollision(listOfFathers);
        }

        public override void Reset()
        {
            listOfFathers.Clear();
            time = 0;
            bath.Reset();

        }
    }
}
