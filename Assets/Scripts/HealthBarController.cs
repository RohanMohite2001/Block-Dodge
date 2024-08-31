using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthText;

    private void OnEnable()
    {
        player.OnHealthChanged += Player_OnHealthChanged;
    }

    private void OnDisable()
    {
        player.OnHealthChanged -= Player_OnHealthChanged;
    }

    private void Player_OnHealthChanged(object sender, Player.HealthChangedEventArgs e)
    {
        if (e.Health == 0)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            healthText.text = e.Health + "/" + e.MaxHealth;
            healthBar.fillAmount = e.Health / e.MaxHealth;
        }
    }
}
