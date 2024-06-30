using UnityEngine;
using InputSystem.UI.Model;
using InputSystem.UI.View;


namespace InputSystem.UI.Presenter
{
    // Связующее звено между Model и View
    public class SelectedItemPresenter : MonoBehaviour
    {
        
        [SerializeField] private SelectedItemModel _model;
        //Притягиваем вьюшку меню
        [SerializeField] private SelectedItemView _view;

        public void Start()
        {
            _model.OnUpdated += UpdateView;
            UpdateView();
        }

        public void OnDestroy()
        {
            _model.OnUpdated -= UpdateView;
        }

        // Обновляем Вьюшку
        private void UpdateView ()
        {
            if (_model.Value == null)
            {
                _view.gameObject.SetActive(false);
                return;
            }
            _view.gameObject.SetActive(true);

            _view.Icon = _model.Value.Icon;
            _view.Name = _model.Value.Name;
            _view.Health = $"Health: {_model.Value.Health} / {_model.Value.MaxHealth}";
            //_view.HealthBar = _model.Value.Health / _model.Value.MaxHealth;

            _view.SliderController(_model.Value.MaxHealth, _model.Value.Health);
        }
    }
}
