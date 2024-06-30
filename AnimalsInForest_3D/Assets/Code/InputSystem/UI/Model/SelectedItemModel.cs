using Abstraction;
using System;
using UnityEngine;


namespace InputSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(SelectedItemModel), menuName = "Strategy/Models")]
    public class SelectedItemModel : ScriptableObject
    {
        private ISelecatable _value;

        public ISelecatable Value => _value;

        public event Action OnUpdated;

        //Сохраняем параметры и запускаем событие
        public void SetValue (ISelecatable value)
        {
            _value = value;
            OnUpdated?.Invoke();
        }
    }
}
