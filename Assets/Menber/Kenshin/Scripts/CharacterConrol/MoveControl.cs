using UnityEngine;
using static InputSystemWithDictionary;

public class MoveControl : MonoBehaviour
{
    [SerializeField] public float ghMoveSpeed;

    float moveX;
    float moveZ;

    public void GetValue(Vector2 someValue)
    {
        moveX = someValue.x;
        moveZ = someValue.y;
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(moveX, 0.0f, moveZ));
    }

}