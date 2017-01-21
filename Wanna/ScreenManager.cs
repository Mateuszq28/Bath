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
    class ScreenManager
    {
        Vector2 resolution;
        SeaScreen seaScreen;

        public ScreenManager(GraphicsDeviceManager graphics)
        {
            //resolution.X = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //resolution.Y = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            resolution.Y = 480;
            resolution.X = 853;
            graphics.PreferredBackBufferHeight = (int)resolution.Y;
            graphics.PreferredBackBufferWidth = (int)resolution.X;
            graphics.IsFullScreen = false;


            seaScreen = new SeaScreen(resolution);
        }

        public void LoadContent(ContentManager Content)
        {
            seaScreen.LoadContent(Content);
        }

        public void Update(GameTime gameTime)
        {
            seaScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            seaScreen.Draw(spriteBatch);
            
        }
    }
}
