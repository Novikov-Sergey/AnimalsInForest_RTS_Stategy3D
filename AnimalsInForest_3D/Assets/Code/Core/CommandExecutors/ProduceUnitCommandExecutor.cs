using Abstraction;
using UnityEngine;


namespace Core.CommandExecutors
{
    public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>
    {
        protected override void ExecuteSpecificCommand (IProduceUnitCommand command)
        {
            Debug.Log("Сделано");
        }
    }
}