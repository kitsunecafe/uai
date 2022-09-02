using UnityEngine;

namespace JuniperJackal.UtilityAI.Extensions
{
    public static class UtilityAIExtensions
    {
        public static IAction FindTopAction(this IAction[] actions, GameObject gameObject)
        {
            float score = 0f;
            int bestIndex = 0;

            for (int i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                if (action.CalculateScore(gameObject) > score)
                {
                    bestIndex = i;
                    score = action.BaseScore;
                }
            }

            return actions[bestIndex];
        }
    }
}