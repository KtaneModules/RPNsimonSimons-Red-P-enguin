using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class simonsScript : MonoBehaviour
{
    public KMBombInfo bomb;
    public KMAudio Audio;

    static int ModuleIdCounter = 0;
    int ModuleId;
    private bool moduleSolved = false;
    private int buttonIndex = 0;
    private bool incorrect = false;

    public KMSelectable[] buttons;

    private KMSelectable selSelectedButton;
    private KMSelectable selCorrectButton;
    private KMSelectable[] selButtons = new KMSelectable[5];
    private KMSelectable[] corButtons = new KMSelectable[5];
    private Light[] selLights = new Light[5];
    private List<KMSelectable> placeholders = new List<KMSelectable>();
    private bool pickingColors = true;
    private Coroutine FlickerRoutine;
    private bool stopLights = false;
    private int stageNumber = 0;
    public Light[] lights;

    void pickButtonColor()
    {
        pickingColors = true;
        //1
        buttonIndex = UnityEngine.Random.Range(0, 15);
        selButtons[0] = buttons[buttonIndex];
        DebugMsg(" The first button is " + selButtons[0]);
        selLights[0] = lights[buttonIndex];
        //2
        buttonIndex = UnityEngine.Random.Range(0, 15);
        selButtons[1] = buttons[buttonIndex];
        DebugMsg("The second button is " + selButtons[1]);
        selLights[1] = lights[buttonIndex];
        //3
        buttonIndex = UnityEngine.Random.Range(0, 15);
        selButtons[2] = buttons[buttonIndex];
        DebugMsg("The third button is " + selButtons[2]);
        selLights[2] = lights[buttonIndex];
        //4
        buttonIndex = UnityEngine.Random.Range(0, 15);
        selButtons[3] = buttons[buttonIndex];
        DebugMsg("The fourth button is " + selButtons[3]);
        selLights[3] = lights[buttonIndex];
        //5
        buttonIndex = UnityEngine.Random.Range(0, 15);
        selButtons[4] = buttons[buttonIndex];
        DebugMsg("The fifth button is " + selButtons[4]);
        selLights[4] = lights[buttonIndex];
        selSelectedButton = selButtons[0];
        CorrectButtonFinder();

    }

    void strikeFindColor()
    {
        corButtons[0] = null;
        corButtons[1] = null;
        corButtons[2] = null;
        corButtons[3] = null;
        corButtons[4] = null;
        selSelectedButton = selButtons[0];
        CorrectButtonFinder();
    }

    void Awake()
    {
        ModuleId = ModuleIdCounter++;

        foreach (KMSelectable button in buttons)
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
            selLights[0].enabled = true;

            if (selButtons[0] == buttons[0] || selButtons[0] == buttons[4] || selButtons[0] == buttons[8] || selButtons[0] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[0] == buttons[1] || selButtons[0] == buttons[5] || selButtons[0] == buttons[9] || selButtons[0] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[0] == buttons[2] || selButtons[0] == buttons[6] || selButtons[0] == buttons[10] || selButtons[0] == buttons[14])
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
            selLights[0].enabled = false;
        }
    }

    private IEnumerator FlickerCoRoutine2()
    {
        while (stageNumber == 1 && stopLights == false)
        {
            yield return new WaitForSeconds(3);
            selLights[0].enabled = true;

            if (selButtons[0] == buttons[0] || selButtons[0] == buttons[4] || selButtons[0] == buttons[8] || selButtons[0] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[0] == buttons[1] || selButtons[0] == buttons[5] || selButtons[0] == buttons[9] || selButtons[0] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[0] == buttons[2] || selButtons[0] == buttons[6] || selButtons[0] == buttons[10] || selButtons[0] == buttons[14])
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
            selLights[0].enabled = false;
            yield return new WaitForSeconds(1);
            selLights[1].enabled = true;

            if (selButtons[1] == buttons[0] || selButtons[1] == buttons[4] || selButtons[1] == buttons[8] || selButtons[1] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[1] == buttons[1] || selButtons[1] == buttons[5] || selButtons[1] == buttons[9] || selButtons[1] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[1] == buttons[2] || selButtons[1] == buttons[6] || selButtons[1] == buttons[10] || selButtons[1] == buttons[14])
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
            selLights[1].enabled = false;
        }
    }

    private IEnumerator FlickerCoRoutine3()
    {
        while (stageNumber == 2 && stopLights == false)
        {
            yield return new WaitForSeconds(3);
            selLights[0].enabled = true;

            if (selButtons[0] == buttons[0] || selButtons[0] == buttons[4] || selButtons[0] == buttons[8] || selButtons[0] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[0] == buttons[1] || selButtons[0] == buttons[5] || selButtons[0] == buttons[9] || selButtons[0] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[0] == buttons[2] || selButtons[0] == buttons[6] || selButtons[0] == buttons[10] || selButtons[0] == buttons[14])
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
            selLights[0].enabled = false;
            yield return new WaitForSeconds(1);
            selLights[1].enabled = true;

            if (selButtons[1] == buttons[0] || selButtons[1] == buttons[4] || selButtons[1] == buttons[8] || selButtons[1] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[1] == buttons[1] || selButtons[1] == buttons[5] || selButtons[1] == buttons[9] || selButtons[1] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[1] == buttons[2] || selButtons[1] == buttons[6] || selButtons[1] == buttons[10] || selButtons[1] == buttons[14])
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
            selLights[1].enabled = false;
            yield return new WaitForSeconds(1);
            selLights[2].enabled = true;

            if (selButtons[2] == buttons[0] || selButtons[2] == buttons[4] || selButtons[2] == buttons[8] || selButtons[2] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[2] == buttons[1] || selButtons[2] == buttons[5] || selButtons[2] == buttons[9] || selButtons[2] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[2] == buttons[2] || selButtons[2] == buttons[6] || selButtons[2] == buttons[10] || selButtons[2] == buttons[14])
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
            selLights[2].enabled = false;
        }
    }

    private IEnumerator FlickerCoRoutine4()
    {
        while (stageNumber == 3 && stopLights == false)
        {
            yield return new WaitForSeconds(3);
            selLights[0].enabled = true;

            if (selButtons[0] == buttons[0] || selButtons[0] == buttons[4] || selButtons[0] == buttons[8] || selButtons[0] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[0] == buttons[1] || selButtons[0] == buttons[5] || selButtons[0] == buttons[9] || selButtons[0] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[0] == buttons[2] || selButtons[0] == buttons[6] || selButtons[0] == buttons[10] || selButtons[0] == buttons[14])
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
            selLights[0].enabled = false;
            yield return new WaitForSeconds(1);
            selLights[1].enabled = true;

            if (selButtons[1] == buttons[0] || selButtons[1] == buttons[4] || selButtons[1] == buttons[8] || selButtons[1] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[1] == buttons[1] || selButtons[1] == buttons[5] || selButtons[1] == buttons[9] || selButtons[1] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[1] == buttons[2] || selButtons[1] == buttons[6] || selButtons[1] == buttons[10] || selButtons[1] == buttons[14])
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
            selLights[1].enabled = false;
            yield return new WaitForSeconds(1);
            selLights[2].enabled = true;

            if (selButtons[2] == buttons[0] || selButtons[2] == buttons[4] || selButtons[2] == buttons[8] || selButtons[2] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[2] == buttons[1] || selButtons[2] == buttons[5] || selButtons[2] == buttons[9] || selButtons[2] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[2] == buttons[2] || selButtons[2] == buttons[6] || selButtons[2] == buttons[10] || selButtons[2] == buttons[14])
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
            selLights[2].enabled = false;
            yield return new WaitForSeconds(1);
            selLights[3].enabled = true;

            if (selButtons[3] == buttons[0] || selButtons[3] == buttons[4] || selButtons[3] == buttons[8] || selButtons[3] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[3] == buttons[1] || selButtons[3] == buttons[5] || selButtons[3] == buttons[9] || selButtons[3] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[3] == buttons[2] || selButtons[3] == buttons[6] || selButtons[3] == buttons[10] || selButtons[3] == buttons[14])
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
            selLights[3].enabled = false;
        }
    }

    private IEnumerator FlickerCoRoutine5()
    {
        while (stageNumber == 4 && stopLights == false)
        {
            yield return new WaitForSeconds(3);
            selLights[0].enabled = true;

            if (selButtons[0] == buttons[0] || selButtons[0] == buttons[4] || selButtons[0] == buttons[8] || selButtons[0] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[0] == buttons[1] || selButtons[0] == buttons[5] || selButtons[0] == buttons[9] || selButtons[0] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[0] == buttons[2] || selButtons[0] == buttons[6] || selButtons[0] == buttons[10] || selButtons[0] == buttons[14])
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
            selLights[0].enabled = false;
            yield return new WaitForSeconds(1);
            selLights[1].enabled = true;

            if (selButtons[1] == buttons[0] || selButtons[1] == buttons[4] || selButtons[1] == buttons[8] || selButtons[1] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[1] == buttons[1] || selButtons[1] == buttons[5] || selButtons[1] == buttons[9] || selButtons[1] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[1] == buttons[2] || selButtons[1] == buttons[6] || selButtons[1] == buttons[10] || selButtons[1] == buttons[14])
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
            selLights[1].enabled = false;
            yield return new WaitForSeconds(1);
            selLights[2].enabled = true;

            if (selButtons[2] == buttons[0] || selButtons[2] == buttons[4] || selButtons[2] == buttons[8] || selButtons[2] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[2] == buttons[1] || selButtons[2] == buttons[5] || selButtons[2] == buttons[9] || selButtons[2] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[2] == buttons[2] || selButtons[2] == buttons[6] || selButtons[2] == buttons[10] || selButtons[2] == buttons[14])
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
            selLights[2].enabled = false;
            yield return new WaitForSeconds(1);
            selLights[3].enabled = true;

            if (selButtons[3] == buttons[0] || selButtons[3] == buttons[4] || selButtons[3] == buttons[8] || selButtons[3] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[3] == buttons[1] || selButtons[3] == buttons[5] || selButtons[3] == buttons[9] || selButtons[3] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[3] == buttons[2] || selButtons[3] == buttons[6] || selButtons[3] == buttons[10] || selButtons[3] == buttons[14])
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
            selLights[3].enabled = false;
            yield return new WaitForSeconds(1);
            selLights[4].enabled = true;

            if (selButtons[4] == buttons[0] || selButtons[4] == buttons[4] || selButtons[4] == buttons[8] || selButtons[4] == buttons[12])
            {
                Audio.PlaySoundAtTransform("blue", transform);
            }
            else
            {
                if (selButtons[4] == buttons[1] || selButtons[4] == buttons[5] || selButtons[4] == buttons[9] || selButtons[4] == buttons[13])
                {
                    Audio.PlaySoundAtTransform("yellow", transform);
                }
                else
                {
                    if (selButtons[4] == buttons[2] || selButtons[4] == buttons[6] || selButtons[4] == buttons[10] || selButtons[4] == buttons[14])
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
            selLights[4].enabled = false;
        }
    }

    void buttonPressed(KMSelectable pressedButton)
    {
        StopAllCoroutines();

        if (pressedButton == buttons[0] || pressedButton == buttons[4] || pressedButton == buttons[8] || pressedButton == buttons[12])
        {
            Audio.PlaySoundAtTransform("blue", transform);
        }
        else if (pressedButton == buttons[1] || pressedButton == buttons[5] || pressedButton == buttons[9] || pressedButton == buttons[13])
        {
            Audio.PlaySoundAtTransform("yellow", transform);
        }
        else if (pressedButton == buttons[2] || pressedButton == buttons[6] || pressedButton == buttons[10] || pressedButton == buttons[14])
        {

            Audio.PlaySoundAtTransform("red", transform);
        }
        else
        {
            Audio.PlaySoundAtTransform("green", transform);
        }

        selLights[0].enabled = false;
        selLights[1].enabled = false;
        selLights[2].enabled = false;
        selLights[3].enabled = false;
        selLights[4].enabled = false;

        pressedButton.AddInteractionPunch();

        if (moduleSolved == true)
        {
            return;
        }

        if (stageNumber == 0)
        {
            if (pressedButton != corButtons[0])
            {
                incorrect = true;
            }

            if (incorrect != true)
            {
                DebugMsg("Correct sequence. Moving to the next stage.");
                stageNumber = stageNumber + 1;
                pressedButton = null;
                FlickerRoutine = StartCoroutine(FlickerCoRoutine2());
            }
            else
            {
                GetComponent<KMBombModule>().HandleStrike();
                incorrect = false;
                DebugMsg("Incorrect sequence. You pressed " + pressedButton + ", when the correct button was " + corButtons[0]);
                pressedButton = null;
                strikeFindColor();
            }
        }
        else if (stageNumber == 1)
        {
            if (placeholders.Count != 1)
            {
                placeholders.Add(pressedButton);
            }
            else
            {
                if (pressedButton != corButtons[1] || placeholders[0] != corButtons[0])
                {
                    incorrect = true;
                }

                if (incorrect != true)
                {
                    DebugMsg("Correct sequence. Moving to the next stage.");
                    stageNumber = stageNumber + 1;
                    pressedButton = null;
                    placeholders[0] = null;
                    stopLights = false;
                    placeholders.Clear();
                    FlickerRoutine = StartCoroutine(FlickerCoRoutine3());
                }
                else
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    incorrect = false;
                    DebugMsg("Incorrect sequence. You pressed " + placeholders[0] + " " + pressedButton + ", when the correct sequence was " + corButtons[0] + " " + corButtons[1]);
                    pressedButton = null;
                    placeholders.Clear();
                    strikeFindColor();
                }
            }
        }
        else if (stageNumber == 2)
        {
            {
                if (placeholders.Count < 2)
                {
                    placeholders.Add(pressedButton);
                }
                else
                {
                    if (pressedButton != corButtons[2] || placeholders[0] != corButtons[0] || placeholders[1] != corButtons[1])
                    {
                        incorrect = true;
                    }

                    if (incorrect != true)
                    {
                        DebugMsg("Correct sequence. Moving to the next stage.");
                        stageNumber = stageNumber + 1;
                        pressedButton = null;
                        stopLights = false;
                        placeholders.Clear();
                        FlickerRoutine = StartCoroutine(FlickerCoRoutine4());
                    }
                    else
                    {
                        GetComponent<KMBombModule>().HandleStrike();
                        incorrect = false;
                        DebugMsg("Incorrect sequence. You pressed " + placeholders[0] + " " + placeholders[1] + " " + pressedButton + ", when the correct sequence was " + corButtons[0] + " " + corButtons[1] + " " + corButtons[2]);
                        pressedButton = null;
                        placeholders.Clear();
                        strikeFindColor();
                    }
                }
            }
        }
        else if (stageNumber == 3)
        {
            if (placeholders.Count < 3)
            {
                placeholders.Add(pressedButton);
            }
            else
            {
                if (pressedButton != corButtons[3] || placeholders[0] != corButtons[0] || placeholders[1] != corButtons[1] || placeholders[2] != corButtons[2])
                {
                    incorrect = true;
                }

                if (incorrect != true)
                {
                    DebugMsg("Correct sequence. Moving to the next stage.");
                    stageNumber = stageNumber + 1;
                    pressedButton = null;
                    stopLights = false;
                    placeholders.Clear();
                    FlickerRoutine = StartCoroutine(FlickerCoRoutine5());
                }
                else
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    incorrect = false;
                    DebugMsg("Incorrect sequence. You pressed " + placeholders[0] + " " + placeholders[1] + " " + placeholders[2] + " " + pressedButton + ", when the correct sequence was " + corButtons[0] + " " + corButtons[1] + " " + corButtons[2] + " " + corButtons[3]);
                    pressedButton = null;
                    placeholders.Clear();
                    strikeFindColor();
                }
            }
        }
        else
        {
            if (placeholders.Count < 4)
            {
                placeholders.Add(pressedButton);
            }
            else
            {
                if (pressedButton != corButtons[4] || placeholders[0] != corButtons[0] || placeholders[1] != corButtons[1] || placeholders[2] != corButtons[2] || placeholders[3] != corButtons[3])
                {
                    incorrect = true;
                }

                if (incorrect != true)
                {
                    moduleSolved = true;
                    GetComponent<KMBombModule>().HandlePass();
                    DebugMsg("Module solved. Have a nice day.");
                }
                else
                {
                    GetComponent<KMBombModule>().HandleStrike();
                    incorrect = false;
                    DebugMsg("Incorrect sequence. You pressed " + placeholders[0] + " " + placeholders[1] + " " + placeholders[2] + " " + placeholders[3] + " " + pressedButton + ", when the correct sequence was " + corButtons[0] + " " + corButtons[1] + " " + corButtons[2] + " " + corButtons[3] + " " + corButtons[4]);
                    pressedButton = null;
                    strikeFindColor();
                }
            }
        }
    }

    public string TwitchHelpMessage = "Press a button using !{0} press TB to press TB. Valid buttons are TB, TY, TR, TG, RB, RY, RR, RG, LB, LY, LR, LG, BB, BY, BR, BG.";
    IEnumerator ProcessTwitchCommand(string cmd)
    {
        if (cmd.ToLowerInvariant().StartsWith("press "))
        {
            string btns = cmd.Substring(6);
            string[] btnSequence = btns.Split(' ');

            if (btnSequence.Length > 5)
            {
                yield return "sendtochaterror Sorry, but that appears to be longer than the maximum sequence.";
                yield break;
            }

            foreach (var btn in btnSequence)
            {
                yield return null;

                if (btn == "TB")
                {
                    yield return new KMSelectable[] { buttons[0] };
                }

                else if (btn == "TY")
                {
                    yield return new KMSelectable[] { buttons[1] };
                }

                else if (btn == "TR")
                {
                    yield return new KMSelectable[] { buttons[2] };
                }

                else if (btn == "TG")
                {
                    yield return new KMSelectable[] { buttons[3] };
                }
                else if (btn == "RB")
                {
                    yield return new KMSelectable[] { buttons[4] };
                }
                else if (btn == "RY")
                {
                    yield return new KMSelectable[] { buttons[5] };
                }
                else if (btn == "RR")
                {
                    yield return new KMSelectable[] { buttons[6] };
                }
                else if (btn == "RG")
                {
                    yield return new KMSelectable[] { buttons[7] };
                }
                else if (btn == "LB")
                {
                    yield return new KMSelectable[] { buttons[8] };
                }
                else if (btn == "LY")
                {
                    yield return new KMSelectable[] { buttons[9] };
                }
                else if (btn == "LR")
                {
                    yield return new KMSelectable[] { buttons[10] };
                }
                else if (btn == "LG")
                {
                    yield return new KMSelectable[] { buttons[11] };
                }
                else if (btn == "BB")
                {
                    yield return new KMSelectable[] { buttons[12] };
                }
                else if (btn == "BY")
                {
                    yield return new KMSelectable[] { buttons[13] };
                }
                else if (btn == "BR")
                {
                    yield return new KMSelectable[] { buttons[14] };
                }
                else if (btn == "BG")
                {
                    yield return new KMSelectable[] { buttons[15] };
                }
                else
                {
                    yield return "sendtochaterror Sorry, I'm not quite sure what one of those is.";
                    yield break;
                }
            }
        }

        else
        {
            yield break;
        }
    }

    void DebugMsg(string msg)
    {
        Debug.LogFormat("[Simon Simons #{0}] {1}", ModuleId, msg);
    }

    void CorrectButtonFinder()
    {
        //0
        if (selSelectedButton == buttons[0] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[15];
        }
        if (selSelectedButton == buttons[0] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[5];
        }
        if (selSelectedButton == buttons[0] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[3];
        }
        //1
        if (selSelectedButton == buttons[1] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[1];
        }
        if (selSelectedButton == buttons[1] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[0];
        }
        if (selSelectedButton == buttons[1] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[6];
        }
        //2
        if (selSelectedButton == buttons[2] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[3];
        }
        if (selSelectedButton == buttons[2] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[2];
        }
        if (selSelectedButton == buttons[2] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[7];
        }
        //3
        if (selSelectedButton == buttons[3] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[6];
        }
        if (selSelectedButton == buttons[3] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[15];
        }
        if (selSelectedButton == buttons[3] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[14];
        }
        //4
        if (selSelectedButton == buttons[4] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[11];
        }
        if (selSelectedButton == buttons[4] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[12];
        }
        if (selSelectedButton == buttons[4] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[9];
        }
        //5
        if (selSelectedButton == buttons[5] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[10];
        }
        if (selSelectedButton == buttons[5] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[6];
        }
        if (selSelectedButton == buttons[5] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[1];
        }
        //6
        if (selSelectedButton == buttons[6] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[12];
        }
        if (selSelectedButton == buttons[6] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[11];
        }
        if (selSelectedButton == buttons[6] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[4];
        }
        //7
        if (selSelectedButton == buttons[7] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[4];
        }
        if (selSelectedButton == buttons[7] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[9];
        }
        if (selSelectedButton == buttons[7] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[15];
        }
        //8
        if (selSelectedButton == buttons[8] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[7];
        }
        if (selSelectedButton == buttons[8] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[14];
        }
        if (selSelectedButton == buttons[8] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[10];
        }
        //9
        if (selSelectedButton == buttons[9] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[14];
        }
        if (selSelectedButton == buttons[9] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[10];
        }
        if (selSelectedButton == buttons[9] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[8];
        }
        //10
        if (selSelectedButton == buttons[10] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[8];
        }
        if (selSelectedButton == buttons[10] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[1];
        }
        if (selSelectedButton == buttons[10] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[12];
        }
        //11
        if (selSelectedButton == buttons[11] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[9];
        }
        if (selSelectedButton == buttons[11] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[7];
        }
        if (selSelectedButton == buttons[11] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[2];
        }
        //12
        if (selSelectedButton == buttons[12] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[0];
        }
        if (selSelectedButton == buttons[12] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[3];
        }
        if (selSelectedButton == buttons[12] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[13];
        }
        //13
        if (selSelectedButton == buttons[13] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[13];
        }
        if (selSelectedButton == buttons[13] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[8];
        }
        if (selSelectedButton == buttons[13] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[5];
        }
        //14
        if (selSelectedButton == buttons[14] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[2];
        }
        if (selSelectedButton == buttons[14] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[4];
        }
        if (selSelectedButton == buttons[14] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[0];
        }
        //15
        if (selSelectedButton == buttons[15] && bomb.GetStrikes() == 0)
        {
            selCorrectButton = buttons[5];
        }
        if (selSelectedButton == buttons[15] && bomb.GetStrikes() == 1)
        {
            selCorrectButton = buttons[13];
        }
        if (selSelectedButton == buttons[15] && bomb.GetStrikes() == 2)
        {
            selCorrectButton = buttons[11];
        }

        if (corButtons[4] == null)
        {
            if (corButtons[0] == null)
            {
                corButtons[0] = selCorrectButton;
                selSelectedButton = selButtons[1];
                DebugMsg("The correct button to press for the first color is " + corButtons[0]);
                CorrectButtonFinder();
            }
            else
            {
                if (corButtons[1] == null)
                {
                    corButtons[1] = selCorrectButton;
                    selSelectedButton = selButtons[2];
                    DebugMsg("The correct button to press for the second color is " + corButtons[1]);
                    CorrectButtonFinder();
                }
                else
                {
                    if (corButtons[2] == null)
                    {
                        corButtons[2] = selCorrectButton;
                        selSelectedButton = selButtons[3];
                        DebugMsg("The correct button to press for the third color is " + corButtons[2]);
                        CorrectButtonFinder();
                    }
                    else
                    {
                        if (corButtons[3] == null)
                        {
                            corButtons[3] = selCorrectButton;
                            selSelectedButton = selButtons[4];
                            DebugMsg("The correct button to press for the fourth color is " + corButtons[3]);
                            CorrectButtonFinder();
                        }
                        else
                        {
                            corButtons[4] = selCorrectButton;
                            DebugMsg("The correct button to press for the fifth color is " + corButtons[4]);
                        }
                    }
                }
            }
        }
        if(stageNumber == 0)
        {
            FlickerRoutine = StartCoroutine(FlickerCoRoutine1());
        }
    }
}