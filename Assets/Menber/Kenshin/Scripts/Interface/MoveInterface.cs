using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveInterface
{
    public interface IMovable
    {
        void Move(Vector2 movementValue);
    }
}
