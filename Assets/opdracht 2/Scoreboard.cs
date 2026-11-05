using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private TextMeshProUGUI textScore;
    private int Score;
    void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
        textScore.text = "Score: 0";
    }

    void OnEnable()
    {
        Pickup.OnPickup += ScoreAdded;
    }

    void OnDisable()
    {
        Pickup.OnPickup -= ScoreAdded;
    }

    private void ScoreAdded(int points)
    {
        Score += points;
        textScore.text = $"Score: {Score}";
    }
}
