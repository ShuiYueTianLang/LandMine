using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jacky
{
    
    /// <summary>
    /// 节点数据
    /// </summary>
    public class NodeData
    {
        private int _x;

        public int X
        {
            get => _x;
            set => _x = value;
        }

        private int _y;

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        private int _val;

        public int Value
        {
            get => _val;
            set => _val = value;
        }

        private GameObject _gameObject;

        public GameObject GObject
        {
            get => _gameObject;
            set => _gameObject = value;
        }

        private Vector3 _pos;

        public Vector3 Position
        {
            get => _pos;
            set => _pos = value;
        }
    }
}

