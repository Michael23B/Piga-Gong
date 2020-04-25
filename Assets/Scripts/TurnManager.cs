using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject[] player1GameObjects;
    public GameObject[] player2GameObjects;
    public Material player1Material;
    public Material player2Material;
    public Ball ball;
    private Renderer ballRenderer;

    // This start method will be executed after the ball start method (Project settings -> script execution order)
    private void Start()
    {
        ballRenderer = ball.GetComponent<Renderer>();
        // Set the initial player based on which direction the ball is moving
        if (ball.startingXDirection < 0)
        {
            OnPlayer2Hit();
        }
        else {
            OnPlayer1Hit();
        }
    }

    public void OnPlayer1Hit()
    {
        foreach (GameObject go in player1GameObjects)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in player2GameObjects)
        {
            go.SetActive(true);
        }

        // ballRenderer.material = player2Material;
    }

    public void OnPlayer2Hit()
    {
        foreach (GameObject go in player1GameObjects)
        {
            go.SetActive(true);
        }

        foreach (GameObject go in player2GameObjects)
        {
            go.SetActive(false);
        }

        // ballRenderer.material = player1Material;
    }
}
