using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TestScripts
{
    public class CardTypeDropDown: MonoBehaviour
    {
        public CardType currentCardType;
        public TMP_Dropdown dropdown; // TextMeshPro를 사용하는 경우
        // public Dropdown dropdown; // 일반 Dropdown을 사용하는 경우
        public TextMeshProUGUI displayText; // 선택된 값을 표시할 TextMeshProUGUI
        // public Text displayText; // 일반 Text를 사용하는 경우

        void Start()
        {
            // Dropdown 초기화
            InitializeDropdown();

            // Dropdown 값이 변경될 때 호출될 메서드 설정
            dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });
        }

        void InitializeDropdown()
        {
            // Dropdown 옵션을 열거형 값으로 초기화
            string[] enumNames = Enum.GetNames(typeof(CardType));
            dropdown.ClearOptions();
            dropdown.AddOptions(new List<string>(enumNames));
        }

        void DropdownValueChanged(TMP_Dropdown change) // TextMeshPro를 사용하는 경우
            // void DropdownValueChanged(Dropdown change) // 일반 Dropdown을 사용하는 경우
        {
            CardType selectedCardType = (CardType)change.value;
            displayText.text = selectedCardType.ToString();
            currentCardType = selectedCardType;
        }
    }
}