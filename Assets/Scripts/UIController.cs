using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UIController : MonoBehaviour
{
    private PlayerController playerController;
    public static event Action nextLevelProv;
    public static event Action levelBegin;
    [SerializeField] private TextMeshProUGUI ballRatio;
    [SerializeField] private TextMeshProUGUI nextButton;
    [SerializeField] private GameObject nextLevelPanel;
    public bool isNextPanel;
    //private GameManager gameManager;

    private void Start()
    {

        playerController = FindObjectOfType<PlayerController>();
        // gameManager = FindObjectOfType<GameManager>();

        isNextPanel = false;
        nextLevelPanel.SetActive(false);

        nextLevelProv += ShowBallRatio;
    }
    public void ShowBallRatio()
    {
        ballRatio.text = ((playerController.coverCount * 100) / playerController.ballCountInScene).ToString() + "%";
    }
    public void ShowNextLevelPanel()
    {
        Invoke("NextLevPanActive", 5f);
    }

    private void NextLevPanActive()
    {
        isNextPanel = false;

        if (!nextLevelPanel.activeInHierarchy)
        {
            nextLevelPanel.SetActive(true);
        }

        if (GameManager.Instance.level >= 3)
            GameManager.Instance.level = 1;
        else
        {
            GameManager.Instance.level++;
        }

        playerController.coverCount = 0;
        nextButton.text = (GameManager.Instance.level).ToString() + "Level";
        nextLevelProv?.Invoke();
    }
    public void NextLevelButton()
    {
        if (nextLevelPanel.activeInHierarchy)
        {
            nextLevelPanel.SetActive(false);
        }
        levelBegin?.Invoke();
    }
}
