using System;
using UnityEngine;

namespace Jacky
{
    public class CoreGameManager : MonoBehaviour
    {
        [SerializeField]
        private int Width =8;

        [SerializeField]
        private int Height = 8;

        [SerializeField]
        private int LandMineCount = 5;

        [SerializeField]
        private Transform uiParent;

        NodeManager _nodeManager = new NodeManager();
        
        public void StartGame()
        {
            _nodeManager.Spawn(Width, Height, LandMineCount, uiParent);
        }

        public void ReStartGame()
        {
            
        }

        public void ExitGame()
        {
            
        }

        public void Win()
        {
            
        }

        public void Lost()
        {
            
        }

        private void OnGUI()
        {
            if (GUILayout.Button("开始游戏"))
            {
                StartGame();
            }
        }
    }
}