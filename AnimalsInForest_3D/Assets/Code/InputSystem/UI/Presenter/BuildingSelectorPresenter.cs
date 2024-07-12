using Abstraction;
using InputSystem.UI.Model;
using InputSystem.UI.View;
using UnityEngine;


namespace InputSystem.UI.Presenter
{
    public class BuildingSelectorPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedItemModel _model;
        private SelectedBuildingsView _selectedBuildings;
        private ISelecatable _currentSelectable;

        public void Start()
        {
            _model.OnUpdated += OnSelected;
            OnSelected();
        }

        public void OnDestroy()
        {
            _model.OnUpdated -= OnSelected;
        }

        private void OnSelected()
        {
            if (_currentSelectable == _model.Value)
            {
                return;
            }

            // назначаем выделенный объект
            _currentSelectable = _model.Value;

            // отправляем текущий объект с фальшем
            setSelected(_selectedBuildings, false);

            // обнуляем выделенный зну селектора
            _selectedBuildings = null;

            // проверка наличия модели
            if (_model.Value != null)
            {
                // берем компонент с выделенного объекта
                _selectedBuildings = (_model.Value as Component)?.GetComponent<SelectedBuildingsView>();
                // отправляем привязаный компонент в обработчик
                setSelected(_selectedBuildings, true);
            }

            static void setSelected(SelectedBuildingsView view, bool value)
            {
                if (view != null)
                {
                    view.SetSelected(value);
                }
            }
        }
    }
}

