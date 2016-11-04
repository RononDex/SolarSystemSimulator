using GameEngine.Graphics2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SolarSystemSimulator.Controls
{
    public class FPSDisplay : Control
    {
        public SpriteFont Font { get; set; }

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
            controller.SpriteBatch.DrawString(Font, string.Format("FPS: {0:0.0}", (1000 / gameTime.ElapsedGameTime.TotalMilliseconds)), this.Position, this.Color, 0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            controller.SpriteBatch.End();
        }
    }
}
