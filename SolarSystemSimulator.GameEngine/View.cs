using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public abstract class View : IDisposable
    {
        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual void Draw(ViewRenderingContext context) { }

        public virtual void Initialize()
        {

        }
    }
}
