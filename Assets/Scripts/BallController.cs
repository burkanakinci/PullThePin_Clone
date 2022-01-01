using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rbBall;
    private RigidbodyConstraints noneConstrain;
    private RigidbodyConstraints zPosConstrain;
    private SphereCollider col;
    private PlayerController playerController;
    private UIController uIController;
    private MeshRenderer meshRenderer;
    [SerializeField] private List<Color> ballColors;
    private bool isCover;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rbBall = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();

        uIController = FindObjectOfType<UIController>();
        playerController = FindObjectOfType<PlayerController>();

        noneConstrain = RigidbodyConstraints.None;
        zPosConstrain = RigidbodyConstraints.FreezePositionZ;
    }
    private void OnEnable()
    {
        meshRenderer.material.color = Color.white;

        rbBall.constraints = zPosConstrain;
        isCover = false;
    }

    public void ColorChange()
    {
        meshRenderer.material.color = ballColors[Random.Range(0, ballColors.Count - 1)];
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FrameCover") &&
            !isCover &&
            meshRenderer.material.color != Color.white)
        {
            playerController.coverCount++;
            rbBall.constraints = noneConstrain;
            isCover = true;

            uIController.ShowBallRatio();

            if (!uIController.isNextPanel)
            {
                uIController.isNextPanel = true;
                uIController.ShowNextLevelPanel();
            }
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ball") &&
            meshRenderer.material.color == Color.white &&
            other.gameObject.GetComponent<MeshRenderer>().material.color != Color.white)
        {
            ColorChange();
        }
    }

}
