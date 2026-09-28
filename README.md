I used 2 Interfaces; IClickable and IHoldable to note whether or the object the script is on is clickable (reactive to being clicked by the mouse) 
or holdable (reactive to the mouse holding down over the object and then moving the cursor to drag the object)
IClickable was used on Suits and Cards
IHoldable was used for Cards

I used delta.Time for the movement of the cards when you drag them around the screen by holding the button down
Used in InputSystem Update to tell the Card the Mouses Position "point"
Used in Cards to for general card movement

Awake is used in scripts Suits and Cards to define important variables for Script Communication
Start is used for GameManager to active functions that happen at the start of the game

All of the input was abstracted through Unity's ActionInput system entered as [SerializeField] to the script ActionInput where the result of the inputs is then defined
Click takes from Mouse<left> Button 
Hold take from Mouse<left> Button
Point takes from Mouse Position
All can be changed and used for a different control scheme with out effecting the code

Scope Adjustment
In the post at the start of class I kind of rambled on about how much I love root's card crafting mechanic because of how much it ties back to. How it massively scopes out to almost every element of the game.
Here however, I simplified the Root's crafting and cards to its most simple form. Matching picture or spending card for perceived value. While its not very interesting it the code can certainly scope outwards to be 
utilized with those more complicated mechanics in the way that makes root so interesting
