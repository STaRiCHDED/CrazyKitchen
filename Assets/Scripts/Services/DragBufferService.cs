using UnityEngine;

namespace Services
{
    public class DragBufferService : IDragBufferService
    {
        private GameObject _buffer;


        public void AddToBuffer(GameObject element)
        {
            _buffer = element;
        }

        public GameObject GetElement()
        {
            var temp = _buffer;
            _buffer = null;
            return temp;
        }
    }
}