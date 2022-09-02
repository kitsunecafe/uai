using UnityEngine;

namespace JuniperJackal.UtilityAI
{
    public interface IConsideration
    {
        string Id { get; }
        float BaseScore { get; }
        float CalculateScore(GameObject gameObject);
    }
}