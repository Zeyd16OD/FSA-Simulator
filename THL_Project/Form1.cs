using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THL_Project
{
    public partial class Form1 : Form
    {
        private List<string> alphabet;
        private List<int> states;
        private List<Tuple<int, int, string>> transitions;
        private int initialState;
        private List<int> finalStates;

        public Form1()
        {
            InitializeComponent();
            alphabet = new List<string>();
            states = new List<int>();
            transitions = new List<Tuple<int, int, string>>();
            finalStates = new List<int>();
        }

        // Méthode appelée lorsque le champ txtAlphabet perd le focus
private void txtAlphabet_Leave(object sender, EventArgs e)
{
    // Récupération de la saisie de l'alphabet et suppression des espaces autour des caractères
    string alphabetInput = txtAlphabet.Text.Trim();
    // Séparation de l'alphabet en une liste de caractères ou chiffres
    alphabet = alphabetInput.Split(',').Select(a => a.Trim()).ToList();

    // Vérification de chaque élément de l'alphabet pour s'assurer qu'il contient une seule lettre ou un seul chiffre
    foreach (var letter in alphabet)
    {
        if (letter.Length != 1 || !char.IsLetterOrDigit(letter[0]))
        {
            // Affichage d'un message d'erreur si un caractère invalide est trouvé dans l'alphabet
            MessageBox.Show("L'alphabet doit contenir des lettres ou des chiffres séparés par des virgules.");
            // Récupération du focus sur le champ d'entrée txtAlphabet
            txtAlphabet.Focus();
            return;
        }
    }
}

// Méthode appelée lorsque le champ txtStates perd le focus
private void txtStates_Leave(object sender, EventArgs e)
{
    try
    {
        // Conversion de la saisie des états en une liste d'entiers
        states = txtStates.Text.Split(',').Select(int.Parse).ToList();
    }
    catch
    {
        // Affichage d'un message d'erreur si la saisie des états n'est pas au format correct
        MessageBox.Show("Veuillez saisir les états au format correct (numéros séparés par des virgules).");
    }
}

// Méthode appelée lorsque le champ txtTransitions perd le focus
private void txtTransitions_Leave(object sender, EventArgs e)
{
    try
    {
        // Initialisation de la liste des transitions
        transitions = new List<Tuple<int, int, string>>();
        // Récupération et découpage de la saisie des transitions en une liste de chaînes
        var transitionsInput = txtTransitions.Text.Trim();
        var transitionsArray = transitionsInput.Split(',');

        // Parcours de chaque transition saisie par l'utilisateur
        foreach (var transition in transitionsArray)
        {
            // Découpage de chaque transition en ses parties (état de départ, état d'arrivée, symboles)
            var parts = transition.Split(':');
            if (parts.Length != 2) throw new FormatException();

            var statesPart = parts[0].Split('-');
            if (statesPart.Length != 2) throw new FormatException();

            // Conversion des parties en entiers et chaînes respectivement
            int stateFrom = int.Parse(statesPart[0]);
            int stateTo = int.Parse(statesPart[1]);
            string symbols = parts[1];

            // Ajout de la transition à la liste des transitions
            transitions.Add(Tuple.Create(stateFrom, stateTo, symbols));
        }

        // Mise à jour du DataGridView après la configuration des transitions
        ConfigureDataGridView();
    }
    catch
    {
        // Affichage d'un message d'erreur si la saisie des transitions n'est pas au format correct
        MessageBox.Show("Veuillez saisir les transitions au format correct (etat-etat:lettre ou plusieurs lettres séparées par des virgules).");
        // Récupération du focus sur le champ d'entrée txtTransitions
        txtTransitions.Focus();
    }
}

// Méthode appelée lorsque le champ txtInitialState perd le focus
private void txtInitialState_Leave(object sender, EventArgs e)
{
    try
    {
        // Conversion de la saisie de l'état initial en un entier
        initialState = int.Parse(txtInitialState.Text);
        // Mise à jour du DataGridView après la configuration de l'état initial
        ConfigureDataGridView();
    }
    catch
    {
        // Affichage d'un message d'erreur si la saisie de l'état initial n'est pas au format correct
        MessageBox.Show("Veuillez saisir l'état initial au format correct (numéro unique).");
    }
}

// Méthode appelée lorsque le champ txtFinalStates perd le focus
private void txtFinalStates_Leave(object sender, EventArgs e)
{
    try
    {
        // Conversion de la saisie des états finaux en une liste d'entiers
        finalStates = txtFinalStates.Text.Split(',').Select(int.Parse).ToList();
        // Mise à jour du DataGridView après la configuration des états finaux
        ConfigureDataGridView();
    }
    catch
    {
        // Affichage d'un message d'erreur si la saisie des états finaux n'est pas au format correct
        MessageBox.Show("Veuillez saisir les états finaux au format correct (numéros séparés par des virgules).");
    }
}


        // Méthode appelée lorsque le bouton btnVerifyWord est cliqué
        private void btnVerifyWord_Click(object sender, EventArgs e)
        {
            // Récupération du mot saisi par l'utilisateur
            string word = txtWord.Text.Trim();
            // Vérification si le mot est accepté par l'automate
            bool isAccepted = VerifyWord(word);

            // Affichage d'un message indiquant si le mot est accepté ou rejeté par l'automate
            if (isAccepted)
            {
                MessageBox.Show("Le mot est accepté par l'automate.");
            }
            else
            {
                MessageBox.Show("Le mot est rejeté par l'automate.");
            }
        }

        // Méthode pour vérifier si un mot est accepté par l'automate
        private bool VerifyWord(string word)
        {
            int currentState = initialState;

            // Parcours de chaque symbole du mot
            foreach (char symbol in word)
            {
                bool transitionFound = false;

                // Recherche d'une transition valide pour l'état actuel et le symbole actuel
                foreach (var transition in transitions)
                {
                    if (transition.Item1 == currentState && transition.Item3.Contains(symbol))
                    {
                        // Passage à l'état suivant si une transition est trouvée
                        currentState = transition.Item2;
                        transitionFound = true;
                        break;
                    }
                }

                // Affichage d'un message d'erreur si aucune transition n'est trouvée pour l'état actuel et le symbole actuel
                if (!transitionFound)
                {
                    MessageBox.Show($"Le symbole '{symbol}' n'existe pas dans l'alphabet ou aucune transition n'existe pour l'état actuel.");
                    return false;
                }
            }

            // Vérification si l'état courant est un état final
            return finalStates.Contains(currentState);
        }

        // Méthode pour configurer le DataGridView pour afficher la matrice des transitions
        private void ConfigureDataGridView()
        {
            // Initialisation de la matrice des transitions avec des chaînes vides
            string[,] transitionMatrix = new string[states.Count, alphabet.Count];
            for (int i = 0; i < states.Count; i++)
            {
                for (int j = 0; j < alphabet.Count; j++)
                {
                    transitionMatrix[i, j] = string.Empty;
                }
            }

            // Remplissage de la matrice des transitions
            foreach (var transition in transitions)
            {
                int stateFromIndex = states.IndexOf(transition.Item1);
                int stateToIndex = states.IndexOf(transition.Item2);
                foreach (var symbol in transition.Item3)
                {
                    int symbolIndex = alphabet.IndexOf(symbol.ToString());

                    if (stateFromIndex >= 0 && stateToIndex >= 0 && symbolIndex >= 0)
                    {
                        if (string.IsNullOrEmpty(transitionMatrix[stateFromIndex, symbolIndex]))
                        {
                            transitionMatrix[stateFromIndex, symbolIndex] = states[stateToIndex].ToString();
                        }
                        else
                        {
                            transitionMatrix[stateFromIndex, symbolIndex] += "," + states[stateToIndex];
                        }
                    }
                }
            }

            // Configuration du DataGridView pour afficher la matrice des transitions
            dgvAutomate.Columns.Clear();
            dgvAutomate.Rows.Clear();

            // Ajout des colonnes pour l'alphabet
            dgvAutomate.ColumnCount = alphabet.Count + 1; // +1 pour la colonne des états
            dgvAutomate.Columns[0].Name = "État/Alphabet";
            for (int j = 0; j < alphabet.Count; j++)
            {
                dgvAutomate.Columns[j + 1].Name = alphabet[j];
            }

            // Ajout des lignes pour les états et remplissage des transitions
            for (int i = 0; i < states.Count; i++)
            {
                string[] row = new string[alphabet.Count + 1];
                row[0] = states[i].ToString();

                for (int j = 0; j < alphabet.Count; j++)
                {
                    row[j + 1] = string.IsNullOrEmpty(transitionMatrix[i, j]) ? " " : transitionMatrix[i, j];
                }

                dgvAutomate.Rows.Add(row);
            }

            // Ajout de lignes supplémentaires pour l'état initial et les états finaux
            string initialStateRow = "Initial: " + initialState.ToString();
            string finalStatesRow = "Finaux: " + string.Join(", ", finalStates);

            dgvAutomate.Rows.Add(initialStateRow, "", "");
            dgvAutomate.Rows.Add(finalStatesRow, "", "");
        }

        // Méthode appelée lorsque le bouton btnDeterminize est cliqué
        private void btnDeterminize_Click(object sender, EventArgs e)
        {
            // Appel de la méthode pour déterminiser l'automate
            DeterminizeAutomate();
        }

        private void DeterminizeAutomate()
        {
            // Listes pour stocker les états, les transitions et les états finaux de l'automate déterminisé
            var dfaStates = new List<HashSet<int>>();
            var dfaTransitions = new List<Tuple<HashSet<int>, HashSet<int>, string>>();
            var dfaInitialState = new HashSet<int> { initialState };
            var dfaFinalStates = new List<HashSet<int>>();

            // File d'attente pour parcourir les états de manière itérative
            var stateQueue = new Queue<HashSet<int>>();
            stateQueue.Enqueue(dfaInitialState);
            dfaStates.Add(dfaInitialState);

            // Parcours itératif des états jusqu'à ce que la file d'attente soit vide
            while (stateQueue.Count > 0)
            {
                var currentSet = stateQueue.Dequeue();

                // Pour chaque symbole de l'alphabet, déterminez les états atteints par la transition
                foreach (var symbol in alphabet)
                {
                    var newStateSet = new HashSet<int>();

                    // Parcours de chaque état dans l'ensemble d'états actuel
                    foreach (var state in currentSet)
                    {
                        // Recherche des transitions correspondant à l'état actuel et au symbole actuel
                        foreach (var transition in transitions)
                        {
                            if (transition.Item1 == state && transition.Item3.Contains(symbol))
                            {
                                newStateSet.Add(transition.Item2); // Ajout de l'état atteint
                            }
                        }
                    }

                    // Si le nouvel ensemble d'états n'est pas vide et n'existe pas déjà, ajoutez-le à la liste des états
                    if (newStateSet.Count > 0 && !dfaStates.Any(set => set.SetEquals(newStateSet)))
                    {
                        dfaStates.Add(newStateSet);
                        stateQueue.Enqueue(newStateSet);
                    }

                    // Ajout de la transition à la liste des transitions
                    dfaTransitions.Add(new Tuple<HashSet<int>, HashSet<int>, string>(currentSet, newStateSet, symbol));
                }

                // Vérification si l'ensemble d'états actuel contient des états finaux
                if (currentSet.Any(state => finalStates.Contains(state)))
                {
                    dfaFinalStates.Add(currentSet); // Ajout de l'ensemble d'états actuel à la liste des états finaux
                }
            }

            // Configuration du DataGridView pour afficher l'automate déterminisé
            ConfigureDataGridViewDFA(dfaStates, dfaTransitions, dfaFinalStates);
            MessageBox.Show("La déterminisation de l'automate a été effectuée.");
        }

        private void ConfigureDataGridViewDFA(List<HashSet<int>> dfaStates, List<Tuple<HashSet<int>, HashSet<int>, string>> dfaTransitions, List<HashSet<int>> dfaFinalStates)
        {
            // Effacement des colonnes et des lignes existantes dans le DataGridView
            dgvAutomateDeterministe.Columns.Clear();
            dgvAutomateDeterministe.Rows.Clear();

            // Ajout des colonnes pour l'alphabet
            dgvAutomateDeterministe.ColumnCount = alphabet.Count + 1; // +1 pour la colonne des états
            dgvAutomateDeterministe.Columns[0].Name = "État/Alphabet";
            for (int j = 0; j < alphabet.Count; j++)
            {
                dgvAutomateDeterministe.Columns[j + 1].Name = alphabet[j];
            }

            // Ajout des lignes pour les états et remplissage des transitions
            foreach (var stateSet in dfaStates)
            {
                string[] row = new string[alphabet.Count + 1];
                row[0] = string.Join(",", stateSet); // Conversion de l'ensemble d'états en chaîne pour l'affichage

                // Remplissage des cellules de la ligne avec les transitions correspondantes
                for (int j = 0; j < alphabet.Count; j++)
                {
                    var symbol = alphabet[j];
                    var transition = dfaTransitions.FirstOrDefault(t => t.Item1.SetEquals(stateSet) && t.Item3 == symbol);

                    // Si une transition existe pour l'ensemble d'états actuel et le symbole actuel, affichez les états atteints
                    row[j + 1] = transition != null && transition.Item2.Count > 0 ? string.Join(",", transition.Item2) : " ";
                }

                // Ajout de la ligne dans le DataGridView
                dgvAutomateDeterministe.Rows.Add(row);
            }

            // Ajout de lignes supplémentaires pour l'état initial et les états finaux
            string initialStateRow = "Initial: " + string.Join(",", dfaStates.First());
            string finalStatesRow = "Finaux: " + string.Join(", ", dfaFinalStates.Select(fs => string.Join(",", fs)));

            // Ajout des lignes pour l'état initial et les états finaux dans le DataGridView
            dgvAutomateDeterministe.Rows.Add(initialStateRow, "", "");
            dgvAutomateDeterministe.Rows.Add(finalStatesRow, "", "");
        }








        // Event Handlers for Text Changed Events (if needed)

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtFinalStates_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtWord_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgvAutomate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //code pour afficher les etats de l'automate sous forme de tableau
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}