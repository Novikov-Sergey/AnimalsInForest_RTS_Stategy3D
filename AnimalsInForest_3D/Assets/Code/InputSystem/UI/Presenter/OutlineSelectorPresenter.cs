using Abstraction;
using InputSystem.UI.Model;
using InputSystem.UI.View;
using UnityEngine;


namespace InputSystem.UI.Presenter
{
    public class OutlineSelectorPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedItemModel _model;
        private SelectedOutlineView[] _outlineSelectors;
        private ISelecatable _currentSelectable;

        private void Start()
        {
            _model.OnUpdated += OnSelected;
            _model.OnZero += ClearHeand;
            OnSelected();
        }

        public void OnDestroy()
        {
            _model.OnUpdated -= OnSelected;
            _model.OnZero -= ClearHeand;
        }

        private void ClearHeand()
        {
            if (_currentSelectable != null)
            {
                setSelected(_outlineSelectors, false);
                _currentSelectable = null;
            }
        }

        private void OnSelected()
        {
            // если повторка сбрасываем
            if (_currentSelectable == _model.Value)
            {
                return;
            }
            // назначаем выделенный объект
            _currentSelectable = _model.Value;

            // отправляем текущий объект с фальшем
            setSelected(_outlineSelectors, false);

            // обнуляем выделенный зну селектора
            _outlineSelectors = null;

            // проверка наличия модели
            if (_model.Value != null)
            {
                // берем компонент с выделенного объекта
                _outlineSelectors = (_model.Value as Component)?.GetComponentsInParent<SelectedOutlineView>();
                // отправляем привязаный компонент в обработчик
                setSelected(_outlineSelectors, true);
            }       
        }
        private void setSelected(SelectedOutlineView[] selectors, bool value)
        {
            if (selectors != null)
            {
                for (int i = 0; i < selectors.Length; i++)
                {
                    selectors[i].SetSelected(value);
                }
            }
        }
    }
}
