using UnityEngine;

namespace Services
{
    public interface IDragBufferService : IService
    {
        public void AddToBuffer(GameObject element);
        public GameObject GetElement();
    }
}