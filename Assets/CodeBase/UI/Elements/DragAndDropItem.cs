using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CodeBase.UI.Elements
{
    public class DragAndDropItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private RectTransform _rectTransform;
        private Image _image;
        private Vector3 _startPosition;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _image = GetComponent<Image>();
            _startPosition = transform.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _image.raycastTarget = false;
            _startPosition = transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _image.raycastTarget = true;
            transform.position = _startPosition;
        }
    }
}