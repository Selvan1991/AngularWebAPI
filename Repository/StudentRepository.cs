using Microsoft.EntityFrameworkCore;
using StudentDetail.Models;

namespace StudentDetail.Repository
{
    public class StudentRepository : IStudentRepository
    {
        protected readonly AngularAssignmentDbContext _angularAssignmentDbContext;
        public StudentRepository(AngularAssignmentDbContext dbcontext)
        {
            _angularAssignmentDbContext = dbcontext;
        }
        public async Task<List<StudentDetails>> GetStudentlists()
        {
            return await _angularAssignmentDbContext.StudentDetails.ToListAsync();
        }
        public async Task<StudentDetails> GetStudentByID(int id)
        {
            return await _angularAssignmentDbContext.StudentDetails.FindAsync(id);
        }

        public void InsertStudent(StudentDetails studentDetail)
        {
            _angularAssignmentDbContext.StudentDetails.Add(studentDetail);
            _angularAssignmentDbContext.SaveChanges();
        }
        public async Task<StudentDetails> UpdateStudent(StudentDetails objStudentDetail)
        {
            //_angularAssignmentDbContext.Entry(objStudentDetail).State = EntityState.Modified;
            //await _angularAssignmentDbContext.SaveChangesAsync();
            //return objStudentDetail;

            //_angularAssignmentDbContext.Update(objStudentDetail);
            //await _angularAssignmentDbContext.SaveChangesAsync();
            //return objStudentDetail;
           
            _angularAssignmentDbContext.Entry(objStudentDetail).State = EntityState.Modified;
            await _angularAssignmentDbContext.SaveChangesAsync();
            return objStudentDetail;
        }
        public async Task<bool> DeleteStudent(int id)
        {
            bool result = false;
            var studentdetail = _angularAssignmentDbContext.StudentDetails.Find(id);
            if (studentdetail != null)
            {
                _angularAssignmentDbContext.Entry(studentdetail).State = EntityState.Deleted;
                await _angularAssignmentDbContext.SaveChangesAsync();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
