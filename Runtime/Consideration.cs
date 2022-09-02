using UnityEngine;

namespace JuniperJackal.UtilityAI
{
    public abstract class Consideration : ScriptableObject, IConsideration
    {
        [SerializeField]
        private string id;
        public string Id => id;

        [SerializeField, Range(0f, 1f)]
        private float baseScore = 0f;
        public float BaseScore
        {
            get => baseScore;
            set
            {
                var clampedValue = Mathf.Clamp01(value);

                if (baseScore != clampedValue)
                {
                    baseScore = clampedValue;
                }
            }
        }

        public abstract float CalculateScore(GameObject gameObject);
    }
}