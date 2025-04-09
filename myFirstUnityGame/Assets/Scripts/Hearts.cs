using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    private Image[] hearts; // Array waarin we alle hartjes opslaan
    private int lives; // Huidig aantal levens
    private int maxLives; // Maximaal aantal levens

    void Start()
    {
        // Alle UI-afbeeldingen ophalen
        Image[] images = GetComponentsInChildren<Image>();
        int count = 0;

        // Tellen hoeveel hartjes er zijn
        foreach (Image img in images)
        {
            if (img.name == "Heart")
            {
                count++;
            }
        }

        // Array maken om hartjes op te slaan
        hearts = new Image[count];
        count = 0;

        // Hartjes opslaan in de array
        foreach (Image img in images)
        {
            if (img.name == "Heart")
            {
                hearts[count] = img;
                count++;
            }
        }

        // Aantal levens instellen op basis van het aantal hartjes
        lives = hearts.Length;
        maxLives = hearts.Length;
    }

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value <= maxLives && value >= 0)
            {
                lives = value;

                // Hartjes in- en uitschakelen
                for (int i = 0; i < hearts.Length; i++)
                {
                    hearts[i].enabled = i < lives;
                }

                // Als de levens op zijn, stop de game
                if (lives == 0) PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Debug.Log("Game Over!"); // Debug-melding voor testing
        Time.timeScale = 0f; // Zet de game op pauze
    }
}
