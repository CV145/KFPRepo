using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    //Camera Zoom Effect
    public static CameraZoom CamZoom = new CameraZoom();
    //length of the powerup
    public static int SublimeBulletTimeLength = 5;
    //speed slowdown multiplier (base speed * this)
    public static float SublimeBulletTimeSpeedMultiplier = 0.5f;
    //set in function, don't touch pls
    public static bool SublimeTimeActive = false;
    //same as above
    public static float SublimeTimeStart;

    //length of the powerup
    public static int QuadruplePupilTimeLength = 5;
    //set in function, don't touch pls
    public static bool QuadruplePupilActive = false;
    //same as above
    public static float QuadruplePupilTimeStart;

    //length of the powerup
    public static int BodySlamJamLength = 5;
    //set in function, don't touch pls
    public static bool BodySlamJamActive = false;
    //same as above
    public static float BodySlamJamTimeStart;

    //length of the powerup
    public static int PushKickTrickLength = 1;
    //power of push kick trick
    public static float PushKickTrickPower = 0.4f;
    //set in function, don't touch pls
    public static bool PushKickTrickActive = false;
    //same as above
    public static float PushKickTrickTimeStart;

    public static Player P;

    public static void PlayPowerup(string name)
    {
        CamZoom.DoZoom(P.gameObject);
        name = name.ToLower();
        if (name == "sublime bullet time")
        {
            SublimeBulletTime();
        } else if(name == "quadruple pupil")
        {
            QuadruplePupil();
        } else if(name == "body slam jam")
        {
            BodySlamJam();
        } else if(name == "push kick trick")
        {
            PushKickTrick();
        }
    }

    public static void PushKickTrick()
    {
        PushKickTrickActive = true;
        PushKickTrickTimeStart = Time.time;
    }

    public static void BodySlamJam()
    {
        BodySlamJamActive = true;
        BodySlamJamTimeStart = Time.time;
        //Mover.MoveMultiplier = 0;
        //Time.timeScale = 0.1f;
    }

    public static void QuadruplePupil()
    {
        QuadruplePupilActive = true;
        QuadruplePupilTimeStart = Time.time;
    }


    public static void SublimeBulletTime()
    {
        Time.timeScale = SublimeBulletTimeSpeedMultiplier;
       // Mover.MoveMultiplier = SublimeBulletTimeSpeedMultiplier;
        SublimeTimeStart = Time.time;
        SublimeTimeActive = true;
        Debug.Log("Initiated SublimeTime");
    }

    private void FixedUpdate()
    {
        if (SublimeTimeActive)
        {
            if(Time.time - SublimeTimeStart >= SublimeBulletTimeLength)
            {
                if (BodySlamJamActive)
                {
                    BodySlamJam();
                }
                else
                {
                    ReturnNormalTime();
                }
                SublimeTimeActive = false;
            }
        }

        if (QuadruplePupilActive)
        {
            if(P == null)
            {
                P = GameObject.Find("Player").GetComponent<Player>();
            }

            P.shooter.CurrentAmmo = 6;
            if (Time.time - QuadruplePupilTimeStart >= QuadruplePupilTimeLength)
            {
                QuadruplePupilActive = false;
            }
        }

        if (BodySlamJamActive)
        {
            if(Time.time - BodySlamJamTimeStart >= BodySlamJamLength)
            {
                if (!SublimeTimeActive)
                {
                    ReturnNormalTime();
                } else
                {
                    SublimeBulletTime();
                }
                BodySlamJamActive = false;
            }
        }

        if (PushKickTrickActive)
        {
            if (P == null)
            {
                P = GameObject.Find("Player").GetComponent<Player>();
            }

            foreach (GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Vector3 Dir = P.transform.position - Enemy.transform.position;
                Enemy.transform.position -= Dir.normalized*PushKickTrickPower;
            }

            if (Time.time - PushKickTrickTimeStart >= PushKickTrickLength)
            {
                PushKickTrickActive = false;
            }
        }
    }

    public void ReturnNormalTime()
    {
        Time.timeScale = 1;
       // Mover.MoveMultiplier = 1;
        Debug.Log("Returning time scale");
    }
}
