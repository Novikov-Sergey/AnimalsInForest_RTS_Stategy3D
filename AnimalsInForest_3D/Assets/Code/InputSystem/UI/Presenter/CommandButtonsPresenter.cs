using Abstraction;
using InputSystem.UI.Model;
using InputSystem.UI.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace InputSystem.UI.Presenter
{

    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedItemModel _model;
        [SerializeField] private CommandButtonsView _view;
        private ISelecatable _currentSelectable;

        private void Start()
        {
            _model.OnUpdated += onSelected;
             onSelected();//_selectable.CurrentValue);
            _view.OnClick += onButtonClick;
        }

        public void OnDestroy ()
        {
            _model.OnUpdated -= onSelected;
        }

        private void onSelected( )
        {
            if(_model.Value == null)
            {
                _view.Clear();
                return;
            }

            var command = (_model.Value as UnityEngine.Component)?.GetComponents<ICommandExecutor>();

            //if (_currentSelectable == selectable)
            //{
            //    return;
            //}
            //_currentSelectable = selectable;
            //
            //if (selectable != null)
            //{
            //    var commandExecutors = new List<ICommandExecutor>();
            //    commandExecutors.AddRange((selectable as
            //    Component).GetComponentsInParent<ICommandExecutor>());
            //    _view.MakeLayout(commandExecutors);
            //}
        }

        private void onButtonClick(ICommandExecutor commandExecutor)
        {
           // var unitProducer = commandExecutor as
           // CommandExecutorBase<IProduceUnitCommand>;
           // if (unitProducer != null)
           // {
           //     unitProducer.ExecuteSpecificCommand(new ProduceUnitCommand());
           //     return;
           // }
           // throw new
           // ApplicationException($"{nameof(CommandButtonsPresenter)}. {nameof(onButtonClick)}: Unknown type of commands executor: { commandExecutor.GetType().FullName }!");
        }
    }
}