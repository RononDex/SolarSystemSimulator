﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameEngine.Graphics3D.Camera;
using GameEngine.Graphics3D;

namespace GameEngine.Graphics3D
{
    /// <summary>
    /// Draws all 3D-component of game
    /// </summary>
    public class Manager3D : DrawableGameComponent
    {
        /// <summary>
        /// A reference to the GameEngine instance
        /// </summary>
        private GameEngine Engine { get; set; }

        /// <summary>
        /// Holds all the 3D objects that are in the current scene
        /// </summary>
        public List<IDrawableObject3D> Objects3D { get; set; } = new List<IDrawableObject3D>();

        DepthStencilState depthStencilState = new DepthStencilState();

        /// <summary>
        /// The camera that is used to render the scene
        /// </summary>
        public Camera.Camera Camera { get; set; }
        
        public Manager3D(GameEngine engine) : base(engine)
        {
            this.Engine = engine;
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Camera = new Camera.Camera(Engine, new Vector3(0, 0, 100), new Vector3(0, 0, 0), Vector3.UnitY);
            this.Camera.ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(70), 800f / 480f, 0.1f, 1000f);
            depthStencilState.DepthBufferEnable = true;
            depthStencilState.DepthBufferWriteEnable = true;
        }

        public override void Draw(GameTime gameTime)
        {
            // Ensure that all necassery render/raster/stencil etc. states for 3D-rendering are set to the Device
            SetRenderState();
            // Draw all visible 3D-components of the current scene
            foreach (IDrawableObject3D obj in Objects3D)
                if (obj.Visible)
                    obj.Draw(this.Camera);

            base.Draw(gameTime);
        }

        private void SetRenderState()
        {
            GraphicsDevice.DepthStencilState = depthStencilState;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (IDrawableObject3D obj in this.Objects3D)
            {
                if (obj.NeedsUpdate)
                    obj.Update(gameTime);
            }

            base.Update(gameTime);
        }
    }
}


