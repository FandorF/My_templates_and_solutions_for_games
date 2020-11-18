using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Characters
{
    public class CharacterView : ICharacterView
    {
        public string Name => _name;

        [SerializeField] private string _name;
    }
}
