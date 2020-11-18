using Engine.Unity.CoroutineManager;
using System;
using System.Collections;
using UnityEngine;

namespace Game.Engine
{
    public abstract class AbstractCoroutineManager : ICoroutineManager
    {
        protected CoroutineManagerView _view;

        protected AbstractCoroutineManager()
        {
            var gameObject = new GameObject("CoroutineManager");
            _view = gameObject.AddComponent<CoroutineManagerView>();
            Debug.LogError($"CoroutineManager game object {_view.gameObject.name} has been created!");

        }

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return _view.StartCoroutine(routine);
        }

        public void StartAfterTimeout(float timeout, Action callback)
        {
            _view.StartCoroutine(PauseInternal(timeout, callback));
        }

        public void StartOnNextFrame(Action callback)
        {
            _view.StartCoroutine(PauseInternal(0.0f, callback));
        }

        public void StopCoroutine(IEnumerator routine)
        {
            _view.StopCoroutine(routine);
        }

        public void StopCoroutine(Coroutine routine)
        {
            if (_view != null)
                _view.StopCoroutine(routine);
        }

        public void StopAllCoroutines()
        {
            _view.StopAllCoroutines();
        }

        private IEnumerator PauseInternal(float timeout, Action callback)
        {
            yield return new WaitForSeconds(timeout);
            callback.Invoke();
        }
    }
}
