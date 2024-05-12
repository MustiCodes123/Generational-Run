using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public Transform audSettings;
    public Transform vidSettings;
    public Transform mainSettings;
    public Transform controlSettings;
    bool isAud = false;
    bool isVid = false;
    bool isContr = false;

    // Start is called before the first frame update
    void Start()
    {
        isAud = false;
        isVid = false;
        isContr= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAud)
            audSettings.gameObject.SetActive(false);
        if (!isVid)
            vidSettings.gameObject.SetActive(false);
        if (!isContr)
            controlSettings.gameObject.SetActive(false);
    }
    public void OnAudioButton()
    {
        isAud = true;
        audSettings.gameObject.SetActive(true);
        controlSettings.gameObject.SetActive(false);
        mainSettings.gameObject.SetActive(false);
    }
    public void OnVideoButton()
    {
        isVid = true;
        vidSettings.gameObject.SetActive(true);
        controlSettings.gameObject.SetActive(false);
        mainSettings.gameObject.SetActive(false);
    }
    public void OnControlButton()
    {
        isContr = true;
        controlSettings.gameObject.SetActive(true);
        vidSettings.gameObject.SetActive(false);
        audSettings.gameObject.SetActive(false);
        mainSettings.gameObject.SetActive(false);
    }
    public void OnAudBackButton()
    {
        isAud = false;
        audSettings.gameObject.SetActive(false);
        mainSettings.gameObject.SetActive(true);
    }
    public void OnVidBackButton()
    {
        isVid = false;
        vidSettings.gameObject.SetActive(false);
        mainSettings.gameObject.SetActive(true);
    }
    public void OnContrBackButton()
    {
        isContr = false;
        controlSettings.gameObject.SetActive(false);
        mainSettings.gameObject.SetActive(true);
    }
}
