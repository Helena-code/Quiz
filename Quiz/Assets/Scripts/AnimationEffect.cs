using UnityEngine;
using DG.Tweening;

public class AnimationEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject _cellImageContent;

    [SerializeField]
    private GameObject _cellImage;

    private ParticleSystem _particleEffect;
    private GameObject _particleEffectGO;
    private Sequence _sequenceB;
    private Sequence _sequenceE;
    private Transform _currentImageTransform;

    public void PlayWrongAnswerAnimation()
    {
        PlayEaseInBounseEffect(_cellImageContent);
    }

    public void PlayRightAnswerAnimation()
    {
        PlayBounceEffect(_cellImageContent);
        _particleEffectGO.SetActive(true);
    }

    private void Start()
    {
        _particleEffect = GetComponentInChildren<ParticleSystem>();
        _particleEffectGO = _particleEffect.gameObject;
        _particleEffectGO.SetActive(false);
        DOTween.Init();
        PlayBounceEffect(_cellImage);
    }

    private void PlayBounceEffect(GameObject currentImage)
    {
        _sequenceB = DOTween.Sequence();
        _sequenceB.Append(currentImage.transform.DOScale(new Vector3(0f, 0f, 0f), 0.1f));
        _sequenceB.Append(currentImage.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f));
        _sequenceB.Append(currentImage.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.5f));
        _sequenceB.Append(currentImage.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f));
    }

    private void PlayEaseInBounseEffect(GameObject currentImage)
    {
        _currentImageTransform = currentImage.transform;
        _sequenceE = DOTween.Sequence();
        _sequenceE.Append(currentImage.transform.DOMoveX(_currentImageTransform.position.x * (1.2f), 0.05f, false));
        _sequenceE.Append(currentImage.transform.DOMoveX(_currentImageTransform.position.x * (1.09f), 0.05f, false));
        _sequenceE.Append(currentImage.transform.DOMoveX(_currentImageTransform.position.x, 0.05f, false));
        _sequenceE.Append(currentImage.transform.DOMoveX(_currentImageTransform.position.x * (0.8f), 0.05f, false));
        _sequenceE.Append(currentImage.transform.DOMoveX(_currentImageTransform.position.x * (0.9f), 0.05f, false));
        _sequenceE.Append(currentImage.transform.DOMoveX(_currentImageTransform.position.x, 0.05f, false));
        _sequenceE.Append(currentImage.transform.DOMoveX(_currentImageTransform.position.x * (1.2f), 0.05f, false));
        _sequenceE.Append(currentImage.transform.DOMoveX(_currentImageTransform.position.x * (1.09f), 0.05f, false));
        _sequenceE.Append(currentImage.transform.DOMoveX(_currentImageTransform.position.x, 0.05f, false));
        _sequenceE.Append(currentImage.transform.DOMoveX(_currentImageTransform.position.x * (0.8f), 0.05f, false));
        _sequenceE.Append(currentImage.transform.DOMoveX(_currentImageTransform.position.x * (0.9f), 0.05f, false));
        _sequenceE.Append(currentImage.transform.DOMoveX(_currentImageTransform.position.x, 0.05f, false));
    }
}
