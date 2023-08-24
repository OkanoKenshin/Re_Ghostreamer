using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using System.Collections;
using JetBrains.Annotations;

public class AssociateWithInputUser : MonoBehaviour
{
    public InputActionAsset actionAsset;
    InputActionMap actionMap;
   
    UserDataVault _userDataVault;

    private string objectTag = "WaitPlease";
    private Vector3 spawnPosition = Vector3.zero;
    private Quaternion spawnRotation = Quaternion.identity;
    GameObject waitPleaseImage;
    GameObject devicePairingImage;
    GameObject pairingCompletedImage;
    Display currentDisplay;

    private int numOfDisplay = 4;
    // 表示Displayの枚数
    void Start()
    {
        StartCoroutine(InitializeUserDataVault());

        actionMap = actionAsset.FindActionMap("Player");
    }
    IEnumerator InitializeUserDataVault()
    {
        yield return new WaitForSeconds(0.1f); // 0.1秒待つ
        _userDataVault = UserDataVault.Instance;
    }
    public void MWaitPlease()
    {
        #region 初期状態として全ディスプレイに入力しないで待つように指示する画像を出す。
        for (int count = 0; count < numOfDisplay; count++)
        {
            if (count == 0)
            {
                int firstDisplay = 0;
                devicePairingImage = ObjectPool.Instance.SpawnFromPool("DevicePairing", spawnPosition, spawnRotation);
                Canvas display2Project = devicePairingImage.GetComponent<Canvas>();
                display2Project.targetDisplay = firstDisplay;
            }
            else
            {
                waitPleaseImage = ObjectPool.Instance.SpawnFromPool(objectTag, spawnPosition, spawnRotation);
                Canvas display2Project = waitPleaseImage.GetComponent<Canvas>();
                display2Project.targetDisplay = count;
            }
        }
        #endregion
    }

