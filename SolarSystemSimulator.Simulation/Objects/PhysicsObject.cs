using Simulation.Physics.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Physics.Objects
{
    public abstract class PhysicsObject : SimulationObject
    {
        public Vector3D Position
        {
            get { return (Vector3D)this["Position"]; }
            set { this["Position"] = value; }
        }

        public Vector3D Velocity {
            get { return (Vector3D)this["Velocity"]; }
            set { this["Velocity"] = value; }
        }

        public Vector3D Acceleration {
            get { return (Vector3D)this["Acceleration"]; }
            set { this["Acceleration"] = value; }
        }

        public double Mass {
            get { return (double)this["Mass"]; }
            set { this["Mass"] = value; }
        }
    }
}
