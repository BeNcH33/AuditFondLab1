using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditFondLab1
{
    [TestFixture]
    public class MyTest
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


            Assert.DoesNotThrow(() => { audit.addTeacher("Быков"); });// Клиент добавится 
            Assert.DoesNotThrow(() => { audit.addTeacher("Беня Жиков"); });// Клиент добавится, но под другим id
            Assert.AreEqual(2, audit.countTeachers());
            Assert.DoesNotThrow(() => { audit.addTeacher("Жиков Беня"); });
            Assert.AreEqual(3, audit.countTeachers());
        }


        [Test]
        public void addRoom()
        {
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 104"); });// Аудитория добавится
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 104"); });// Аудитория добавится с другим id 
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 102"); });// Аудитория добавится c другим названием 
            Assert.AreEqual(3, audit.countAuditors());//проверяю что аудитории добавились


        }

        [Test]
        public void testremoveRoom() 
        {
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 104"); });
            Assert.DoesNotThrow(() => { audit.removeRoom("Аудитория 104"); });
            Assert.AreEqual(0, audit.countAuditors());//проверяю что аудитории удалились
        }

        [Test]
        public void testRemoveTeacher()
        {
            Assert.DoesNotThrow(() => { audit.addTeacher("Быков"); });
            Assert.DoesNotThrow(() => { audit.removeTeacher(1); }); //Преподователь удалиться
                                                                    
        }

        [Test]
        public void testIdTeacher()
        {
            Assert.DoesNotThrow(() => { audit.generateIdTeacher(); }); //Не будет ошибки при генерации числа 
            Assert.IsNotNull(audit.generateIdTeacher()); //Генерация не нулевая
        }

        [Test]
        public void testTakeAudi()
        {
            Assert.DoesNotThrow(() => { audit.addTeacher("Быков"); });
            Assert.DoesNotThrow(() => { audit.addTeacher("Беня Жиков"); });
            Assert.AreEqual(2, audit.countTeachers());
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 104"); });
            Assert.AreEqual(1, audit.countAuditors());
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 102"); });
            Assert.DoesNotThrow(() => { audit.takeAuditors("Аудитория 104", 1); }); //Аудитория займеться новым поользователем \
            Assert.AreEqual(1, audit.countBusyAuditors());
            Assert.DoesNotThrow(() => { audit.takeAuditors("Аудитория 102", 2); });
            Assert.AreEqual(2, audit.countBusyAuditors());
        }
         [Test]
         public void testRemoveAudi()
        {
            Assert.DoesNotThrow(() => { audit.addTeacher("Быков"); });
            Assert.DoesNotThrow(() => { audit.addTeacher("Беня Жиков"); });
            Assert.AreEqual(2, audit.countTeachers());
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 104"); });
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 102"); });
            Assert.DoesNotThrow(() => { audit.takeAuditors("Аудитория 104", 1); }); //Аудитория займеться новым поользователем \
            Assert.AreEqual(1, audit.countBusyAuditors());
            Assert.DoesNotThrow(() => { audit.RemoveAudi(1); });
            Assert.AreEqual(0, audit.countBusyAuditors());
        }
    }
}
