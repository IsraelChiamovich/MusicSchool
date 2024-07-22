using MusicScooleXml.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MusicScooleXml.Configuration.MusicSchollConfiguration;
using static MusicScooleXml.Model.Student;

namespace MusicScooleXml.Service
{
    internal static class MusicSchoolService
    {
        public static void CreateXmlIfNotExists()
        {
            // בדיקה אם הקובץ קיים
            if (!File.Exists(musicSchoolPath))
            {
                // יצירת מסמך XML חדש
                XDocument document = new();
                // יצירת אלמנט 'music-school'
                XElement musicSchool = new("music-school");
                // הוספת אלמנט 'music-school' למסמך
                document.Add(musicSchool);
                // שמירת המסמך בנתיב שהוגדר
                document.Save(musicSchoolPath);
            }
        }

        public static void InsertClassroom(string classroomName)
        {
            // טעינת מסמך ה-XML מהנתיב שהוגדר
            XDocument document = XDocument.Load(musicSchoolPath);

            // מציאת אלמנט 'music-school'
            XElement? musicSchool = document.Descendants("music-school").FirstOrDefault();

            // אם האלמנט לא נמצא, יוצא מהפונקציה
            if (musicSchool == null)
            {
                return;
            }

            // יצירת אלמנט 'class-room' עם שם הכיתה
            XElement classroom = new("class-room", new XAttribute("name", classroomName));

            // הוספת האלמנט 'class-room' לאלמנט 'music-school'
            musicSchool.Add(classroom);

            // שמירת השינויים במסמך ה-XML
            document.Save(musicSchoolPath);
        }

        public static void AddTeacher(string classRoomName, string teacherName)
        {
            // טעינת מסמך ה-XML מהנתיב שהוגדר
            XDocument document = XDocument.Load(musicSchoolPath);

            // מציאת אלמנט 'class-room' לפי שם הכיתה
            XElement? classRoom = document.Descendants("class-room").FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);

            // אם האלמנט לא נמצא, יוצא מהפונקציה
            if (classRoom == null)
            {
                return;
            }

            // יצירת אלמנט 'teacher' עם שם המורה
            XElement teacher = new("teacher", new XAttribute("name", teacherName));

            // הוספת האלמנט 'teacher' לאלמנט 'class-room'
            classRoom.Add(teacher);

            // שמירת השינויים במסמך ה-XML
            document.Save(musicSchoolPath);
        }

        public static void AddStudent(string classRoomName, string studentName, string instrumentName)
        {
            // טעינת מסמך ה-XML מהנתיב שהוגדר
            XDocument document = XDocument.Load(musicSchoolPath);

            // מציאת אלמנט 'class-room' לפי שם הכיתה
            XElement? classRoom = document.Descendants("class-room").FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);

            // אם האלמנט לא נמצא, יוצא מהפונקציה
            if (classRoom == null)
            {
                return;
            }

            // יצירת אלמנט 'student' עם שם התלמיד ואלמנט 'instrument' עם שם הכלי
            XElement student = new("student", new XAttribute("name", studentName),
                new XElement("instrument", instrumentName));

            // הוספת האלמנט 'student' לאלמנט 'class-room'
            classRoom.Add(student);

            // שמירת השינויים במסמך ה-XML
            document.Save(musicSchoolPath);
        }

        public static void AddManyStudents(string classRoomName, params Student[] students)
        {
            // טעינת מסמך ה-XML מהנתיב שהוגדר
            XDocument document = XDocument.Load(musicSchoolPath);

            // מציאת אלמנט 'class-room' לפי שם הכיתה
            XElement? classRoom = document.Descendants("class-room").FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);

            // אם האלמנט לא נמצא, יוצא מהפונקציה
            if (classRoom == null)
            {
                return;
            }

            // המרת כל תלמיד לאלמנט XML והוספתם לרשימה אחת
            List<XElement> studentsList = students.Select(StudentToXelemnt).ToList();

            // הוספת התלמידים לאלמנט 'class-room'
            classRoom.Add(studentsList);

            // שמירת השינויים במסמך ה-XML
            document.Save(musicSchoolPath);
        }

        public static void SetInstrumentByStudent(string studentName, string newInstrument)
        {
            // טעינת מסמך ה-XML מהנתיב שהוגדר
            XDocument document = XDocument.Load(musicSchoolPath);

            // מציאת אלמנט 'class-room' לפי שם הכיתה
            XElement? studentEl = document.Descendants("student").FirstOrDefault(room => room.Attribute("name")?.Value == studentName);

            if (studentEl == null)
            {
                return;
            }

            // מציאת אלמנט 'instrument' ושינוי ערכו
            XElement? instrumentEl = studentEl.Element("instrument");
            {
                if (instrumentEl != null)
                {
                    instrumentEl.Value = newInstrument;
                }
            }

            // שמירת השינויים במסמך ה-XML
            document.Save(musicSchoolPath);

        }

        private static XElement StudentToXelemnt(Student student)
        {
            // יצירת אלמנט 'student' עם שם התלמיד ואלמנט 'instrument' עם שם הכלי
            XElement newStudent =
                new("student",
                new XAttribute("name", student.studentName),
                new XElement("instrument", student.Instrument.instrumentName));
            return newStudent;
        }
    }
}
