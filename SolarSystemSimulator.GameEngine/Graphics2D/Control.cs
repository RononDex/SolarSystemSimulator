using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Graphics2D
{
    public abstract class Control
    {
        /// <summary>
        /// Unique ID of this UI control
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Position of the control on the UI
        /// </summary>
        public Vector2 Position { get; set; } = new Vector2(0, 0);

        public virtual void Initialize(UIController controller)
        {

        }

        public virtual void Draw(GameTime gameTime, UIController controller)
        {

        }
    }
}
