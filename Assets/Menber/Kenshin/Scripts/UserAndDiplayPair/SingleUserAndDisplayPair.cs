using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;

public class SingleUserAndDisplayPair : MonoBehaviour
{
    public class UserDisplayPair
    {
        public InputUser User;
        public Display UserDisplay;

        public UserDisplayPair(InputUser user, Display display)
        {
            User = user;
            UserDisplay = display;
        }
    }
}
