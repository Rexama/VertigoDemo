using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace _Code.Tools
{
    public class SpriteLoader : MonoBehaviour
    {
        [SerializeField] private string spriteName;

        private Image _image;
        private SpriteAtlas _spriteAtlas;

        private void OnValidate()
        {
            TryLoadSprite();
        }

        private void Awake()
        {
            TryLoadSprite();
        }

        private void TryLoadSprite()
        {
            
            TryCacheComponents();
            var sprite = _spriteAtlas.GetSprite(spriteName);

            if (sprite == null) return;
            
            LoadSprite(sprite);
        }

        private void TryCacheComponents()
        {
            if (_spriteAtlas != null) return;

            _image = GetComponent<Image>();
            _spriteAtlas = Resources.Load<SpriteAtlas>("SpriteAtlas");
        }

        private void LoadSprite(Sprite sprite)
        {
            _image.sprite = sprite;
            var pivot = sprite.pivot;
            var size = sprite.rect.size;
            _image.rectTransform.pivot = new Vector2(pivot.x / size.x, pivot.y / size.y);
        }

        public void UpdateSprite(string newSpriteName)
        {
            spriteName = newSpriteName;
            TryLoadSprite();
        }
    }
}