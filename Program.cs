using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusMoins
{
    class Program
    {
        static string stringFill(string s, int size)
        // Renvoi une chaine remplie d'espaces si sa longueur est inférieur à size
        // Renvoi la même chaine sinon
        {
            while( s.Length <= size)
                s += " ";
            return s;
        }
        static void afficherCommande(string commande, string howto, string desc)
        {
            // Affiche la commande dans le help sous forme de trois données
            // La commande, puis comment l'utiliser et enfin une description de cette commande
            int tailleCommande = 10;
            int tailleHowto = 30;

            commande = stringFill(commande, tailleCommande);
            howto = stringFill(howto, tailleHowto);
            Console.WriteLine(commande + "\t" + howto + "\t" + desc);
        }

        static int transformerEntier(string s_entre)
            // Transforme une chaine en un entier, si probleme renvoit -1
        {
            int input;
            try
            {
                input = int.Parse(s_entre);
            }
            catch (Exception)
            {
                Console.WriteLine("Il faut entrer un nombre entier. (tapez help en cas de problème)");
                input = -1;
            }
            return input;
        }

        static bool estPlusMoins(int input, int awaited)
        {
            // Le jeu en lui meêm : fonction principal du jeu plus ou moins
            // Renvoit faux si le joueur n'a pas trouvé ou s'il souhaite continuer
            // Renvoit vrai sinon
            bool br = false;
            if (input > awaited)
                Console.WriteLine("C'est moins !");
            else if (input < awaited)
                Console.WriteLine("C'est plus !");
            else
            {
                Console.WriteLine("Bravo ! Une autre partie ? (o/n)");
                if (Console.ReadLine() == "n")
                    br = true;
            }
            return br;
        }

        static void finPartie()
        {
            Console.WriteLine("A une prochaine !");
            System.Threading.Thread.Sleep(2000);
        }
        static void Main(string[] args)
        {
            // Le main du programme
            bool continuer = true;
            Random rand = new Random();
            int input; // Nombre entre l'utilisateur

            Console.WriteLine("Salut ! Si besoin d'aide tapez la commande help. Bonne partie !");
            input = -1; // choix abritraire
            while (continuer)
            {
                int awaited = rand.Next(0, 100); // Genere un nombre aleatoire entre 0 et 100
                Console.WriteLine("Un nouveau nombre mystère entre 0 et 100 a été généré avec succès.");
                // C'est le nombre mystere
                while (input != awaited)
                {
                    Console.Write("(h ou help si besoin d'aide) >>>");
                    string s_entre = Console.ReadLine();
                    switch (s_entre)
                    {
                        case "h":
                        case "help":
                            Console.WriteLine("Vous avez demandé de l'aide");
                            afficherCommande("Commande", "Utilisation", "Description");
                            afficherCommande("clear", "clear", "vide l'écran (commande cls marche aussi)");
                            afficherCommande("quit", "quit", "quitte le programme (les commandes bye et exit marchent aussi)");
                            afficherCommande("restart", "restart", "recommence la partie avec un nouveau nombre aléatoire");
                            break;
                        case "quit":
                        case "bye":
                        case "exit":
                            input = awaited;
                            continuer = false;
                            finPartie();
                            break;
                        case "clear":
                        case "cls":
                            Console.Clear();
                            break;
                        case "restart":
                            input = awaited;
                            break;
                        default:
                            // Aucune commande reconnue, le joueur a tapé normalement un nombre
                            input = transformerEntier(s_entre);
#pragma warning disable CS0642 // Possibilité d'instruction vide erronée
                            if (input == -1);
#pragma warning restore CS0642 // Possibilité d'instruction vide erronée
                            else
                            {
                                if (input < 0)
                                    Console.WriteLine("Il faut entrer un nombre entier positif. (tapez help en cas de problème)");
                                else
                                {
                                    if (estPlusMoins(input, awaited))
                                    {
                                        continuer = false;
                                        finPartie();
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            
        }
    }
}
