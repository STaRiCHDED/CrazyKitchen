using System;
using Events;
using Models;
using UnityEngine;
using UnityEngine.EventSystems;
using Views;

namespace Controllers
{
    public class PanController : MonoBehaviour, IDropHandler
    {
        [SerializeField]
        private PanView _panView;
    
        private PanModel _panModel;
        private MeatController _meatController;
        private IDisposable _subscription;
    
        public void Initialize(PanModel panModel, MeatController meatController)
        {
            _panModel = panModel;
            _meatController = meatController;
            _panView.Initialize(_meatController.MeatView);
            _panModel.IsAvailable = false;
        
            _panView.MeatCooked += OnMeetCooked;
            _subscription = EventStreams.Game.Subscribe<ReleaseMeatRequestEvent>(Action);
        }

        private void Action(ReleaseMeatRequestEvent obj)
        {
            _panModel.IsAvailable = true;
        }

        private void OnMeetCooked()
        {
            _meatController.ChangeMeatState(true);
        }

        private void Update()
        {
            if ( _panModel==null || _panModel.IsAvailable)
            {
                return;
            }
        
            _panView.Cook(_panModel.CookingTime);
        }


        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("Сковородкин");
        }

        private void OnDestroy()
        {
            _subscription.Dispose();
        }
    }
}