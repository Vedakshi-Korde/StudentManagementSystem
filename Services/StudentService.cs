using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Student>> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<Student> GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Task Add(Student student)
        {
            return _repo.Add(student);
        }

        public Task Update(Student student)
        {
            return _repo.Update(student);
        }

        public Task Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}