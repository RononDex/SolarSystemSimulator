using Simulation.Physics.Math;
using Simulation.Physics.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Physics.Engines
{
    public class NewtonianGravityEngine : SimulationEngine
    {
        /// <summary>
        /// The gravitational constant used to calculate the gravitational force acting on two bodies
        /// </summary>
        public const double GRAVITATIONAL_CONSTANT = 6.67408e-11;

        public override void UpdateWorld(SimulationContext context, TimeSpan step)
        {
            var physicsObjects = context.World.Objects.FindByType<PhysicsObject>(true);

            // Calculate gravity vector direction and length
            foreach (var physObject in physicsObjects)
            {
                if (physObject.Mass <= 0)
                    continue;

                var garvityForceVector = new Vector3D();

                foreach (var relativeObject in physicsObjects)
                {
                    if (physObject[BuiltInProperties.ID] == relativeObject[BuiltInProperties.ID])
                        continue;
                    if (relativeObject.Mass <= 0)
                        continue;

                    // First calculate the direction of the force
                    var subGravityVector = relativeObject.Position - physObject.Position;

                    // Second calculate the magnitude of the force
                    var magnitude = GRAVITATIONAL_CONSTANT * physObject.Mass * relativeObject.Mass / System.Math.Pow(subGravityVector.Length, 2);

                    // Make the gravity vector the length of the magnitude
                    subGravityVector.ChangeMagnitude(magnitude);

                    // Add it to the gravitationalVector acting on the current object
                    garvityForceVector += subGravityVector;
                }

                physObject["Gravity"] = garvityForceVector;

                // Calculate acceleration
                var acceleration = garvityForceVector / physObject.Mass; // F = m * a  --> a = F / m
                physObject["Acceleration"] = acceleration;

                // Calculate new velocity
                if (physObject.Velocity == null)
                    physObject.Velocity = new Vector3D();

                var oldVelocity = new Vector3D(physObject.Velocity.X, physObject.Velocity.Y, physObject.Velocity.Z);
                physObject.Velocity += acceleration * step.TotalSeconds;

                // Calculate new position (using linear interpolation for velocity)
                var deltaVelocity = physObject.Velocity - oldVelocity;
                physObject.Position += ((oldVelocity) + (deltaVelocity / 2)) * step.TotalSeconds;
            }
        }
    }
}
