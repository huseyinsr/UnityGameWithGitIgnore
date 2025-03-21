using UnityEngine;
using TMPro;

public class KeepScore : MonoBehaviour
{
    private TMP_Text scoreField;
    private int score = 0;

    void Start()
    {
        scoreField = GetComponent<TMP_Text>();
        score = 0;
        scoreField.text = score.ToString();
    }

    public void AddScore(int add)
    {
        score += add;
        scoreField.text = score.ToString();
    }
}
