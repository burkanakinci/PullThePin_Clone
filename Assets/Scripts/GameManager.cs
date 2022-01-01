using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    [SerializeField] private GameObject[] levelManScripts;
    public int level;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }
    void Start()
    {
        instance = this;

        level = 1;

        levelManScripts = Resources.LoadAll<GameObject>("Prefabs/LevelsPrefab");

        SpawnLevelOnManager();

        UIController.levelBegin += SpawnLevelOnManager;
    }

    public void SpawnLevelOnManager()
    {
        Instantiate(levelManScripts[level - 1], Vector3.zero, Quaternion.identity);
    }
}
