using Game.Common.Movement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Common.Movement
{
    [CreateAssetMenu(menuName = "ScriptableObject/Database/CommonMovementDatabase", fileName = "MovementDatabaseAsset" )]

    public class CommonMovementDatabaseAsset : ScriptableObject
    {
        public CommonTargetDefaultData TargetDefaultData => _targetDefaultData;

        [SerializeField] private CommonTargetDefaultData _targetDefaultData;  
    }
}
