using System.Collections.Generic;
using System.Threading.Tasks;

namespace IN2.Models
{
    public interface IRepository
    {
        IEnumerable<STUDENT> ListOfStudents { get; }
        STUDENT GetStudent(int studentID);
        Task<int> SaveStudent(STUDENT student);
        Task<STUDENT> DeleteStudent(int studentID);
        
        IEnumerable<PREDMET> ListOfSubjects { get; }
        PREDMET GetSubject(int subjectID);
        Task<int> SaveSubject(PREDMET subject);
        Task<PREDMET> DeleteSubject(int subjectID);

        IEnumerable<POLOZENI_ISPITI> ListOfPassedExams { get; }
        Task<int> SavePassedExam(POLOZENI_ISPITI passedExam);
    }
}
