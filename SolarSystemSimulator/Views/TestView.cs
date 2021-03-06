﻿using GameEngine;
using GameEngine.Graphics3D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SolarSystemSimulator.Controls;
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
            base.Draw(context);

            var rotationalPeriod = 0.5;
            this.Manager3D.Camera.Position = Vector3.Transform(this.Manager3D.Camera.Position - this.Manager3D.Camera.Target, Matrix.CreateFromAxisAngle(Vector3.UnitY, Convert.ToSingle((context.GameTime.TotalGameTime.TotalMilliseconds % rotationalPeriod) / (2 * Math.PI)))) + this.Manager3D.Camera.Target;
        }

        public override void Initialize(GameEngine.GameEngine engine)
        {
            base.Initialize(engine);

            var fpsDisplay = new FPSDisplay();
            fpsDisplay.Initialize(this.UIController);
            fpsDisplay.Position = new Vector2(10, 10);
            this.UIController.Controls.AddControl(fpsDisplay);

			var shader = engine.Content.Load<Effect>("Effects/Test2");//SHADER
			var planetModel = engine.ModelLoader.Load3DModel("Test/ASP_Elite_Dangerous");
            this.Manager3D.Objects3D.Add(new Object3D(planetModel) { Position = new Vector3(), Up = Vector3.UnitY, Forward = Vector3.UnitZ, Visible = true, Scale = new Vector3(1,1,1), Shader = shader });
			

		}
	}
}
