using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IN2.Models
{
    public class StudentRepository : IRepository
    {
        private IN2_DbContext _context; /*= new IN2_DbContext();*/
        public StudentRepository()
        {
            _context = new IN2_DbContext();
        }
        public IEnumerable<PREDMET> ListOfSubjects
        {
            get
            {
                return _context.PREDMET.Include("POLOZENI_ISPITI");
            }
        }

        public IEnumerable<POLOZENI_ISPITI> ListOfPassedExams
        {
            get
            {
                return _context.POLOZENI_ISPITI.Include("STUDENT").Include("PREDMET");
            }
        }

        public IEnumerable<STUDENT> ListOfStudents
        {
            get
            {
                return _context.STUDENT; /*.Include("POLOZENI_ISPITI");*/
            }
        }

        public async Task<PREDMET> DeleteSubject(int subjectID)
        {
            PREDMET dbEntry = new PREDMET();
            dbEntry = _context.PREDMET.Find(subjectID);

            if (dbEntry != null)
            {
                _context.PREDMET.Remove(dbEntry);
            }

            await _context.SaveChangesAsync();
            return dbEntry;

        }

        public async Task<STUDENT> DeleteStudent(int studentID)
        {
            STUDENT dbEntry = new STUDENT();
            dbEntry = _context.STUDENT.Find(studentID);

            if (dbEntry != null)
            {
                _context.STUDENT.Remove(dbEntry);
            }

            await _context.SaveChangesAsync();
            return dbEntry;
        }

        public async Task<int> SaveSubject(PREDMET subject)
        {
            if (subject.PredmetID == 0)
            {
                _context.PREDMET.Add(subject);
            }
            else
            {
                PREDMET dbEntry = new PREDMET();
                dbEntry = _context.PREDMET.Find(subject.PredmetID);

                if (dbEntry != null)
                {
                    dbEntry.Naziv = subject.Naziv;
                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveStudent(STUDENT student)
        {
            if (student.StudentID == 0)
            {
                _context.STUDENT.Add(student);
            }
            else
            {
                STUDENT dbEntry = new STUDENT();
                dbEntry = _context.STUDENT.Find(student.StudentID);

                if (dbEntry != null)
                {
                    dbEntry.ImePrezime = student.ImePrezime;
                }
            }
            return await _context.SaveChangesAsync();
        }
        public async Task<int> SavePassedExam(POLOZENI_ISPITI passedExam)
        {
            POLOZENI_ISPITI dbEntry = new POLOZENI_ISPITI();
            dbEntry = _context
                .POLOZENI_ISPITI
                .Where(p => p
                .StudentID == passedExam
                .StudentID && p
                .PredmetID == passedExam
                .PredmetID)
                .FirstOrDefault();

            if (dbEntry != null)
            {
                dbEntry.Ocena = passedExam.Ocena;
            }
            else
            {
                _context.POLOZENI_ISPITI.Add(passedExam);
            }
            
            return await _context.SaveChangesAsync();
        }

        public STUDENT GetStudent(int studentID)
        {
            STUDENT dbEntry = new STUDENT();
            dbEntry = _context
                .STUDENT
                .Include("POLOZENI_ISPITI")
                .Where(s => s
                .StudentID == studentID && s
                .POLOZENI_ISPITI
                .All(p => p
                .StudentID == studentID))
                .FirstOrDefault();
            
            return  dbEntry;
        }

        public PREDMET GetSubject(int subjectID)
        {
            PREDMET dbEntry = new PREDMET();
            dbEntry = _context
                .PREDMET
                .Include("POLOZENI_ISPITI")
                .Where(p => p
                .PredmetID == subjectID && p
                .POLOZENI_ISPITI
                .All(x => x
                .PredmetID == subjectID))
                .FirstOrDefault();

            return dbEntry;
        }
    }
}