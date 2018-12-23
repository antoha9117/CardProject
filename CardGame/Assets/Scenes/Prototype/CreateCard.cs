using Card.RenderCard.Facilities;
using Card.RenderCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class CreateCard : MonoBehaviour
    {
        public float size = 1f;
        public float interval = 1f;
        public int maxCards = 7;
        public GameObject hand;

        public List<SelectCard> cards;

        private void Start()
        {
            cards = new List<SelectCard>(maxCards);
        }

        void OnMouseDown()
        {
            if (cards.Count <= maxCards)
            {
                CardFacilitie facilitie = new SadowTwoSideCardFacilitie();
                CardRender curCard = facilitie.CreateMinionCard();
                curCard.Configure();
                Transform card = curCard.cardObject.transformObj;

                BoxCollider box = curCard.face.transform.gameObject.AddComponent<BoxCollider>();
                box.size = new Vector3(box.size.x, box.size.y, 0.1f);
                SelectCard s = curCard.face.transform.gameObject.AddComponent<SelectCard>();
                s.myTransform = card;
                s.creator = this;

                card.localScale = new Vector3(size, size, 1);
                card.rotation = hand.transform.rotation;

                cards.Add(s);
                setHand();
            }
        }

        public void setHand()
        {
            float start = (interval / 2) * (cards.Count - 1);
            int step = 0;
            foreach (var cr in cards)
            {
                cr.index = step;
                float x = hand.transform.position.x - start + (interval * step);
                cr.setTransf( new Vector3(x, hand.transform.position.y, hand.transform.position.z));
                step++;
            }
        }
    }
}