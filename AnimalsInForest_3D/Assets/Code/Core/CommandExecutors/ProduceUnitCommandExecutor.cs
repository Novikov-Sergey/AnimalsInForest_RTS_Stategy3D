using Abstraction;
using UnityEngine;


namespace Core.CommandExecutors
{
    public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>
    {
        protected override void ExecuteSpecificCommand (IProduceUnitCommand command)
        {
            Debug.Log("Сделано");
            Instantiate(command.UnitPrefab, transform.position + Vector3.forward * 2, Quaternion.identity);
        }
    }
}