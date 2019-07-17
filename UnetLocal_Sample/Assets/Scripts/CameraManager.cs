using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        //look at my player
        // ReSharper disable once Unity.PerformanceCriticalCodeNullComparison
        if (PlayerManager.MyPlayer != null)
            transform.LookAt(PlayerManager.MyPlayer.transform);
    }
}