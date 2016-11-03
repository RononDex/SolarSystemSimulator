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

        private Vector3 _position;
        /// <summary>
        /// The position of the camera in the 3d world
        /// </summary>
        public Vector3 Position
        {
            get
            {
                return _position;
            }
            set
            {
                this._position = value;
                RecalcView();
            }
        }

        private Vector3 _target;
        /// <summary>
        /// The direction in which the camera looks
        /// </summary>
        public Vector3 Target
        {
            get
            {
                return _target;
            }

            set
            {
                this._target = value;
                RecalcView();
            }
        }

        private Vector3 _upVector;
        /// <summary>
        /// The up vector of the camera for the rotation
        /// </summary>
        protected Vector3 UpVector
        {
            get
            {
                return _upVector;
            }
            set
            {
                this._upVector = value;
                RecalcView();
            }
        }

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
