using UnityEngine;

namespace JuniperJackal.UtilityAI
{
    public interface IAction
    {
        string Id { get; }
        float BaseScore { get; }
        float CalculateScore(GameObject gameObject);
        void Execute(GameObject gameObject);
    }
}
