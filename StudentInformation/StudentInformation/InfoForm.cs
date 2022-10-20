using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentInformation
{
    public partial class InfoForm : MetroFramework.Forms.MetroForm
    {
        readonly string fileName;
        bool flag = true;
        string name;

        public InfoForm(string fileName)
        {
            InitializeComponent();
            this.fileName = fileName;
        }

        public InfoForm()
        {
            InitializeComponent();
            flag = false;
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (flag)
                {
                    IEnumerable<string> resultStudent = File.ReadLines(fileName, Encoding.GetEncoding(1251)).Skip(1).Take(9);
                    IEnumerable<string> resultParent = File.ReadLines(fileName, Encoding.GetEncoding(1251)).Skip(11).Take(4);
                    IEnumerable<string> resultExam = File.ReadLines(fileName, Encoding.GetEncoding(1251)).Skip(16).Take(4);
                    IEnumerable<string> resultInterest = File.ReadLines(fileName, Encoding.GetEncoding(1251)).Skip(21).Take(10);
                    Text = resultStudent.ElementAt(0);
                    //заполнение полей студента
                    textBoxNameStudent.Text = resultStudent.ElementAt(0);
                    name = textBoxNameStudent.Text;
                    maskedTextBoxBirthday.Text = resultStudent.ElementAt(1);
                    textBoxPlace.Text = resultStudent.ElementAt(2);
                    maskedTextBoxPhoneStudent.Text = resultStudent.ElementAt(3);
                    textBoxUniversity.Text = resultStudent.ElementAt(4);
                    textBoxInstitute.Text = resultStudent.ElementAt(5);
                    textBoxSpecialty.Text = resultStudent.ElementAt(6);
                    textBoxDepartment.Text = resultStudent.ElementAt(7);
                    textBoxGroup.Text = resultStudent.ElementAt(8);
                    //заполнение полей родителей
                    textBoxNameFather.Text = resultParent.ElementAt(0);
                    maskedTextBoxPhoneFather.Text = resultParent.ElementAt(1);
                    textBoxNameMother.Text = resultParent.ElementAt(2);
                    maskedTextBoxPhoneMother.Text = resultParent.ElementAt(3);
                    //заполнение полей экзаменов
                    textBoxRus.Text = resultExam.ElementAt(0);
                    textBoxMath.Text = resultExam.ElementAt(1);
                    textBoxPhysics.Text = resultExam.ElementAt(2);
                    maskedTextBoxPoint.Text = resultExam.ElementAt(3);
                    if (!CheckAllTextBox())
                    {
                        Close();
                        throw new PersonException("Выбран неподходящий файл");
                    }
                    //заполнение интересов
                    int count = 0;
                    if (resultInterest.ElementAt(0).ElementAt(resultInterest.ElementAt(0).Length - 1) == '+')
                    {
                        metroCheckBoxSport.Checked = true;
                        count++;
                    }
                    if (resultInterest.ElementAt(1).ElementAt(resultInterest.ElementAt(1).Length - 1) == '+')
                    {
                        metroCheckBoxComputer.Checked = true;
                        count++;
                    }
                    if (resultInterest.ElementAt(2).ElementAt(resultInterest.ElementAt(2).Length - 1) == '+')
                    {
                        metroCheckBoxBooks.Checked = true;
                        count++;
                    }
                    if (resultInterest.ElementAt(3).ElementAt(resultInterest.ElementAt(3).Length - 1) == '+')
                    {
                        metroCheckBoxMusic.Checked = true;
                        count++;
                    }
                    if (resultInterest.ElementAt(4).ElementAt(resultInterest.ElementAt(4).Length - 1) == '+')
                    {
                        metroCheckBoxArt.Checked = true;
                        count++;
                    }
                    if (resultInterest.ElementAt(5).ElementAt(resultInterest.ElementAt(5).Length - 1) == '+')
                    {
                        metroCheckBoxCreativity.Checked = true;
                        count++;
                    }
                    if (resultInterest.ElementAt(6).ElementAt(resultInterest.ElementAt(6).Length - 1) == '+')
                    {
                        metroCheckBoxTrip.Checked = true;
                        count++;
                    }
                    if (resultInterest.ElementAt(7).ElementAt(resultInterest.ElementAt(7).Length - 1) == '+')
                    {
                        metroCheckBoxScience.Checked = true;
                        count++;
                    }
                    if (resultInterest.ElementAt(8).ElementAt(resultInterest.ElementAt(8).Length - 1) == '+')
                    {
                        metroCheckBoxFriends.Checked = true;
                        count++;
                    }
                    if (resultInterest.ElementAt(9).ElementAt(resultInterest.ElementAt(9).Length - 1) == '+')
                    {
                        metroCheckBoxAnother.Checked = true;
                        count++;
                    }
                    if (count == 0)
                    {
                        Close();
                        throw new PersonException("Выбран неподходящий файл");
                    }
                }
            }
            catch (PersonException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }            
        }

        private void metroButtonSave_Click(object sender, EventArgs e)
        {
            bool flag = CheckAllTextBox();       
            if (flag && CheckInterests())
            {
                string path = Environment.CurrentDirectory;
                path += "/студенты/";
                if (File.Exists($"{path}{textBoxNameStudent.Text}.txt"))
                {
                    MessageBox.Show("Студент с таким именем уже существует!");
                }
                else
                {
                    StreamWriter sw = new StreamWriter($"{path}{textBoxNameStudent.Text}.txt", false, Encoding.GetEncoding(1251));
                    sw.WriteLine("СТУДЕНТ");
                    sw.WriteLine(textBoxNameStudent.Text);
                    sw.WriteLine(maskedTextBoxBirthday.Text);
                    sw.WriteLine(textBoxPlace.Text);
                    sw.WriteLine(maskedTextBoxPhoneStudent.Text);
                    sw.WriteLine(textBoxUniversity.Text);
                    sw.WriteLine(textBoxInstitute.Text);
                    sw.WriteLine(textBoxSpecialty.Text);
                    sw.WriteLine(textBoxDepartment.Text);
                    sw.WriteLine(textBoxGroup.Text);
                    sw.WriteLine("РОДИТЕЛИ");
                    sw.WriteLine(textBoxNameFather.Text);
                    sw.WriteLine(maskedTextBoxPhoneFather.Text);
                    sw.WriteLine(textBoxNameMother.Text);
                    sw.WriteLine(maskedTextBoxPhoneMother.Text);
                    sw.WriteLine("РЕЗУЛЬТАТЫ");
                    sw.WriteLine(textBoxRus.Text);
                    sw.WriteLine(textBoxMath.Text);
                    sw.WriteLine(textBoxPhysics.Text);
                    sw.WriteLine(maskedTextBoxPoint.Text);
                    sw.WriteLine("ИНТЕРЕСЫ");
                    if (metroCheckBoxSport.Checked == true)
                        sw.WriteLine("Спорт +");
                    else
                        sw.WriteLine("Спорт -");
                    if (metroCheckBoxComputer.Checked == true)
                        sw.WriteLine("Компьютер +");
                    else
                        sw.WriteLine("Компьютер -");
                    if (metroCheckBoxBooks.Checked == true)
                        sw.WriteLine("Книги +");
                    else
                        sw.WriteLine("Книги -");
                    if (metroCheckBoxMusic.Checked == true)
                        sw.WriteLine("Музыка +");
                    else
                        sw.WriteLine("Музыка -");
                    if (metroCheckBoxArt.Checked == true)
                        sw.WriteLine("искусство +");
                    else
                        sw.WriteLine("искусство -");
                    if (metroCheckBoxCreativity.Checked == true)
                        sw.WriteLine("творчество +");
                    else
                        sw.WriteLine("творчество -");
                    if (metroCheckBoxTrip.Checked == true)
                        sw.WriteLine("путешествия +");
                    else
                        sw.WriteLine("путешествия -");
                    if (metroCheckBoxScience.Checked == true)
                        sw.WriteLine("научная деятельность +");
                    else
                        sw.WriteLine("научная деятельность -");
                    if (metroCheckBoxFriends.Checked == true)
                        sw.WriteLine("прогулки с друзьями +");
                    else
                        sw.WriteLine("прогулки с друзьями -");
                    if (metroCheckBoxAnother.Checked == true)
                        sw.WriteLine("другое +");
                    else
                        sw.WriteLine("другое -");
                    sw.WriteLine();
                    sw.Close();
                    if (this.flag)
                    {
                        MessageBox.Show("Данные обновлены!");
                        if (name != textBoxNameStudent.Text)
                        {
                            File.Delete(fileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Студент добавлен!");
                    }
                    Close();
                }               
            }              
        }

        private void metroButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool CheckName(TextBox textBoxName)
        {
            string name = textBoxName.Text;
            if (name.Length < 8 || name.Length > 40)
            {
                textBoxName.ForeColor = Color.Red;
                return false;
            }
            foreach (var item in name)
            {
                if (!char.IsLetter(item) && !char.IsWhiteSpace(item))
                {
                    textBoxName.ForeColor = Color.Red;
                    return false;
                }
            }
            textBoxName.ForeColor = Color.Black;
            return true;
        }

        private bool CheckBirthday(string birthday)
        {
            if (birthday.Length != 10)
            {
                maskedTextBoxBirthday.ForeColor = Color.Red;
                return false;
            }
            maskedTextBoxBirthday.ForeColor = Color.Black;
            return true;
        }

        private bool CheckPlace(string place)
        {
            if (place.Length < 3 || place.Length > 55)
            {
                textBoxPlace.ForeColor = Color.Red;
                return false;
            }
            foreach (var item in place)
            {
                if (!char.IsLetter(item) && item != '.' && item != ',' && !char.IsWhiteSpace(item))
                {
                    textBoxPlace.ForeColor = Color.Red;
                    return false;
                }
            }
            textBoxPlace.ForeColor = Color.Black;
            return true;
        }

        private bool CheckPhone(MaskedTextBox textBoxPhone)
        {
            string phone = textBoxPhone.Text;
            if (phone.Length != 17)
            {
                textBoxPhone.ForeColor = Color.Red;
                return false;
            }
            textBoxPhone.ForeColor = Color.Black;
            return true;
        }

        private bool CheckUniversityInfo(TextBox textBox)
        {
            string str = textBox.Text;
            if (str.Length < 3 || str.Length > 65)
            {
                textBox.ForeColor = Color.Red;
                return false;
            }
            foreach (var item in str)
            {
                if (!char.IsLetter(item) && item != '-' && !char.IsWhiteSpace(item))
                {
                    textBox.ForeColor = Color.Red;
                    return false;
                }
            }
            textBox.ForeColor = Color.Black;
            return true;
        }

        private bool CheckGroup(string group)
        {
            if (group.Length < 5 || group.Length > 12)
            {
                textBoxGroup.ForeColor = Color.Red;
                return false;
            }
            foreach (var item in  group)
            {
                if (!char.IsLetterOrDigit(item) && item != '-')
                {
                    textBoxGroup.ForeColor = Color.Red;
                    return false;
                }
            }
            textBoxGroup.ForeColor = Color.Black;
            return true;
        }

        private bool CheckScore(TextBox textBox)
        {
            string score = textBox.Text;
            if (score.Length < 1 || score.Length > 3)
            {
                textBox.ForeColor = Color.Red;
                return false;
            }
            foreach (var item in score)
            {
                if (!char.IsNumber(item))
                {
                    textBox.ForeColor = Color.Red;
                    return false;
                }
            }
            if (int.Parse(score) > 100)
            {
                textBox.ForeColor = Color.Red;
                return false;
            }
            textBox.ForeColor = Color.Black;
            return true;
        }

        private bool CheckPoint(string point)
        {
            if (point.Length != 3)
            {
                maskedTextBoxPoint.ForeColor = Color.Red;
                return false;
            }
            if (Convert.ToDouble(point) > 5)
            {
                maskedTextBoxPoint.ForeColor = Color.Red;
                return false;
            }
            return true;
        }

        private bool CheckAllTextBox()
        {
            bool flag = true;
            if (!CheckName(textBoxNameStudent))
                flag = false;
            if (!CheckPhone(maskedTextBoxPhoneStudent))
                flag = false;
            if (!CheckBirthday(maskedTextBoxBirthday.Text))
                flag = false;
            if (!CheckPlace(textBoxPlace.Text))
                flag = false;
            if (!CheckUniversityInfo(textBoxUniversity))
                flag = false;
            if (!CheckUniversityInfo(textBoxInstitute))
                flag = false;
            if (!CheckUniversityInfo(textBoxSpecialty))
                flag = false;
            if (!CheckUniversityInfo(textBoxDepartment))
                flag = false;
            if (!CheckGroup(textBoxGroup.Text))
                flag = false;
            if (!CheckName(textBoxNameFather))
                flag = false;
            if (!CheckPhone(maskedTextBoxPhoneFather))
                flag = false;
            if (!CheckName(textBoxNameMother))
                flag = false;
            if (!CheckPhone(maskedTextBoxPhoneMother))
                flag = false;
            if (!CheckScore(textBoxRus))
                flag = false;
            if (!CheckScore(textBoxMath))
                flag = false;
            if (!CheckScore(textBoxPhysics))
                flag = false;
            if (!CheckPoint(maskedTextBoxPoint.Text))
                flag = false;
            return flag;
        }

        private bool CheckInterests()
        {
            int count = 0;
            if (metroCheckBoxSport.Checked == true)
                count++;
            if (metroCheckBoxComputer.Checked == true)
                count++;
            if (metroCheckBoxBooks.Checked == true)
                count++;
            if (metroCheckBoxMusic.Checked == true)
                count++;
            if (metroCheckBoxArt.Checked == true)
                count++;
            if (metroCheckBoxCreativity.Checked == true)
                count++;
            if (metroCheckBoxTrip.Checked == true)
                count++;
            if (metroCheckBoxScience.Checked == true)
                count++;
            if (metroCheckBoxFriends.Checked == true)
                count++;
            if (metroCheckBoxAnother.Checked == true)
                count++;
            if (count == 0)
            {
                MessageBox.Show("Должен быть выбран хотя-бы один интерес!");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
