using Abstraction;
using Abstraction.Command;
using InputSystem.UI.Model;
using InputSystem.UI.View; 
using System.Linq;
using UnityEngine;
using Utils;
using System;
using static Codice.CM.WorkspaceServer.WorkspaceTreeDataStore;
//using static Codice.CM.WorkspaceServer.WorkspaceTreeDataStore;


namespace InputSystem.UI.Presenter
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedItemModel _model;
        [SerializeField] private CommandButtonsView _view;

        [SerializeField] private AssetsStorage _assets;

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

        // Область реакции на клики по объекту
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

        // Область реакции на кнопки команд
        private void OnButtonClick(ICommandExecutor commandExecutor)
        {
            var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;

            if (unitProducer != null)
            {
                unitProducer.ExecuteCommand(Injector.Inject(_assets, new ProduceUnitCommand()));
                return;
            }

            var attacker = commandExecutor as CommandExecutorBase<IAttackCommand>;
            if (attacker != null)
            {
                attacker.ExecuteCommand(new AttackCommand());
                return;
            }

            var stopper = commandExecutor as CommandExecutorBase<IStopCommand>;
            if (stopper != null)
            {
                stopper.ExecuteCommand(new StopCommand());
                return;
            }

            var mover = commandExecutor as CommandExecutorBase<IMoveCommand>;
            if (mover != null)
            {
                mover.ExecuteCommand(new MoveCommand());
                return;
            }

            var patroller = commandExecutor as CommandExecutorBase<IPatrolCommand>;
            if (patroller != null)
            {
                patroller.ExecuteCommand(new PatrolCommand());
                return;
            }

            throw new ApplicationException($"{nameof(CommandButtonsPresenter)}." +
                $"{nameof(OnButtonClick)}: Unknown type of commands executor: { commandExecutor.GetType().FullName }!");
          //  commandExecutor.ExecuteCommand(Injector.Inject(_assets, new ProduceUnitCommand()));
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