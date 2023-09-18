using UnityEngine;

namespace Rino.Shared.Utils
{
    public static class EaseUtility
    {
        public enum Ease
        {
            Linear = 0,
            InSine = 1, OutSine = 2, InOutSine = 3,
            InQuad = 4, OutQuad = 5, InOutQuad = 6,
            InCubic = 7, OutCubic = 8, InOutCubic = 9,
            InQuart = 10, OutQuart = 11, InOutQuart = 12,
            Zero = 13, One = 14
        }

        // Todo: Remove the ranges
        public static float Evaluate(Ease easeType, float time, float duration, float startRange, float endRange)
        {
            var range = endRange - startRange;
            var realTime = duration * startRange + time * range;
            var startEase = Evaluate(easeType, startRange, 1f);
            var endEase = Evaluate(easeType, endRange, 1f);
            var easeRange = endEase - startEase;
            return (Evaluate(easeType, realTime, duration) - startEase) / easeRange;
        }

        private const float PI = 3.141592654f;
        public static float Evaluate(Ease easeType, float time, float duration)
        {
            var value = time / duration;

            if (duration == 0) return 1f;
            
            if (value < 0f) return 0f;
            if (value > 1f) return 1f;
            return easeType switch
            {
                Ease.Linear => value,
                Ease.InSine => 1 - Mathf.Cos(value * PI * 0.5f),
                Ease.OutSine => Mathf.Sin(value * PI * 0.5f),
                Ease.InOutSine => -(Mathf.Cos(value * PI) - 1) * 0.5f,
                Ease.InQuad => value * value,
                Ease.OutQuad => 1 - (1 - value) * (1 - value),
                Ease.InOutQuad => value < 0.5 ? 2 * value * value : 1 - Mathf.Pow(-2 * value + 2, 2) * 0.5f,
                Ease.InCubic => value * value * value,
                Ease.OutCubic => 1 - Mathf.Pow(1 - value, 3),
                Ease.InOutCubic => value < 0.5 ? 4 * Mathf.Pow(value, 3) : 1 - Mathf.Pow(-2 * value + 2, 3) * 0.5f,
                Ease.InQuart => value * value * value * value,
                Ease.OutQuart => 1 - Mathf.Pow(1 - value, 4),
                Ease.InOutQuart => value < 0.5 ? 8 * Mathf.Pow(value, 4) : 1 - Mathf.Pow(-2 * value + 2, 4) * 0.5f,
                Ease.Zero => 0f,
                Ease.One => 1f,
                _ => value
            };
        }
    }
}
