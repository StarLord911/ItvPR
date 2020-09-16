using Itv.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Itv
{
    //структура которая хранит в себе состояние формы
    [Serializable]
    public struct FormState
    {
        public int X;
        public int Y;
        public int Weight;
        public int Height;
       
        public FormState(Form form)
        {
            X = form.Location.X;
            Y = form.Location.Y;
            Weight = form.Width;
            Height = form.Height;
        }
    }
    public partial class Form1 : Form
    {
        //Формы которые были открыты   
        private List<FormState> myForms = new List<FormState>();
        //формы которые были не закрыты в момент закрытия основной формы
        private List<FormState> openForms = new List<FormState>();
        //путь к сериализуемому фаилу
        private string path = "forms.dat";

        public Form1()
        {
            InitializeComponent();
            Load();
        }

        //показ форм на экран
        private void CreateForm()
        {
            Form2 form = new Form2() { Owner = this };
            form.Show();
            form.FormClosing += (s,e) => { myForms.Add(new FormState(form)); };
        }

        //создание окон используя кординаты и размеры из фаила
        private void CreateFormInStart(int x, int y,int h,int w)
        {
            Form2 form = new Form2() {Owner = this};
            form.FormClosing += (s, e) => { myForms.Add(new FormState(form)); };
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new System.Drawing.Point(x, y);
            form.Size = new System.Drawing.Size(w,h);
            form.Show();
        }

        //закрытие формы и сохранение положение формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //сериализация форм которые остались активными в момент закрытия основной формы
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                //проверка дочерних форм на их активность
                foreach (var form in this.OwnedForms)
                {
                    if (!form.IsDisposed)
                    {
                        openForms.Add(new FormState(form));
                    }
                }
                //сериализация активных дочерних форм
                formatter.Serialize(fs,openForms);
            }
        }

        //создание доч формы по нажатию на кнопку
        private void CreateForms_Click(object sender, EventArgs e)
        {
            CreateForm();
        }

        //загрузка форм которые сохранены в фаил
        private void Load()
        {
            if (File.Exists(path))
            {
                using (FileStream fs = File.OpenRead(path))
                {

                    string line = File.ReadAllText(path);
                    if (!string.IsNullOrEmpty(line))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        var formStates = (List<FormState>)formatter.Deserialize(fs);

                        foreach (var form in formStates)
                        {
                            CreateFormInStart(form.X, form.Y, form.Height, form.Weight);
                        }
                    }
                }
            }
        }
    }
}
