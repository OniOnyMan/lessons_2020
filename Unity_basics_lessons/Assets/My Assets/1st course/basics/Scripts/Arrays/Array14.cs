using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.My_Assets.Scripts.Arrays
{
    public class Array14 : MonoBehaviour
    {
        public Text Text;

        int[] array = new int[500];
        int[,] matrix = new int[10, 10];
        int[][] tearedArray = new int[10][];

        public void OnButtonPressed()
        {
            Text.text = "";
            for (int i = 0; i < array.Length; i++)
            {
                var dotNetRandom = new System.Random();
                array[i] = dotNetRandom.Next(0, 10);
                Text.text += array[i] + " ";
            }
        }

        public void OnMatrixCalled()
        {
            Text.text = "";
            int i = 0;
            do
            {
                int j = 0;
                while (j < matrix.GetLength(1))
                {
                    matrix[i, j] = Random.Range(0, 10);
                    Text.text += matrix[i, j] + " ";
                    j++;
                }
                Text.text += "\n";
                i++;
            }while (i < matrix.GetLength(0)) ;
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
}
