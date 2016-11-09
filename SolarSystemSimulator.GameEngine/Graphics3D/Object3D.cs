using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Graphics3D
{
    /// <summary>
    /// Represents a standard 3D-model rendered with a BasicEffect (WP7 doesn't support custom shaders) 
    /// </summary>
    public class Object3D : IDrawableObject3D
    {
        protected Vector3 forward;
        protected Vector3 up;
        protected Vector3 position;
        protected Vector3 scale;

        public virtual Matrix World { get; private set; } = Matrix.Identity;

        public virtual Model Model { get; set; }

        public virtual Vector3 Forward
        {
            get { return forward; }
            set { forward = value; RecalcWorld(); }
        }

        public virtual Vector3 Up
        {
            get { return up; }
            set { up = value; RecalcWorld(); }
        }

        public virtual Vector3 Position
        {
            get { return position; }
            set { position = value; RecalcWorld(); }
        }

        public virtual Vector3 Scale
        {
            get { return scale; }
            set { scale = value; RecalcWorld(); }
        }

        /// <summary>
        /// The shader used for this object
        /// </summary>
        public Effect Shader { get; set; }

        protected virtual void RecalcWorld()
        {
            forward.Normalize();
            up.Normalize();
            World = Matrix.CreateWorld(position, forward, up) * Matrix.CreateScale(scale);
        }

        public virtual void Draw(Camera.Camera camera)
        {
            Matrix[] transforms = new Matrix[Model.Bones.Count];
            Model.CopyAbsoluteBoneTransformsTo(transforms);

            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in Model.Meshes)
            {
                // Check if a shader is used or not
                if (this.Shader != null)
                {
                    foreach (ModelMeshPart part in mesh.MeshParts)
                    {
                        part.Effect = this.Shader;

                        #region Shader parameters

                        if (this.Shader.Parameters["WorldViewProjection"] != null)
                            this.Shader.Parameters["WorldViewProjection"].SetValue((World * mesh.ParentBone.Transform) * camera.ViewMatrix * camera.ProjectionMatrix);
                        if (this.Shader.Parameters["ViewInverse"] != null)
                            this.Shader.Parameters["ViewInverse"].SetValue(Matrix.Invert(camera.ViewMatrix));



                        #endregion

                        //this.Shader.Parameters["ProjectionMatrix"].SetValue(camera.ProjectionMatrix);
                        //TODO: Lösung für dynamische Parameter finden, die in der Draw() Methode berechnet werden müssten
                        //Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(transforms[mesh.ParentBone.Index] * world));
                        //this.Shader.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                    }
                }
                else
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        // This is where the mesh orientation is set, as well 
                        // as our camera and projection.
                        //if (this.GetType() != typeof(SkyModel))
                        //    effect.EnableDefaultLighting();
                        effect.EnableDefaultLighting();
                        effect.World = World;
                        effect.View = camera.ViewMatrix;
                        effect.Projection = camera.ProjectionMatrix;

                        effect.DirectionalLight0.DiffuseColor = new Vector3(0, 0, 0);
                        effect.DirectionalLight0.Direction = Vector3.UnitX;
                        effect.DirectionalLight0.SpecularColor = new Vector3(1, 1, 1);
                    }
                }

                mesh.Draw();
            }

        }

        public virtual bool Visible
        {
            get;
            set;
        }

        public Object3D()
        {
            Visible = true;
            forward = Vector3.Forward;
            up = Vector3.Up;
            position = Vector3.Zero;
            scale = Vector3.One;
        }

        public Object3D(Model model) : this()
        {
            this.Model = model;
        }

        public void Update(GameTime time)
        {

        }

        public bool NeedsUpdate
        {
            get { return false; }
        }
    }
}
