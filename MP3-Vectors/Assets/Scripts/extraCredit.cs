using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraCredit : MonoBehaviour
{
    public Light world;
    public Light eaLight;
    public Light ebLight;

    public Material sky;
    public Material dark;

    public Material sphere;
    public Material enda;
    public Material endb;
    public Material barrier;

    private Material sphereOriginal;
    private Material eaOriginal;
    private Material ebOriginal;
    private Material barOriginal;

    public static bool nightMode;


    // Start is called before the first frame update
    void Start()
    {
        sphereOriginal = sphere;
        eaOriginal = enda;
        ebOriginal = endb;
        barOriginal = barrier;
        eaLight.enabled = false;
        ebLight.enabled = false;

        nightMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            nightMode = !nightMode;
            world.enabled = !world.enabled;
            eaLight.enabled = !eaLight.enabled;
            ebLight.enabled = !ebLight.enabled;
        }

        if(nightMode)
        {
            RenderSettings.skybox = dark;
            RenderSettings.ambientLight = Color.black;

            sphere.SetColor("_EmissionColor", new Color(0.4f, 1f, 1f));
            sphere.EnableKeyword("_EMISSION");

            enda.SetColor("_EmissionColor", new Color(1f, 0f, 0f));
            enda.EnableKeyword("_EMISSION"); 

            endb.SetColor("_EmissionColor", new Color(1f, 0f, 1f));
            endb.EnableKeyword("_EMISSION");

            barrier.SetColor("_EmissionColor", new Color(0f, 1f, 0f));
            barrier.EnableKeyword("_EMISSION");
        }
        else
        {
            RenderSettings.skybox = sky;
            RenderSettings.ambientLight = new Color(0.6f, 0.7f, 0.7f);

            sphere = sphereOriginal;
            enda = eaOriginal;
            endb = ebOriginal;
            barrier = barOriginal;
            sphere.DisableKeyword("_EMISSION");
            enda.DisableKeyword("_EMISSION");
            endb.DisableKeyword("_EMISSION");
            barrier.DisableKeyword("_EMISSION");
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
    }
}
