using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SpawnCustomer : MonoBehaviour//, IDeselectHandler //This Interface is required to receive OnDeselect callbacks.
{
    //BaseEventData data; //- 1f,2f,20f,10f
    public float delayTime;
    public float spawnWait;
    public float waveWait;
    public float customerCount;
    public int lane;
	//public GameObject customer;
    public GameObject[] customer;
	public GameObject location;

    public Slider spawnRateSlider;
    public Slider waveRateSlider;
    public Slider custNumberSlider;
    public Slider laneSlider;
    public Slider delaySlider;

    public Text spawnText;
    public Text waveText;
    public Text custNumText;
    public Text laneText;
    public Text delayText;

    public bool startSpawn;

    public Button reset;
	// Use this for initialization
	void Start () {
        startSpawn = true;
		StartCoroutine (Spawn ());
	}
	
	// Update is called once per frame
	void Update () {
      
        //yield return new WaitForSeconds(5.0f);
        this.spawnText.text = "Spawn Rate: " + spawnWait;
        this.waveText.text = "Wave Rate: " + waveWait;
        this.custNumText.text = "Customer Count: " + customerCount;
        this.laneText.text = "Lane " + lane;
        this.delayText.text = "Delay: " + delayTime;
    }

	public IEnumerator Spawn () {
		
		yield return new WaitForSeconds (delayTime);
		while (startSpawn)
		{
			for (int i = 0; i < customerCount; i++) {

                //customer.transform.position.Set(xDisplace, customer.transform.position.y, customer.transform.position.z);
                Instantiate(customer[lane], location.transform);
                //location.transform.position.Set(xDisplace, location.transform.position.y, location.transform.position.z);
                yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

	}
		
}
    /*public void OnDeselect(BaseEventData eventData)
    {
        eventData.selectedObject = spawnRateSlider.gameObject;

    }*/

    public void waveSlider()
    {

        /*spawnRateSlider.OnDeselect(data);
         {
         spawnWait = spawnRateSlider.value;
             //Debug.Log("Deselect");
             Debug.Log("Spawn Rate Changed");

         }*/
        waveWait = waveRateSlider.value;
        Debug.Log("Wave Rate Changed: " + waveWait);

    }
    public void customerSlider()
    {

        /*spawnRateSlider.OnDeselect(data);
         {
         spawnWait = spawnRateSlider.value;
             //Debug.Log("Deselect");
             Debug.Log("Spawn Rate Changed");

         }*/
        customerCount = custNumberSlider.value;
        Debug.Log("Customer Count Changed: " + customerCount);

    }
    public void spawnSlider()
    {

        /*spawnRateSlider.OnDeselect(data);
         {
         spawnWait = spawnRateSlider.value;
             //Debug.Log("Deselect");
             Debug.Log("Spawn Rate Changed");

         }*/
        spawnWait = spawnRateSlider.value;
        Debug.Log("Spawn Rate Changed: " + spawnWait);

    }
    public void laneSliderFunction()
{
    lane = (int)laneSlider.value;
    Debug.Log("Lane " + lane);
}
    public void delaySliderFunction()
    {
        delayTime = delaySlider.value;
    }
    public void ResetButton()
    {
        StopAllCoroutines();
        StartCoroutine(Spawn());
        Debug.Log("(RESET) New Coroutine in " + delayTime + " (sec)");

    }

}
