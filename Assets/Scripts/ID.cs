using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID : MonoBehaviour
{
    [SerializeField] Sprite id00;
    [SerializeField] Sprite id01;
    [SerializeField] Sprite id02;
    [SerializeField] Sprite id03;
    [SerializeField] Sprite id04;

    [SerializeField] SpriteRenderer IDRenderer;

    //ID Trackign
    public int currentPlayerID;

    // Start is called before the first frame update
    void Start()
    {
        int currentPlayerID = Random.Range(0, 3);
        UpdateIDs(currentPlayerID);
    }

    public void UpdateIDs(int id)
    {
        Sprite[] IDSprites = new Sprite[]
        {id00, id01, id02, id03};
        
        IDRenderer.sprite = IDSprites[id];
    }



}
