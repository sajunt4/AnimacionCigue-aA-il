using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraAdjustment : MonoBehaviour
{
    [SerializeField] Sprite firstSprite;
    // Start is called before the first frame update

    void Start()
    {
        if(firstSprite != null)
        {
            Camera.main.transform.position = new Vector3(firstSprite.rect.position.x, firstSprite.rect.position.y, -10);
            Camera.main.orthographicSize = firstSprite.bounds.size.x * Screen.height / Screen.width * 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
