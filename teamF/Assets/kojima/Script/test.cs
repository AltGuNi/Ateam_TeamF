using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB; //mobile backendのSDKを読み込む

public class test : MonoBehaviour {

    //Texture2D texture;

    // Use this for initialization
    void Start () {
        NCMBObject obj = new NCMBObject("TextureResource");
        obj.ObjectId = "fFGQGPJ9SgyAgaZf";

        transform.position = Vector2.zero;

        obj.FetchAsync((NCMBException e) =>
        {
            if (e != null)
            {
                //エラー処理
            }
            else
            {
                //成功時の処理
                //texture = new Texture2D(System.Convert.ToInt32(obj["Width"]), System.Convert.ToInt32(obj["Height"]));
                NCMBFile file = new NCMBFile(System.Convert.ToString(obj["Name"]));
                file.FetchAsync((byte[] fileData, NCMBException error) =>
                {
                    if (error != null)
                    {
                        // 失敗
                    }
                    else
                    {
                        // 成功
                        Texture2D texture = new Texture2D(System.Convert.ToInt32(obj["Width"]), System.Convert.ToInt32(obj["Height"]));
                        texture.LoadImage(fileData);
                        GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, 300, 300), new Vector2(0.5f, 0.5f));
                    }
                });
            }
        });
    }

    // Update is called once per frame
    void Update () {
    }
}
