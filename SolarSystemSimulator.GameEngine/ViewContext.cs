using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    /// <summary>
    /// The context for a view draw event
    /// </summary>
    public class ViewRenderingContext
    {
        public GraphicsDevice GraphicsDevice { get; private set; }

        public GameTime GameTIme { get; private set; }

        public ViewRenderingContext(GraphicsDevice graphicsDevice, GameTime gameTime)
        {
            this.GraphicsDevice = graphicsDevice;
            this.GameTIme = gameTime;
        }
    }
}
