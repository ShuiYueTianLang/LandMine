using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Jacky
{
    public class NodeManager
    {
        private Dictionary<IntVector2, AbstractNode> _nodes = new Dictionary<IntVector2, AbstractNode>();
        
        private List<AbstractNode> _nodeList = new List<AbstractNode>();

        public void Spawn(int width, int height, int landMineCount,Transform parent)
        {
            if (landMineCount > width * height)
            {
                Debug.LogError("地雷数量大于格子数量！");
                return;
            }
            IntVector2[] mineNodePos = new IntVector2[landMineCount];
            for (int i = 0; i < landMineCount; i++)
            {
                int randomX = Random.Range(0, width);
                int randomY = Random.Range(0, height);
                while (!JudgePos(randomX, randomY, mineNodePos))
                {
                    randomX = Random.Range(0, width);
                    randomY = Random.Range(0, height);
                }
                mineNodePos[i] = new IntVector2()
                {
                    x = randomX,y = randomY
                };
            }

           
            for (int i = 0; i < mineNodePos.Length; i++)
            {
                var go = AssetService.LoadAsset("Node");
                go.transform.SetParent(parent);
                var node = GetNodeByType(NodeType.LandMine);
                NodeInitData initData = new NodeInitData()
                {
                    X =  mineNodePos[i].x,Y = mineNodePos[i].y,Value = -1,GObject = go,
                    Pos = NodeHelp.GetPosition(mineNodePos[i].x, mineNodePos[i].y, width,height)
                };
                node.Init(initData);
                node.ClickEvent += OnClickNode;
                _nodes.Add(mineNodePos[i],node);
                _nodeList.Add(node);
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (_nodes.ContainsKey(new IntVector2() {x = i, y = j}))
                    {
                        continue;
                    }

                    int val = CalculateBoundLandMineCount(i, j, width, height);
                    var node = GetNodeByType(NodeType.Normal);
                    var go = AssetService.LoadAsset("Node");
                    go.transform.SetParent(parent);
                    NodeInitData initData = new NodeInitData()
                    {
                        X =  i,Y = j,Value = val,GObject = go,
                        Pos = NodeHelp.GetPosition(i, j, width,height)
                    };
                    node.Init(initData);
                    node.ClickEvent += OnClickNode;
                    _nodes.Add(new IntVector2(){x = i,y= j}, node);
                    _nodeList.Add(node);
                }
            }
        }

        private bool JudgePos(int x, int y, IntVector2[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].x == x && arr[i].y == y)
                {
                    return false;
                }
            }

            return true;
        }

        private int CalculateBoundLandMineCount(int x, int y,int width, int height)
        {
            int count = 0;
            int leftX = x - 1;
            int rightX = x + 1;
            int topY = y + 1;
            int bottomY = y - 1;
            if (leftX > 0)
            {
                if (topY < height)
                {
                    if (_nodes.ContainsKey(new IntVector2(){x= leftX,y = topY}))
                    {
                        count++;
                    }
                }

                if (_nodes.ContainsKey(new IntVector2() {x = leftX, y = y}))
                {
                    count++;
                }

                if (bottomY >= 0)
                {
                    if (_nodes.ContainsKey(new IntVector2() {x = leftX, y = bottomY}))
                    {
                        count++;
                    }
                }
            }

            if (topY < height)
            {
                if (_nodes.ContainsKey(new IntVector2() {x = x, y = topY}))
                {
                    count++;
                }
            }

            if (bottomY > -1)
            {
                if (_nodes.ContainsKey(new IntVector2() {x = x, y = bottomY}))
                {
                    count++;
                }
            }

            if (rightX < width)
            {
                if (topY < height)
                {
                    if (_nodes.ContainsKey(new IntVector2() {x = rightX, y = topY}))
                    {
                        count++;
                    }
                }

                if (_nodes.ContainsKey(new IntVector2() {x = rightX, y = y}))
                {
                    count++;
                }

                if (bottomY > -1)
                {
                    if(_nodes.ContainsKey(new IntVector2(){x = rightX, y = bottomY}))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private void OnClickNode(AbstractNode node)
        {
            
        }


        public void ReSet()
        {
            
        }
        
        public void Dispose()
        {
            
        }

        private AbstractNode GetNodeByType(NodeType typeId)
        {
            switch (typeId)
            {
                case NodeType.Normal:return new NormalNode();
                case NodeType.LandMine: return new LandMineNode();
            }

            return null;
        }
        
        
    }
}