using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace Tools
{
    public class SpriteLoader : MonoBehaviour
    {
        [SerializeField] private Image image;
        
        public void TryUpdateSprite(Sprite newSprite)
        {
            if (image.sprite == newSprite) return;

            image.sprite = newSprite;
            var pivot = newSprite.pivot;
            var size = newSprite.rect.size;
            image.rectTransform.pivot = new Vector2(pivot.x / size.x, pivot.y / size.y);
        }
    }
}