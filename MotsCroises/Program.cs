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
            if (((ligne >= 0) && (ligne < 9)) && ((colonne >= 0) && (colonne <9)) && ((sens == 'h') || (sens == 'v')))
            {
                return true;
            }
            return false;
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
            Console.WriteLine(tab[ligne, colonne]);
            
            if (('.' == tab[ligne, colonne]) || (lettre == tab[ligne, colonne]))
            {
                Console.WriteLine("Encodage accepté.");
                return true;
            }
            Console.WriteLine("Encodage refusé.");
            return false;
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
        static bool MotPossible(char[,] tab, int ligne, int colonne, char lettre, string mot)
        {
            int maximum = mot.Count();
            if (lettre == 'h')
            {
                int numlettre = 0;
                while ((tab[ligne, colonne] != '*') && (colonne < tab.GetLength(1)) && (numlettre < tab.GetLength(1)) && (numlettre < maximum))
                {
                    bool ATesterLigne = LettrePossible(tab, ligne, colonne, mot[numlettre]);
                    colonne++;
                    numlettre++;

                    if (ATesterLigne == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (lettre == 'v')
            {
                int NbreLettre = 0;
                while ((tab[ligne, colonne] != '*') && (ligne < tab.GetLength(0)) && (NbreLettre < tab.GetLength(0)) && (NbreLettre < maximum))
                {
                    bool ATesterCol = LettrePossible(tab, ligne, colonne, mot[NbreLettre]);
                    ligne++;
                    NbreLettre++;

                    if (ATesterCol == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool EcrireMot (char [,] tab, int ligne, int colonne, char lettre, string mot)
        {
            int max = mot.Count();
            int NumeroLettre = 0;
            bool TesterMot = MotPossible(tab, ligne, colonne, lettre, mot);

            if (TesterMot == true)
            {
                if (lettre == 'h')
                {
                    for (int i = ligne; i < max; i++)
                    {
                        tab[ligne, colonne] = mot[NumeroLettre];
                        NumeroLettre++;
                    }
                    return true;
                }
                else if (lettre == 'v')
                {
                    for (int j = colonne; j < max; j++)
                    {
                        tab[ligne, colonne] = mot[NumeroLettre];
                        NumeroLettre++;
                    }
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            // 4 : AfficherGrille
            Console.WriteLine("Question 4");
            AfficherGrille(ConstruireGrilleDeTest());

            // 5 : CoordonneesValide
            Console.WriteLine("Question 5");
            int ligneCoordonnees = -1;
            int colonneCoordonnees = -1;
            char sens = 'h';
            bool resultCoordonnesValide = CoordonneesValide(ligneCoordonnees, colonneCoordonnees, sens);

            // 6 : LireCoordonnes 
            Console.WriteLine("Question 6");
            LireCoordonnees(out ligneCoordonnees, out colonneCoordonnees, out sens);

            // 7 : LettrePossible 
            Console.WriteLine("Question 7");
            int LigneLettrePossible = 3;
            int ColonneLettrePossible = 2;
            char ValeurPossible = 'T';
            LettrePossible(ConstruireGrilleDeTest(), ligneCoordonnees, colonneCoordonnees, ValeurPossible);

            // 8 : EcrireLettre
            Console.WriteLine("Question 8");
            EcrireLettre(ConstruireGrilleDeTest(), ligneCoordonnees, colonneCoordonnees, ValeurPossible);
            AfficherGrille(ConstruireGrilleDeTest());

            // 9 : MotPossible
            Console.WriteLine("Question 9");
            string ValMot = "RAT";
            MotPossible(ConstruireGrilleDeTest(), ligneCoordonnees, colonneCoordonnees, sens, ValMot);

            Console.WriteLine("Question 10");
            // 10 EcrireMot
            EcrireMot(ConstruireGrilleDeTest(), ligneCoordonnees, colonneCoordonnees, sens, ValMot);
            AfficherGrille(ConstruireGrilleDeTest());
        }
    }
}