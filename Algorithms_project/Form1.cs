using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Algorithms_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void check_for_word_in_2d_array (ref char [][]arr , ref List<index> checked_chars , string word , index i , int counter , int n )
        {
            counter++;
           // MessageBox.Show(i.x.ToString() + " " + i.y.ToString());
            if(counter==word.Length-1)
            {
                if (!listBox1.Items.Contains(word))
                    listBox1.Items.Add(word);
                return;
            }
            try
            {
             if ( arr[i.x + 1][i.y] == word[counter+1]  )
            {
                index j = new index(i.x + 1, i.y);
                checked_chars.Add(i);
                check_for_word_in_2d_array(ref arr, ref checked_chars, word, j, counter ,n);
            }
            }
            catch { }
            try
            {
if ( arr[i.x - 1][i.y] == word[counter+1]  )
            {
                index j = new index(i.x - 1, i.y);
                checked_chars.Add(i);
                check_for_word_in_2d_array(ref arr, ref checked_chars, word, j, counter,n);
            }
            }
            catch { }
             try
            {
 if ( arr[i.x][i.y - 1] == word[counter+1]  )
            {
                index j = new index(i.x, i.y - 1);
                checked_chars.Add(i);
                check_for_word_in_2d_array(ref arr, ref checked_chars, word, j, counter,n);
            }
            }
            catch { }
            try
            {
if ( arr[i.x][i.y + 1] == word[counter+1]  )
            {
                index j = new index(i.x, i.y + 1);
                checked_chars.Add(i);
                check_for_word_in_2d_array(ref arr, ref checked_chars, word, j, counter,n);
            }
            }
            catch { }
            try
            {
if ( arr[i.x - 1][i.y - 1] == word[counter+1]  )
            {
                index j = new index(i.x - 1, i.y - 1);
                checked_chars.Add(i);
                check_for_word_in_2d_array(ref arr, ref checked_chars, word, j, counter,n);
            }
            }
            catch { }
            try
            {
if ( arr[i.x + 1][i.y + 1] == word[counter+1]  )
            {
                index j = new index(i.x + 1, i.y + 1);
                checked_chars.Add(i);
                check_for_word_in_2d_array(ref arr, ref checked_chars, word, j, counter,n);
            }
            }
            catch { }
            try
            {
 if ( arr[i.x - 1][i.y + 1] == word[counter+1]  )
            {
                index j = new index(i.x - 1, i.y + 1);
                checked_chars.Add(i);
                check_for_word_in_2d_array(ref arr, ref checked_chars, word, j, counter,n);
            }
            }
            catch { }
            try
            {
if ( arr[i.x + 1][i.y - 1] == word[counter+1]  )
            {
                index j = new index(i.x + 1, i.y - 1);
                checked_chars.Add(i);
                check_for_word_in_2d_array(ref arr, ref checked_chars, word, j, counter,n);
            }
            }
            catch { }
             
           
                

        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.ShowDialog();
                string filename = fd.FileName;
                Dictionary<char, List<index>> char_table_index = new Dictionary<char, List<index>>();
                FileStream fs = new FileStream(filename, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                int n = int.Parse(sr.ReadLine());
                char[][] matrix = new char[n][];

                for (int i = 0; i < n; i++)
                {


                    string[] x = sr.ReadLine().Split(' ');
                    matrix[i] = new char[n];

                    for (int j = 0; j < n; j++)
                    {
                        matrix[i][j] = char.Parse(x[j]);

                        if (!char_table_index.ContainsKey(matrix[i][j]))
                        {

                            char_table_index.Add(matrix[i][j], new List<index>());
                            char_table_index[matrix[i][j]].Add(new index(i, j));
                        }
                        else
                        {

                            char_table_index[matrix[i][j]].Add(new index(i, j));
                        }
                    }
                }
                List<index> to_be_checked = new List<index>();
                while (sr.Peek() != -1)
                {
                    to_be_checked.Clear();
                    string word = sr.ReadLine();

                    if (!char_table_index.ContainsKey(word[0]))
                        continue;


                    for (int i = 0; i < char_table_index[word[0]].Count; i++)
                        check_for_word_in_2d_array(ref matrix, ref to_be_checked, word, char_table_index[word[0]].ElementAt(i), -1, n);
                    
                }


                sr.Close();
                fs.Close();

            }
            catch
            {
                MessageBox.Show("Please choose right file !", "ERROR !",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }
