using static MusicScooleXml.Service.MusicSchoolService;
using static MusicScooleXml.Model.Student;
using MusicScooleXml.Model;

namespace MusicScooleXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CreateXmlIfNotExists();

            //InsertClassroom("guitar jazz");

            //AddTeacher("guitar jazz", "yossi-levi");

            //AddStudent("guitar jazz", "israel", "giutar");

            /*AddManyStudents("guitar jazz",
                new Student("Itsik", new Instrument("piano")),
                new Student("Itsik", new Instrument("piano")));*/




        }
    }
}
