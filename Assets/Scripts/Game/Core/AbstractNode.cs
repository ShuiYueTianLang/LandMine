using System;
using UnityEngine;

namespace Jacky
{
    /// <summary>
    /// 节点类基类
    /// </summary>
    public abstract class AbstractNode
    {
        public NodeData Data;

        public abstract NodeType nType { get; }

        public Action<AbstractNode> ClickEvent;

        public abstract void Init(NodeInitData initData);

        public virtual void PlayInitAnimation()
        {
            
        }

        public virtual void PlayDestroyAnimation()
        {
            
        }
        public abstract void Dispose();
    }

    public class NodeInitData
    {
        public int X;
        public int Y;
        public GameObject GObject;
        public Vector3 Pos;
        public int Value;
    }

    public enum NodeType
    {
        /// <summary>
        /// 正常节点
        /// </summary>
        Normal = 0,
        
        /// <summary>
        /// 地雷节点
        /// </summary>
        LandMine = 1,
    }
}