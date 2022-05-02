using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using CapstoneManager.Models;
using CapstoneManager.Utils;

namespace CapstoneManager.Repositories
{
    public class StudentRepository : BaseRepository
    {
        public StudentRepository(IConfiguration config) : base(config) { }

        public List<Student> GetStudentsByClassId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT s.Id, s.ClassId, s.Name, s.ProposalTitle, s.Note, p.Id progressId, p.Name progressName, p.ImageUrl
                                        FROM Student s
                                        JOIN Progress p ON p.Id = s.ProgressId
                                        WHERE s.ClassId = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    List<Student> students = null;
                    while (reader.Read())
                    {
                        var student = new Student()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            ClassId = DbUtils.GetInt(reader, "ClassId"),
                            ProposalTitle = DbUtils.GetString(reader, "ProposalTitle"),
                            Note = DbUtils.GetString(reader, "Note"),
                            Progress = new Progress()
                            {
                                Id = DbUtils.GetInt(reader, "progressId"),
                                Name = DbUtils.GetString(reader, "progressName"),
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl")
                            }
                        };
                        students.Add(student);
                    }
                    conn.Close();
                    return students;
                }
            }
        }
    }
}
