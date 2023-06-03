using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimationScript : MonoBehaviour
{
    [SerializeField] private Animation _animation;
    [SerializeField] private List<AnimationClip> _animationClips;

    private void Start()
    {
        PrepareClips();
    }

    private void PrepareClips()
    {
        // выставляем флаг legacy в true для того, чтобы компонент Animation мог с ними работат
        foreach (AnimationClip clip in _animationClips)
        {
            clip.legacy = true;
            _animation.AddClip(clip, clip.name);
        }
    }
}
