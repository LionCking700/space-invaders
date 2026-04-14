using UnityEngine;

public class BestScore : MonoBehaviour
{
    [SerializeField]
    private TextMash bestscoreText;
    public void UpdatebestScore(int bestScore)
    {
        int highScore = PlayerPrefabs.GetInt("BestScore", 0);
        if (bestScore > highScore)
        {
            PlayerPrefabs.SetInt("BestScore", bestScore);
            bestscoreText.text = "Best Score\n" + highScore.ToString();
        }
        else
        {
            bestscoreText.text = "Best Score\n" + highScore.ToString();
        }
    }
}
