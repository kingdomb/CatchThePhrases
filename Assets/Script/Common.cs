using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * This ScriptableObject represents a common collection of images with associated tooltip text.
 * It is used to create and manage different difficulty levels of image collections.
 */
//[CreateAssetMenu(fileName ="newImageCollection", menuName = "imageCollection")]
[CreateAssetMenu(fileName = "newImageCollection", menuName = "Image Collection")]
public class Common : ScriptableObject
{
    // List of ImageData instances, each containing a Sprite image and its associated tooltip text.
    //public List<Sprite> images;

    [System.Serializable]
    public class ImageData
    {
        public Sprite image;        // The image sprite.
        public string tooltipText;  // The tooltip text associated with the image.
    }

    public List<ImageData> imageDatas;  // List of ImageData instances representing the image collection.
}
