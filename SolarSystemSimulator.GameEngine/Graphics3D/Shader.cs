using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Graphics3D
{
    public class Shader
    {
        /// <summary>
        /// The Monogame Shader object
        /// </summary>
        public Effect Effect { get; set; }

        public Shader(Effect shader)
        {
            #region PRECONDITION

            if (shader == null)
                throw new ArgumentNullException("Shader can not be null!");

            #endregion

            this.Effect = shader;
        }

        public void PrepareShader(ShaderRenderingContext context)
        {
            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in context.Object3D.Model.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    part.Effect = this.Effect;

                    SetDefaultParameters(context, mesh);
                }
            }
        }

        public void SetDefaultParameters(ShaderRenderingContext context, ModelMesh mesh)
        {
            if (this.Effect.Parameters["WorldViewProjection"] != null)
                this.Effect.Parameters["WorldViewProjection"].SetValue((context.Object3D.World * mesh.ParentBone.Transform) * context.Camera.ViewMatrix * context.Camera.ProjectionMatrix);
            if (this.Effect.Parameters["ViewInverse"] != null)
                this.Effect.Parameters["ViewInverse"].SetValue(Matrix.Invert(context.Camera.ViewMatrix));
            if (this.Effect.Parameters["WorldMatrix"] != null)
                this.Effect.Parameters["WorldMatrix"].SetValue(context.Object3D.World * mesh.ParentBone.Transform);
            if (this.Effect.Parameters["ViewMatrix"] != null)
                this.Effect.Parameters["ViewMatrix"].SetValue(context.Camera.ViewMatrix);
            if (this.Effect.Parameters["ProjectionMatrix"] != null)
                this.Effect.Parameters["ProjectionMatrix"].SetValue(context.Camera.ProjectionMatrix);
        }

        public void SetCustomParameter(string key, object value)
        {

        }
    }
}
