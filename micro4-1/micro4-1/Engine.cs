using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace micro4_1
{
    class Engine : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager Graphics;

        public Engine()
        {
            Graphics = new GraphicsDeviceManager(this);

            Graphics.DeviceCreated += new EventHandler(Graphics_DeviceCreated);
        }

        void Graphics_DeviceCreated(object sender, EventArgs e)
        {
            
        }
        protected override void Draw(GameTime gameTime)
        {
            
        }
        
    }
}
