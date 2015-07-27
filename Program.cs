using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
namespace Anti_Flame_Sharp
{
   
    class Program
    {
        private static Menu Config;
        private static string[] badwords;
        static void Main(string[] args)
        {
            badwords = new string[] { "arse"  , "ass" , "asshole" , "bastard" , "bitch" , "bloody" , "bollocks" , "child-fucker" , "christ on a bike" ,"christ on a cracker" , "cunt" , "dick" , "pussy" , "mofo" , "sob" , "fuck" , "fucker" , "gay" , "slut" ,"shit" , "motherfucker" , "shit", "son of a bitch" , "son of a motherless goat" , "son of a whore" , "fuck you" };

            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }
        static void Game_OnGameLoad(EventArgs args)
        {
            Config = new Menu("Anti-Flame Sharp", "AFS", true);
            Config.AddItem(new MenuItem("EAFS", "Enable Anti-Flame").SetValue(true));
            Config.AddItem(new MenuItem("RBWWB", "Replace Bad Words With Beautiful").SetValue(true));
            Config.AddItem(new MenuItem ("IDK" , "Anti-Flame Sharp 0.1 By iamjustop aka 'Saeed Suleiman' "));

            Config.AddToMainMenu();
            Game.OnUpdate += OnGameUpdate;
            Game.OnChat += OnChatSender;
            Notifications.AddNotification("Anti-Flame Sharp 0.1 Loaded!", 5000);
            Notifications.AddNotification("By iamjustop", 5000);

        }
        private static string badwordnow;
        private static string messagenow;
         private static void OnGameUpdate(EventArgs args)
            
    {
      //Game.Say(premsg.ToString());
    }
         private static void OnChatSender(GameChatEventArgs args)
         {
             if (!Config.Item("EAFS").GetValue<bool>())
                 return;
             if (args.Sender.IsMe)
             {
                 for (int i = 0; i < 25; i++)
                 {
                     messagenow = args.Message;
                     badwordnow = badwords[i];
                     if (args.Message.Contains(badwordnow)) {
                         args.Process = false;
                         if (Config.Item("RBWWB").GetValue<bool>())
                         {
                             Game.Say(messagenow.Replace(badwordnow, "Beautiful"));

                         }

                     }



                 }

             }




         }
    }
}
