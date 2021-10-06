using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditFondLab1
{
    [TestFixture]
    class MyTest
    {
        Audit audit;
        [SetUp]
        public void SetUp()
        {
            audit = new Audit();
        }

        [Test]
        public void testAddTeacher()
        {


            Assert.DoesNotThrow(() => { audit.addTeacher("Беня Жиков"); });// Клиент добавится 
            Assert.DoesNotThrow(() => { audit.addTeacher("Беня Жиков"); });// Клиент добавится, но под другим id
        }


        [Test]
        public void addRoom()
        {
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 104"); });// Аудитория добавится
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 104"); });// Аудитория добавится с другим id 
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 102"); });// Аудитория добавится c другим названием 

        }

        [Test]
        public void testRemoveTeacher()
        {
            Assert.DoesNotThrow(() => { audit.removeTeacher(1); }); //Преподователь удалиться
            Assert.DoesNotThrow(() => { audit.removeTeacher(2); }); //Удалиться преподватель с другим id 
        }

        [Test]
        public void testIdTeacher()
        {
            Assert.DoesNotThrow(() => { audit.generateIdTeacher(); }); //Не будет ошибки при генерации числа 
            Assert.IsNotNull(audit.generateIdTeacher()); //Генерация не нулевая
        }
    }
}
