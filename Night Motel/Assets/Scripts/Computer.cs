using UnityEngine;
using TMPro;
public class Computer : MonoBehaviour
{
    #region Variables
    public GameObject desktop;
    [SerializeField] private GameObject searchlyengine;
    [SerializeField] private GameObject bookingwindow;
    [SerializeField] private GameObject Successwindow;
    [SerializeField] private InputField searchlyinpfield;
    [SerializeField] private TextMeshProUGUI downtext;
    private bool isbooked = false;
    public bool hasescaped=false;
    [SerializeField] private GameObject DarkShadow;
    private bool openedSearchly = false;
    [SerializeField] private GameObject LabubuDoll;
    [SerializeField]private LabubuDoll labubuDollScript;
    #endregion

    public void ComputerStart()
    {
        Interatable intertable = gameObject.GetComponent<Interatable>();
        intertable.isInteractable = false;
        desktop.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }

    public void OpenSearchlyEngine()
    {
        Debug.Log("Open Searchly Engine");
        searchlyengine.SetActive(true);
        desktop.SetActive(false);
        SoundManager.PlaySound(SoundType.Click, 1f);
        openedSearchly = true;
    }

    public void OpenBookingWindow()
    {
        Debug.Log("Open Booking Window");
        bookingwindow.SetActive(true);
        searchlyengine.SetActive(false);
        
    }

    public void OpenSuccessScreen()
    {
        searchlyengine.SetActive(false);
        Successwindow.SetActive(true);
        SoundManager.PlaySound(SoundType.Click, 1f);
        isbooked = true;
    }

    public void GenerateLabubuDoll()
    {
        Successwindow.SetActive(false);
        bookingwindow.SetActive(false);
        searchlyengine.SetActive(false);
        desktop.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        hasescaped = true;
        LabubuDoll.SetActive(true);
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Return)|| Input.GetKey(KeyCode.Return))
        {
            if (openedSearchly)
            {
                OpenBookingWindow();
            }

            else
            {
                Debug.Log("Pagal Samjha Kya:)");
            }
        }

        if(isbooked && Input.GetKey(KeyCode.Escape))
        {
            GenerateLabubuDoll();
            labubuDollScript.Jumpscared = true;
        }
    }
}