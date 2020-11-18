using System.Collections.Generic;

namespace Engine.UnityEvent
{
    public class UnityEventProjectMediator : UnityEventMediator
    {
        public UnityEventProjectMediator(List<IUpdatable> updatables, List<ILateUpdatable> lateUpdatables,
            List<IFixedUpdatable> fixedUpdatables, List<IApplicationPauseListener> applicationPauses,
            List<IApplicationFocusListener> applicationFocus, List<IApplicationQuitListener> applicationQuits)
            : base(updatables, lateUpdatables, fixedUpdatables, applicationPauses, applicationFocus, applicationQuits)
        {
            _unityEventMediatorView.SetDontDestroy();
        }
    }
}