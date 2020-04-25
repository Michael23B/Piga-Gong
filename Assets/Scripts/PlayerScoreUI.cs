using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreUI : MonoBehaviour
{
    public string scoreText = "Boints: {score}";
    public Text text;
    private float playerScore = 0;
    private string displayedText;

    public void IncreaseScore()
    {
        playerScore++;
        RedrawText();
    }

    public void ResetScore()
    {
        playerScore = 0;
        RedrawText();
    }

    private void RedrawText()
    {
        text.text = scoreText.Replace("{score}", playerScore.ToString());
    }
}
