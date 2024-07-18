using Abstraction;
using UnityEngine;


namespace Core.CommandExecutors
{
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        protected override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log($"{name} is attacking!");
        }
    }
}
