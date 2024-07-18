using Abstraction; 
using UnityEngine;


namespace Core.CommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        protected override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log($"{name} is moving!");
        }
    }
}
