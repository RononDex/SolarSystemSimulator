using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Graphics3D.Camera
{
    public class Camera : GameComponent
    {
        /// <summary>
        /// The view matrix of the camera
        /// </summary>
        public Matrix ViewMatrix { get; set; }

        /// <summary>
        /// The Projection Matrix
        /// </summary>
        public Matrix ProjectionMatrix { get; set; }

        /// <summary>
        /// The position of the camera in the 3d world
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// The direction in which the camera looks
        /// </summary>
        protected Vector3 Target { get; set; }

        /// <summary>
        /// The up vector of the camera for the rotation
        /// </summary>
        protected Vector3 UpVector { get; set; }

        /// <summary>
        /// Recalculates the view Matrix
        /// </summary>
        protected virtual void RecalcView()
        {
            this.ViewMatrix = Matrix.CreateLookAt(this.Position, this.Target, this.UpVector);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine">Reference to the game engine</param>
        public Camera(GameEngine engine, Vector3 position = new Vector3(), Vector3 target = new Vector3(), Vector3 up = new Vector3()) : base(engine)
        {
            this.Position = position;
            this.Target = target;
            this.UpVector = up;
            RecalcView();
        }
    }
}
