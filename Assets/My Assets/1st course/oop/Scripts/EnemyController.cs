using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyController : HumanController
{
    public string Name = "Zombie";
    public int MaxLengthOfMessage = 10;

    public override string GetMessage()
    {
        StringBuilder builder = new StringBuilder(Name + " says: ");
        int countOfCharacters = Random.Range(1, MaxLengthOfMessage + 1);

        for (int i = 0; i < countOfCharacters; i++)
        {
            builder.Append(GetChar());
        }

        return builder.ToString();
    }

    private char GetChar()
    {
        if (Random.Range(0, 100) > 50)
        {
            return (char)Random.Range(65, 91);
        }
        else
        {
            return (char)Random.Range(97, 123);
        }
    }
}
