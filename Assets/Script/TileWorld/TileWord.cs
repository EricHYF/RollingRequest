using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 区块世界管理器
/// </summary>
public class TileWord : MonoBehaviour
{




    #region 属性定义


    [SerializeField]
    TileManager tileManager;   // 网格管理器

    [SerializeField]
    GameObject tilesContainer;   // 网格容器

    [SerializeField]
    GameObject charContainer;   //角色容器
    
    [SerializeField]
    GameObject canvas;   //场景容器

    [SerializeField]
    TileWorldCamera worldCamera; // 世界摄像机


    [SerializeField]
    GameObject tilePrefab;        // 单元格的预制物


    [SerializeField]
    Vector2 size;  // 世界的尺寸





    // 测试数据

    [SerializeField]
    TileSetData[] tileSets; //区块设置

    [SerializeField]
    CharPlayer[] playerSets;  //玩家列表














    private List<CharPlayer> playerList; // 玩家列表

    private CharPlayer hostPlayer;


    private TileNode startNode; //起始节点


    private  List<TileNodeItem> playerPath;


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


    /// <summary>
    /// 初始化世界
    /// </summary>
    public virtual void Setup()
    {

        size = new Vector2(10, 10);  //预设 10 x 10



        InitTiles();
       

        if(playerSets != null)
        {
            playerList = new List<CharPlayer>();

            foreach (var p in playerSets)
            {
                GameObject obj = Instantiate(p.gameObject);
                CharPlayer player = obj.GetComponent<CharPlayer>();


                if (player.type == WorlCharType.Host)
                {
                    hostPlayer = player;
                }

                player.transform.parent = charContainer.transform;
                player.Setup(this);
            }
        }






        if (hostPlayer != null)
        {
            worldCamera.target = hostPlayer;
            
            hostPlayer.transform.position = startNode.transform.position;
            
        }



    }

    /// <summary>
    /// 获取节点实例
    /// </summary>
    /// <returns></returns>
    public TileNode GetNode()
    {
        GameObject obj = Instantiate(tilePrefab);
        return obj.GetComponent<TileNode>();
    }


    #endregion

    #region 网格初始化

    private void InitTiles()
    {




        if (tileSets != null)
        {

            tileManager.Setup(tileSets, size);  // 初始化网格管理器

            foreach (var data in tileSets)
            {
                TileNode n = GetNode();
                n.transform.parent = tilesContainer.transform;
                n.Setup(data);

                if (data.type == TileSetType.Start)
                {
                    startNode = n;
                }
            }


            if(startNode != null)
            {
                Debug.Log(">>>>>>> Find Path");
                List<TileNodeItem> path = tileManager.GetPathForward((int)startNode.pos.x, (int)startNode.pos.y);

                if (path.Count > 0)
                {




                }
                else
                {
                    Debug.Log(">>>>>>> path is empty");
                }

            }
            else
            {
                Debug.Log(">>>>>> Start Node is NULL");
            }



        }
        

    }


    #endregion










    #region UnitTest


    void OnGUI()
    {
        if(GUILayout.Button("Test Move"))
        {
            if (playerPath != null)
            {
                Debug.Log("---- Show path ----");
                foreach (TileNodeItem n in playerPath)
                {
                    Debug.Log("===> node: " + n.id);
                }
            }
        }



    }


    #endregion













}
