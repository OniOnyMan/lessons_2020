using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrays13 : MonoBehaviour
{
    public Text Text;

    int[] arrayMax = new int[1000];
    int[,] matrix = new int[10, 10];
    int[][] tearedArray = new int[10][];

    //var rand = new System.Random();

    public void OnButtonPressed()
    {
        Text.text = "";
        for (int i = 0; i < arrayMax.Length; i++)
        {
            arrayMax[i] = UnityEngine.Random.Range(0, 10 + 1);
            //arrayMax[i] = rand.Next(0, 10 + 1);
            Text.text += arrayMax[i] + " ";
        }
    }

    public void OnMatrixCalled()
    {
        Text.text = "";
        int i = 10;
        do
        {
            int j = 0;
            while (j < matrix.GetLength(1))
            {
                matrix[i, j] = UnityEngine.Random.Range(0, 10);
                Text.text += matrix[i, j] + " ";
                j++;
            }
            Text.text += "\n";
            i++;
        } while (i < matrix.GetLength(0));
    }

    public void OnTearedArrayCalled()
    {
        Text.text = "";
        for (int i = 0; i < tearedArray.Length; i++)
        {
            tearedArray[i] = new int[Random.Range(0, 11)];
            for (int j = 0; j < tearedArray[i].Length; j++)
            {
                tearedArray[i][j] = Random.Range(0, 10);
                Text.text += tearedArray[i][j] + " ";
            }
            Text.text += "\n";
        }
    }
}
