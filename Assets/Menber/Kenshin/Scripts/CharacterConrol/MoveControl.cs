//public class MoveControl : MonoBehaviour, IMovable
//{
//    [SerializeField] public float ghMoveSpeed;
//    public void Move(Vector2 direction)
//    {
//        transform.Translate(new Vector3(movementVector.x, 0, movementVector.y) * ghMoveSpeed * Time.deltaTime);
//    }
//}


using UnityEngine;
using static MoveInterface;

public class MoveControl : MonoBehaviour, IMovable
{
    [SerializeField] public float ghMoveSpeed;

    public void Move(Vector2 movementVector)
    {
        transform.Translate(new Vector3(movementVector.x, 0, movementVector.y) * ghMoveSpeed * Time.deltaTime);

    }

}