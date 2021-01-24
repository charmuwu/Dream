using System.Collections;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    [SerializeField]
    GameObject prefabCharacter0;
    [SerializeField]
    GameObject prefabCharacter1;
    [SerializeField]
    GameObject prefabCharacter2;
    [SerializeField]
    GameObject prefabCharacter3;
    [SerializeField]
    GameObject prefabCharacter4;


    // need for location of new character
    GameObject currentCharacter;

    // first frame input support
    bool previousFrameChangeCharacterInput = false;

    //first prefab we load next
    int prefabNumber = 1;
        
    //Vector for the spawn point location
    public Vector3 spawn = new Vector3();    
    

    void Start()
    {
        //Sets the location of spawn point
        spawn.x = -5f;
        spawn.y = 11f;

        currentCharacter = Instantiate<GameObject>(
            prefabCharacter0, spawn,
            Quaternion.identity);

    }

    void Update()
    {
        // change character on left mouse button
        if (Input.GetKey("f"))
        {
            // only change character on first input frame
            if (!previousFrameChangeCharacterInput)
            {
                previousFrameChangeCharacterInput = true;

                // save current position and destroy current character
                Vector3 position = currentCharacter.transform.position;
                Destroy(currentCharacter);

                if (prefabNumber == 0)
                {
                    currentCharacter = Instantiate(prefabCharacter0,
                        position, Quaternion.identity);
                }
                else if (prefabNumber == 1)
                {
                    currentCharacter = Instantiate(prefabCharacter1,
                        position, Quaternion.identity);
                }
                else if (prefabNumber == 2)
                {
                    currentCharacter = Instantiate(prefabCharacter2,
                        position, Quaternion.identity);
                }
                else if (prefabNumber == 3)
                {
                    currentCharacter = Instantiate(prefabCharacter3,
                        position, Quaternion.identity);
                }
                else if (prefabNumber == 4)
                {
                    currentCharacter = Instantiate(prefabCharacter4,
                        position, Quaternion.identity);
                }

                prefabNumber++;

                if (prefabNumber > 4)
                {
                    prefabNumber = 0;
                }
            }
        }
        else
        {
            // no change character input
            previousFrameChangeCharacterInput = false;
        }
    }
}