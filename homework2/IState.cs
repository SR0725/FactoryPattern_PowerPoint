using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    abstract class IState
    {
        protected IContext _context;

        // set context
        public void SetContext(IContext context)
        {
            this._context = context;
        }

        // handle mouse down
        public abstract Shape HandleMouseDown(PowerPointModal powerPointModal, ToolBar toolBar, double positionX, double positionY);

        // handle mouse move
        public abstract Shape HandleMouseMove(PowerPointModal powerPointModal, ToolBar toolBar, double positionX, double positionY);

        // handle mouse up
        public abstract Shape HandleMouseUp(PowerPointModal powerPointModal, ToolBar toolBar, double positionX, double positionY);
    }
}
