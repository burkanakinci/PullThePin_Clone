using UnityEngine;

public class PinController : MonoBehaviour
{
    private bool touched;
    private Vector3 targetPos;
    private void OnEnable()
    {
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (touched)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 5f * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        targetPos = transform.position - transform.right * 5f;
        touched = true;
    }
}
