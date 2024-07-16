using Abstraction;
using Abstraction.Command;
using InputSystem.UI.Model;
using InputSystem.UI.View; 
using System.Linq;
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
            _model.OnUpdated += OnSelected;
            _model.OnZero += ClearHeand;
            OnSelected();//_selectable.CurrentValue);
            _view._onClick += OnButtonClick;
        }

        public void OnDestroy ()
        {
            _model.OnUpdated -= OnSelected;
            _model.OnZero -= ClearHeand;
            _view._onClick -= OnButtonClick;
        }

        private void ClearHeand ()
        {
            _view.Clear();
        }

        // ������� ������� �� ����� �� �������
        private void OnSelected( )
        {           
            _view.Clear();
             
            if (_model.Value == null)
            {   
                return;
            }
            _currentSelectable = _model.Value;
            var command = (_model.Value as UnityEngine.Component)?.GetComponents<ICommandExecutor>().ToList();
            _view.MakeLayout(command);

            //if (_currentSelectable == selectable)
            //{
            //    return;
            //}

            //_currentSelectable = selectable;
            
            //if (selectable != null)
            //{
            //    var commandExecutors = new List<ICommandExecutor>();
            //    commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            //    _view.MakeLayout(commandExecutors);
            //}
        }

        // ������� ������� �� ������ ������
        private void OnButtonClick(ICommandExecutor commandExecutor)
        {
            commandExecutor.ExecuteCommand(new ProduceUnitCommand());
           // var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;

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