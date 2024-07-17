using UnityEngine;
using Utils;


namespace Abstraction.Command
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [InjectAsset("Child")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
         
        public ProduceUnitCommand ()
        {

        }
    }
}