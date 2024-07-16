using Abstraction; 
using UnityEngine;

public class People : MonoBehaviour,  ISelecatable
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
