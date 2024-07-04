using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ConsoleApp4;

namespace WpfApp1
{
   
    public partial class MainWindow : Window
    {

        public static int turn, i, j, counter = 0, c1 = 0, c2 = 0, counterturns = 0;
        public static char c;
        public static bool bot = false;
        public static bool player; // אמת=שחקן אמיתי שקר=בוט 
        public static string whichLevel;
        Game_Board ta1;
        public static Button[] barr;

        public MainWindow()
        {
            InitializeComponent();
            barr = new Button[9];
            barr[0] = b1;
            barr[1] = b2;
            barr[2] = b3;
            barr[3] = b4;
            barr[4] = b5;
            barr[5] = b6;
            barr[6] = b7;
            barr[7] = b8;
            barr[8] = b9;
            b1.IsEnabled = false;
            b2.IsEnabled = false;
            b3.IsEnabled = false;
            b4.IsEnabled = false;
            b5.IsEnabled = false;
            b6.IsEnabled = false;
            b7.IsEnabled = false;
            b8.IsEnabled = false;
            b9.IsEnabled = false;


        }



        private void startgame(object sender, RoutedEventArgs e)
        {
            GuideForPlayer.Visibility = Visibility;
            Level.IsEnabled = false;
            GuideForBot.Visibility = Visibility.Hidden;
            xlabel.Text = ":איקס";
            olabel.Text = ":עיגול";
            if (bot == true)
            {
                c1 = 0;
                c2 = 0;
                go.Text = "0 ";
                gx.Text = "0 ";
                 }

            tshowplayer.Visibility = Visibility;
            lshowplayer.Visibility = Visibility;

            if (turn == 1)
                tshowplayer.Text = "O";
            else
                tshowplayer.Text = "X";

            bot = false;
            bwin.Visibility = Visibility.Hidden;
            bfinalwin.Visibility = Visibility.Hidden;
            counterturns++;
            bstart.IsEnabled = false;
            bbot.IsEnabled = false;
            b1.IsEnabled = true;
            b2.IsEnabled = true;
            b3.IsEnabled = true;
            b4.IsEnabled = true;
            b5.IsEnabled = true;
            b6.IsEnabled = true;
            b7.IsEnabled = true;
            b8.IsEnabled = true;
            b9.IsEnabled = true;
            b1.Content = "";
            b2.Content = "";
            b3.Content = "";
            b4.Content = "";
            b5.Content = "";
            b6.Content = "";
            b7.Content = "";
            b8.Content = "";
            b9.Content = "";
            if (counterturns % 2 == 0)
                turn = 1;
            else
                turn = 2;
            ta1 = new Game_Board();
            ta1.cleanBoardBoard();
            counter = 0;
     

      
        }

        private void bbot_Click(object sender, RoutedEventArgs e)
        {if (Level.Text != "")
            {
                Level.IsEnabled = false;
                string whichLevel;
                whichLevel = Level.Text;
                GuideForPlayer.Visibility = Visibility.Hidden;
                GuideForBot.Visibility = Visibility;
                xlabel.Text = ":מחשב";
                olabel.Text = ":שחקן";
                if (bot == false)
                {
                    c1 = 0;
                    c2 = 0;
                    go.Text = "0 ";
                    gx.Text = "0 ";
                }
                turn = 1;

                if (counterturns > 0 && bot == false)
                    counterturns = 0;
                if (counterturns > 0 && counterturns % 2 == 0)
                    turn = 1;
                else if (counterturns > 0 && counterturns % 2 != 0)
                    turn = 2;
                bot = true;
                bwin.Visibility = Visibility.Hidden;
                bfinalwin.Visibility = Visibility.Hidden;

                bstart.IsEnabled = false;
                bbot.IsEnabled = false;
                b1.IsEnabled = true;
                b2.IsEnabled = true;
                b3.IsEnabled = true;
                b4.IsEnabled = true;
                b5.IsEnabled = true;
                b6.IsEnabled = true;
                b7.IsEnabled = true;
                b8.IsEnabled = true;
                b9.IsEnabled = true;
                b1.Content = "";
                b2.Content = "";
                b3.Content = "";
                b4.Content = "";
                b5.Content = "";
                b6.Content = "";
                b7.Content = "";
                b8.Content = "";
                b9.Content = "";


                if (turn == 2)
                    turn = 1;
                else
                    turn = 2;
                ta1 = new Game_Board();
                ta1.cleanBoardBoard();
                counter = 0;


           
                int num = 0;   
                if (whichLevel == "קשה")
                    if (turn == 2)
                    {
                        num = botchecks.botstart(ta1.board, turn);
                        ChangeButtonState(barr[num]);
                    }
                if (whichLevel == "קל")
                    if (turn == 2)
                    {
                        while (ta1.getValueInBoard((num / 3), (num % 3)) != 0)
                            num = botchecks.boteasy();
                        ChangeButtonState(barr[num]);
                    }
                if (whichLevel == "בינוני")
                    if (turn == 2)
                    {
                        num = botchecks.botmedium(ta1.board, turn);
                        ChangeButtonState(barr[num]);
                    }

                counterturns++;
            }
        }

