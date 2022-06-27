using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string alphabet = "abcdefghijklmnopqrstuvwxyz";
        //static string reflector = "yruhqsldpxngokmiebfzcwvjat";

        static string rotor1String = "ekmflgdqvzntowyhxuspaibrcj";
        static string rotor2String = "ajdksiruxblhwtmcqgznpyfvoe";
        static string rotor3String = "bdfhjlcprtxvznyeiwgakmusqo";
        static string rotor4String = "esovpzjayquirhxlnftgkdcmwb";
        static string rotor5String = "vzbrgityupsdnhlxawmjqofeck";
        static string rotor6String = "jpgvoumfyqbenhzrdkasxlictw";
        static string rotor7String = "nzjhgrcxmyswboufaivlpekqdt";
        static string rotor8String = "fkqhtlxocbjspdzramewniuygv";
        static string rotorBString = "leyjvcnixwpbqmdrtakzgfuhos";
        static string rotorGString = "fsokanuerhmbtiycwlqpzxvgjd";

        static Dictionary<char, string> rotors = new Dictionary<char, string>(2)
        {
            {'1', rotor1String},
            {'2', rotor2String},
            {'3', rotor3String},
            {'4', rotor4String},
            {'5', rotor5String},
            {'6', rotor6String},
            {'7', rotor7String},
            {'8', rotor8String},
            {'B', rotorBString},
            {'G', rotorGString},
        };

        int rotorR = -1, rotorM = -1, rotorL = -1;
        int rotorRValue = 0, rotorMValue = 0, rotorLValue = 0;
        int rotorRStep = 1, rotorMStep = 1, rotorLStep = 1;

        static List<char> reflectorLetter = new List<char>(26)
        {
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
        };

        static int[] reflectors = new int[26]
        {
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RotorRValue.Text = rotorRValue.ToString();
            RotorMValue.Text = rotorMValue.ToString();
            RotorLValue.Text = rotorLValue.ToString();
            RotorRStep.Text = rotorRStep.ToString();
            RotorMStep.Text = rotorMStep.ToString();
            RotorLStep.Text = rotorLStep.ToString();
            foreach (KeyValuePair<char, string> rotor in rotors)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "[Rotor " + rotor.Key.ToString() + "] - " + rotor.Value.ToString();
                item.IsEnabled = true;
                RotorL.Items.Add(item);
            }
            foreach (KeyValuePair<char, string> rotor in rotors)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "[Rotor " + rotor.Key.ToString() + "] - " + rotor.Value.ToString();
                item.IsEnabled = true;
                RotorM.Items.Add(item);
            }
            foreach (KeyValuePair<char, string> rotor in rotors)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = "[Rotor " + rotor.Key.ToString() + "] - " + rotor.Value.ToString();
                item.IsEnabled = true;
                RotorR.Items.Add(item);
            }
            foreach(ComboBox reflectorComboBox in ReflectorGrid.Children)
            {
                foreach (char letter in reflectorLetter)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = letter.ToString();
                    item.IsEnabled = true;
                    reflectorComboBox.Items.Add(item);
                }
            }
        }

        private void RotorL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rotorL != -1)
            {
                ((ComboBoxItem)RotorM.Items.GetItemAt(rotorL)).IsEnabled = true;
                ((ComboBoxItem)RotorR.Items.GetItemAt(rotorL)).IsEnabled = true;
            }
            rotorL = this.RotorL.SelectedIndex;
            ((ComboBoxItem)RotorM.Items.GetItemAt(this.RotorL.SelectedIndex)).IsEnabled = false;
            ((ComboBoxItem)RotorR.Items.GetItemAt(this.RotorL.SelectedIndex)).IsEnabled = false;
        }

        private void RotorM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rotorM != -1)
            {
                ((ComboBoxItem)RotorL.Items.GetItemAt(rotorM)).IsEnabled = true;
                ((ComboBoxItem)RotorR.Items.GetItemAt(rotorM)).IsEnabled = true;
            }
            rotorM = this.RotorM.SelectedIndex;
            ((ComboBoxItem)RotorL.Items.GetItemAt(this.RotorM.SelectedIndex)).IsEnabled = false;
            ((ComboBoxItem)RotorR.Items.GetItemAt(this.RotorM.SelectedIndex)).IsEnabled = false;
        }

        private void RotorR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rotorR != -1)
            {
                ((ComboBoxItem)RotorL.Items.GetItemAt(rotorR)).IsEnabled = true;
                ((ComboBoxItem)RotorM.Items.GetItemAt(rotorR)).IsEnabled = true;
            }
            rotorR = this.RotorR.SelectedIndex;
            ((ComboBoxItem)RotorL.Items.GetItemAt(this.RotorR.SelectedIndex)).IsEnabled = false;
            ((ComboBoxItem)RotorM.Items.GetItemAt(this.RotorR.SelectedIndex)).IsEnabled = false;
        }

        private void Reflector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ComboBox reflectorComboBox in ReflectorGrid.Children)
            {
                foreach (ComboBoxItem reflectorComboBoxItem in reflectorComboBox.Items)
                {
                    reflectorComboBoxItem.IsEnabled = true;
                }
            }
            int comboBox = ReflectorGrid.Children.IndexOf((ComboBox)sender);
            int comboBoxItem = ((ComboBox)ReflectorGrid.Children[comboBox]).SelectedIndex;
            reflectors[comboBox] = comboBoxItem;
            foreach (ComboBox reflectorComboBox in ReflectorGrid.Children)
            {
                for (int i = 0; i < reflectors.Length; i++)
                {
                    if (reflectors[i] != -1)
                    {
                        ((ComboBoxItem)reflectorComboBox.Items.GetItemAt(reflectors[i])).IsEnabled = false;
                        ((ComboBoxItem)((ComboBox)ReflectorGrid.Children[i]).Items.GetItemAt(reflectors[i])).IsEnabled = true;
                    }
                }
            }
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            int temp = 0;
            foreach (int item in reflectors)
            {
                if (item == -1)
                {
                    temp++;
                }
            }
            if (rotorR != -1 && rotorM != -1 && rotorL != -1 && temp == 0)
            {
                string reflector = "abcdefghijklmnopqrstuvwxyz";
                rotorRValue = Int32.Parse(RotorRValue.Text);
                rotorMValue = Int32.Parse(RotorMValue.Text);
                rotorLValue = Int32.Parse(RotorLValue.Text);
                rotorRStep = Int32.Parse(RotorRStep.Text);
                rotorMStep = Int32.Parse(RotorMStep.Text);
                rotorLStep = Int32.Parse(RotorLStep.Text);

                for (int i = 0; i < 13; i++)
                {
                    string first = reflector.Substring(reflectors[i], 1);
                    string second = reflector.Substring(reflectors[i + 13], 1);
                    reflector = reflector.Replace(Convert.ToChar(first), '@');
                    reflector = reflector.Replace(Convert.ToChar(second), '#');
                    reflector = reflector.Replace('@', Convert.ToChar(second));
                    reflector = reflector.Replace('#', Convert.ToChar(first));
                }

                int letterPosition = -1;
                string letter = ((Button)sender).Content.ToString().ToLower();
                //Rotor R
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (letter == alphabet[i].ToString())
                    {
                        letterPosition = ((i + rotorRValue) % 26);
                    }
                }
                letter = rotors.ElementAt(rotorR).Value[letterPosition].ToString();
                //RotorM
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (letter == alphabet[i].ToString())
                    {
                        letterPosition = ((i + rotorMValue) % 26);
                    }
                }
                letter = rotors.ElementAt(rotorM).Value[letterPosition].ToString();
                //RotorL
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (letter == alphabet[i].ToString())
                    {
                        letterPosition = ((i + rotorLValue) % 26);
                    }
                }
                letter = rotors.ElementAt(rotorL).Value[letterPosition].ToString();
                //Reflector
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (letter == alphabet[i].ToString())
                    {
                        letterPosition = i;
                    }
                }
                letter = reflector[letterPosition].ToString();
                //RotorL
                for (int i = 0; i < rotors.ElementAt(rotorL).Value.Length; i++)
                {
                    if (letter == rotors.ElementAt(rotorL).Value[i].ToString())
                    {
                        if (i - rotorLValue >= 0)
                        {
                            letterPosition = ((i - rotorLValue) % 26);
                        }
                        else
                        {
                            letterPosition = 26 + i - rotorLValue;
                        }
                    }
                }
                letter = alphabet[letterPosition].ToString();
                //RotorM
                for (int i = 0; i < rotors.ElementAt(rotorM).Value.Length; i++)
                {
                    if (letter == rotors.ElementAt(rotorM).Value[i].ToString())
                    {
                        if (i - rotorMValue >= 0)
                        {
                            letterPosition = ((i - rotorMValue) % 26);
                        }
                        else
                        {
                            letterPosition = 26 + i - rotorMValue;
                        }
                    }
                }
                letter = alphabet[letterPosition].ToString();
                //Rotor R
                for (int i = 0; i < rotors.ElementAt(rotorR).Value.Length; i++)
                {
                    if (letter == rotors.ElementAt(rotorR).Value[i].ToString())
                    {
                        if (i - rotorRValue >= 0)
                        {
                            letterPosition = ((i - rotorRValue) % 26);
                        }
                        else
                        {
                            letterPosition = 26 + i - rotorRValue;
                        }
                    }
                }
                letter = alphabet[letterPosition].ToString();

                rotorRValue = rotorRValue + rotorRStep;
                if (rotorRValue > alphabet.Length - 1)
                {
                    rotorRValue = (rotorRValue % alphabet.Length);
                    rotorMValue = rotorMValue + rotorMStep;
                }
                if (rotorMValue > alphabet.Length - 1)
                {
                    rotorMValue = (rotorMValue % alphabet.Length);
                    rotorLValue = rotorLValue + rotorLStep;
                }
                if (rotorLValue > alphabet.Length - 1)
                {
                    rotorLValue = 0;
                    rotorMValue = 0;
                }

                RotorRValue.Text = rotorRValue.ToString();
                RotorMValue.Text = rotorMValue.ToString();
                RotorLValue.Text = rotorLValue.ToString();

                if (letter == "a") TextA.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "b") TextB.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "c") TextC.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "d") TextD.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "e") TextE.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "f") TextF.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "g") TextG.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "h") TextH.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "i") TextI.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "j") TextJ.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "k") TextK.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "l") TextL.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "m") TextM.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "n") TextN.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "o") TextO.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "p") TextP.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "q") TextQ.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "r") TextR.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "s") TextS.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "t") TextT.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "u") TextU.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "v") TextV.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "w") TextW.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "x") TextX.Foreground = new SolidColorBrush(Colors.Gold);
                else if (letter == "y") TextY.Foreground = new SolidColorBrush(Colors.Gold);
                else TextZ.Foreground = new SolidColorBrush(Colors.Gold);

                CancellationTokenSource cts = new CancellationTokenSource();
                await Task.Delay(TimeSpan.FromMilliseconds(1000), cts.Token);

                if (letter == "a") TextA.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "b") TextB.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "c") TextC.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "d") TextD.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "e") TextE.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "f") TextF.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "g") TextG.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "h") TextH.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "i") TextI.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "j") TextJ.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "k") TextK.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "l") TextL.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "m") TextM.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "n") TextN.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "o") TextO.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "p") TextP.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "q") TextQ.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "r") TextR.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "s") TextS.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "t") TextT.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "u") TextU.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "v") TextV.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "w") TextW.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "x") TextX.Foreground = new SolidColorBrush(Colors.Black);
                else if (letter == "y") TextY.Foreground = new SolidColorBrush(Colors.Black);
                else TextZ.Foreground = new SolidColorBrush(Colors.Black);

                cts.Cancel();
            }
            else
            {
                MessageBox.Show("Настройте Энигму перед работой");
            }
        }
    }
}
