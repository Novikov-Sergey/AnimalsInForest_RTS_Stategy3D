using UnityEngine;


namespace Abstraction.Command
{
    public class MoveCommand : IMoveCommand
    {
        private Vector3 _position;
        public Vector3 To => _position;
    }
}
