using GameEngine;
using GameEngine.Graphics3D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystemSimulator.Views
{
    public class TestView : View3D
    { 
        public override void Draw(ViewRenderingContext context)
        {
            //GraphicsDevice.Clear(Color.Black);
            base.Draw(context);
        }

        public override void Initialize(GameEngine.GameEngine engine)
        {
            base.Initialize(engine);

            var planetModel = engine.ModelLoader.Load3DModel("sphere");
            this.Manager3D.Objects3D.Add(new Object3D(planetModel) { Position = new Vector3(), Up = Vector3.UnitY, Forward = Vector3.UnitZ, Visible = true, Scale = new Vector3(1,1,1) });
        }
    }
}
