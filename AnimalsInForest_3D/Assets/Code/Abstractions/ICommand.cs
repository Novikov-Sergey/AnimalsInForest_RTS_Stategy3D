using UnityEngine;


namespace Abstraction
{
    //Общий интерфейс
    public interface ICommand
    {

    }

    //Команды юнитов
    public interface IAttackCommand : ICommand
    {
        GameObject Target { get; }
    }

    public interface IMoveCommand : ICommand
    {
        Vector3 To { get; } 
    }
    public interface IPatrolCommand : ICommand
    {

    }
    public interface IStopCommand : ICommand
    {

    }

    // Команды зданий
    public interface IProduceUnitCommand : ICommand
    {
        GameObject UnitPrefab { get; }
    }
}