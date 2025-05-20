using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var newPosition = transform.position + Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;

        if (IsPositionOutOfCamera(newPosition))
        {
            ReusePipe();
            return;
        }
        else
        {
            transform.position = newPosition;
        }
    }

    // move pipe to the right of the camera to reuse
    private void ReusePipe()
    {
        var pipeWidth = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        var rightBound = CameraUtils.RightEdge();
        var randomY = Random.Range(-1f, 3f);
        transform.position = new Vector3(rightBound + pipeWidth / 2, randomY, 0);
    }

    private bool IsPositionOutOfCamera(Vector3 position)
    {
        float pipeWidth = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        float leftBound = CameraUtils.LeftEdge();

        return position.x < leftBound - pipeWidth / 2;
    }
}
