using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject boardSquarePrefab;
    public GameObject boardBorder;
    public Material blackSquareMaterial;
    public Material whiteSquareMaterial;
    public List<GameObject> chessboard;

    void Start()
    {
        InstantiateChessboard();
    }

    void InstantiateChessboard()
    {
        Instantiate(boardBorder, transform);
        bool isSquareBlack = true;
        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 8; j++)
            {
                CreateSquare(i, j, isSquareBlack);
                isSquareBlack = !isSquareBlack;
            }
            isSquareBlack = !isSquareBlack;
        }
    }

    void CreateSquare(int row, int column, bool isSquareBlack)
    {
        GameObject square = Instantiate(boardSquarePrefab, new Vector3(row, -1, column), Quaternion.identity, transform);
        if (isSquareBlack)
            square.GetComponent<Renderer>().material = blackSquareMaterial;
        else
            square.GetComponent<Renderer>().material = whiteSquareMaterial;
        chessboard.Add(square);
    }

    internal Vector3 CalculatePositionFromCoordinates(Vector2Int coordinates)
    {
        return new Vector3(coordinates.x, 0f, coordinates.y);
    }
}