    public void OnDevicePair2Display(InputEventPtr eventPtr, InputDevice device)
    {
        
        Debug.Log("OnDevicePair2Display called with device: " + device.name);
        var buttonControl = eventPtr.GetFirstButtonPressOrNull();
        int usercount = 4;
        // ボタン入力を検知
        #region 入力したDeviceとInputUserの取得
        if (buttonControl != null)
            // もしボタンが押されたら…
           
        {
            for (int displayCount = 0; displayCount < usercount; displayCount++)
            {
                InputUser getedUser = default;

                foreach(var user in InputUser.all)
                {
                    foreach (var pairedDevice in user.pairedDevices)
                    {
                        Debug.Log("ユーザー" +user.index+ "とペアのデバイスは" + pairedDevice.name);

                    }
                }
                

                InputDevice targetDevice = device;
                // 引数で受け取ったDevice情報

                getedUser = GetUserPairedToDevice(targetDevice);

                if (!getedUser.valid)
                {
                    Debug.LogError("Invalid InputUser");
                    return;
                }

                InputUser firstUser;
                InputUser secondUser;
                InputUser thirdUser;
                InputUser fourthUser;
                                              
                // 入力を行ったDeviceと紐づいたUserを取得してgetedUserに格納
                {
                    switch (displayCount)
                    {
                        case 0:
                            firstUser = getedUser;
                            #region Nullチェック
                            if (_userDataVault == null)
                            {
                                _userDataVault = UserDataVault.Instance;
                                if (_userDataVault == null)
                                {
                                    Debug.LogError("_userDataVault is still null after trying to initialize");
                                    return;
                                }
                            }
                            #endregion

                            if (!_userDataVault.userMapping.ContainsKey(firstUser))
                            {
                                _userDataVault.userMapping.Add(firstUser, new UserData());
                            }

                            MDisplayPairing(firstUser, displayCount);
                            break;

                        case 1:
                           secondUser = getedUser;
                            #region Nullチェック
                            if (_userDataVault == null)
                            {
                                _userDataVault = UserDataVault.Instance;
                                if (_userDataVault == null)
                                {
                                    Debug.LogError("_userDataVault is still null after trying to initialize");
                                    return;
                                }
                            }
                            #endregion

                            if (!_userDataVault.userMapping.ContainsKey(secondUser))
                            {
                                _userDataVault.userMapping.Add(secondUser, new UserData());
                            }
                            MDisplayPairing(secondUser, displayCount);

                            break;

                        case 2:
                            thirdUser = getedUser;
                            #region Nullチェック
                            if (_userDataVault == null)
                            {
                                _userDataVault = UserDataVault.Instance;
                                if (_userDataVault == null)
                                {
                                    Debug.LogError("_userDataVault is still null after trying to initialize");
                                    return;
                                }
                            }
                            #endregion

                            if (!_userDataVault.userMapping.ContainsKey(thirdUser))
                            {
                                _userDataVault.userMapping.Add(thirdUser, new UserData());
                            }
                            MDisplayPairing(thirdUser, displayCount);
                            break;

                        case 3:
                            fourthUser = getedUser;
                            #region Nullチェック
                            if (_userDataVault == null)
                            {
                                _userDataVault = UserDataVault.Instance;
                                if (_userDataVault == null)
                                {
                                    Debug.LogError("_userDataVault is still null after trying to initialize");
                                    return;
                                }
                            }
                            #endregion

                            if (!_userDataVault.userMapping.ContainsKey(fourthUser))
                            {
                                _userDataVault.userMapping.Add(fourthUser, new UserData());
                            }

                            MDisplayPairing(fourthUser, displayCount);
                            break;

                        default:
                            Debug.LogError("これ以上のデバイス追加は不可能です。");
                            break;
                    }
                    //}
                }
                #endregion

                //#region Display登録が無いUserにDisplayを若い順で紐づけ
                //InputUser currentUser = getedUser;

                //    Debug.Log(device + "から入力を受けた！");
                //    #region 76行目で発生したヌルポの対策
                //    if (_userDataVault == null || _userDataVault.userMapping == null)
                //    {
                //        _userDataVault = UserDataVault.Instance;
                //        if (_userDataVault == null)
                //        {
                //            Debug.LogError("_userDataVault が null です");
                //        }
                //        return;
                //    }
                //    #endregion
                //    //for (int displayCount = 0; displayCount < Display.displays.Length; displayCount++)
                //    //{
                //    //switch (currentUser)
                //    //{
                //    //    case :
                //    //    break;
                //    //}
                //    //MDisplayPairing(currentUser, displayCount);

                //    //}

                //#endregion
            }
        }
    }


    public void MDisplayPairing(InputUser userName,int displayNum)
    {
        if (_userDataVault.userMapping.TryGetValue(userName, out UserData userData))
        {
            currentDisplay = userData.display;
            if (currentDisplay == null)
            {
                #region DictionaryのDisplay情報を上書き
                userData.display = Display.displays[displayNum];
                _userDataVault.userMapping[userName] = userData;
                MDisplay2Project(displayNum, "PairingCompleted", objectName: pairingCompletedImage);
                #endregion

                #region 次のDisplayにボタンを押してと表示
                int nextDisplay = displayNum + 1;
                devicePairingImage = ObjectPool.Instance.SpawnFromPool("DevicePairing", spawnPosition, spawnRotation);
                Canvas display2Project = devicePairingImage.GetComponent<Canvas>();
                display2Project.targetDisplay = nextDisplay;
                #endregion
                Debug.Log(displayNum + "ペアリング完了");
            }
        }
    }
    public void MDisplay2Project(int displayNum,string objectTagName,GameObject objectName)
    {
        #region  
            objectName = ObjectPool.Instance.SpawnFromPool(objectTagName, spawnPosition, spawnRotation);
            Canvas display2Project = objectName.GetComponent<Canvas>();
            display2Project.targetDisplay = displayNum;
        #endregion
    }

    public InputUser GetUserPairedToDevice(InputDevice targetDevice)
    {
        foreach (var user in InputUser.all)
        {
            if (user.pairedDevices.Contains(targetDevice))
            {
                return user;
            }

        }
        return default; // ペアリングされているユーザーが見つからなかった場合

    }

}

//for (int count = 0; count < numOfDisplay; count++)
//{
//    if (waitPleaseImage != null)
//    {
//        waitPleaseImage.SetActive(false);
//    }
//}