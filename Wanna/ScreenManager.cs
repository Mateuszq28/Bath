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
        List<Screen> screens = new List<Screen>();
        int currentScreen;
        int prevScreen;
        SpriteFont font;
        float time = 0;
        string scoreString;
        int score;


        public ScreenManager(GraphicsDeviceManager graphics)
        {
            currentScreen = 3;
            resolution.X = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            resolution.Y = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferHeight = (int)resolution.Y;
            graphics.PreferredBackBufferWidth = (int)resolution.X;
            graphics.IsFullScreen = false;


            screens.Add(new SeaScreen(resolution));
            screens.Add(new BattleScreen(resolution));
            screens.Add(new OverScreen(resolution));
            screens.Add(new StartScreen(resolution));
        }

        public void LoadContent(ContentManager Content)
        {
            foreach(Screen s in screens)
            {
                s.LoadContent(Content);
            }

            font = Content.Load<SpriteFont>("Score");
        }

        public void Update(GameTime gameTime)
        {

            if (currentScreen == 0)
            {
                time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            

            score = (int)time / 2;
            scoreString = "Score: " + score;

            screens[currentScreen].Update(gameTime);
            
            if(screens[currentScreen].ScreenChange() != currentScreen)
            {
                prevScreen = currentScreen;
                currentScreen = screens[currentScreen].ScreenChange();
                screens[prevScreen].Reset();
                if (prevScreen == 2 && currentScreen == 0)
                {
                    time = 0;
                }
                
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            screens[currentScreen].Draw(spriteBatch);
            if (currentScreen == 0 || currentScreen == 1 || currentScreen == 2)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, scoreString, new Vector2(100, 100), Color.Black);
                spriteBatch.End();
            }
        }
    }
}
