using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;





public class TileGridEditor
{


}




/// <summary>
/// 编辑器窗口
/// </summary>
public class TileGridEditorWindow : EditorWindow
{


    public static TileGridEditorWindow window;

    [MenuItem("Tools/Tile Grid Editor")]
    public static void OpenWindow()
    {
        window = EditorWindow.CreateInstance<TileGridEditorWindow>();


        window.Init();
        window.Show();



    }






    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {

    }


























}








