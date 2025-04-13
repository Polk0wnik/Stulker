using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHp : MonoBehaviour
{
    private Image hpChar;
    public TextMeshProUGUI gameText;
    private float currentHp  = 100f;
    private void Awake()
    {
        hpChar = GetComponentInChildren<Image>();
        Time.timeScale = 1;
    }
    private void Update()
    {
        hpChar.fillAmount = currentHp / 100f;
    }
    public void TakeDamage(float damage)
    {
        if (currentHp <= 0)
        {
            // Вкл анимацию смерти
            // Выкл управление игроком
            // Подождать анимацию 4 секунды
            // Открыть меню закргузки игры
            Time.timeScale = 0;
            gameText.text = "Game over";
        }
        else
        {
            currentHp -= damage;
        }
    }
    public void HealHp(float healHp)
    {
        currentHp += healHp;
    }
}
