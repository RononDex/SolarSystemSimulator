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
    /// The game engine for the simulation
    /// Controls all the rendering
    /// </summary>
    public class GameEngine : Game
    {
        public GraphicsDeviceManager Graphics { get; private set; }

        /// <summary>
        /// All objects that are beeing rendered ingame are in this collection
        /// </summary>
        public List<Model> Objects { get; set; }

        public View CurrentView { get; private set; }

        public GameEngine(GameEngineSettings settings)
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = settings.ContentDirectoryRoot;

            // Run one frame, to make sure everything is initialized properly
            this.RunOneFrame();

            // Set the first view and initialize it
            if (settings.StartView != null)
                ChangeCurrentView(settings.StartView);
        }

        /// <summary>
        /// Updates the applications rendering
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            if (CurrentView == null)
                return;

            CurrentView.GraphicsDevice = this.GraphicsDevice;
            CurrentView.Content = this.Content;
            CurrentView.Draw(new ViewRenderingContext(gameTime));
        }

        /// <summary>
        /// Changes the current main view
        /// </summary>
        /// <param name="newView"></param>
        public void ChangeCurrentView(View newView)
        {
            if (CurrentView != null)
            {
                CurrentView.Dispose();
                CurrentView = null;
            }

            CurrentView = newView;
            newView.Initialize(this);
        }
    }
}
