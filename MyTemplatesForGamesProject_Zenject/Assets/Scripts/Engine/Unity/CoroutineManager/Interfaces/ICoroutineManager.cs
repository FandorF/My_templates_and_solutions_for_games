using System;
using System.Collections;
using UnityEngine;

namespace Engine.Unity.CoroutineManager
{
    public interface ICoroutineManager
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StartAfterTimeout(float timeout, Action callback);
        void StartOnNextFrame(Action callback);
        void StopCoroutine(Coroutine routine);
        void StopCoroutine(IEnumerator routine);
        void StopAllCoroutines();
    }
}
