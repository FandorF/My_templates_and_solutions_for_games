using UnityEngine;

namespace Game.Engine
{
    //предотвращает удаление объекта CoroutineManagerView со сцены при переходе на другую сцену.
    public class CoroutineProjectManager : AbstractCoroutineManager, ICoroutineProjectManager
    {
        public CoroutineProjectManager() : base()
        {
            Object.DontDestroyOnLoad(_view);
        }
    }
}
