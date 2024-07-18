using Abstraction; 
using UnityEngine;


namespace Core.CommandExecutors
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        protected override void ExecuteSpecificCommand(IStopCommand command)
        {
            Debug.Log($"{name} has stopped!");
        }

    }
}
