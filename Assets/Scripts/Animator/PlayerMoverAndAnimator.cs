using UnityEngine;

public class PlayerMoverAndAnimator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float speed = 0;
        float rotateSpeed = 0;

        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
            speed = _speed;
 
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * _speed * Time.deltaTime;
            speed = _speed;
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -_rotateSpeed * Time.deltaTime);
        }

        _animator.SetFloat("speed", speed);
    }
}
