using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Graphics3D
{
    /// <summary>
    /// Caches all models that are being used by the game, so they dont get loaded more than once (performance)
    /// </summary>
    public class ModelLoader
    {
        Dictionary<string, Model> _cache = new Dictionary<string, Model>();
        Microsoft.Xna.Framework.Content.ContentManager contentManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentManager">The ContentManager to load the models from</param>
        public ModelLoader(Microsoft.Xna.Framework.Content.ContentManager contentManager)
        {
            #region PRECONDITION

            if (contentManager == null)
                throw new NullReferenceException("The ContentManager may not be NULL!");

            #endregion

            this.contentManager = contentManager;
        }


        /// <summary>
        /// Cache for all loaded Models
        /// </summary>
        public Dictionary<string, Model> Cache3D
        {
            get { return this._cache; }
        }

        /// <summary>
        /// Loads a Model by the contentManager given to the constructor. If Model already cached, the cached object is returned
        /// </summary>
        /// <param name="contentPath">Path to the content directory + asset name</param>
        /// <returns></returns>
        public Model Load3DModel(string contentPath)
        {
            if (!this._cache.ContainsKey(contentPath))
                this._cache.Add(contentPath, this.contentManager.Load<Model>(contentPath));

            return this._cache[contentPath];
        }

        /// <summary>
        /// Clears the cache
        /// </summary>
        public void ClearCache()
        {
            this._cache.Clear();
            this._cache = null;
            this._cache = new Dictionary<string, Model>();
        }
    }
}
