using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    [SerializeField] Camera cam;
    private void OnMouseDown()
    {
        Debug.Log("Mouse Is Click");
        //Spawn defender on mouse click
        //Spawn on where mouse clicked (core game area) 
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }
    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }
    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
    }
    private Vector2 GetSquareClicked()
    {
        //Mouse click return position where mouse was clicked(core game area)
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = cam.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
    private void SpawnDefender (Vector2 roundedPos)
    {
        //Spawn defenders in spesified area
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity)as Defender;
        Debug.Log(roundedPos);
    }
}
