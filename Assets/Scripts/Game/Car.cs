using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;
    private Vector2 _playerDirection;
    private void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        _playerDirection = new Vector2(0, directionY).normalized;
    }
    private void FixedUpdate()
    {
        if(_gameManager.gameStarted == true)
            _rigidbody.velocity = new Vector2(0, _playerDirection.y * _playerSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            _gameManager.GameOver();
        }
        if(collision.transform.tag == "Money")
        {
            Destroy(collision.gameObject);
            _gameManager.score+= 30;
            _gameManager.TextsUpdate();
        }
    }
}
