using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CardGame.Elements
{
    abstract class PackGame : MonoBehaviour
    {
        public virtual void Look()
        {
            throw new NotImplementedException();
        }

        public virtual void Take()
        {
            throw new NotImplementedException();
        }

        public virtual void Put()
        {
            throw new NotImplementedException();
        }
    }
}
