using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.UnityEvent
{
    public interface IUpdatable
    {
        void CustomUpdate(float deltaTime);
    }
}
