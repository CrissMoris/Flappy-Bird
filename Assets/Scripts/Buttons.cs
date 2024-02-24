
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Buttons : MonoBehaviour
{
    // public GameObject panel;
    public void CikisButonu()
    {
        print("Oyundan ��k�ld�");
        Application.Quit();
    }
    // Start is called before the first frame update
    public void YeniOyun()
    {
        SceneManager.LoadScene(1);
       // SceneManager.LoadScene("Oyun Ba�lad�");
    }

    public void IlkSahne()
    {
        SceneManager.LoadScene(0);
    }
    public void Settings()
    {
        SceneManager.LoadScene(2);
    }
    public void On_Value_Changed(float deger)
    {
        print(deger);
    }
}*/  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public void CikisButonu()
    {
        print("Oyundan ��k�ld�");
        Application.Quit();
    }

    public void YeniOyun()
    {
        SceneManager.LoadScene(1); // Yeni oyun sahnesinin indeksi buraya atanacak
    }

    public void IlkSahne()
    {
        SceneManager.LoadScene(0); // �lk sahnenin indeksi buraya atanacak
    }

    public void Settings()
    {
        SceneManager.LoadScene(2); // Ayarlar sahnesinin indeksi buraya atanacak
    }

    public void OnValueChange(float deger)
    {
        print(deger);
    }
}
