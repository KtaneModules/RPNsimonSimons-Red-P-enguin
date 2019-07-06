using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class simonsScript : MonoBehaviour {
    public KMBombInfo bomb;
    public KMAudio Audio;

    static int ModuleIdCounter = 0;
    int ModuleId;
    private bool moduleSolved = false;
    private int buttonIndex = 0;
    private bool incorrect = false;

    public KMSelectable[] Whatareyoudoingheregobacktodefusingyourbomb;

    private KMSelectable selSelectedButton;
    private KMSelectable selCorrectButton;
    private static KMSelectable button1;
    private static KMSelectable button2;
    private static KMSelectable button3;
    private static KMSelectable button4;
    private static KMSelectable button5;
    private KMSelectable corButton1;
    private KMSelectable corButton2;
    private KMSelectable corButton3;
    private KMSelectable corButton4;
    private KMSelectable corButton5;
    private Light light1;
    private Light light2;
    private Light light3;
    private Light light4;
    private Light light5;
    private KMSelectable placeholder1;
    private KMSelectable placeholder2;
    private KMSelectable placeholder3;
    private KMSelectable placeholder4;

    private bool pickingColors = true;
    private Coroutine FlickerRoutine;
    private bool stopLights = false;
    private int stageNumber = 0;
    public Light[] lights;

    void pickButtonColor()
    {
        pickingColors = true;
        if(corButton1 == null)
        {
            buttonIndex = UnityEngine.Random.Range(0, 15);
            button1 = Whatareyoudoingheregobacktodefusingyourbomb[buttonIndex];
            selSelectedButton = button1;
            Debug.LogFormat("Simon Simons [#{0}]: The first button is {1}.", ModuleId, button1);
            light1 = lights[buttonIndex];
            CorrectButtonFinder();
        }
        if(corButton2 == null)
        {
            buttonIndex = UnityEngine.Random.Range(0, 15);
            button2 = Whatareyoudoingheregobacktodefusingyourbomb[buttonIndex];
            selSelectedButton = button2;
            Debug.LogFormat("Simon Simons [#{0}]: The second button is {1}.", ModuleId, button2);
            light2 = lights[buttonIndex];
            CorrectButtonFinder();
        }
        if (corButton3 == null)
        {
            buttonIndex = UnityEngine.Random.Range(0, 15);
            button3 = Whatareyoudoingheregobacktodefusingyourbomb[buttonIndex];
            selSelectedButton = button3;
            Debug.LogFormat("Simon Simons [#{0}]: The third button is {1}.", ModuleId, button3);
            light3 = lights[buttonIndex];
            CorrectButtonFinder();
        }
        if (corButton4 == null)
        {
            buttonIndex = UnityEngine.Random.Range(0, 15);
            button4 = Whatareyoudoingheregobacktodefusingyourbomb[buttonIndex];
            selSelectedButton = button4;
            Debug.LogFormat("Simon Simons [#{0}]: The fourth button is {1}.", ModuleId, button4);
            light4 = lights[buttonIndex];
            CorrectButtonFinder();
        }
        if (corButton5 == null)
        {
            buttonIndex = UnityEngine.Random.Range(0, 15);
            button5 = Whatareyoudoingheregobacktodefusingyourbomb[buttonIndex];
            selSelectedButton = button5;
            Debug.LogFormat("Simon Simons [#{0}]: The fifth button is {1}.", ModuleId, button5);
            light5 = lights[buttonIndex];
            CorrectButtonFinder();
        }
    }

    void strikeFindColor()
    {
        corButton1 = null;
        corButton2 = null;
        corButton3 = null;
        corButton4 = null;
        corButton5 = null;
        selSelectedButton = button1;
        CorrectButtonFinder();
    }

    void Awake()
    {
        ModuleId = ModuleIdCounter++;

        foreach (KMSelectable button in Whatareyoudoingheregobacktodefusingyourbomb)
        {
            KMSelectable pressedButton = button;
            button.OnInteract += delegate () { buttonPressed(pressedButton); return false; };
        }
        foreach (Light light in lights)
        {
           light.enabled = false;
        }
        pickButtonColor();
    }

    private IEnumerator FlickerCoRoutine1()
    {
        while (stageNumber == 0 && stopLights == false)
        {
            yield return new WaitForSeconds(3);
            light1.enabled = true;

            if(button1 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if(button1 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if(button1 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light1.enabled = false;
        }
    }

    private IEnumerator FlickerCoRoutine2()
    {
        while (stageNumber == 1 && stopLights == false)
        {
            yield return new WaitForSeconds(3);
            light1.enabled = true;

            if (button1 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button1 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button1 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light1.enabled = false;
            yield return new WaitForSeconds(1);
            light2.enabled = true;

            if (button2 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button2 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button2 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light2.enabled = false;
        }
    }

    private IEnumerator FlickerCoRoutine3()
    {
        while (stageNumber == 2 && stopLights == false)
        {
            yield return new WaitForSeconds(3);
            light1.enabled = true;

            if (button1 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button1 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button1 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light1.enabled = false;
            yield return new WaitForSeconds(1);
            light2.enabled = true;

            if (button2 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button2 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button2 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light2.enabled = false;
            yield return new WaitForSeconds(1);
            light3.enabled = true;

            if (button3 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button3 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button3 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light3.enabled = false;
        }
    }

    private IEnumerator FlickerCoRoutine4()
    {
        while (stageNumber == 3 && stopLights == false)
        {
            yield return new WaitForSeconds(3);
            light1.enabled = true;

            if (button1 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button1 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button1 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light1.enabled = false;
            yield return new WaitForSeconds(1);
            light2.enabled = true;

            if (button2 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button2 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button2 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light2.enabled = false;
            yield return new WaitForSeconds(1);
            light3.enabled = true;

            if (button3 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button3 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button3 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light3.enabled = false;
            yield return new WaitForSeconds(1);
            light4.enabled = true;

            if (button4 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button4 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button4 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light4.enabled = false;
        }
    }

    private IEnumerator FlickerCoRoutine5()
    {
        while (stageNumber == 4 && stopLights == false)
        {
            yield return new WaitForSeconds(3);
            light1.enabled = true;

            if (button1 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button1 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button1 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button1 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light1.enabled = false;
            yield return new WaitForSeconds(1);
            light2.enabled = true;

            if (button2 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button2 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button2 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button2 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light2.enabled = false;
            yield return new WaitForSeconds(1);
            light3.enabled = true;

            if (button3 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button3 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button3 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button3 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light3.enabled = false;
            yield return new WaitForSeconds(1);
            light4.enabled = true;

            if (button4 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button4 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button4 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button4 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light4.enabled = false;
            yield return new WaitForSeconds(1);
            light5.enabled = true;

            if (button5 == Whatareyoudoingheregobacktodefusingyourbomb[0] || button5 == Whatareyoudoingheregobacktodefusingyourbomb[4] || button5 == Whatareyoudoingheregobacktodefusingyourbomb[8] || button5 == Whatareyoudoingheregobacktodefusingyourbomb[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (button5 == Whatareyoudoingheregobacktodefusingyourbomb[1] || button5 == Whatareyoudoingheregobacktodefusingyourbomb[5] || button5 == Whatareyoudoingheregobacktodefusingyourbomb[9] || button5 == Whatareyoudoingheregobacktodefusingyourbomb[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (button5 == Whatareyoudoingheregobacktodefusingyourbomb[2] || button5 == Whatareyoudoingheregobacktodefusingyourbomb[6] || button5 == Whatareyoudoingheregobacktodefusingyourbomb[10] || button5 == Whatareyoudoingheregobacktodefusingyourbomb[14])
                    {
                        Audio.PlaySoundAtTransform("red", transform);
                    }
                    else
                    {
                        Audio.PlaySoundAtTransform("green", transform);
                    }
                }
            }

            yield return new WaitForSeconds(1);
            light5.enabled = false;
        }
    }

    void buttonPressed(KMSelectable pressedButton)
    {
        StopAllCoroutines();

        if (pressedButton == Whatareyoudoingheregobacktodefusingyourbomb[0] || pressedButton == Whatareyoudoingheregobacktodefusingyourbomb[4] || pressedButton == Whatareyoudoingheregobacktodefusingyourbomb[8] || pressedButton == Whatareyoudoingheregobacktodefusingyourbomb[12])
        {
            Audio.PlaySoundAtTransform("blue", transform);
        }
        else
        {
            if (pressedButton == Whatareyoudoingheregobacktodefusingyourbomb[1] || pressedButton == Whatareyoudoingheregobacktodefusingyourbomb[5] || pressedButton == Whatareyoudoingheregobacktodefusingyourbomb[9] || pressedButton == Whatareyoudoingheregobacktodefusingyourbomb[13])
            {
                Audio.PlaySoundAtTransform("yellow", transform);
            }
            else
            {
                if (pressedButton == Whatareyoudoingheregobacktodefusingyourbomb[2] || pressedButton == Whatareyoudoingheregobacktodefusingyourbomb[6] || pressedButton == Whatareyoudoingheregobacktodefusingyourbomb[10] || pressedButton == Whatareyoudoingheregobacktodefusingyourbomb[14])
                {
                    Audio.PlaySoundAtTransform("red", transform);
                }
                else
                {
                    Audio.PlaySoundAtTransform("green", transform);
                }
            }
        }

        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        light4.enabled = false;
        light5.enabled = false;

        pressedButton.AddInteractionPunch();

        if (moduleSolved == true)
        {
            return;
        }

        if (stageNumber == 0)
        {
            if (pressedButton != corButton1)
            {
                incorrect = true;
            }

            if (incorrect != true)
            {
                Debug.LogFormat("Simon Simons [#{0}]: Correct sequence. Moving to the next stage.", ModuleId);
                stageNumber = stageNumber + 1;
                pressedButton = null;
                FlickerRoutine = StartCoroutine(FlickerCoRoutine2());
            }
            else
            {
                GetComponent<KMBombModule>().HandleStrike();
                incorrect = false;
                Debug.LogFormat("Simon Simons [#{0}]: Incorrect sequence. You pressed {1}, when the correct button was {2}.", ModuleId, pressedButton, corButton1);
                pressedButton = null;
                FlickerRoutine = StartCoroutine(FlickerCoRoutine1());
                strikeFindColor();
            }
        }
        else
        {
            if(stageNumber == 1)
            {
                if(placeholder1 == null)
                {
                    placeholder1 = pressedButton;
                }
                else
                {
                    if (pressedButton != corButton2 || placeholder1 != corButton1)
                    {
                        incorrect = true;
                    }

                    if (incorrect != true)
                    {
                        Debug.LogFormat("Simon Simons [#{0}]: Correct sequence. Moving to the next stage.", ModuleId);
                        stageNumber = stageNumber + 1;
                        pressedButton = null;
                        placeholder1 = null;
                        stopLights = false;
                        FlickerRoutine = StartCoroutine(FlickerCoRoutine3());
                    }
                    else
                    {
                        GetComponent<KMBombModule>().HandleStrike();
                        incorrect = false;
                        Debug.LogFormat("Simon Simons [#{0}]: Incorrect sequence. You pressed {1}, {2}, when the correct sequence was {3}, {4}.", ModuleId, pressedButton, placeholder1, corButton1, corButton2);
                        pressedButton = null;
                        placeholder1 = null;
                        FlickerRoutine = StartCoroutine(FlickerCoRoutine2());
                        strikeFindColor();
                    }
                }
            }
            else
            {
                if (stageNumber == 2)
                {
                    if (placeholder1 == null)
                    {
                        placeholder1 = pressedButton;
                    }
                    else
                    {
                        if (placeholder1 != null && placeholder2 == null)
                        {
                            placeholder2 = pressedButton;
                        }
                        else
                        {
                            if (pressedButton != corButton3 || placeholder1 != corButton1 || placeholder2 != corButton2)
                            {
                                incorrect = true;
                            }

                            if (incorrect != true)
                            {
                                Debug.LogFormat("Simon Simons [#{0}]: Correct sequence. Moving to the next stage.", ModuleId);
                                stageNumber = stageNumber + 1;
                                pressedButton = null;
                                placeholder1 = null;
                                placeholder2 = null;
                                stopLights = false;
                                FlickerRoutine = StartCoroutine(FlickerCoRoutine4());
                            }
                            else
                            {
                                GetComponent<KMBombModule>().HandleStrike();
                                incorrect = false;
                                Debug.LogFormat("Simon Simons [#{0}]: Incorrect sequence. You pressed {1}, {2}, {3}, when the correct sequence was {4}, {5}, {6}.", ModuleId, pressedButton, placeholder1, placeholder2, corButton1, corButton2, corButton3);
                                pressedButton = null;
                                placeholder1 = null;
                                placeholder2 = null;
                                FlickerRoutine = StartCoroutine(FlickerCoRoutine3());
                                strikeFindColor();
                            }
                        }
                    }
                }
                else
                {
                    if (stageNumber == 3)
                    {
                        if (placeholder1 == null)
                        {
                            placeholder1 = pressedButton;
                        }
                        else
                        {
                            if (placeholder1 != null && placeholder2 == null)
                            {
                                placeholder2 = pressedButton;
                            }
                            else
                            {
                                if (placeholder2 != null && placeholder3 == null)
                                {
                                    placeholder3 = pressedButton;
                                }
                                else
                                {
                                    if (pressedButton != corButton4 || placeholder1 != corButton1 || placeholder2 != corButton2 || placeholder3 != corButton3)
                                    {
                                        incorrect = true;
                                    }

                                    if (incorrect != true)
                                    {
                                        Debug.LogFormat("Simon Simons [#{0}]: Correct sequence. Moving to the next stage.", ModuleId);
                                        stageNumber = stageNumber + 1;
                                        pressedButton = null;
                                        placeholder1 = null;
                                        placeholder2 = null;
                                        placeholder3 = null;
                                        stopLights = false;
                                        FlickerRoutine = StartCoroutine(FlickerCoRoutine5());
                                    }
                                    else
                                    {
                                        GetComponent<KMBombModule>().HandleStrike();
                                        incorrect = false;
                                        Debug.LogFormat("Simon Simons [#{0}]: Incorrect sequence. You pressed {1}, {2}, {3}, {4}, when the correct sequence was {5}, {6}, {7}, {8}.", ModuleId, pressedButton, placeholder1, placeholder2, placeholder3, corButton1, corButton2, corButton3, corButton4);
                                        pressedButton = null;
                                        placeholder1 = null;
                                        placeholder2 = null;
                                        placeholder3 = null;
                                        strikeFindColor();
                                        FlickerRoutine = StartCoroutine(FlickerCoRoutine4());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (placeholder1 == null)
                        {
                            placeholder1 = pressedButton;
                        }
                        else
                        {
                            if (placeholder1 != null && placeholder2 == null)
                            {
                                placeholder2 = pressedButton;
                            }
                            else
                            {
                                if (placeholder2 != null && placeholder3 == null)
                                {
                                    placeholder3 = pressedButton;
                                }
                                else
                                {
                                    if (placeholder3 != null && placeholder4 == null)
                                    {
                                        placeholder4 = pressedButton;
                                    }
                                    else
                                    {
                                        if (pressedButton != corButton5 || placeholder1 != corButton1 || placeholder2 != corButton2 || placeholder3 != corButton3 || placeholder4 != corButton4)
                                        {
                                            incorrect = true;
                                        }

                                        if (incorrect != true)
                                        {
                                            moduleSolved = true;
                                            GetComponent<KMBombModule>().HandlePass();
                                            Debug.LogFormat("Simon Simons [#{0}]:  Module solved. Have a nice day.", ModuleId);
                                        }
                                        else
                                        {
                                            GetComponent<KMBombModule>().HandleStrike();
                                            incorrect = false;
                                            Debug.LogFormat("Simon Simons [#{0}]: Incorrect sequence. You pressed {1}, {2}, {3}, {4}, {5}, when the correct sequence was {6}, {7}, {8}, {9}, {10}.", ModuleId, pressedButton, placeholder1, placeholder2, placeholder3, placeholder4, corButton1, corButton2, corButton3, corButton4, corButton5);
                                            pressedButton = null;
                                            placeholder1 = null;
                                            placeholder2 = null;
                                            placeholder3 = null;
                                            placeholder4 = null;
                                            FlickerRoutine = StartCoroutine(FlickerCoRoutine5());
                                            strikeFindColor();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void CorrectButtonFinder()
    {
        //0
        if(selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[0] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[15];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[0] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[5];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[0] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[3];
        }
        //1
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[1] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[1];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[1] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[5];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[1] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[6];
        }
        //2
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[2] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[3];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[2] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[2];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[2] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[7];
        }
        //3
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[3] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[6];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[3] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[15];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[3] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[14];
        }
        //4
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[4] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[11];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[4] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[12];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[4] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[9];
        }
        //5
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[5] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[10];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[5] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[6];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[5] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[1];
        }
        //6
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[6] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[12];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[6] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[11];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[6] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[4];
        }
        //7
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[7] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[4];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[7] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[9];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[7] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[15];
        }
        //8
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[8] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[7];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[8] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[14];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[8] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[10];
        }
        //9
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[9] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[14];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[9] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[10];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[9] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[8];
        }
        //10
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[10] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[8];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[10] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[1];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[10] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[12];
        }
        //11
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[11] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[9];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[11] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[7];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[11] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[2];
        }
        //12
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[12] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[0];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[12] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[3];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[12] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[13];
        }
        //13
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[13] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[13];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[13] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[8];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[13] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[5];
        }
        //14
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[14] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[2];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[14] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[4];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[14] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[0];
        }
        //15
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[15] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[5];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[15] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[13];
        }
        if (selSelectedButton == Whatareyoudoingheregobacktodefusingyourbomb[15] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = Whatareyoudoingheregobacktodefusingyourbomb[11];
        }

        if (corButton5 == null)
        {
            if (corButton1 == null)
            {
                corButton1 = selCorrectButton;
                selSelectedButton = button2;
                Debug.LogFormat("Simon Simons [#{0}]: The correct button to press for the first color is {1}.", ModuleId, corButton1);
            }
            else
            {
                if (corButton2 == null)
                {
                    corButton2 = selCorrectButton;
                    selSelectedButton = button3;
                    Debug.LogFormat("Simon Simons [#{0}]: The correct button to press for the second color is {1}.", ModuleId, corButton2);
                }
                else
                {
                    if (corButton3 == null)
                    {
                        corButton3 = selCorrectButton;
                        selSelectedButton = button4;
                        Debug.LogFormat("Simon Simons [#{0}]: The correct button to press for the third color is {1}.", ModuleId, corButton3);
                    }
                    else
                    {
                        if (corButton4 == null)
                        {
                            corButton4 = selCorrectButton;
                            selSelectedButton = button5;
                            Debug.LogFormat("Simon Simons [#{0}]: The correct button to press for the fourth color is {1}.", ModuleId, corButton4);
                        }
                        else
                        {
                            corButton5 = selCorrectButton;
                            Debug.LogFormat("Simon Simons [#{0}]: The correct button to press for the fifth color is {1}.", ModuleId, corButton5);
                        }
                    }
                }
            }
            if (pickingColors == true && corButton5 == null)
            {
                pickButtonColor();
            }
            if (pickingColors == true && corButton5 != null)
            {
                pickingColors = false;
                StopAllCoroutines();
                FlickerRoutine = StartCoroutine(FlickerCoRoutine1());
            }

            if (pickingColors != true && corButton5 == null)
            {
                CorrectButtonFinder();
            }
        }
    }
}