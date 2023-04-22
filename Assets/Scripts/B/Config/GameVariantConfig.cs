using B.ConfigModels;
using UnityEngine;

namespace B.Config
{
    [CreateAssetMenu(fileName = "Config", menuName = "Config")]
    public class GameVariantConfig : ScriptableObject
    {
        public ConfigCookableUtensilModel[] ConfigCookableUtensilModels => _configCookableUtensilModels;
        
        public ConfigUtensilModel[] ConfigUtensilModels => _configUtensilModels;

        [SerializeField]
        private ConfigCookableUtensilModel[] _configCookableUtensilModels;

        [SerializeField]
        private ConfigUtensilModel[] _configUtensilModels;
    }
}