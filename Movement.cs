using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    const float MoveSpeed = 0.5f;
    const float jumpHeigth = 0.5f;
  
    
    SpriteRenderer SR;
    Transform jumper;
    TileLogic tileAtual;
    // Start is called before the first frame update
    void Awake()
    {
        jumper = transform.Find("Jumper");
        SR = GetComponentInChildren<SpriteRenderer>();
    }  


    public IEnumerator Move(List<TileLogic> path)
    {
        tileAtual = Turn.unit.tile;
        tileAtual.content = null;

        for (int i=0; i<path.Count; i++)
        {
            TileLogic to = path[i];
           

            if(tileAtual.floor!=to.floor)
            {
                yield return StartCoroutine(Jump(to));
            }
            else
            {
                yield return StartCoroutine(Walk(to));
            }
        }
    }

    IEnumerator Walk(TileLogic to)
    {
        int id = LeanTween.move(transform.gameObject, to.worldPos, MoveSpeed).id;
        tileAtual = to;
        yield return new WaitForSeconds(MoveSpeed * 0.5f);
        SR.sortingOrder = to.contentOrder;

        while(LeanTween.descr(id)!=null)
        {
            yield return null;
        }
        to.content = this.gameObject;
    }
    IEnumerator Jump(TileLogic to)
    {
        int id1 = LeanTween.move(transform.gameObject, to.worldPos, MoveSpeed).id;
        LeanTween.moveLocalY(jumper.gameObject, jumpHeigth, MoveSpeed * 0.5f).
        setLoopPingPong(1).setEase(LeanTweenType.easeInOutQuad);
        float timeOrderUpdate = MoveSpeed;
        if(tileAtual.floor.tilemap.tileAnchor.y>to.floor.tilemap.tileAnchor.y)
        {
            timeOrderUpdate *= 0.85f;
        }
        else
        {
            timeOrderUpdate *= 0.2f;
        }
        yield return new WaitForSeconds(timeOrderUpdate);
        tileAtual = to;
        SR.sortingOrder = to.contentOrder;

        while(LeanTween.descr(id1)!=null)
        {
            yield return null;
        }
        to.content = this.gameObject;
    }
}
