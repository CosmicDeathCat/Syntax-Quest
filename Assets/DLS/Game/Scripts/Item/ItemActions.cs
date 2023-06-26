using UnityEngine;
using DLS.Game.Scripts.Player;

namespace DLS.Game.Scripts.Item
{
    public static class ItemActions
    {
        public static void OnHealAction(GameObject obj, int amount)
        {
            PlayerController target = obj.GetComponent<PlayerController>();

            int currPlusAmount = target.CurrentHealth + amount;
            if (currPlusAmount >= target.MaxHealth)
            {
                target.CurrentHealth = target.MaxHealth;
            }
            else
                target.CurrentHealth += amount;
        }
    }
}