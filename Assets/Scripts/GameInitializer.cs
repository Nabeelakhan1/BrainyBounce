// GameInitializer.cs script
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private void Start()
    {
        if (!LevelManager.Instance.IsLevelUnlocked(1))
        {
            LevelManager.Instance.UnlockLevel(1);
        }
    }
}
