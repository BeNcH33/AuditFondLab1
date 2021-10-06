using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditFondLab1
{
    class Audit
    {
        public Dictionary<string, int> Room { get; } = new Dictionary<string, int>();

        public Dictionary<int, string> Teacher { get; } = new Dictionary<int, string>();



        //Добавление новой аудитории
        public void addRoom(string nameRoom, int count = 1)
        {
            if (nameRoom == "" || nameRoom == " ")
            {
                throw new Exception("Не правильный вариант ввода названия");
            }

            if (!Room.ContainsKey(nameRoom))
            {
                Room.Add(nameRoom, count);
                return;
            }

            if (Room.ContainsKey(nameRoom))
            {
                Room[nameRoom] += count;
                return;
            }
        }


            //Добавление нового преподователя
            public void addTeacher(string nameTeacher)
        {
            if (nameTeacher != null)
            {
                Teacher.Add(generateIdTeacher(), nameTeacher);
            }
            else
            {
                throw new Exception("Введено пустое поле");
            }
        }

        //Удаление преподователя

        public void removeTeacher(int idTeacher)
        {
            if (Teacher.ContainsKey(idTeacher))
            {
                Teacher.Remove(idTeacher);
            }
        }

        public int generateIdTeacher()
        {
            int current = 1;
            if (Teacher.ContainsKey(current))
            {
                return Teacher.Last().Key + 1;
            }
            else
            {
                return current;
            }
        }
    }
}
