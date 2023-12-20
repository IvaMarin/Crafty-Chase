using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSelection : MonoBehaviour
{
    public Sprite[] sprites;
    public Image[] images;

    [ContextMenu("SelectSprites")]
    private void SelectSprites()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = sprites[i];
        }
    }
}
