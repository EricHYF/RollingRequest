using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 世界角色类型
/// </summary>
public enum WorlCharType
{
    Unkonwn = 0,
    Host,
    Alliance,
    Enemy,
    NPC,

}



public class BaseWorldChar : MonoBehaviour
{


    public TileWord world;

    public WorlCharType type;




    // Use this for initialization
    void Start () {
		
	}




    #region 初始化

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="w"></param>
    public virtual void Setup(TileWord w)
    {
        world = w;





    }


    #endregion



}
