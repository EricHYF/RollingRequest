using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 区块世界管理器
/// </summary>
public class TileWord : MonoBehaviour {




    #region 属性定义



    [SerializeField]
    GameObject tilesContainer;   //网格容器

    [SerializeField]
    GameObject charContainer;   //角色容器


    [SerializeField]
    GameObject canvas;   //场景容器
    
    [SerializeField]
    TileSetData[] tileSets; //区块设置

    [SerializeField]
    GameObject tilePrefab;        // 单元格的预制物

    #endregion



    #region 初始化

    /// <summary>
    /// 初始化
    /// </summary>
    void Start()
    {
        Setup();
    }








    #endregion






    #region 设置世界

    public void Setup()
    {


        if(tileSets != null)
        {
            foreach(var data in tileSets)
            {

                TileNode n = GetNode();
                n.transform.parent = tilesContainer.transform;
                n.Setup(data);

            }
        }
    }


    public TileNode GetNode()
    {
        GameObject obj = Instantiate(tilePrefab);
        return obj.GetComponent<TileNode>();
    }


    #endregion
























}
