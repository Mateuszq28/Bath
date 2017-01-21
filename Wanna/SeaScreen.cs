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
        Texture2D seaTex;
        Vector2 res;
        float scale;

        public SeaScreen(Vector2 res)
        {
            this.res = res;
            bath = new Bath(res);
        }

        public void LoadContent(ContentManager Content)
        {
            seaTex = Content.Load<Texture2D>("background");
            scale = res.Y / seaTex.Height;
            bath.LoadContent(Content);
        }

        public void Update(GameTime gameTime)
        {
            bath.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(seaTex, Vector2.Zero, null,
                Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.End();


            bath.Draw(spriteBatch);
            //bath update

        }
    }
}
