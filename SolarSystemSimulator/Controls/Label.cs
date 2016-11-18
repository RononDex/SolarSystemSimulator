using GameEngine.Graphics2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystemSimulator.Controls
{
    public class Label : Control
    {
		/// <summary>
        /// The text to render
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// The font that is used to render the text
        /// </summary>
        public SpriteFont Font { get; set; }

        /// <summary>
        /// The color used to render the text
        /// </summary>
        public Color Color { get; set; } = Color.Yellow;

        public override void Initialize(UIController controller)
        {
            base.Initialize(controller);

            this.Font = controller.DefaultFont;
        }

        public override void Draw(GameTime gameTime, UIController controller)
        {
            base.Draw(gameTime, controller);

            controller.SpriteBatch.Begin();
            controller.SpriteBatch.DrawString(Font, this.Text, this.Position, this.Color, 0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            controller.SpriteBatch.End();
        }
    }
}
