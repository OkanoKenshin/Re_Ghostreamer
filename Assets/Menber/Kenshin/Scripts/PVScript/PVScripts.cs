using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem;

public class PVScripts : MonoBehaviour
{
    // Start is called before the first frame update
    int numOfGhost = 1;
    int numOfStreamer = 1;
    private void Start()
    {
        InputSystem.onEvent += GetPressdButton;
    }

    public void GetPressdButton(InputEventPtr eventPtr, InputDevice device)
    {
        var getPressButton = eventPtr.GetFirstButtonPressOrNull();
        // Button“ü—Í‚ðŒŸ’m

        if (getPressButton != null)
        {
            for (int i = 0; i < numOfGhost; i++)
            {
                string objectName= "Ghost";
                Vector3 spawnPoint = new Vector3(65.78f, 83.75f, -14.88f);
                Quaternion spawnRotate = Quaternion.Euler(0.0f, 250.665f, 0.0f);
                ObjectPool.Instance.SpawnFromPool(objectName,spawnPoint,spawnRotate);
    
            }
            for (int i = 0; i < numOfStreamer; i++)
            {
                string objectName= "Streamer";
                Vector3 spawnPoint = new Vector3(30.01f, 83.8f, -23.77f);
                Quaternion spawnRotate = Quaternion.Euler(0f, 43.123f, 0f);
                ObjectPool.Instance.SpawnFromPool(objectName, spawnPoint, spawnRotate);

            }
        }
        
    }
}
