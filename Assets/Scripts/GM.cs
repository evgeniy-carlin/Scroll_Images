using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    private string[] urls =
        {
        "https://images.ua.prom.st/146832347_w0_h0_1548.jpg", //red
        "http://www.planetadsp.ru/blobs/3424249.jpg", //orange
        "https://vignette.wikia.nocookie.net/phobia/images/9/92/Yellow.png/revision/latest?cb=20161109225530", //yellow
        "https://static.trade-light.ru/trade-light/images/items/1559_2368_preview.jpg?1505405217", //green
        "http://www.simplycoatings.co.uk/ekmps/shops/simplycoatings2/images/yester-30-matt-powder-coating-20kg-box--1519-p.jpg", //blue
        "https://www.thevinylspectrum.com/var/images/product/400.400/651-067_1_1.png", //dark blue
        "http://art-mozaika.ru/published/publicdata/MOZAIKADB/attachments/SC/products_pictures/%2190614.jpg", //pink
    };
    private string url;
    private new Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        url = urls[Random.Range(0, urls.Length)]; //randomize colors in list and choose one of them
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Press Esc to quit game
        {
            Application.Quit();
        }
    }

    //When visible blocks get into "death zone", they become invisible and clean
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "offImage") //if they reach "death zone"
        {
            renderer.enabled = false; //make them invisible
            renderer.material.mainTexture = null; //clean them from picture
        }
    }

    //When blocks get out of "death zone", they again become visible and take image that we transfer from random url
    private IEnumerator OnTriggerExit(Collider other)
    {
        renderer.enabled = true; //make them visible again

        WWW www = new WWW(url); //transfer url to WWW
        yield return www;
        renderer.material.mainTexture = www.texture; //color blocks by pictures from urls
    }
}
