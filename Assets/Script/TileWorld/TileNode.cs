using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 单元格
/// </summary>
public class TileNode : MonoBehaviour
{
    

    public Vector2 pos
    {
        get
        {

            if (data != null) return data.pos;
            return Vector2.zero;
        }
    }
    public TileSetData data;


    public float width = 0.5f;
    public float height = 0.5f;




    // Use this for initialization
    void Start () {
		
	}

	

    /// <summary>
    /// 配置节点
    /// </summary>
    /// <param name="d"></param>
    public void Setup(TileSetData d)
    {
        data = d;

        this.name = data.name;
        this.transform.localPosition = new Vector3(pos.x * width, 0, pos.y * height);



    }



}
