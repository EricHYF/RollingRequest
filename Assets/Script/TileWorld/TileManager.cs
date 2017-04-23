using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 移动方向
/// </summary>
public enum TileMoveDirection
{
    Up,
    Down,
    Left,
    Right
}



/// <summary>
/// 网格管理器
/// </summary>
public class TileManager : MonoBehaviour
{



    private List<TileSetData> dataList;
    private Dictionary<string, TileSetData> dataDic;

    public int width;
    public int height;


    public Dictionary<string, TileNodeItem> nodeDic;        // 节点字典




    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="data"></param>
    public void Setup(TileSetData[] data, Vector2 size)
    {

        width = (int)size.x;
        height = (int)size.y;

        nodeDic = new Dictionary<string, TileNodeItem>();

        dataList = new List<TileSetData>();
        dataDic = new Dictionary<string, TileSetData>();
        foreach (var d in data)
        {
            dataList.Add(d);
            
            string id = GetNodeID(d.pos);
            dataDic.Add(id, d);
            TileNodeItem node = new TileNodeItem();
            node.Setup(this, (int)d.pos.x, (int)d.pos.y);

            nodeDic.Add(id, node);
        }


        foreach(var k in nodeDic)
        {
            TileNodeItem node = k.Value;
            node.nearItems = GetNearItems(node.x, node.y);  //刷新数据
            
        }



    }




    /// <summary>
    /// 获取节点ID
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public string GetNodeID(int x, int y)
    {
        return string.Format("t_{0}_{1}", x, y);
    }


    /// <summary>
    /// 获取节点ID
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public string GetNodeID(Vector2 pos)
    {
        return GetNodeID((int)pos.x, (int)pos.y);
    }


    /// <summary>
    /// 获取节点对象
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public TileNodeItem GetNodeItem(int x, int y)
    {
        string id = GetNodeID(x, y);
        if (nodeDic.ContainsKey(id)) return nodeDic[id];
        return null;
    }



    /// <summary>
    /// 获取附近的节点
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public List<TileNodeItem> GetNearItems(int x, int y)
    {
        List<TileNodeItem> near = new List<TileNodeItem>();

        TileNodeItem node = null;

        node = GetNodeItem(x, y-1);
        if (node != null) near.Add(node);  // UP

        node = GetNodeItem(x - 1, y);
        if (node != null) near.Add(node);  // LEFT

        node = GetNodeItem(x, y+1);
        if (node != null) near.Add(node); // DOWN

        node = GetNodeItem(x + 1, y);
        if (node != null) near.Add(node); // RIGHT

        Debug.Log(">>>> Near for ["+x +", "+y+"] : "+ near.Count);

        return near;
    }








    /// <summary>
    /// 获取单向前进路线
    /// </summary>
    /// <param name="sx"></param>
    /// <param name="sy"></param>
    /// <param name="dir"></param>
    /// <returns></returns>
    public List<TileNodeItem> GetPathForward(int sx, int sy, TileMoveDirection dir = TileMoveDirection.Down)
    {
        List<TileNodeItem> path = new List<TileNodeItem>();


        List<TileNodeItem> finds = null;

        TileNodeItem cur = GetNodeItem(sx, sy);
        path.Add(cur);

        while (cur != null)
        {
            if(cur.nearItems !=null && cur.nearItems.Count>0)
            {

                finds = new List<TileNodeItem>();
                foreach (TileNodeItem n in cur.nearItems)
                {
                    if (n.id != cur.id && !path.Contains(n))
                    {
                        finds.Add(n);
                    }
                }
                if (finds.Count == 1)
                {
                    cur = finds[0];
                    path.Add(cur);
                }
                else
                {
                    cur = null;
                }

            }
            else
            {
                cur = null;
            }


        }



        return path;
    }


    private TileNodeItem GetNextNode(TileNodeItem currentNode, out List<TileNodeItem> findList)
    {
        findList = new List<TileNodeItem>();

        if(currentNode.nearItems !=null && currentNode.nearItems.Count > 0)
        {
            foreach(var n in currentNode.nearItems)
            {
                Debug.LogFormat("---F[{0}] c: {1}", currentNode.id, n.id);

                if (n.id != currentNode.id)
                    findList.Add(n);
            }
        }
        
        if (findList.Count == 1) return findList[0];  //返回唯一的次节点
        return null;
    }





}



#region 节点数据

/// <summary>
/// 网格节点对象
/// </summary>
public class TileNodeItem
{
    public int x;
    public int y;
    public string id;

    private TileManager manager;

    public List<TileNodeItem> nearItems;    //周边节点


    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="manager"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void Setup(TileManager m, int x, int y)
    {
        manager = m;

        this.x = x;
        this.y = y;


        this.id = manager.GetNodeID(x, y);
    }














}


#endregion
