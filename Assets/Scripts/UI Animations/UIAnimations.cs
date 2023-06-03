using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIAnimations : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private Animation _screen0Animation;
    [SerializeField] private Animation _screen1Animation;

    [SerializeField] private Animation _animation;
    [SerializeField] private List<UIAnimationModel> _animationClips;

    private void Start()
    {
        PrepareClips();
    }

    private void PrepareClips()
    {
        // ���������� ���� legacy � true ��� ����, ����� ��������� Animation ��� � ���� �������
        foreach (UIAnimationModel model in _animationClips)
        {
            model.Clip.legacy = true;
            _animation.AddClip(model.Clip, model.Name);
        }
    }

    // ���� ����� ��������� ����� ������ ���� ������ � ������ UI ��������, �� ������� ����� ������
    public void OnPointerEnter(PointerEventData eventData)
    {
        _animation.PlayQueued("ScaleUp");
    }

    // ���� ����� ��������� ����� ������ ���� ������ �� ������� UI ��������, �� ������� ����� ������
    public void OnPointerExit(PointerEventData eventData)
    {
        _animation.Play("ScaleDown");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _animation.Play("ChangeColor");
    }

    public void OnButtonDown()
    {
        _screen0Animation.Play();
        _screen1Animation.Play();
    }
}
