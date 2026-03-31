using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject confirmSairHUD, creditosHUD;
    public void Jogar()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Creditos()
    {
        creditosHUD.SetActive(true);
    }

    public void Voltar()
    {
        creditosHUD.SetActive(false);
        confirmSairHUD.SetActive(false);
    }

    public void Sair()
    {
        confirmSairHUD.SetActive(true);
    }

    public void ConfirmSair()
    {
        Debug.Log("saiu do jogo");
        Application.Quit();
    }
}
