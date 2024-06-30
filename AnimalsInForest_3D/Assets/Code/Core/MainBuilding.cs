using UnityEngine;
using Abstraction;


namespace Core
{
    public class MainBuilding : MonoBehaviour, ISelecatable
    {
        [SerializeField] private string _name;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;
        [SerializeField] private Sprite _icon;

        public string Name => _name;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
    }
}
//{

//

//
//    private float _health = 1000;
//
//    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
//    {
//        Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0,
//        Random.Range(-10, 10)), Quaternion.identity);//, _unitsParent);
//    }
//
//    // public void ProduceUnit()
//    // {
//    // Instantiate(_unitPrefab, new Vector3(Random.Range(-10,10), 0, 
//    // Random.Range(-10, 10)), Quaternion.identity, _unitParent);
//    // }
//}
