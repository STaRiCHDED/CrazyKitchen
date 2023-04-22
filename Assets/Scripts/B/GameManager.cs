using B.Config;
using B.Managers;
using B.Models;
using Services;
using UnityEngine;

namespace B
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameVariantConfig _gameConfig;

        [SerializeField]
        private CookingUtensilsManager _cookingUtensilsManager;

        [SerializeField]
        private UtensilManager _utensilManager;

        private void Awake()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.RegisterSingle<IDragBufferService>(new DragBufferService());
            
            _cookingUtensilsManager.Initialize(CreateCookingUtensilModels());
            _utensilManager.Initialize(CreateUtensilModels());
        }

        private CookingUtensilModel[] CreateCookingUtensilModels()
        {
            var utensilModels = new CookingUtensilModel[_gameConfig.ConfigCookableUtensilModels.Length];
            
            for (var i = 0; i < utensilModels.Length; i++)
            {
                var configModel = _gameConfig.ConfigCookableUtensilModels[i];
                utensilModels[i] =
                    new CookingUtensilModel(configModel.Name, configModel.IsAvailable, configModel.CookingTime);
            }

            return utensilModels;
        }
        
        private UtensilModel[] CreateUtensilModels()
        {
            var utensilModels = new UtensilModel[_gameConfig.ConfigUtensilModels.Length];
            
            for (var i = 0; i < utensilModels.Length; i++)
            {
                var configModel = _gameConfig.ConfigUtensilModels[i];
                utensilModels[i] =
                    new UtensilModel(configModel.Name, configModel.IsAvailable);
            }

            return utensilModels;
        }
    }
}