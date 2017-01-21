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
        float scale;
        Vector2 res;


        public BattleScreen(Vector2 res)
        {
            this.res = res;
        }

        public override void LoadContent(ContentManager Content)
        {
            seaTex = Content.Load<Texture2D>("background");
            waterTex = Content.Load<Texture2D>("water");
            scale = res.X / seaTex.Width;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(seaTex, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(waterTex, new Vector2(-res.X / 2, 3 * res.Y / 4), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(waterTex, new Vector2(res.X / 2, 3 * res.Y / 4), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        public override bool GetCollisionState()
        {
            throw new NotImplementedException();
        }
    }
}
