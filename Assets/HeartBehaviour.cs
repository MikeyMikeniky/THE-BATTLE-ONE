using UnityEngine;
using UnityEngine.UI;

public class HeartBehaviour : MonoBehaviour
{
    public int health = 10;
    [SerializeField] private int maxHealth = 10;

    [SerializeField] private Image[] hearts;

    [SerializeField] private Sprite fullHeart, halfHeart, emptyHeart;

    public Player player;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Hide hearts above max health
            if (i < maxHealth / 2)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
                continue;
            }

            // Full hearts
            if (i < player.Health / 2)
            {
                hearts[i].sprite = fullHeart;
            }
            // Half heart
            else if (i == player.Health / 2 && player.Health % 2 == 1)
            {
                hearts[i].sprite = halfHeart;
            }
            // Empty heart
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}