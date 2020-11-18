using Engine.Mediators;
using Engine.UnityEvent;
using Game.Common.Audio;
using Game.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Common.Movement
{
    public class MovementController : IMovementController, ICommonInitializable, IUpdatable
    {
        private readonly ICommonAudioController _commonAudioController;
        private readonly IMovementView _movementView;
        private readonly ICoroutineProjectManager _coroutineManager;
        private CommonMovementDatabaseAsset _commonMovementDatabase;

        public MovementController(IMovementView movementView, CommonMovementDatabaseAsset commonMovementDatabase,
                                  ICoroutineProjectManager coroutineManager, ICommonAudioController commonAudioController)
        {
            _movementView = movementView;
            _commonMovementDatabase = commonMovementDatabase;
            _coroutineManager = coroutineManager;
            _commonAudioController = commonAudioController; 
        }

        public IEnumerator Start()
        {
            while (true)
            {
                yield return _coroutineManager.StartCoroutine(MoveAfterInput());
                yield return _coroutineManager.StartCoroutine(MoveToTarget());
                //yield return _coroutineManager.StartCoroutine(AIMovement());
                //yield return _coroutineManager.StartCoroutine(RandomTimeWait(minTime: 2, maxTime: 6));
                Debug.LogError("Start Coroutine");
            }
        }

        public IEnumerator MoveToTarget()
        {
            if (_commonMovementDatabase == null)
                yield return null;
            Debug.LogError("Move to target started");

            while (Vector3.Distance(_movementView.Position, _commonMovementDatabase.TargetDefaultData.Target.position) > float.Epsilon)  //пока расстояние между го и целью есть, до тех пор будет выполняться цикл 
            {
                var viewPosition = Vector3.MoveTowards(_movementView.Position, _commonMovementDatabase.TargetDefaultData.Target.position, _movementView.Speed * Time.deltaTime);
                _movementView.SetPosition(viewPosition);
                _commonAudioController.PlaySound(ECommonAudio.TAP);
                yield return null;
            }
        }

        public IEnumerator MoveAfterInput()
        {
            while(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                var tranlationX = Input.GetAxis("Horizontal") * _movementView.Speed;
                var tranlationZ = Input.GetAxis("Vertical") * _movementView.Speed;

                tranlationX *= Time.deltaTime;
                tranlationZ *= Time.deltaTime;

                _movementView.Transform.Translate(tranlationX, 0, tranlationZ);

                yield return null;
            }
        }

        public IEnumerator AIMovement()
        {
            Debug.LogError($"AI movement started. Waypoints count: {_movementView.Waypoints.Count}");
            if (_movementView.Waypoints.Count == 0)
                yield return null;

            var destination = _movementView.Waypoints[Random.Range(0, _movementView.Waypoints.Count)].position;

            while(Vector3.Distance(_movementView.Position, destination) > float.Epsilon)
            {
                var viewPosition = Vector3.MoveTowards(_movementView.Position, destination,
                                                       _movementView.Speed * Time.deltaTime);

                _movementView.SetPosition(viewPosition);

                yield return null;
            }
        }

        public IEnumerator Jump()
        {
            throw new NotImplementedException();
        }

        public IEnumerator Wait(float waitingTime)
        {
            Debug.LogError("Waiting started");
            yield return new WaitForSeconds(waitingTime);
        }

        public IEnumerator RandomTimeWait(float minTime, float maxTime)
        {
            var randomWaitingTime = Random.Range(minTime, maxTime);
            Debug.LogError($"Random time waiting started. Random value is: {randomWaitingTime}");
            yield return new WaitForSeconds(randomWaitingTime);
        }

        public void Initialize()
        {
            _coroutineManager.StartCoroutine(Start());
        }

        public void CustomUpdate(float deltaTime)
        {
        }
    }
}
