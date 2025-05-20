using UnityEngine;

public class PipeSpawner : MonoBehaviour, IObserver<GameStatus>
{
    public GameObject pipe;
    public float gap = 5;

    // spawn 2 pipes
    void Start()
    {
        gap = CameraUtils.RightEdge();
        GameManager.Instance.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // when game status changed
    public void OnUpdate(GameStatus gameStatus)
    {
        if (gameStatus == GameStatus.Running)
        {
            ClearAllPipes();
            SpanwInitialPipes();
        }
    }

    private void SpanwInitialPipes()
    {
        var startPositionX = Camera.main.transform.position.x;
        Vector3 firstPipePos = new Vector3(startPositionX + gap, Random.Range(-1f, 3f), 0);
        Vector3 secondPipePos = firstPipePos + new Vector3(gap, 0, 0);

        Instantiate(pipe, firstPipePos, Quaternion.identity);
        Instantiate(pipe, secondPipePos, Quaternion.identity);
    }

    private void ClearAllPipes()
    {
        var pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (var item in pipes)
        {
            Destroy(item);
        }
    }
}
