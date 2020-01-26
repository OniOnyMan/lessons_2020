using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Stats")]
    public int Health = 10;
    public int Damage = 2;
    public Vector3 WorldPosition = new Vector3(0, 0);
    public float Money = 10;
    public int Armor = 5;
    public int Xp = 0;

    [Space]
    [Header("Staff")]
    public Text Console;
    public bool IsNewGame = false;
    public bool IsXpIncrease = true;
    public int MaxXpIncrease = 100;
    public float MoneyChanseIncrease = 32.5f;
    public int MoneyMaxIncrease = 100;
    public float GetDamageChanse = 45.9f;
    public int ArmorResistance = 23;

    private void Start()
    {
        Console.text = string.Empty;

        if (IsNewGame)
            ShowStats();
        else
            Load();
    }

    private void Update()
    {
        StartCoroutine(XpIncrease());
    }

    private IEnumerator XpIncrease()
    {
        while (IsXpIncrease)
        {
            var value = Random.Range(MaxXpIncrease / 2, MaxXpIncrease);
            yield return new WaitForSecondsRealtime(value * 25);
            Xp += value;
            Console.text += string.Format("Получен опыт в размере {0}\n", value);
            ShowStats();
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Health", Health);
        PlayerPrefs.SetInt("Armor", Armor);
        PlayerPrefs.SetInt("Damage", Damage);
        PlayerPrefs.SetFloat("Money", Money);
        PlayerPrefs.SetInt("Xp", Xp);

        PlayerPrefs.SetFloat("WorldPositionX", WorldPosition.x);
        PlayerPrefs.SetFloat("WorldPositionY", WorldPosition.y);
        PlayerPrefs.SetFloat("WorldPositionZ", WorldPosition.z);

        PlayerPrefs.Save();
        ShowStats();
        Console.text += "успешно сохранены\n";
    }

    public void Load()
    {
        Health = PlayerPrefs.GetInt("Health");
        Armor = PlayerPrefs.GetInt("Armor");
        Damage = PlayerPrefs.GetInt("Damage");
        Money = PlayerPrefs.GetFloat("Money");
        Xp = PlayerPrefs.GetInt("Xp");

        WorldPosition = new Vector3(PlayerPrefs.GetFloat("WorldPositionX"),
                                    PlayerPrefs.GetFloat("WorldPositionY"),
                                    PlayerPrefs.GetFloat("WorldPositionZ"));

        Console.text += "Сохранение загружено\n";
        ShowStats();
    }

    public void ShowStats()
    {
        Console.text += string.Format("Текущие параметры: Health (+ Armor): {0}, (+{1}), Damage: {2}, Money: {3}, Xp: {4}, Pos: {5}\n", Health, Armor, Damage, Money, Xp, WorldPosition);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void HealUp()
    {
        //var count = Random.Range(1, 10);
        Health += count;
        Console.text += string.Format("Уух, спасибо! Health увеличено на {0}\n", count);
        ShowStats();
    }

    public void Teleport()
    {
        var x = Random.Range(float.MinValue / 2, float.MaxValue / 2);
        var y = Random.Range(float.MinValue / 2, float.MaxValue / 2);
        var z = Random.Range(float.MinValue / 2, float.MaxValue / 2);
        WorldPosition = new Vector3(x, y, z);
        Console.text += string.Format("Воооуу!!! WorldPosition перемещено на {0}\n", WorldPosition);
        ShowStats();
    }

    public void TryLuck()
    {
        var chanse = Random.Range(0, 100f);
        var value = Random.Range(0, MoneyMaxIncrease);
        if (chanse <= MoneyChanseIncrease)
        {
            Money += value;
            Console.text += string.Format("Ух ты, зарплату выдали. Получено денег: {0}\n", value);
        }
        else
        {
            if (Money - value > 0)
            {
                Money -= value;
                Console.text += string.Format("Живот заболел, пришлось идти к врачу. Потрачено денег: {0}", value);
            }
            else
            {
                Money = 0;
                Console.text += "Зря я пошёл в этот переулок. Недоброжелатели отжали все деньги.\n";
            }
        }
        ShowStats();
    }

    public void GetDamage()
    {
        if (Health > 1)
        {
            var chanse = Random.Range(0, 100f);
            if (chanse <= GetDamageChanse)
            {
                var value = Damage - Armor * 100 / ArmorResistance / 10;
                if (Health - value > 1)
                {
                    Health -= value;
                    Armor -= value / 10;
                    Console.text += string.Format("Ай, надение огра! Получен урон: {0}\n", value);
                }
                else
                {
                    Health = 1;
                    Armor = 0;
                    Console.text += "Ну, всё. Жмите F!\n";
                }
            }
            else
            {
                Console.text += "Сегодня похоже мой день, и ничего не произошло...\n";
            }
        }
        else
        {
            Console.text += "Я и так при смерти, куда уж больше то?!\n";
        }
        ShowStats();
    }
}
