using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class IContext
    {
        // A reference to the current state of the Context.
        private IState _state = null;

        // constructor
        public IContext(IState state)
        {
            this.SetState(state);
        }

        // change state
        public void SetState(IState state)
        {
            this._state = state;
            this._state.SetContext(this);
        }

        // handle mouse down
        public Shape HandleMouseDown(PowerPointModal powerPointModal, ToolBar toolBar, double positionX, double positionY) 
        {
            return this._state.HandleMouseDown(powerPointModal, toolBar, positionX, positionY);
        }

        // handle mouse move
        public Shape HandleMouseMove(PowerPointModal powerPointModal, ToolBar toolBar, double positionX, double positionY)
        {
            return this._state.HandleMouseMove(powerPointModal, toolBar, positionX, positionY);
        }

        // handle mouse up
        public Shape HandleMouseUp(PowerPointModal powerPointModal, ToolBar toolBar, double positionX, double positionY)
        {
            return this._state.HandleMouseUp(powerPointModal, toolBar, positionX, positionY);
        }
    }
}
