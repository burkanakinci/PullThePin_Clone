using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> framePool = new List<GameObject>();
    [SerializeField] private List<GameObject> ballPool = new List<GameObject>();
    [SerializeField] private List<GameObject> basketPool = new List<GameObject>();
    [SerializeField] private List<GameObject> pinPool = new List<GameObject>();
    private GameObject tempBall;

    private void Start()
    {
        UIController.nextLevelProv += ClearScene;
    }

    public void SpawnFrame(GameObject _frame)
    {
        if (framePool.Count > 0)
        {
            for (int i = framePool.Count - 1; i >= 0; i--)
            {
                if (_frame == framePool[i])
                {
                    framePool[i].SetActive(true);
                    framePool.Remove(framePool[i]);
                    break;
                }
                else if (i == framePool.Count - 1)
                {
                    Instantiate(_frame, Vector3.zero, Quaternion.identity);
                }
            }
        }
        else
        {
            Instantiate(_frame, Vector3.zero, Quaternion.identity);
        }
    }
    public void SpawnPin(GameObject[] _pinPoses, GameObject _pin)
    {
        for (int j = _pinPoses.Length - 1; j >= 0; j--)
        {
            if (pinPool.Count > 0)
            {
                pinPool[0].SetActive(true);
                pinPool[0].transform.position = _pinPoses[j].transform.position;
                pinPool[0].transform.eulerAngles = _pinPoses[j].transform.eulerAngles;
                pinPool.Remove(pinPool[0]);
            }
            else
            {
                Instantiate(_pin, _pinPoses[j].transform.position, _pinPoses[j].transform.rotation);
            }
        }

    }
    public void SpawnBall(int _ballCount, GameObject[] _ballPoses, GameObject _ball)
    {

        for (int k = _ballPoses.Length - 1; k >= 0; k--)
        {
            for (int l = _ballCount; l > 0; l--)
            {
                if (ballPool.Count > 0)
                {
                    tempBall = ballPool[0];
                    ballPool[0].SetActive(true);
                    ballPool[0].transform.position = _ballPoses[k].transform.position;
                    ballPool.Remove(ballPool[0]);
                }
                else
                {
                    tempBall = Instantiate(_ball, _ballPoses[k].transform.position, Quaternion.identity);
                }
                if (k == _ballPoses.Length - 1)
                    tempBall.GetComponent<BallController>().ColorChange();
            }
        }
    }
    public void SpawnBasket(GameObject _basket)
    {
        if (basketPool.Count > 0)
        {
            for (int i = basketPool.Count - 1; i >= 0; i--)
            {
                if (_basket == basketPool[i])
                {
                    basketPool[i].SetActive(true);
                    basketPool.Remove(basketPool[i]);
                    break;
                }
                else if (i == basketPool.Count - 1)
                {
                    Instantiate(_basket, new Vector3(0f, -1f, 0f), Quaternion.identity);
                }
            }
        }
        else
        {
            Instantiate(_basket, new Vector3(0f, -1f, 0f), Quaternion.identity);
        }
    }
    public void ClearScene()
    {
        GameObject tempLevel;
        tempLevel = GameObject.FindGameObjectWithTag("LevelPrefab");
        Destroy(tempLevel);

        ClearBall();
        ClearPin();
        ClearBasket();
        ClearFrame();
    }

    private void ClearBall()
    {
        BallController[] tempBalls;
        tempBalls = FindObjectsOfType<BallController>();

        for (int b = tempBalls.Length - 1; b >= 0; b--)
        {
            ballPool.Add(tempBalls[b].gameObject);
            tempBalls[b].gameObject.SetActive(false);
        }
    }
    private void ClearPin()
    {
        PinController[] tempPins;
        tempPins = FindObjectsOfType<PinController>();

        for (int p = tempPins.Length - 1; p >= 0; p--)
        {
            pinPool.Add(tempPins[p].gameObject);
            tempPins[p].gameObject.SetActive(false);
        }
    }
    private void ClearBasket()
    {
        GameObject[] tempBasket;
        tempBasket = GameObject.FindGameObjectsWithTag("Basket");

        for (int p = tempBasket.Length - 1; p >= 0; p--)
        {
            basketPool.Add(tempBasket[p].gameObject);
            tempBasket[p].gameObject.SetActive(false);
        }
    }
    private void ClearFrame()
    {
        GameObject[] tempFrame;
        tempFrame = GameObject.FindGameObjectsWithTag("Frame");

        for (int p = tempFrame.Length - 1; p >= 0; p--)
        {
            framePool.Add(tempFrame[p].gameObject);
            tempFrame[p].gameObject.SetActive(false);
        }
    }
}
