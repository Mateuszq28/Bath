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
        //SeaScreen seaScreen;
        bool fatherCatched;
        List<Screen> screens = new List<Screen>();
        int currentScreen;


        public ScreenManager(GraphicsDeviceManager graphics)
        {
            currentScreen = 0;
            resolution.X = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            resolution.Y = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //resolution.Y = 480;
            //resolution.X = 853;
            graphics.PreferredBackBufferHeight = (int)resolution.Y;
            graphics.PreferredBackBufferWidth = (int)resolution.X;
            graphics.IsFullScreen = false;


            //seaScreen = new SeaScreen(resolution);
            screens.Add(new SeaScreen(resolution));
            screens.Add(new BattleScreen(resolution));
        }

        public void LoadContent(ContentManager Content)
        {
            foreach(Screen s in screens)
            {
                s.LoadContent(Content);
            }
            //seaScreen.LoadContent(Content);
        }

        public void Update(GameTime gameTime)
        {
            screens[currentScreen].Update(gameTime);
            //seaScreen.Update(gameTime);
            if(screens[0].GetCollisionState())
            {
                currentScreen = 1;
                screens[0].Reset();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            screens[currentScreen].Draw(spriteBatch);
            //seaScreen.Draw(spriteBatch);
            
        }
    }
}