        private void ChangeButtonState(Button btn)
        {


            string row, col;
            row = btn.CommandParameter.ToString()[0].ToString();
            col = btn.CommandParameter.ToString()[1].ToString();


            counter++;
            if (turn == 1)
                c = 'O';
            else
                c = 'X';

            i = int.Parse(row);
            j = int.Parse(col);
            ta1.setValueInBoard(i, j, turn);
            btn.Content = c;

            if (turn ==2)
                turn = 1;
            else
                turn = 2;
            btn.IsEnabled = false;
            if (turn == 1)
                tshowplayer.Text = "O";
            else
                tshowplayer.Text = "X";
            if (ta1.checkwin()[0] != 0)
            {
                tshowplayer.Visibility = Visibility.Hidden;
                lshowplayer.Visibility = Visibility.Hidden;

                if (ta1.checkwin()[0] == 1)
                {
                    c1++;
                    go.Text = c1.ToString();
                }
                else
                {

                    c2++;
                    gx.Text = c2.ToString();
                }
                bfinalwin.Text = c.ToString();
                bfinalwin.Visibility = Visibility;
                bwin.Text = ":המנצח הוא";
                bwin.Visibility = Visibility;
                b1.IsEnabled = false;
                b2.IsEnabled = false;
                b3.IsEnabled = false;
                b4.IsEnabled = false;
                b5.IsEnabled = false;
                b6.IsEnabled = false;
                b7.IsEnabled = false;
                b8.IsEnabled = false;
                b9.IsEnabled = false;
                bbot.IsEnabled = true;
                bstart.IsEnabled = true;
                Level.IsEnabled = true;

                if (c1 > c2)
                {
                    go.Foreground = new SolidColorBrush(Colors.Green);
                    gx.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
         if (c2 > c1)
                {
                    gx.Foreground = new SolidColorBrush(Colors.Green);
                    go.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    gx.Foreground = new SolidColorBrush(Colors.Blue);
                    go.Foreground = new SolidColorBrush(Colors.Blue);
                }
            }
            else
            if (counter == 9)
            {
                tshowplayer.Visibility = Visibility.Hidden;
                lshowplayer.Visibility = Visibility.Hidden;
                bstart.IsEnabled = true;
                bbot.IsEnabled = true;
                Level.IsEnabled = true;
                bfinalwin.Text = "תיקו";
                bfinalwin.Visibility = Visibility;
            }


        }
       
        private void C1(object sender, RoutedEventArgs e)
        {
            ChangeButtonState((Button)sender);
            if ( (ta1.checkwin()[0] == 0) && bot == true && counter < 9)
            {
                int num = 0;          

                if (Level.Text == "קשה")
                    if (turn == 2)
                    {
                        num = botchecks.botstart(ta1.board, turn);
                        ChangeButtonState(barr[num]);
                    }
                if (Level.Text == "קל")
                    if (turn == 2)
                    {
                        while (ta1.getValueInBoard((num / 3), (num % 3)) != 0 )
                            num = botchecks.boteasy();
                        ChangeButtonState(barr[num]);
                    }
                if (Level.Text == "בינוני")
                    if (turn == 2)
                    {
                        num = botchecks.botmedium(ta1.board, turn);
                        ChangeButtonState(barr[num]);
                    }


            }
        }
    }
}
