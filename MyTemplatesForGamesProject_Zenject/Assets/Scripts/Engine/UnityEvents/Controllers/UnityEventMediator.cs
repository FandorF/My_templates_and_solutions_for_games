using System;
using System.Collections.Generic;
using UnityEngine;

namespace Engine.UnityEvent
{
    public abstract class UnityEventMediator : IDisposable
    {
        private readonly List<IUpdatable> _updatables;
        private readonly List<ILateUpdatable> _lateUpdatables;
        private readonly List<IFixedUpdatable> _fixedUpdatables;
        private readonly List<IApplicationPauseListener> _applicationPauses;
        private readonly List<IApplicationFocusListener> _applicationFocus;
        private readonly List<IApplicationQuitListener> _applicationQuits;

        protected readonly UnityEventMediatorView _unityEventMediatorView;

        protected UnityEventMediator(List<IUpdatable> updatables, List<ILateUpdatable> lateUpdatables,
            List<IFixedUpdatable> fixedUpdatables, List<IApplicationPauseListener> applicationPauses,
            List<IApplicationFocusListener> applicationFocus, List<IApplicationQuitListener> applicationQuits)
        {
            _updatables = updatables;
            _lateUpdatables = lateUpdatables;
            _fixedUpdatables = fixedUpdatables;
            _applicationPauses = applicationPauses;
            _applicationFocus = applicationFocus;
            _applicationQuits = applicationQuits;

            _unityEventMediatorView = new GameObject("UnityEventMediator").AddComponent<UnityEventMediatorView>();
            Debug.LogError("UnityEventMediator created");
            _unityEventMediatorView.Listen(Update, FixedUpdate, LateUpdate, ApplicationPause, ApplicationFocus, ApplicationQuit);
        }

        private void Update(float deltaTime)
        {
            foreach (var item in _updatables)
                item.CustomUpdate(deltaTime);
        }

        private void FixedUpdate(float deltaTime)
        {
            foreach (var item in _fixedUpdatables)
                item.CustomFixedUpdate(deltaTime);
        }

        private void LateUpdate(float deltaTime)
        {
            foreach (var item in _lateUpdatables)
                item.LateUpdate(deltaTime);
        }

        private void ApplicationPause(bool pauseStatus)
        {
            foreach (var item in _applicationPauses)
                item.OnApplicationPause(pauseStatus);
        }

        private void ApplicationFocus(bool focusState)
        {
            foreach (var item in _applicationFocus)
                item.OnApplicationFocus(focusState);
        }

        private void ApplicationQuit()
        {
            foreach (var item in _applicationQuits)
                item.OnApplicationQuit();
        }

        public void Dispose()
        {
            _unityEventMediatorView.UnlistenAll();
        }
    }
}