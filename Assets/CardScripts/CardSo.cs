using UnityEngine;

namespace CardScripts
{
    [CreateAssetMenu(fileName = "NewCardScriptableObject", menuName = "CardScriptableObject")]
    public class CardSo: ScriptableObject
    {
        public CardType type;
        public int number;
        public Operator operation;
        public Logic logic;
    }
}