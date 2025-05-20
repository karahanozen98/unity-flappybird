using UnityEngine;

public class PlayerController : MonoBehaviour, IObserver<GameStatus>
{
    public Rigidbody2D Rigidbody2D;
    public float JumpStrength;

    void Start()
    {
        enabled = false;
        Rigidbody2D.gravityScale = 0;
        GameManager.Instance.Subscribe(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.W) ||
            Input.GetMouseButtonUp(1))
        {
            this.Rigidbody2D.linearVelocityY = JumpStrength;
        }
    }

    // when passes through between pipes
    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameManager.Instance.IncreaseScore();
    }

    // when hits pipes
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }

    public void OnUpdate(GameStatus gameStatus)
    {
        enabled = gameStatus == GameStatus.Running;

        if (gameStatus == GameStatus.Running)
        {
            InitializePlayer();
        }
    }

    private void InitializePlayer()
    {
        Rigidbody2D.linearVelocity = new Vector2(0, 0);
        Rigidbody2D.angularVelocity = 0f;
        Rigidbody2D.gravityScale = 2;
        Rigidbody2D.rotation = 0;
        transform.position = new Vector3(0f, 0f, 0f);
    }
}
