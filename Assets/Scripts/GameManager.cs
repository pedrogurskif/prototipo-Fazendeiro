using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject confirmSairHUD, creditosHUD, baseHUD;
    public void Jogar()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Creditos()
    {
        creditosHUD.SetActive(true);
        baseHUD.SetActive(false);
    }

    public void Voltar()
    {
        creditosHUD.SetActive(false);
        confirmSairHUD.SetActive(false);
        baseHUD.SetActive(true);
    }

    public void Sair()
    {
        confirmSairHUD.SetActive(true);
        baseHUD.SetActive(false);
    }

    public void MenuInicial()
    {
        SceneManager.LoadScene("cena");
    }

    public void ConfirmSair()
    {
        #if UNITY_EDITOR
        Debug.Log("saiu do jogo");
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
