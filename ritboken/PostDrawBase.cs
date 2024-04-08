using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritboken
{
    internal abstract class PostDrawBase : DrawBase // basklass för när saker ritas efter att mus upp ex ellipse
    {
        public Point mouseDownLoc;
        public Point currMouseLoc;
        public bool fillShapes = false;
        public PostDrawBase(Color color,int width) : base(color,width) { }


        public abstract void DrawPreview(Graphics g);
        
        
        
    }
}
