using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWorldCamera : MonoBehaviour
{



    /// <summary>
    /// 主相机
    /// </summary>
    [SerializeField]
    Camera m_camera;


    public BaseWorldChar target;




	// Use this for initialization
	void Start () {
		
	}
	


    /// <summary>
    /// 摄像机跟踪
    /// </summary>
    void FixedUpdate()
    {

        if(target != null)
        {
            transform.position = target.transform.position;
        }


    }
    

}
