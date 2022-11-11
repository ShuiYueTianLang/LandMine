namespace Jacky
{
    public class NormalNode : AbstractNode
    {
        public override NodeType nType { get;}

        public override void Init(NodeInitData initData)
        {
            Data = new NodeData
            {
                X = initData.X, Y = initData.Y, Value = initData.Value, GObject = initData.GObject, Position = initData.Pos
            };
            Data.GObject.transform.localPosition = initData.Pos;
        }

        public override void Dispose()
        {
            if (Data != null)
            {
                if (Data.GObject != null)
                {
                    AssetService.ReleaseAsset(Data.GObject);
                }
            }

            ClickEvent = null;
            Data = null;
        }
    }
}