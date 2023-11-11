using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Feel
{
    public class CubeFeel : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform startTransform;
        [SerializeField] private Transform endTransform;
        [SerializeField] private Transform modelTransform;
        [SerializeField] private Renderer modelRenderer;
        [SerializeField] private float tweenDuration;
        [SerializeField] private float deformAmount;
        [SerializeField] private float shakeStrength;

        private Sequence _moveSequence;
        private Vector3 _defaultCamPos;

        private void Awake()
        {
            _defaultCamPos = cameraTransform.position;
        }

        [Button]
        private void PlayTween()
        {
            if ((_moveSequence != null && _moveSequence.IsPlaying()) || DOTween.IsTweening(transform)) return;
            
            transform.position = startTransform.position;
            transform.DOMove(endTransform.position, tweenDuration).SetEase(Ease.InOutExpo);
            
            _moveSequence = DOTween.Sequence();
            _moveSequence.Append(modelTransform.DOScaleY(1 - deformAmount, tweenDuration / 2).SetEase(Ease.InExpo));
            _moveSequence.Join(modelTransform.DOScaleX(1 + deformAmount, tweenDuration / 2).SetEase(Ease.InExpo));
            _moveSequence.Join(DOVirtual.Float(0 ,1f, tweenDuration / 2, ShakeCamera).SetEase(Ease.InExpo));
            _moveSequence.Join(DOVirtual.Color(Color.white , Color.red, tweenDuration / 2, ChangeColor).SetEase(Ease.InExpo));
            _moveSequence.Append(modelTransform.DOScaleY(1, tweenDuration / 2).SetEase(Ease.OutExpo));
            _moveSequence.Join(modelTransform.DOScaleX(1f, tweenDuration / 2).SetEase(Ease.OutExpo));
            _moveSequence.Join(DOVirtual.Float(1f ,0, tweenDuration / 2, ShakeCamera).SetEase(Ease.OutExpo));
            _moveSequence.Join(DOVirtual.Color(Color.red , Color.white, tweenDuration / 2, ChangeColor).SetEase(Ease.OutExpo));
            
        }

        private void ShakeCamera(float value)
        {
            cameraTransform.transform.position = _defaultCamPos 
                                                 + new Vector3(Random.Range(-value, value), Random.Range(-value, value), 0) * shakeStrength;
        }

        private void ChangeColor(Color color)
        {
            modelRenderer.sharedMaterial.color = color;
        }

        private void Update()
        {
        
        }
    }
}
