using GameEngine.Graphics2D;
using GameEngine.Graphics3D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Graphics3D
{
    /// <summary>
    /// A view that contains a 3D view
    /// </summary>
    public abstract class View3D : View2D
    {
        public Manager3D Manager3D { get; set; }

        public override void Initialize(GameEngine engine)
        {
            Manager3D = new Manager3D(engine);
            Manager3D.Initialize();

            UIController = new UIController(engine);
            UIController.Initialize();

            base.Initialize(engine);
        }

        public override void Draw(ViewRenderingContext context)
        {
            Manager3D.Game.GraphicsDevice.Clear(Color.Black);
            base.Draw(context);
            this.Manager3D.Draw(context.GameTime);
        }
    }
}
