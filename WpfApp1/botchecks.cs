using System;

namespace WpfApp1
{
    static class botchecks
    {

        // Generates a random move for easy difficulty
        static public int boteasy()
        {
            int num;
            Random rnd = new Random();
            num = rnd.Next(0, 9);
            return num;
        }

        // Checks if only one move has been made and the center is available
        static public bool c1(int[,] arr)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] != 0)
                        count++;
                }
            }
            if (count <= 1 && arr[1, 1] == 0)
                return true;
            else return false;
        }

        // Medium difficulty bot move selection
        static public int botmedium(int[,] arr, int turn)
        {
            int row = 0, col = 0;

            // Check for winning move or block opponent's winning move
            if (b23(arr, turn)[2] != 0)              
            {
                row = (b23(arr, turn)[0]) * 3;
                col = b23(arr, turn)[1];
                return row + col;
            }

            // Defensive moves for different turns
            if (turn == 2)
            {
                if (b23(arr, 1)[2] != 0)
                {
                    row = (b23(arr, 1)[0]) * 3;
                    col = b23(arr, 1)[1];
                    return row + col;
                }
            }
            if (turn == 1)
            {
                if (b23(arr, 2)[2] != 0)
                {
                    row = (b23(arr, 2)[0]) * 3;
                    col = b23(arr, 2)[1];
                    return row + col;
                }
            }

            // Check other strategic moves
            if (b8(arr) != 444)
                return b8(arr);
            else return 444; // Error code
        }

        // Start move logic for the bot
        static public int botstart(int[,] arr, int turn)
        {
            int row = 0, col = 0;

            // First move strategy
            if (b1(arr))                                /* בדיקה ראשונה*/
                return 4;

            // Check for winning move or block opponent's winning move
            if (b23(arr, turn)[2] != 0)                /* בדיקה שנייה*/
            {
                row = (b23(arr, turn)[0]) * 3;
                col = b23(arr, turn)[1];
                return row + col;
            }
            //בדיקה שלישית
            // Defensive moves for different turns
            if (turn == 2)
            {
                if (b23(arr, 1)[2] != 0)
                {
                    row = (b23(arr, 1)[0]) * 3;
                    col = b23(arr, 1)[1];
                    return row + col;
                }
            }
            if (turn == 1)
            {
                if (b23(arr, 2)[2] != 0)
                {
                    row = (b23(arr, 2)[0]) * 3;
                    col = b23(arr, 2)[1];
                    return row + col;
                }
            }
            //בדיקה רביעית
            // Additional strategic moves
            if (b4(arr,turn)!=444)
            return b4(arr, turn);
            //בדיקה חמישית
            if (b5(arr) != 444)
                return b5(arr);
            if (b6(arr) != 444)
                return b6(arr);
            if (b7(arr) != 444)
                return b7(arr);
            if (b8(arr) != 444)
                return b8(arr);
            else
                return 444; // Error code
        }

        // Checks if only one move has been made and the center is available
        static public bool b1(int[,] arr)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] != 0)
                        count++;
                }
            }
            return count <= 1 && arr[1, 1] == 0;
         

        }
        //אם שלוש משבצות מסומנות והמשבצת המרכזית שלי – לסמן משבצת בטור או בשורה שעליהן מסומנת אחת המשבצות של היריב, עם עדיפות למשבצת פינתית.
        // Checks if three moves have been made and the center belongs to the bot

        static public int b4(int[,] arr, int turn)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] != 0)
                        count++;
                }
            }
            if (count == 3 && arr[1, 1] == turn)
            {
                count = 0;
                for (int i = 0; i < 3 ; i++)
                {
                    if (arr[0, i] != turn && arr[0, i] != 0)
                        count++;
                }
                if (count > 0)
                {
                    if (arr[0, 0] == 0)
                        return 0;
                    else if (arr[1, 1] == 0)
                        return 2;
                    else
                        return 1;
                }
                // Check last row
                count = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (arr[2, i] != turn && arr[2, i] != 0)
                        count++;
                }
                if (count > 0)
                {
                    if (arr[2, 0] == 0)
                        return 6;
                    else if (arr[2, 2] == 0)
                        return 8;
                    else
                        return 7;
                }
                // Check first column
                count = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (arr[i, 0] != turn && arr[i, 0] != 0)
                        count++;
                }
                if (count > 0)
                {
                    if (arr[0, 0] == 0)
                        return 0;
                    else if (arr[2, 0] == 0)
                        return 6;
                    else
                        return 3;
                }
                // Check last column
                count = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (arr[i, 2] != turn && arr[i, 2] != 0)
                        count++;
                }
                if (count > 0)
                {
                    if (arr[0, 2] == 0)
                        return 0;
                    else if (arr[2, 2] == 0)
                        return 8;
                    else
                        return 5;
                }
                // Check middle row
                count = 0;
                for (int i = 0; i <3; i++)
                {
                    if (arr[1, i] != turn && arr[1, i] != 0)
                        count++;
                }
                if (count > 0)
                {
                    if (arr[1, 0] == 0)
                        return 3;
                    else if (arr[1, 2] == 0)
                        return 5;
                    else
                        return 4;
                }
                // Check middle column
                count = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (arr[i, 1] != turn && arr[i, 1] != 0)
                        count++;
                }
                if (count > 0)
                {
                    if (arr[0, 1] == 0)
                        return 1;
                    else if (arr[2, 1] == 0)
                        return 7;
                    else
                        return 4;
                }
            }

            return 444; // Error code
        }

        //אם יש פינה פנויה ומשני צדדיה שתי שורות ריקות – לסמן את הפינה
        // Checks if a corner is available and both rows and columns adjacent to it are empty

        static public int b5(int[,] arr)
        {
            
            bool fr1=true, fr3 = true;      /*האם השורה ראשונה ואחרונה מקיימים את התנאי*/ // Check if first and last rows are empty
            bool fc1 = true, fc3 = true; /*האם הטור הראשון ואחרון מקיימים את התנאי*/ // Check if first and last columns are empty


            // Check first row and first column
            for (int i = 0; i < 3; i++)          
            {
                if (arr[0, i] != 0)
                    fr1 = false;
            }
            if (fr1)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (arr[i, 0] != 0)
                        fc1 = false;
                }
            }
          if(fr1 && fc1)                    /*     בודק משבצת ראשונה בשורה ראשונה*/
                return 0;// First corner in the first row and column

            // Check last row and first column
            for (int i = 0; i < 3; i++)
            {
                if (arr[i, 2] != 0)
                    fc3 = false;
            }
            if (fr1 && fc3)                  /*     בודק משבצת אחרונה בשורה ראשונה*/
                return 2; // Last

            for (int i = 0; i < 3; i++)
            {
                if (arr[2, i] != 0)
                    fr3 = false;
            }
            if (fr3 && fc1)   /*   בודק משבצת ראשונה בשורה אחרונה*/
                return 6;
            if (fr3 && fc3)   /*  בודק משבצת אחרונה בשורה אחרונה*/
                return 8;
            return 444; //שגיאה
             }


        // Checks if the center is available
        static public int b6(int[,] arr)
        {
            if (arr[1, 1] == 0)
                return 4;
            return 444; // Error code
        }


        // Checks if there is an empty row or diagonal to place a piece
        static public int b7(int[,] arr)
        {
            bool f1 = true, f2 = true, f3=true;
  
                                                 //בודק שורות
            for (int i = 0; i < 3; i++)
            {
                f1 = true;
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] != 0)
                        f1 = false;
                }
                if (f1)
                {
                    if (arr[i, 0] == 0)
                    {
                        return i*3;
                    }
                    if (arr[i, 2] == 0)
                    {
                        return (i * 3) + 2;
                    }

                }
            }
            //בודק אלכסונים
            if (arr[0, 0] != 0 && arr[1, 1] != 0 & arr[2, 2] != 0)
                f2 = false;
             if(f2)
                {
                    if (arr[0, 0] == 0)
                        return 0;
                    if (arr[2, 2] == 0)
                        return 8;
                }
            //בודק אלכסונים
            if (arr[0, 2] != 0 && arr[1, 1] != 0 & arr[2, 0] != 0)
                f3 = false;
                if (f3)
                {
                    if (arr[0, 2] == 0)
                        return 2;
                    if (arr[2, 0] == 0)
                        return 6;
                }

            return 444; //שגיאה         
        }



        static public int b8(int[,] arr)
        {
            int num = 444;
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] == 0)
                        num= (i * 3) + j;
                }
            }
               
            return num; //שגיאה         
        }


        //אם בשורה או באלכסון מסומנות שתי משבצות שלי/של היריב – לסמן את המשבצת השלישית
        static public int[] b23(int[,] arr,int turn) /*הפעולה מחזירה לבעל התור מערך בעל 3 תאים שבתא הראשון והשני יש את המקיום שצריך למלא ובתא השלישי את הסוג איקס או עיגול*/
        {


            int[] place = new int[3];
            place[0] = 0;
            place[1] = 0;
            place[2] = 0;
            for (int i = 0; i < 3; i++)
            {
             
                //בודק שורות
                if (arr[i, 0] == arr[i, 1] && arr[i,0]==turn && arr[i, 2] == 0)
                {
                    place[0] =i;
                    place[1] = 2;
                    place[2] = arr[i, 0];
                }
                if (arr[i, 0] == arr[i, 2] &&arr[i, 0] == turn && arr[i, 1] == 0)
                {
                    place[0] = i;
                    place[1] = 1;
                    place[2] = arr[i, 0];
                }
                if (arr[i, 1] == arr[i, 2] && arr[i, i] == turn && arr[i, 0] == 0)
                {
                    place[0] = i;
                    place[1] = 0;
                    place[2] = arr[i, 1];
                }
                //בודק טורים
                if (arr[0, i] == arr[1, i] && arr[0, i] == turn && arr[2, i] == 0)
                {
                    place[0] = 2;
                    place[1] = i;
                    place[2] = arr[0, i];
                }
                if (arr[0, i] == arr[2, i] && arr[0, i] == turn && arr[1, i] == 0)
                {
                    place[0] = 1;
                    place[1] = i;
                    place[2] = arr[0, i];

                }
                if (arr[1, i] == arr[2, i] && arr[1, i] == turn && arr[0, i] == 0) 
                {
                    place[0] = 0;
                    place[1] = i;
                    place[2] = arr[i, i];
                }
            }
            //בדיקת אלכסון לימין
            if (arr[0,0]==arr[1,1] && arr[0, 0] == turn && arr[2,2]==0)
            {
                place[0] = 2;
                place[1] = 2;
                place[2] = arr[0, 0];
            }
            if (arr[0, 0] == arr[2, 2] && arr[0, 0] == turn && arr[1, 1] == 0)
            {
                place[0] = 1;
                place[1] = 1;
                place[2] = arr[0, 0];
            }
            if (arr[2, 2] == arr[1, 1] && arr[2, 2] == turn && arr[0, 0] == 0)
            {
                place[0] = 0;
                place[1] = 0;
                place[2] = arr[2, 2];
            }
            //בדיקת אלכסון לשמאל
            if (arr[0, 2] == arr[1, 1] && arr[0, 2] == turn && arr[2, 0] == 0)
            {
                place[0] = 2;
                place[1] = 0;
                place[2] = arr[0, 2];
            }
            
            if (arr[2, 0] == arr[1, 1] && arr[2, 0] == turn && arr[0, 2] == 0)
            {
                place[0] = 0;
                place[1] = 2;
                place[2] = arr[2, 0];
            }

            if (arr[2, 0] == arr[0, 2] && arr[2, 0] == turn && arr[1, 1] == 0)
            {
                place[0] = 1;
                place[1] = 1;
                place[2] = arr[2, 0];
            }

            return place;

        }
     
    }
    
}
