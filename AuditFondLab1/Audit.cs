using System;
using System.Collections.Generic;
using System.Linq;


namespace AuditFondLab1
{
    class Audit
    {
        public Dictionary<string, int> Room { get; } = new Dictionary<string, int>();

        public Dictionary<int, string> Teacher { get; } = new Dictionary<int, string>();
        public Dictionary<int, string> BusyAudi { get; } = new Dictionary<int, string>();



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
        //Удаление созданной аудитории//
        public void removeRoom(string name)
        {
            if (Room.ContainsKey(name))
            {
                Room.Remove(name);
            }
            else { throw new Exception("Возникла ошибка в удалении)"); }
        }

        public void takeAuditors(string NameAudi, int idTeacher) //Добавление аудитории к определенному преподователю //
        {
            if (Room.ContainsKey(NameAudi) && Teacher.ContainsKey(idTeacher))
            {
                BusyAudi.Add(idTeacher, NameAudi);
            }
            else
            {
                throw new Exception("Невозможно это выполнить!");
            }
        }
        public void RemoveAudi(int idTeacher) //Снятие аудитории к определенному преподователю //
        {
            if (BusyAudi.ContainsKey(idTeacher))
            {
                BusyAudi.Remove(idTeacher);
            }
            else
            {
                throw new Exception("Снятие аудитории невозможно!");
            }
        }

        public int countAuditors() //Подсчет всех доступных аудиторий
        {
            int count = 0;

            foreach (var v in Room.Keys)
            {
                count += Room[v];
            }

            return count;
        }
        public int countTeachers() //Подсчет всех преподователей
        {
            int count = 0;
            count += Teacher.Count;
            return count;
        }


        //Добавление нового преподователя//
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

        public int countBusyAuditors() //Подсчет всех занятых аудиторий
        {
            int count = BusyAudi.Count;
            return count;
        }

        //Удаление преподователя//

        public void removeTeacher(int idTeacher)
        {
            if (Teacher.ContainsKey(idTeacher))
            {
                Teacher.Remove(idTeacher);
            }
            else throw new Exception("Возникла ошибка в удалении)");
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
