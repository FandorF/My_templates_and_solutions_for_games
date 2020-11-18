using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Engine.UnityEvent
{
    public class UnityEventMediatorView : MonoBehaviour
    {
        private Action<float> _update;
        private Action<float> _fixedUpdate;
        private Action<float> _lateUpdate;
        private Action<bool> _applicationPause;
        private Action<bool> _applicationFocus;
        private Action _applicationQuit;

        private void Awake()
        {
            gameObject.hideFlags = HideFlags.HideInHierarchy;
        }

        public void Listen(Action<float> update, Action<float> fixedUpdate, Action<float> lateUpdate,
            Action<bool> applicationPause, Action<bool> applicationFocus, Action applicationQuit)
        {
            _update = update;
            _fixedUpdate = fixedUpdate;
            _lateUpdate = lateUpdate;
            _applicationPause = applicationPause;
            _applicationFocus = applicationFocus;
            _applicationQuit = applicationQuit;
        }

        public void UnlistenAll()
        {
            _update = null;
            _fixedUpdate = null;
            _lateUpdate = null;
            _applicationPause = null;
            _applicationFocus = null;
            _applicationQuit = null;
        }

        public void SetDontDestroy()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            _update?.Invoke(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _fixedUpdate?.Invoke(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _lateUpdate?.Invoke(Time.deltaTime);
        }

        private void OnApplicationFocus(bool focus)
        {
            _applicationFocus?.Invoke(focus);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            _applicationPause?.Invoke(pauseStatus);
        }

        private void OnApplicationQuit()
        {
            _applicationQuit?.Invoke();
        }
    }
}
