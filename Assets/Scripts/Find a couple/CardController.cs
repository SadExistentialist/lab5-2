using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {


    public GameObject cardback;
    public int _id;
    public GameController gameController;
    

    private void Start()
    {
        gameController = GameObject.Find("gameController").GetComponent<GameController>();
        
    }


    public void OnMouseDown()
    {
        if(cardback.activeSelf && gameController.SecondCardNotOpened())
        {
            cardback.SetActive(false);
            gameController.cardOpened(this);
        }
     
    }

    public void CloseCard()
    {
        cardback.SetActive(true);
    }


    public void changeimages(Sprite card,int id)
    {
        this.GetComponent<SpriteRenderer>().sprite = card;
        _id = id;
      
    }

  
    

    
}
