using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Text;

public class ArrayLesson : MonoBehaviour
{
    public ToggleGroup ToggleGroup;
    public float[] ArrayField;
    public int[,] MatrixField;
    public int[][] ArrayArrayField;
    public Text ResultText;

    public void ButtonPressed()
    {
        //ertyuieqopf[wsefwefwef
        //wtygqhuvjwdfem,.g
        // yfguhjikgl;T''
        ResultText.text = "";
        var activeToggle = ToggleGroup.ActiveToggles().First();
        switch (activeToggle.name)
        {
            case "Array":
                {
                    ArrayInitialize();
                }
                break;
            case "ArrayArray":
                {
                    ArrayArrayInitialize();
                }
                break;
            default:
                {
                    MatrixInitialize();
                }
                break;
        }
    }

    private void ArrayInitialize()
    {
        ArrayField = new float[UnityEngine.Random.Range(5, 12)];
        for (int i = 0; i < ArrayField.Length; i++)
        {
            ArrayField[i] = UnityEngine.Random.Range(0f, 100);
        }

        var strbd = new StringBuilder();
        for (int i = 0; i < ArrayField.Length; i++)
        {
            strbd.Append(ArrayField[i] + " ");
        }

        ResultText.text = strbd.ToString();
    }

    private void MatrixInitialize()
    {
        var dotNetRandom = new System.Random();
        MatrixField = new int[dotNetRandom.Next(1, 10), dotNetRandom.Next(1, 10)];
        for (int i = 0; i < MatrixField.GetLength(0); i++)
        {
            for (int j = 0; j < MatrixField.GetLength(1); j++)
            {
                MatrixField[i, j] = dotNetRandom.Next(10, 100);
            }
        }

        var strbd = new StringBuilder();
        for (int i = 0; i < MatrixField.GetLength(0); i++)
        {
            for (int j = 0; j < MatrixField.GetLength(1); j++)
            {
                strbd.Append(MatrixField[i, j] + " ");
            }
            strbd.Append("\n");
        }
        ResultText.text = strbd.ToString();
    }

    private void ArrayArrayInitialize()
    {
        ArrayArrayField = new int[UnityEngine.Random.Range(1, 10)][];
        for (int i = 0; i < ArrayArrayField.Length; i++)
        {
            ArrayArrayField[i] = new int[UnityEngine.Random.Range(1, 10)];
            for (int j = 0; j < ArrayArrayField[i].Length; j++)
            {
                ArrayArrayField[i][j] = UnityEngine.Random.Range(10, 100);
            }
        }

        var strbd = new StringBuilder();
        for (int i = 0; i < ArrayArrayField.Length; i++)
        {
            for (int j = 0; j < ArrayArrayField[i].Length; j++)
            {
                strbd.Append(ArrayArrayField[i][j] + " ");
            }
            strbd.Append("\n");
        }
        ResultText.text = strbd.ToString();

    }
}
