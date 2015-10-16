using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

    public float scrollLunchSpeed = 0.8f, frictionAcc = 1f;
    public float maxSlide;

    float totalSlideDist = 0;
    float currentSpeed;
    float objectLastXPosition;
    Vector3 mouseLastXPosition;

    bool holding = false;
    bool lastHoldingFrame = false;

    void Start()
    {
        objectLastXPosition = transform.position.x;
        mouseLastXPosition = Input.mousePosition;
    }
    void Update()
    {
        scrolling();
        //Debug.Log(totalSlideDist);
        updateSpeedNPosition();
    }

    void scrolling()
    {
        if (holding)
        {
            float deltaMouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x 
                - Camera.main.ScreenToWorldPoint(mouseLastXPosition).x;
            if(totalSlideDist + deltaMouseX > maxSlide)
            {
                deltaMouseX = maxSlide - totalSlideDist;
                totalSlideDist = maxSlide;
            }
            else if (totalSlideDist + deltaMouseX < -maxSlide)
            {
                deltaMouseX = -maxSlide - totalSlideDist;
                totalSlideDist = -maxSlide;
            }
            else
            {
                totalSlideDist += deltaMouseX;
            }

            foreach(Transform child in transform)
            {
                child.position = new Vector3(child.position.x + deltaMouseX, child.position.y, child.position.z);
            }
        }
        // lunch velocity
        else if(lastHoldingFrame)
        {
            if ((Input.mousePosition.x - mouseLastXPosition.x) > 0)
            {
                currentSpeed = scrollLunchSpeed;
            }
            else if ((Input.mousePosition.x - mouseLastXPosition.x) < 0)
            {
                currentSpeed = -scrollLunchSpeed;
            }
            else
            {
                currentSpeed = 0;
            }
        }

        lastHoldingFrame = holding;
        mouseLastXPosition = Input.mousePosition;
    }

    void updateSpeedNPosition()
    {
        if(!holding)
        {
            // TODO
            //bool speedTooMuch = false;
            //if(totalSlideDist + currentSpeed > maxSlide)
            //{
            //    currentSpeed = maxSlide - totalSlideDist;
            //    totalSlideDist = maxSlide;
            //    speedTooMuch = true;
            //}
            //else if (totalSlideDist + currentSpeed < -maxSlide)
            //{
            //    currentSpeed = -maxSlide - totalSlideDist;
            //    totalSlideDist = -maxSlide;
            //    speedTooMuch = true;
            //}
            //else
            //{
            //    totalSlideDist += currentSpeed;
            //    speedTooMuch = false;
            //}

            foreach(Transform child in transform)
            {
                child.position = new Vector3(child.position.x + currentSpeed * Time.deltaTime, child.position.y, child.position.z);
            }

            
            if (currentSpeed > 0)
            {
                currentSpeed -= frictionAcc * Time.deltaTime;

                if (currentSpeed < 0)
                    currentSpeed = 0;
            }
            else
            {
                currentSpeed += frictionAcc * Time.deltaTime;
                
                if(currentSpeed > 0)
                    currentSpeed = 0;
            }
        }
    }

	void OnMouseDown()
    {
        holding = true;
    }

    void OnMouseUp()
    {
        holding = false;
    }
}
