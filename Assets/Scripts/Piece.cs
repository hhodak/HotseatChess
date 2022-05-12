using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MaterialSetter))]
public abstract class Piece : MonoBehaviour
{
    private MaterialSetter materialSetter;
    public Board board { protected get; set; }
    public Vector2Int occupiedSquare { get; set; }
    public PieceColor team { get; set; }
    public bool hasMoved { get; private set; }
    public List<Vector2Int> availableMoves;
    //private IObjectTweener tweener;
    public abstract List<Vector2Int> SelectAvailableSquares();

    private void Awake()
    {
        availableMoves = new List<Vector2Int>();
        materialSetter = GetComponent<MaterialSetter>();
        hasMoved = false;
    }

    public void SetMaterial(Material material)
    {
        if (materialSetter == null)
            materialSetter = GetComponent<MaterialSetter>();
        materialSetter.SetMaterial(material);
    }

    public bool IsFromSameTeam(Piece piece)
    {
        return team == piece.team;
    }

    public bool CanMoveTo(Vector2Int coordinates)
    {
        return availableMoves.Contains(coordinates);
    }

    public virtual void MovePiece(Vector2Int cordinates)
    {

    }

    protected void TryToAddMove(Vector2Int coordinates)
    {
        availableMoves.Add(coordinates);
    }

    public void SetData(Vector2Int coordinates, PieceColor team, Board board)
    {
        this.team = team;
        occupiedSquare = coordinates;
        this.board = board;
        transform.position = board.CalculatePositionFromCoordinates(coordinates);
    }
}
