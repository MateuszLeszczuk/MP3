using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMp3Player
{
    public partial class Form1 : Form
    {
        private Mp3Player mp3Player = new Mp3Player();
        private ContainerForData con = new ContainerForData();
        public Form1()
        {
            InitializeComponent();
        }


        private class ContainerForData
        {
            public List<string> myList = new List<string>();
            public int counter;
            public int currentIndex;
        }


        private void button1_Click(object sender, EventArgs e)  //search file
        {
            Form1 f = new Form1();
            

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Mp3 Files|*.mp3";

                ofd.Multiselect = true;


                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    foreach (var x in ofd.FileNames)
                    {
                        con.myList.Add(x);
                    }

                    con.currentIndex = 0;
                    con.counter = con.myList.Count();
                    mp3Player.open(con.myList[con.currentIndex]);
                }
            }


        }

       

        private void button3_Click(object sender, EventArgs e)  //play
        {
            mp3Player.play();
        }

        private void button4_Click(object sender, EventArgs e)  //pause
        {
            mp3Player.stop();
        }

        private void button6_Click(object sender, EventArgs e)  //exit
        {
            Application.Exit();
        }

        private void button5_Click_1(object sender, EventArgs e)    //next
        {
           
            con.currentIndex +=1;
            if (con.currentIndex < con.counter)
            {
                mp3Player.close();
                mp3Player.open(con.myList[con.currentIndex]);
                button3_Click(sender, e);
            }
            else
                con.currentIndex -= 1;
            
        }

        private void button2_Click(object sender, EventArgs e)  //previous
        {
            
            con.currentIndex -= 1;

            if (con.currentIndex >= 0)
            {
                mp3Player.close();
                mp3Player.open(con.myList[con.currentIndex]);
                button3_Click(sender, e);
            }
            else
                con.currentIndex += 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            con.currentIndex = rand.Next(con.counter);
            mp3Player.close();
            mp3Player.open(con.myList[con.currentIndex]);
            button3_Click(sender, e);
        }
    }
}
