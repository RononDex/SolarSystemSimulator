using GameEngine.Graphics3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace SolarSystemSimulator.Views
{
    public class TestSimView : View3D
    {
        public override void Initialize(GameEngine.GameEngine engine)
        {
            base.Initialize(engine);

            var state = GameEngine.SimState.SimState.LoadFromXml("Saves/Sol.xml");


        }
    }
}
