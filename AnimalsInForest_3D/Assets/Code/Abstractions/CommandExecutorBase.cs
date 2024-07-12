using UnityEngine;


namespace Abstraction
{
    public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor where T : ICommand
    {
        public void ExecuteCommand(ICommand command) => ExecuteSpecificCommand((T)  command);
        protected abstract void ExecuteSpecificCommand(T command);// where T : ICommand;
    }
} 