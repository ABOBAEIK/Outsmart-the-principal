using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void Quit(bool needVerify)
    {
        if (needVerify)
        {
            CertaintyWindow window = CertaintyWindow.Instance;

            window.Request((result) =>
            {
                if (result == CertaintyAnswer.Yes)
                {
                    Application.Quit();
                }
            });
        }
        else
        {
            Application.Quit();
        }
    }
}