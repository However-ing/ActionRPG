using UnityEngine;
using UnityEngine.UI;

public class hpMonster : MonoBehaviour
{
    public Image hpBar;
    public float hp = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        hpBar.fillAmount = (float)hp / 100f;
    }
}
