using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jacky
{
    public class NodeUIBase : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        [SerializeField]
        private Text _text;

        public virtual void Init(int val)
        {
            _text.text = val.ToString();
        }

        public virtual void Dispose()
        {
            
        }
    }
}
