using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _smoothRotation = 0.3f;
    [SerializeField] private StickMove _testMove;

    private Rigidbody _rihidBody;
    private Animator _animator;
    private PlayerInput _playerInput;
    private Vector2 _stickPosition;
    private Vector3 _direction;
    private Vector3 _zeroVector;
    private Vector3 _directionRotate;
    private bool _canMove;

    public event UnityAction Track;

    private void OnValidate()
    {
        if(_smoothRotation > 1.0f)
            _smoothRotation = 1.0f;
        if (_smoothRotation < 0f)
            _smoothRotation = 0f;
    }
    private void Awake()
    {
        _direction = _directionRotate = _zeroVector = new Vector3();
        _rihidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerInput = new PlayerInput();
        _playerInput.Enable();

        CanPlayerMove(true);
    }
    private void Update()
    {
        //_stickPosition = _playerInput.Player.Move.ReadValue<Vector2>();
        _stickPosition = _testMove.Position;

    }

    private void FixedUpdate()
    {
        _animator.SetFloat("Speed", GetMaxAbsValue(_stickPosition));
        _rihidBody.velocity = _zeroVector;
        if(_canMove && GetMaxAbsValue(_stickPosition) > 0)
        {
            Move();
            Rotate();
        }
        
    }
    public void CanPlayerMove(bool condition )
    {
        _canMove = condition;
    }
    private void Rotate()
    {
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.Euler(0, Mathf.Atan2(_stickPosition.x, _stickPosition.y) * Mathf.Rad2Deg ,0),
            _smoothRotation);
    }
    private void Move()
    {  
        _direction.x = _stickPosition.x;
        _direction.z = _stickPosition.y;
        _rihidBody.velocity = _direction * _speed ;
        Track?.Invoke();
    }
    private float GetMaxAbsValue(Vector2 vector)
    {
        if(Mathf.Abs(vector.x) > Mathf.Abs(vector.y))
            return Mathf.Abs(vector.x);
        else
            return Mathf.Abs(vector.y);
    }
}
