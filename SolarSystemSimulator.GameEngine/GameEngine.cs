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
        /// <summary>
        /// All objects that are beeing rendered ingame are in this collection
        /// </summary>
        public List<Model> Objects { get; set; }

        public View CurrentView { get; private set; }

        /// <summary>
        /// Updates the applications rendering
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {

        }
    }
}
