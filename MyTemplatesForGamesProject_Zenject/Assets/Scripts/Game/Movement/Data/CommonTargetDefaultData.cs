using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Common.Movement.Data
{
    [Serializable]
    public class CommonTargetDefaultData
    {
        public Transform Target => _target;

        [SerializeField] private Transform _target;
    }
}
