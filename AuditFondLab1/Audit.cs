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
            if (nameRoom == null)
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
        public void removeRoom(string name)
        {
            if (Room.ContainsKey(name))
            {
                Room.Remove(name);
            }
            else { throw new Exception("Возникла ошибка в удалении)"); }
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
            else  throw new Exception("Возникла ошибка в удалении)"); 
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
