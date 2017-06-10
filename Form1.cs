using System;
using System.Drawing;
using System.Windows.Forms;

namespace АзбукаМорзе
{
    public partial class Form1 : Form
    {
        private byte _checkBox = 1; // Выбор radioButton
        private readonly char[] _morEng = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        private readonly char[] _morRus = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Э', 'Ю', 'Я', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'Ь', 'Ы', 'Й' };
        private readonly string[] _morzeEng = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "-----" };
        private readonly string[] _morzeRus = { ".-", "-...", ".--", "--.", "-..", ".", "...-", "--..", "..", "-.-.", ".-..", "--", "-.", "---", ".--.", ".-.", "...", "-", "..-.", "..-.", "....", "-.-.", "---.", "----", "--.-", "..-..", "..--", ".-.-", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "-----", "-..-", "-.-", ".---" };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = @"Код Морзе";
            radioButton1.Text = @"Перевод с Латиницы";
            radioButton2.Text = @"Перевод с Кириллицы";
            label1.Text = @"Введие букву/слово, для перевода:";
            label2.Text = @"Морзе:";
            label3.Text = @"v.1.0 by Trainian";
            textBox2.BackColor = Color.SeaShell;
            textBox2.ReadOnly = true;
            button1.Text = @"Перевести";
            checkBox1.Text = @"Морзе -> Текст";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            string text = textBox1.Text; // Копируем текст что бы удалить все пробелы в начале и конец и тем самым
            text = text.ToUpper();
            char[] textChar = text.ToCharArray();
            text = text.Trim();          // проверить не только ли пробелы набраны ?! и убрать лишние пробелы.
            

            if (text == "") // либо использовать String.IsNullOrWhiteSpace(text);
            {
                MessageBox.Show(@"Введите пожалуйста какое-нибудь значение для перевода в код Морзе", @"Пустой элемент", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                return;
            }
            if (checkBox1.Checked)
            {
                string[] words = new string[100];
                uint y = 0;
                bool firstSpace = true;
                Array.Resize(ref textChar, textChar.Length + 1);
                textChar[textChar.Length - 1] = ' ';

                switch (_checkBox)
                {
                    case 1:
                        foreach (char t in textChar)
                        {
                            if (t == '.' || t == '-')
                            {
                                words[y] += t;
                                firstSpace = true;
                            }
                            else if (firstSpace && t == ' ')
                            {
                                for (int j = 0; j < _morzeEng.Length; j++)
                                {
                                    if (words[y] == _morzeEng[j])
                                    {
                                        textBox2.Text += _morEng[j] + @" ";
                                    }
                                }

                                firstSpace = false;
                                words[y + 1] += t;
                                y += 2;
                            }
                        }
                        break;


                    case 2:
                        foreach (char t in textChar)
                        {
                            if (t == '.' || t == '-')
                            {
                                words[y] += t;
                                firstSpace = true;
                            }
                            else if (firstSpace && t == ' ')
                            {
                                for (int j = 0; j < _morzeRus.Length; j++)
                                {
                                    if (words[y] == _morzeRus[j])
                                    {
                                        textBox2.Text += _morRus[j] + @" ";
                                    }
                                }

                                firstSpace = false;
                                words[y + 1] += t;
                                y += 2;
                            }
                        }
                        break;
                }


            }
            else
            {
                bool notSymbol = false;
                bool notSay;

                switch (_checkBox)
                {
                    case 1:
                        for (uint i = 0; i < textChar.Length; i++)
                        {
                            notSay = true;
                            for (uint j = 0; j < _morEng.Length; j++)
                            {
                                if (textChar[i] == _morEng[j])
                                {
                                    textBox2.Text += (@"   " + _morzeEng[j] + @"   ");
                                    notSay = false;
                                }
                                else notSymbol = true;
                            }
                            if (notSymbol && notSay)
                            {
                                textBox2.Text += textChar[i];
                                notSymbol = false;
                            }
                        }
                        break;


                    case 2:
                        for (uint i = 0; i < textChar.Length; i++)
                        {
                            notSay = true;
                            for (uint j = 0; j < _morRus.Length; j++)
                            {
                                if (textChar[i] == _morRus[j])
                                {
                                    textBox2.Text += (@"   " + _morzeRus[j] + @"   ");
                                    notSay = false;
                                }
                                else notSymbol = true;
                            }
                            if (notSymbol && notSay)
                            {
                                textBox2.Text += textChar[i];
                                notSymbol = false;
                            }
                        }
                        break;
                }
            }
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _checkBox = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _checkBox = 2;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = label1.Text == @"Введие букву/слово, для перевода:" ? @"Введите код Морзе, для перевода:" : @"Введие букву/слово, для перевода:";
        }
    }
}
