using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public abstract class View : IDisposable
    {
        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }

        public abstract void Draw(ViewRenderingContext context);

        public virtual void Initialize(GameEngine engine)
        {
            this.Content = engine.Content;
        }

        public GraphicsDevice GraphicsDevice { get; set; }

        public ContentManager Content { get; set; }
    }
}
