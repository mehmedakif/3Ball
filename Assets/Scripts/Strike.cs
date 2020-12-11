using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*Strike clasi oyundaki vuruslari temsil eder. Oyuncu Space tusuna bastigi anda yeni bir vurus olusturulur.*/
public class Strike
{
    private Rigidbody[] balls;
    private bool isCollidedYellow;
    private bool isCollidedRed;
    public bool isMoving;

    public Strike(Rigidbody[] _balls)
    {
        balls = _balls;        
    }
    public bool checkCollide(string name)
    {
        if (name == "YellowBall")
        {
            isCollidedYellow = true;
        }
        else if (name == "RedBall")
        {
            isCollidedRed = true;
        }
        if (isCollidedRed && isCollidedYellow) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void checkMovement()
    {
        isStopped(balls[0].velocity.magnitude, balls[1].velocity.magnitude, balls[2].velocity.magnitude);
    }
    public void isStopped(float v0, float v1, float v2)
    {
        if (v0 < 0.01f && v1 < 0.01f && v2 < 0.01f)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
}
