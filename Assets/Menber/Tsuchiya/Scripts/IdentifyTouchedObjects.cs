using UnityEngine;

/*public class IdentifyTouchedObjects : MonoBehaviour
{
    public string touchedObject;
    public bool lookingAtMap;
    private bool inputOn;

    [SerializeField] private GameObject AttachedCollectTheIRCamera;
    private CollectTheIRCamera _collectTheIRCamera;

    [SerializeField] private GameObject AttachedCloserToTheMap;
    private CloserToTheMap _closerToTheMap;

    private void Awake()
    {
        if (AttachedCollectTheIRCamera != null)
        {
            _collectTheIRCamera = AttachedCollectTheIRCamera.GetComponent<CollectTheIRCamera>();
            if (_collectTheIRCamera != null)
            {
                Debug.Log("�uCollectTheIRCamera�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uAttachedCollectTheIRCamera�v�̓A�^�b�`����Ă��܂����A �uCollectTheIRCamera�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uAttachedCollectTheIRCamera�v�̓A�^�b�`����Ă��܂���B");
        }

        if (AttachedCloserToTheMap != null)
        {
            _closerToTheMap = AttachedCloserToTheMap.GetComponent<CloserToTheMap>();
            if (_closerToTheMap != null)
            {
                Debug.Log("�uCloserToTheMap�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uAttachedCloserToTheMap�v�̓A�^�b�`����Ă��܂����A �uCloserToTheMap�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uAttachedCloserToTheMap�v�̓A�^�b�`����Ă��܂���B");
        }
    }

    private void FixedUpdate()
    {
        if (touchedObject != "" && !inputOn)
        {
            switch (touchedObject)
            {
                case "IRCamera":
                    Debug.Log("X�{�^���ŃJ�������������");
                    // �uX�{�^���ŃJ�������������v�ƕ\������UI��UI�S���҂�����
                    break;
                case "FloorMap":
                    Debug.Log("X�{�^���Ńt���A�}�b�v������");
                    // �uX�{�^���Ńt���A�}�b�v������v�ƕ\������UI��UI�S���҂�����
                    break;
            }
        }

        if (lookingAtMap)
        {
            _closerToTheMap.MReturnPosition();
            _closerToTheMap.MReturnRotation();
        }

        if (touchedObject != "" && inputOn && !lookingAtMap)
        {
            switch (touchedObject)
            {
                case "IRCamera":
                    _collectTheIRCamera.MCollectTheIRCamera();
                    _collectTheIRCamera.MAbortCoroutine();
                    break;
                case "FloorMap":
                    lookingAtMap = true;
                    _closerToTheMap.MMoveThePosition();
                    _closerToTheMap.MMoveTheRotation();
                    // �ォ��}�b�v���J���Ă��鎞�Ɉړ������b�N����@�\��ǉ�
                    // UI�S���҂�������Map�̃L�����o�X��\�����鏈����ǉ�
                    break;
            }
        }
    }
}*/
