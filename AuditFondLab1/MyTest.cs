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
        }


        [Test]
        public void addRoom()
        {
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 104"); });// Аудитория добавится
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 104"); });// Аудитория добавится с другим id 
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 102"); });// Аудитория добавится c другим названием 

        }

        [Test]
        public void testremoveRoom() 
        {
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 104"); });
            Assert.DoesNotThrow(() => { audit.removeRoom("Аудитория 104"); });
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

            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 104"); });
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 102"); });
            Assert.DoesNotThrow(() => { audit.takeAuditors("Аудитория 104", 1); }); //Аудитория займеться новым поользователем \
            Assert.DoesNotThrow(() => { audit.takeAuditors("Аудитория 102", 2); });
        }
         [Test]
         public void testRemoveAudi()
        {
            Assert.DoesNotThrow(() => { audit.addTeacher("Быков"); });
            Assert.DoesNotThrow(() => { audit.addTeacher("Беня Жиков"); });
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 104"); });
            Assert.DoesNotThrow(() => { audit.addRoom("Аудитория 102"); });
            Assert.DoesNotThrow(() => { audit.takeAuditors("Аудитория 104", 1); }); //Аудитория займеться новым поользователем \
            Assert.DoesNotThrow(() => { audit.RemoveAudi(1); });
        }
    }
}
