using System;
using BaseX.Utils;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.HealthSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Example
{
    public class TimerView : MonoBehaviour,IDisposable
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TextMeshProUGUI infoText;
        private CountDownType _countDownType;
        private float _duration;

        public void Initialize()
        {
        }

        public void Setup(float duration, CountDownType countDownType)
        {
            float initialValue = countDownType == CountDownType.Increase ? 0 : duration;
            Setup(duration, countDownType, initialValue);
        }

        public void Setup(float duration, CountDownType countDownType, float initialValue)
        {
            _countDownType = countDownType;
            _duration = duration;
            Reset();
            SetRange(0, _duration);
            
            slider.value = initialValue;
            infoText.text = DateUtils.SecondToReadableStringWithSymbol(initialValue);
            infoText.gameObject.SetActive(true);
            
            this.transform.DOScale(Vector3.one, .2f).SetEase(Ease.InOutElastic).OnStart(() =>
            {
                this.gameObject.SetActive(true);
            });
        }

        public void SetRange(float min, float max)
        {
            slider.minValue = min;
            slider.maxValue = max;
        }

        public void UpdateValue(float seconds)
        {
            slider.DOValue(seconds, 1f).OnComplete(() =>
            {
                infoText.text = DateUtils.SecondToReadableStringWithSymbol(seconds);
            }).SetEase(Ease.Linear);
        }

        public async UniTaskVoid Complete()
        {
            float value = _countDownType == CountDownType.Increase ? _duration : 0;
            infoText.text = DateUtils.SecondToReadableStringWithSymbol(value);
            await UniTask.Delay(TimeSpan.FromSeconds(.5f));
            Reset();
            this.transform.DOScale(Vector3.zero, .3f).SetEase(Ease.InOutBounce).OnComplete(() =>
            {
                this.gameObject.SetActive(false);
            });
        }

        public void Reset()
        {
            slider.value = 0;
            infoText.text = "";
            infoText.gameObject.SetActive(false);
        }

        public void Dispose()
        {
            Reset();
        }
    }
}