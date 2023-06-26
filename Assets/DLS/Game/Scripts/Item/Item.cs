using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

namespace DLS.Game.Scripts.Item
{ 
    
    
    
    [CreateAssetMenu(fileName = "New Item", menuName = "DLS/Items/Item")]    
    public class Item : ScriptableObject
    {

        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private UnityEvent<GameObject,int> onUseEvent;
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public Sprite sprite
        {
            get => _sprite;
            set => _sprite = value;
        }
        
        public void UseItem(GameObject target, int amount)
        {
            onUseEvent.Invoke(target, amount);
        }
        
    }
}