using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region データ保持用のクラス
    public class InputParam
    {
        public float MoveX = 0;
        public float MoveZ = 0;
        public float CamX = 0;
        public float CamY = 0;
        public bool Ability = false;
        public bool Attack = false;
        public bool Select = false;
        public bool Dash = false;
        public bool CursorLock = false;

        //public bool AbilityFlag = false;
        //public bool AttackFlag = false;
        //public bool SelectFlag = false;
        //public bool DashFlag = false;
    }
    public class InputTypeString
    {
        public string Horizontal;
        public string Vertical;
        public string CamHorizontal;
        public string CamVertical;
        public string Ability;
        public string Attack;
        public string Select;
        public string Dash;
        public string CursorLock;
    }

    #endregion

    #region データテーブル

    /// <summary>
    /// 入力値を保存するテーブル
    /// </summary>
    private Dictionary<CommonParam.UnitType, InputParam> _unitInputParams = new Dictionary<CommonParam.UnitType, InputParam>()
    {
        //FGGインプット
        {CommonParam.UnitType.FGGhost, new InputParam(){ MoveX = 0, MoveZ = 0, CamX = 0, CamY = 0, Ability = false, Attack = false, Select = false, Dash = false, CursorLock = false} },
        //FPGインプット
        {CommonParam.UnitType.FPGhost, new InputParam(){ MoveX = 0, MoveZ = 0, CamX = 0, CamY = 0, Ability = false, Attack = false, Select = false, Dash = false, CursorLock = false} },
        //HAGインプット
        {CommonParam.UnitType.HAGhost, new InputParam(){MoveX = 0, MoveZ = 0, CamX = 0, CamY = 0, Ability = false, Attack = false, Select = false, Dash = false, CursorLock = false} },
        //STインプット
        {CommonParam.UnitType.Streamer, new InputParam(){MoveX = 0, MoveZ = 0, CamX = 0, CamY = 0, Ability = false, Attack = false, Select = false, Dash = false, CursorLock = false} },
    };
    /// <summary>
    /// 入力値の外部参照用
    /// </summary>
    public Dictionary<CommonParam.UnitType, InputParam> UnitInputParams => _unitInputParams;

    private Dictionary<CommonParam.UnitType, InputTypeString> _inputKinds = new Dictionary<CommonParam.UnitType, InputTypeString>()
    {
        {CommonParam.UnitType.FGGhost, new InputTypeString()    { Horizontal = "FGGHorizontal", Vertical = "FGGVertical", CamHorizontal = "FGGCamHori", CamVertical = "FGGCamVer", Ability = "FGGAbility", Attack = "FGGAttack", Select = "FGGSelect", Dash = "FGGDash", CursorLock = "FGGCursorLock"}},
        {CommonParam.UnitType.FPGhost, new InputTypeString()    { Horizontal = "FPGHorizontal", Vertical = "FPGVertical", CamHorizontal = "FPGCamHori", CamVertical = "FPGCamVer", Ability = "FPGAbility", Attack = "FPGAttack", Select = "FPGSelect", Dash = "FPGDash", CursorLock = "FPGCursorLock"}},
        {CommonParam.UnitType.HAGhost, new InputTypeString()    { Horizontal = "HAGHorizontal", Vertical = "HAGVertical", CamHorizontal = "HAGCamHori", CamVertical = "HAGCamVer", Ability = "HAGAbility", Attack = "HAGAttack", Select = "HAGSelect", Dash = "HAGDash", CursorLock = "HAGCursorLock"}},
        {CommonParam.UnitType.Streamer, new InputTypeString()    { Horizontal = "StHorizontal", Vertical = "StVertical", CamHorizontal = "StCamHori", CamVertical = "StCamVer", Ability = "StAbility", Attack = "StAttack", Select = "StSelect", Dash = "StDash", CursorLock = "StCursorLock"}},
    };

    #endregion

    // Update is called once per frame
    void Update()
    {
        InputCheck(CommonParam.UnitType.FGGhost);
        InputCheck(CommonParam.UnitType.FPGhost);
        InputCheck(CommonParam.UnitType.HAGhost);
        InputCheck(CommonParam.UnitType.Streamer);
    }

    public void InputCheck(CommonParam.UnitType unitType)
    {
        var input = _inputKinds[unitType];
        var inputParam = _unitInputParams[unitType];
        inputParam.MoveX = Input.GetAxisRaw(input.Horizontal);
        inputParam.MoveZ = Input.GetAxisRaw(input.Vertical);
        inputParam.CamX = Input.GetAxisRaw(input.CamHorizontal);
        inputParam.CamY = Input.GetAxisRaw(input.CamVertical);
        inputParam.Ability = Input.GetButton(input.Ability);
        //if (inputParam.Ability) inputParam.AbilityFlag = true;
        inputParam.Attack = Input.GetButton(input.Attack);
        //if (inputParam.Attack) inputParam.AttackFlag = true;
        inputParam.Dash = Input.GetButton(input.Dash);
        //if (inputParam.Dash) inputParam.DashFlag = true;
        inputParam.Select = Input.GetButton(input.Select);
        //if(inputParam.Select) inputParam.SelectFlag = true;
        inputParam.CursorLock = Input.GetButton(input.CursorLock);
    }
}
