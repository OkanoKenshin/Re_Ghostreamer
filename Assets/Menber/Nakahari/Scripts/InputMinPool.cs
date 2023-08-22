//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class InputMinPool : MonoBehaviour
//{
//    private Re_Ghostreamer _ghostReamer;
//    void Start()
//    {
//        _ghostReamer = new Re_Ghostreamer();
//        _ghostReamer.Enable();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //Vector2 move = MGetMoveValueForPlayer(_type.ToString());
//    }

//    public Vector2 MGetMoveValueForPlayer(string playerName)
//    {
//        InputActionMap actionMap = _ghostReamer.asset.FindActionMap(playerName);
//        if (actionMap != null)
//        {
//            InputAction moveAction = actionMap.FindAction("Move");
//            if (moveAction != null)
//            {
//                return moveAction.ReadValue<Vector2>();
//            }
//        }
//        return Vector2.zero; // Default value
//    }
//}
