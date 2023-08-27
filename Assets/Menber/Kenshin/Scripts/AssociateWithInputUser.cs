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
    // �\��Display�̖���
    void Start()
    {
        StartCoroutine(InitializeUserDataVault());

        actionMap = actionAsset.FindActionMap("Player");
    }
    IEnumerator InitializeUserDataVault()
    {
        yield return new WaitForSeconds(0.1f); // 0.1�b�҂�
        _userDataVault = UserDataVault.Instance;
    }
    public void MWaitPlease()
    {
        #region ������ԂƂ��đS�f�B�X�v���C�ɓ��͂��Ȃ��ő҂悤�Ɏw������摜���o���B
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
        // �{�^�����͂����m
        #region ���͂���Device��InputUser�̎擾
        if (buttonControl != null)
            // �����{�^���������ꂽ��c
           
        {
            for (int displayCount = 0; displayCount < usercount; displayCount++)
            {
                InputUser getedUser = default;

                foreach(var user in InputUser.all)
                {
                    foreach (var pairedDevice in user.pairedDevices)
                    {
                        Debug.Log("���[�U�[" +user.index+ "�ƃy�A�̃f�o�C�X��" + pairedDevice.name);

                    }
                }
                

                InputDevice targetDevice = device;
                // �����Ŏ󂯎����Device���

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
                                              
                // ���͂��s����Device�ƕR�Â���User���擾����getedUser�Ɋi�[
                {
                    switch (displayCount)
                    {
                        case 0:
                            firstUser = getedUser;
                            #region Null�`�F�b�N
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
                            #region Null�`�F�b�N
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
                            #region Null�`�F�b�N
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
                            #region Null�`�F�b�N
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
                            Debug.LogError("����ȏ�̃f�o�C�X�ǉ��͕s�\�ł��B");
                            break;
                    }
                    //}
                }
                #endregion

                //#region Display�o�^������User��Display���Ⴂ���ŕR�Â�
                //InputUser currentUser = getedUser;

                //    Debug.Log(device + "������͂��󂯂��I");
                //    #region 76�s�ڂŔ��������k���|�̑΍�
                //    if (_userDataVault == null || _userDataVault.userMapping == null)
                //    {
                //        _userDataVault = UserDataVault.Instance;
                //        if (_userDataVault == null)
                //        {
                //            Debug.LogError("_userDataVault �� null �ł�");
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
                #region Dictionary��Display�����㏑��
                userData.display = Display.displays[displayNum];
                _userDataVault.userMapping[userName] = userData;
                MDisplay2Project(displayNum, "PairingCompleted", objectName: pairingCompletedImage);
                #endregion

                #region ����Display�Ƀ{�^���������Ăƕ\��
                int nextDisplay = displayNum + 1;
                devicePairingImage = ObjectPool.Instance.SpawnFromPool("DevicePairing", spawnPosition, spawnRotation);
                Canvas display2Project = devicePairingImage.GetComponent<Canvas>();
                display2Project.targetDisplay = nextDisplay;
                #endregion
                Debug.Log(displayNum + "�y�A�����O����");
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
        return default; // �y�A�����O����Ă��郆�[�U�[��������Ȃ������ꍇ

    }

}

//for (int count = 0; count < numOfDisplay; count++)
//{
//    if (waitPleaseImage != null)
//    {
//        waitPleaseImage.SetActive(false);
//    }
//}