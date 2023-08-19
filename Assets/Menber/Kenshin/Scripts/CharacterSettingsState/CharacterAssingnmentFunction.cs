using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CharacterAssingnmentFunction : MonoBehaviour
{
    public CharacterController[] characterControllers;

    public void MCharacterAssingnmentFunction()
    {
        foreach (var controller in characterControllers)
        {
            string characterID = "A";//‚±‚ÌA‚Ì‚Æ‚±‚ë‚ÉDictionary‚Ì’†‚É‚ ‚éƒLƒƒƒ‰‚ÌIDî•ñ‚ğ“ü‚ê‚éB
            switch (characterID)
            {
                case "FPGhost":
                    controller.SetCharacterState(new FPGhost());
                    break;
                case "FGGhost": 
                    controller.SetCharacterState(new FGGhost());
                    break;
                case "Streamer":
                    controller.SetCharacterState(new Streamer());
                    break;
            }

        }
    }
}
