using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Abstraction;


namespace InputSystem.UI.View
{
    public class CommandButtonsView : MonoBehaviour
    {       
        [SerializeField] private GameObject _attackButton;
        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _patrolButton;
        [SerializeField] private GameObject _stopButton;
        [SerializeField] private GameObject _produceUnitButton;

        private Dictionary<Type, GameObject> _buttonsByExecutorType;
        public  Action<ICommandExecutor> _onClick;

        private void Awake()
        {
            _buttonsByExecutorType = new Dictionary<Type, GameObject>();
            _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IAttackCommand>), _attackButton);
            _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IMoveCommand>), _moveButton);
            _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton);
            _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IStopCommand>), _stopButton);
            _buttonsByExecutorType
            .Add(typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton);
        }

        public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors)
        {
            foreach (var currentExecutor in commandExecutors)
            {
                var buttonGameObject = _buttonsByExecutorType.FirstOrDefault(kvp => kvp.Key.IsInstanceOfType(currentExecutor)).Value;

                if (buttonGameObject == null) continue;

              //  var buttonGameObject = _buttonsByExecutorType
              //  .Where(type => type
              //  .Key
              //  .IsAssignableFrom(currentExecutor.GetType()))
              //  .First()
              //  .Value;

                buttonGameObject.SetActive(true);

                var button = buttonGameObject.GetComponent<Button>();
                button.onClick.AddListener(() => _onClick?.Invoke(currentExecutor));
            }
        }

        public void Clear()
        {
            foreach (var kvp in _buttonsByExecutorType)
            {
                kvp.Value.GetComponent<Button>().onClick.RemoveAllListeners();
                kvp.Value.SetActive(false);
            }
        }
    }
}
