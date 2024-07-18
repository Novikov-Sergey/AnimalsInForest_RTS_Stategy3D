using Abstraction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstraction.Command
{
    public class AttackCommand : IAttackCommand
    {
        private GameObject _unitAttack;
        public GameObject UnitAttack => _unitAttack;

    }
}