using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Graphics2D
{
    public class View2D : View
    {

        public UIController UIController { get; set; }

        public override void Draw(ViewRenderingContext context)
        {
            UIController.Draw(context.GameTime);
        }

        public override void Initialize(GameEngine engine)
        {
            base.Initialize(engine);

            UIController = new UIController(engine);
            UIController.Initialize();
        }
    }
}
