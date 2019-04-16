using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotsCroises
{
    class Program
    {
        static char[,] ConstruireGrilleDeTest()
        // Renvoie une grille de test de mots croisés, de taille 10*10, contenant des cases noircies pré-calculées.
        {
            char[,] Grille = new char[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Grille[i, j] = '.';
                }
            }
            Grille[2, 2] = '*';
            Grille[2, 8] = '*';
            Grille[3, 1] = '*';
            Grille[3, 9] = '*';
            Grille[4, 5] = '*';
            Grille[5, 3] = '*';
            Grille[6, 2] = '*';
            Grille[6, 8] = '*';
            Grille[7, 4] = '*';
            Grille[8, 2] = '*';
            Grille[8, 7] = '*';
            Grille[9, 5] = '*';

            Grille[0, 5] = 'T';
            Grille[1, 5] = 'A';
            Grille[2, 5] = 'I';
            Grille[3, 5] = 'T';
            return Grille;
        }
        static void AfficherGrille(char [,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write(tab[i,j] + " ");
                }
                Console.WriteLine(" ");
            }
        }
        static bool CoordonneesValide (int ligne, int colonne, char sens)
        {
            bool ATester = false;

            if (((ligne >= 0) && (ligne < 9)) && ((colonne >= 0) && (colonne <9)) && ((sens == 'h') || (sens == 'v')))
            {
                ATester = true;
            }
            return ATester;
        }
        static void LireCoordonnees (out int ligne, out int colonne, out char sens)
        {
            Console.WriteLine("Veuillez introduire un numéro de ligne");
            int ChiffreLigne = int.Parse(Console.ReadLine());

            Console.WriteLine("Veuillez introduire un numéro de colonne");
            int ChiffreColonne = int.Parse(Console.ReadLine());

            Console.WriteLine("Veuillez introduire un sens, h pour horizontal, v pour vertical");
            char ValeurSens = char.Parse(Console.ReadLine());

            if (CoordonneesValide(ChiffreLigne, ChiffreColonne, ValeurSens) == true)
            {
                ligne = ChiffreLigne;
                colonne = ChiffreColonne;
                sens = ValeurSens;
                Console.WriteLine("Valeurs correctes");
            }
            else
            {
                ligne = ChiffreLigne;
                colonne = ChiffreColonne;
                sens = ValeurSens;
                Console.WriteLine("Valeurs incorrectes");
            }
        }
        static bool LettrePossible (char [,] tab, int ligne, int colonne, char lettre)
        {
            bool ATester = false;
            Console.WriteLine(tab[ligne, colonne]);
            
            if (('.' == tab[ligne, colonne]) || (lettre == tab[ligne, colonne]))
            {
                ATester = true;
                Console.WriteLine("Encodage accepté.");
                return ATester;
            }
            Console.WriteLine("Encodage refusé.");
            return ATester;
        }
        static bool EcrireLettre (char [,] tab, int ligne, int colonne, char lettre)
        {
            bool TesterLettre = LettrePossible(tab, ligne, colonne, lettre);

            if (TesterLettre == true)
            {
                tab[ligne, colonne] = lettre;
                Console.WriteLine("La lettre " +lettre + " a été encodée dans la grille.");
                return TesterLettre;
            }
            Console.WriteLine("Erreur, la lettre n'a pas été encodée.");
            return TesterLettre;
        }
        static bool MotPossible (char [,] tab, int ligne, int colonne, char lettre, string mot)
        {
            bool testPosition = CoordonneesValide(ligne, colonne, lettre);
            bool testLettre = false;

        }
        static void Main(string[] args)
        {
            // 4 : AfficherGrille
            AfficherGrille(ConstruireGrilleDeTest());

            // 5 : CoordonneesValide
            int ligneCoordonnees = -1;
            int colonneCoordonnees = -1;
            char sens = 'a';
            bool resultCoordonnesValide = CoordonneesValide(ligneCoordonnees, colonneCoordonnees, sens);

            // 6 : LireCoordonnes 
            LireCoordonnees(out ligneCoordonnees, out colonneCoordonnees, out sens);

            // 7 : LettrePossible 
            int LigneLettrePossible = 0;
            int ColonneLettrePossible = 0;
            char ValeurPossible = 'T';
            LettrePossible(ConstruireGrilleDeTest(), LigneLettrePossible, ColonneLettrePossible, ValeurPossible);

            // 8 : EcrireLettre
            EcrireLettre(ConstruireGrilleDeTest(), LigneLettrePossible, ColonneLettrePossible, ValeurPossible);

            // 9 : MotPossible
        }
    }
}