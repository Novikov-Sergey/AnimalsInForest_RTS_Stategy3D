using UnityEngine;


namespace Abstraction
{
    public interface ISelecatable
    {
        string Name { get; }
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }         
    }
}