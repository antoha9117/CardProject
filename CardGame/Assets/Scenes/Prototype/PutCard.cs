using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{

    public class PutCard : MonoBehaviour
    {
        public Transform card;
        Vector3 sc = Vector3.zero;

        void OnMouseDown()
        {
            if (card == null && SelectCard.select != null)
            {
                if(SelectCard.select.cell != null)
                {
                    SelectCard.select.cell.card = null;
                }
                SelectCard.select.cell = this;
                card = SelectCard.select.myTransform;
                card.localPosition = transform.position + new Vector3(0, 0.1f, 0);
                card.rotation = Quaternion.Euler(90, 0, 0);

                if (SelectCard.select.inHand)
                {
                    sc = card.localScale * 2.5f;
                    SelectCard.select.inHand = false;
                    CreateCard cc = SelectCard.select.creator;
                    cc.cards.RemoveAt(SelectCard.select.index);
                    cc.setHand();
                }
                else if(sc == Vector3.zero)
                {
                    sc = card.localScale;
                }
                card.localScale = sc;
            }
        }
    }
}
