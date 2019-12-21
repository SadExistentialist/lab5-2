using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

   
    public GameObject card;



    int rows = 4;
    int cols = 4;

    float offset = 2.3F;

    float startX = -5F;
    float startY = 3F;

    public Sprite[] images;
   int[] cardsId = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

    public CardController card_1;
    public CardController card_2;

    private int score=0;
    public int Score { set { score = value; } get { return score; } }

    int combo = 1;

    private int flagEnum = 0;

    public int FlagEnum { set { flagEnum = value; } get { return flagEnum; } }

    private void Start()
    {
        Shuffle();
        SetCards();
      
    }

    public void Shuffle()
    {
        int[] temparr = cardsId.Clone() as int[];
        for(int i=0;i<temparr.Length;i++)
        {
            int tmp = temparr[i];
            int pos = Random.Range(i, temparr.Length);
            temparr[i] = temparr[pos];
            temparr[pos] = tmp;
        }
        cardsId = temparr;

      
    }

    public bool SecondCardNotOpened()
    {
        return card_2 == null;
    }

    public void cardOpened(CardController CC)
    {
        if(card_1==null)
        {
            card_1 = CC;
        }
        else
        {
            card_2 = CC;
            StartCoroutine(checkCards());
        }
    }

    private IEnumerator checkCards()
    {
        

        if(card_1._id==card_2._id)
        {
            score += 10 * combo;
            combo++;
            flagEnum++;
        }
        else
        {
            yield return new WaitForSeconds(0.3F);
            card_1.CloseCard();
            card_2.CloseCard();
            score -= 5;

            combo = 1;
        }

        card_1 = null;
        card_2 = null;

    }

    public void SetCards()
    {
        for(int i=0;i<cols;i++)
        {
            for(int j=0;j<rows;j++)
            {


                GameObject newcard = Instantiate(card) as GameObject;
                
                float posX = startX + i * offset;
                float posY = startY - j * offset;

                Vector3 pos = new Vector3(posX, posY, 0);
                newcard.transform.position = pos;

                int index = j * cols + i;
                
                int imageId = cardsId[index];
                newcard.GetComponent<CardController>().changeimages(images[imageId],imageId);
               
               
            }
        }
    }
}
