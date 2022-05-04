using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using CapstoneManager.Models;
using CapstoneManager.Utils;

namespace CapstoneManager.Repositories
{
    public class StudentRepository : BaseRepository, IStudentRepository
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
                    List<Student> students = new List<Student>();
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

        public Student GetStudentById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using ( var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT s.Id, s.ClassId, s.Name, s.ProposalTitle, s.Note, p.Id progressId, p.Name progressName, p.ImageUrl
                                        FROM Student s
                                        JOIN Progress p ON p.Id = s.ProgressId
                                        WHERE s.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    Student student = null;
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        student = new Student()
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
                    }
                    reader.Close();
                    return student;
                }
            }
        }

        public void Update(Student student)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Student
                                        SET Name = @name,
                                            ProposalTitle = @proposalTitle,
                                            ProgressId = @progressId,
                                            Note = @note
                                        WHERE Id = @id";
                    DbUtils.AddParameter(cmd, "@name", student.Name);
                    DbUtils.AddParameter(cmd, "@proposalTitle", student.ProposalTitle);
                    DbUtils.AddParameter(cmd, "@progressId", student.ProgressId);
                    DbUtils.AddParameter(cmd, "@note", student.Note);
                    DbUtils.AddParameter(cmd, "@id", student.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
