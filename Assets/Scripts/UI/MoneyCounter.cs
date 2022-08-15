using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private SaleZone _saleZone;
    [SerializeField] private TMP_Text _moneyDisplay;
    [SerializeField] private float _delay;
    [SerializeField] private Coin _coinUI;

    private WaitForSeconds _sleep;

    private void OnEnable()
    {
        _sleep = new WaitForSeconds(_delay);
        _saleZone.AddMoney += GetMoney;
    }
    private void OnDisable()
    {
        _saleZone.AddMoney += GetMoney;
    }
    private void GetMoney(int money)
    {
        StartCoroutine(AddByOneCoin(money));
    }
    private IEnumerator AddByOneCoin(int money)
    {
        _coinUI.PlayCoinAnimation();
        for (int i = 0; i < money; i++)
        {
            _moneyDisplay.text = (int.Parse(_moneyDisplay.text) + 1).ToString();
            yield return _sleep;
        }
    }
}
