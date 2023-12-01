using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[CreateAssetMenu(fileName ="newImageCollection", menuName = "imageCollection")]
[CreateAssetMenu(fileName = "newImageCollection", menuName = "Image Collection")]
public class Common : ScriptableObject
{
    //public List<Sprite> images;

    [System.Serializable]
    public class ImageData
    {
        public Sprite image;
        public string tooltipText;
    }

    public List<ImageData> imageDatas;
}

