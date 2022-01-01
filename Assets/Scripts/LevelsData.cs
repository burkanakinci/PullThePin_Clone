using UnityEngine;

[CreateAssetMenu(fileName = "LevelsData", menuName = "Levels Data")]
public class LevelsData : ScriptableObject
{
    public GameObject frame;
    public GameObject[] pinPoses;
    public GameObject ball;
    public GameObject basket;
    public GameObject[] ballPoses;
    public GameObject pin;
    public int ballCount = 450;
    private SpawnManager spawnManager;
    private PlayerController playerController;


    public void SpawnLevel()
    {
        spawnManager = FindObjectOfType<SpawnManager>();

        spawnManager.SpawnFrame(frame);
        spawnManager.SpawnPin(pinPoses, pin);
        playerController = FindObjectOfType<PlayerController>();
        playerController.ballCountInScene = ballCount * ballPoses.Length;
        spawnManager.SpawnBall(ballCount, ballPoses, ball);
        spawnManager.SpawnBasket(basket);
    }

}
