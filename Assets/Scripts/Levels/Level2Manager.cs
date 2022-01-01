using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    private LevelsData levelsData;

    private void Start()
    {
        levelsData = Resources.Load<LevelsData>("Prefabs/LevelsPrefab/LevelsData");

        levelsData.pin = Resources.Load<GameObject>("Prefabs/Pin");
        levelsData.frame = Resources.Load<GameObject>("Prefabs/Level1Frame");
        levelsData.pinPoses = GameObject.FindGameObjectsWithTag("PinPose");
        levelsData.ball = Resources.Load<GameObject>("Prefabs/Ball");
        levelsData.basket = Resources.Load<GameObject>("Prefabs/Basket");

        levelsData.ballPoses = GameObject.FindGameObjectsWithTag("SpawnPose");

        levelsData.SpawnLevel();
    }
}
