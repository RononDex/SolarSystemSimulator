using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Graphics2D
{
    /// <summary>
    /// 
    /// </summary>
    public class UIController : DrawableGameComponent
    {
        /// <summary>
        /// The controls container
        /// </summary>
        public ControlContainer Controls { get; set; } = new ControlContainer();

        private GameEngine Engine { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public SpriteFont DefaultFont { get; set; }

        public ContentManager Content { get; set; }

        public UIController(GameEngine gameEngine) : base(gameEngine)
        {
            this.Engine = gameEngine;
        }

        public override void Initialize()
        {
            base.Initialize();

            this.Content = Engine.Content;

            this.SpriteBatch = new SpriteBatch(Engine.GraphicsDevice);
            this.DefaultFont = Content.Load<SpriteFont>("Fonts/DefaultFont");
        }
        
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            foreach (Control control in this.Controls)
            {
                control.Draw(gameTime, this);
            }
        }
    }
}
