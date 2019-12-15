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

    private void Start()
    {
        Console.text = string.Empty + string.Format("Текущие параметры: Health (+ Armor): {0}, (+{1}), Damage: {2}, Money: {3}, Xp: {4}, Pos: {5}\n", Health, Armor, Damage, Money, Xp, WorldPosition);
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

        Console.text += string.Format("Сохранены параметры: Health (+ Armor): {0}, (+{1}), Damage: {2}, Money: {3}, Xp: {4}, Pos: {5}\n", Health, Armor, Damage, Money, Xp, WorldPosition);
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
        Console.text += string.Format("Текущие параметры: Health (+ Armor): {0}, (+{1}), Damage: {2}, Money: {3}, Xp: {4}, Pos: {5}\n", Health, Armor, Damage, Money, Xp, WorldPosition);
    }
}
