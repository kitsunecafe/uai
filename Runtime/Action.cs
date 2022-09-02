using UnityEngine;

namespace JuniperJackal.UtilityAI
{
    public abstract class Action : ScriptableObject, IAction
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

        [SerializeField]
        private Consideration[] considerations;

        public virtual float CalculateScore(GameObject gameObject)
        {
            var score = 1f;
            var len = considerations.Length;
            for (int i = 0; i < len; i++)
            {
                score *= considerations[i].CalculateScore(gameObject);

                if (score == 0)
                {
                    return 0;
                }
            }

            var modFactor = 1 - (1 / len);
            var makeupValue = (1 - score) * modFactor;
            return score + (makeupValue * score);
        }

        public abstract void Execute(GameObject gameObject);
    }
}
