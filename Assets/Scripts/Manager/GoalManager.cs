using TMPro;
using UnityEngine;

namespace Manager
{
    public class GoalManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI currentScoreText;

        int currentScore;

        public void AddScore()
        {
            currentScore++;
            currentScoreText.text = currentScore.ToString();
        }
    }
}
