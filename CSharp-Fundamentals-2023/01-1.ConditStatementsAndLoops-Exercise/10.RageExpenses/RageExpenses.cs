/*
 * As a MOBA challenger player, Petar has the bad habit of trashing his PC when he loses a game and of rage quiting. 
 * His gaming setup consists of a headset, mouse, keyboard, and display. 
 * You will receive Petar's lost games count.
 * Every second lost game, Petar trashes his headset.
 * Every third lost game, Petar trashes his mouse.
 * When Petar trashes both his mouse and headset in the same lost game, he also trashes his keyboard.
 * Every second time, when he trashes his keyboard, he also trashes his display.
 * You will receive the price of each item in his gaming setup.
 * Calculate his rage expenses for renewing his gaming equipment.
 */

//INPUT
int lostGamesCount = int.Parse(Console.ReadLine());     //[0…1000]
double headsetPrice = double.Parse(Console.ReadLine()); //[0…1000]
double mousePrice = double.Parse(Console.ReadLine()); //[0…1000]
double keyboardPrice = double.Parse(Console.ReadLine()); //[0…1000]
double displayPrice = double.Parse(Console.ReadLine()); //[0…1000]

//LOGIC

// Var1
/* 
int headsetBrokenCnt = 0;
int mouseBrokenCnt = 0;
int keybordBrokenCnt = 0;
int displayBrokenCnt = 0;

for (int game = 1; game < lostGamesCount; game++)
{
    if (game % 2 == 0)         //Every second lost game, Petar trashes his headset
    {
        headsetBrokenCnt++;
    }
    if (game % 3 == 0)         //Every third lost game, Petar trashes his mouse
    {
        mouseBrokenCnt++;
    }
    if (game % 6 == 0)         //When Petar trashes both his mouse and headset in the same lost game, he also trashes his keyboard
    {
        keybordBrokenCnt++;
    }
    if (game % 12 == 0)        //Every second time, when he trashes his keyboard, he also trashes his display
    {
        displayBrokenCnt++;
    }

}

double totalCost = (headsetBrokenCnt * headsetPrice) + (mouseBrokenCnt * mousePrice) + (keybordBrokenCnt * keyboardPrice) + (displayBrokenCnt * displayPrice);

*/

// Var2 - memory efficient
int headsetBrokenCnt = lostGamesCount / 2;
int mouseBrokenCnt = lostGamesCount / 3;
int keybordBrokenCnt = lostGamesCount / 6;
int displayBrokenCnt = lostGamesCount / 12;

double totalCost = (headsetBrokenCnt * headsetPrice) + (mouseBrokenCnt * mousePrice) + (keybordBrokenCnt * keyboardPrice) + (displayBrokenCnt * displayPrice);

//OUTPUT
Console.WriteLine($"Rage expenses: {totalCost:f2} lv.");
