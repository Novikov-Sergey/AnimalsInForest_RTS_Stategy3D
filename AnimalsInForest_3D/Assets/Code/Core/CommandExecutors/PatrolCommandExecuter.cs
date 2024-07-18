using Abstraction; 
using UnityEngine;


namespace Core.CommandExecutors
{
    public class PatrolCommandExecuter : CommandExecutorBase<IPatrolCommand>
    {
        protected override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} patroling!");
        }
    }
}
