using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("left");
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetBool("right", true);
        }
    }
}
