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

        public abstract void Initialize();

        public GraphicsDevice GraphicsDevice { get; set; }

        public ContentManager Content { get; set; }
    }
}
