using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Graphics3D
{
    /// <summary>
    /// Represents a drawable visual 3D-component
    /// </summary>
    public interface IDrawableObject3D
    {
        /// <summary>
        /// Draws the 3D-component
        /// </summary>
        /// <param name="camera">The Camera to get the view and projection matrices from</param>
        void Draw(Camera.Camera camera);
        /// <summary>
        /// Indicates wheter the 3D-component is drawn or not;
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// Updates the Drawable if nessecary
        /// </summary>
        /// <param name="time">Game timing</param>
        void Update(GameTime time);

        /// <summary>
        /// Defines wether this Object needs to be updated or not
        /// </summary>
        bool NeedsUpdate { get; }
    }
}
